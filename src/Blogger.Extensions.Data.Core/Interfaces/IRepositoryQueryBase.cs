using System.Data.SqlClient;

namespace Blogger.Extensions.Data.Core.Interfaces;

public interface IRepositoryQueryBase
{
    SqlConnection GetConnection();
}