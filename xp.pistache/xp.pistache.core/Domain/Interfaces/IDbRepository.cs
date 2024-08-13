using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xp.pistache.core.Domain.Interfaces
{
    public interface IDbRepository
    {
        IDbConnection DbConnection { get; }

        Task<T> QuerySingleAsync<T>(string sql, object param = null);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null);
        Task<int> ExecuteAsync(string sql, object param = null);
        Task<T> ExecuteScalarAsync<T>(string sql, object param = null);
        Task ExecuteScalarAsync(string sql, object param = null);
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null);
    }

}
