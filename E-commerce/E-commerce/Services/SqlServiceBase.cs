using System.Data.Common;
using System.Data.SqlClient;

namespace E_commerce.Services
{
    public class SqlServiceBase : ServiceBase
    {
        private readonly IConfiguration _config;

        public SqlServiceBase(IConfiguration config)
        {
            _config = config;
        }

        protected override DbCommand GetCommand(string commandText)
        {
            var command = new SqlCommand(commandText);
            command.Connection = (SqlConnection)GetConnection();
            return command;
        }

        protected override DbConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString("AppConn"));
        }
    }
}
