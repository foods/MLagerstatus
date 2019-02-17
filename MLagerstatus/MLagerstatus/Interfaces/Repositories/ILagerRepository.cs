using System.Collections.Generic;
using System.Threading.Tasks;
using MLagerstatus.Models.LagerStatus;

namespace MLagerstatus.Interfaces.Repositories
{
    public interface ILagerRepository
    {
        Task<IList<Lager>> GetAllLager();
        Task<IList<Lager>> GetByArtikel(string artikel);
        Task<IList<Lager>> GetSums();
        Task<Lager> GetSumByArtikel(string artikel);
    }
}