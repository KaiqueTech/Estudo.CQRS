using System.Data;

namespace SnackGestor.Application.Abstractions.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
