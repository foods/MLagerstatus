using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MLagerstatus.Interfaces.Repositories;
using MLagerstatus.Models.LagerStatus;
using Microsoft.Extensions.Configuration;

namespace MLagerstatus.Repositories
{
    public class ReservationerRepository : BaseRepository, IReservationerRepository
    {
        public ReservationerRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IList<Reservation>> GetAllReservationer()
        {
            string sql = "Select * from tblReservationer";
            List<Reservation> reservations = await Query<Reservation>(sql);
            return reservations;
        }

        public async Task<IList<Reservation>> GetByArtikel(string artikel)
        {
            string sql = "Select * from tblReservationer where artikel=@artikel";
            List<Reservation> reservations = await Query<Reservation>(sql, new {artikel = artikel});
            return reservations;
        }

        public async Task<IList<Reservation>> GetSums()
        {
            string sql = @"select sum(beställtAntal) as beställtAntal, sum(plockatAntal) as plockatAntal, artikel
                            from tblReservationer
                            group by artikel";
            List<Reservation> reservations = await Query<Reservation>(sql);
            return reservations;
        }

        public async Task<Reservation> GetSumByArtikel(string artikel)
        {
            string sql = @"Select sum(beställtAntal) as beställtAntal, sum(plockatAntal) as plockatAntal, artikel
                            from tblReservationer
                            where artikel=@artikel
                            group by artikel";
            var queryRes = await Query<Reservation>(sql, new {artikel = artikel});
            Reservation reservation = queryRes.SingleOrDefault();
            return reservation;
        }

    }
}
