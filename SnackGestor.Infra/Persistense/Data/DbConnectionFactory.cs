using Microsoft.Extensions.Configuration;
using Npgsql;
using SnackGestor.Application.Abstractions.Data;
using System.Data;

namespace SnackGestor.Infra.Persistense.Data
{
    public class DbConnectionFactory(IConfiguration configuration) : IDbConnectionFactory
    {
        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
