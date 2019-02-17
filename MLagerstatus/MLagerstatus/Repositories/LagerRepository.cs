using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MLagerstatus.Interfaces.Repositories;
using MLagerstatus.Models.LagerStatus;
using Microsoft.Extensions.Configuration;

namespace MLagerstatus.Repositories
{
    public class LagerRepository : BaseRepository, ILagerRepository
    {
        public LagerRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IList<Lager>> GetAllLager()
        {
            string sql = "Select * from tblLager";
            List<Lager> lagerList = await Query<Lager>(sql);
            return lagerList;
        }

        public async Task<IList<Lager>> GetByArtikel(string artikel)
        {
            string sql = "Select * from tblLager where artikel = @artikel";
            List<Lager> lagerList = await Query<Lager>(sql, new {artikel});
            return lagerList;
        }

        public async Task<IList<Lager>> GetSums()
        {
            string sql = @"select sum(antal) as antal, artikel
                           from tblLager
                           group by artikel";
            List<Lager> lagerList = await Query<Lager>(sql);
            return lagerList;
        }

        public async Task<Lager> GetSumByArtikel(string artikel)
        {
            string sql = @"select sum(antal) as antal, artikel
                           from tblLager
                           where artikel=@artikel
                           group by artikel";

            var queryRes = await Query<Lager>(sql, new {artikel});
            return queryRes.SingleOrDefault();
        }
    }
}

