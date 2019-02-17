using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MLagerstatus.Interfaces.Factories.Views;
using MLagerstatus.Interfaces.Repositories;
using MLagerstatus.Models.Views;

namespace MLagerstatus.Factories.Views
{
    public class ProduktViewFactory : IProduktViewFactory
    {
        private readonly ILagerRepository _lagerRepository;
        private readonly IReservationerRepository _reservationerRepository;

        public ProduktViewFactory(ILagerRepository lagerRepository,
            IReservationerRepository reservationerRepository)
        {
            _lagerRepository = lagerRepository;
            _reservationerRepository = reservationerRepository;
        }

        public async Task<ProduktIndexView> Build()
        {
            // Hämta det som finns på hyllorna (summerat) för alla artiklar
            var lagerSums = await _lagerRepository.GetSums();
            // Hämta alla reservationer (summerat per artikel)
            var reservationerSums = await _reservationerRepository.GetSums();

            var viewModel = new ProduktIndexView();
            if (lagerSums != null)
            {
                foreach (var lagerSum in lagerSums)
                {
                    var reservationSumsForArtikel = reservationerSums.SingleOrDefault(r => r.artikel.Equals(lagerSum.artikel, StringComparison.InvariantCultureIgnoreCase));
                    var lagerStatus = lagerSum.antal;
                    if (reservationSumsForArtikel != null)
                    {
                        // Dra ifrån antalet utestående beställningar (beställning minus det som redan plockats) från summan av all lagerhållning.
                        // Lägg aldrig till, ifall PlockatAntal skulle överstiga Beställt antal
                        lagerStatus -= Math.Max((reservationSumsForArtikel.beställtAntal - reservationSumsForArtikel.plockatAntal), 0);
                    }
                    viewModel.Produkter.Add(new ProduktView()
                    {
                        ProduktNamn = lagerSum.artikel,
                        LagerStatus = lagerStatus
                    });
                }
            }

            return viewModel;
        }

        public async Task<ProduktDetailView> Build(string artikel)
        {
            var lager = await _lagerRepository.GetSumByArtikel(artikel);
            var reservationer = await _reservationerRepository.GetSumByArtikel(artikel);

            var viewModel = new ProduktDetailView()
            {
                ProduktNamn = artikel,
                LagerStatus = lager.antal
            };
            if (reservationer != null)
            {
                viewModel.LagerStatus -= Math.Max(0, reservationer.beställtAntal - reservationer.plockatAntal);
            }
            return viewModel;
        }
    }
}
