using E_commerce.Services;
using System.Data.Common;
using System.Data.SqlClient;

namespace E_commerce.Services
{
    public class SqlServiceBase : ServiceBase
    {
        private SqlConnection _connection;

        public SqlServiceBase(IConfiguration config)
        {
            _connection = new SqlConnection(config.GetConnectionString("AppConn"));
        }
        protected override DbCommand GetCommand(string commandText)
        {
            return new SqlCommand(commandText, (SqlConnection)_connection);
        }

        protected override DbConnection GetConnection()
        {
            return _connection;
        }
    }
}