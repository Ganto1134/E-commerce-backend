using E_commerce.Services;
using System.Data.Common;
using System.Data.SqlClient;

namespace E_commerce.Services
{
    public abstract class ServiceBase
    {
        private SqlConnection _connection;

        protected abstract DbConnection GetConnection();
        protected abstract DbCommand GetCommand(string commandText);
    }
    }

