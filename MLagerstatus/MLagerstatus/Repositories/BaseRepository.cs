using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace MLagerstatus.Repositories
{
    public abstract class BaseRepository
    {
        public IConfiguration Configuration;

        public BaseRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected async Task<T> QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
            }
        }

        protected async Task<List<T>> Query<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                var enumerableT = await connection.QueryAsync<T>(sql, parameters);
                return enumerableT.ToList();
            }
        }

        protected async Task<int> Execute(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return await connection.ExecuteAsync(sql, parameters);
            }
        }

        private IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(Configuration.GetConnectionString("LagerConnection"));
            return connection;
        }
    }
}
