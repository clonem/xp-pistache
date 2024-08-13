using Dapper;
using System.Data;
using xp.pistache.core.Domain.Interfaces;

namespace xp.pistache.core.Infra.Repositories
{
    public class DapperRepository : IDbRepository, IDisposable
    {
        private readonly IDbConnection _connection;

        public DapperRepository(IDbConnection connection)
        {
            _connection = connection;

            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public IDbConnection DbConnection
        {
            get
            {
                return _connection;
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null)
        {
            return await _connection.QueryFirstOrDefaultAsync<T>(sql, param);
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object param = null)
        {
            return await _connection.QuerySingleAsync<T>(sql, param);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
        {
            return await _connection.QueryAsync<T>(sql, param);
        }

        public async Task<int> ExecuteAsync(string sql, object param = null)
        {
            return await _connection.ExecuteAsync(sql, param);
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, object param = null)
        {
            return await _connection.ExecuteScalarAsync<T>(sql, param);
        }

        public async Task ExecuteScalarAsync(string sql, object param = null)
        {
            await _connection.ExecuteScalarAsync(sql, param);
        }

        public void Dispose()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
