using System.Collections.Generic;
using System.Threading.Tasks;
using MLagerstatus.Models.LagerStatus;

namespace MLagerstatus.Interfaces.Repositories
{
    public interface IReservationerRepository
    {
        Task<IList<Reservation>> GetAllReservationer();
        Task<IList<Reservation>> GetByArtikel(string artikel);
        Task<Reservation> GetSumByArtikel(string artikel);
        Task<IList<Reservation>> GetSums();
    }
}
