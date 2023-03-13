using System.Data;
using Blogger.Domain.Configuration;
using Blogger.Domain.Interfaces.Repositories.Queries;
using Blogger.Extensions.Data.Core.Base;
// using Blogger.Extensions.Data.Core.Base;
using Dapper;
using Microsoft.Extensions.Options;

namespace Blogger.Infra.Data.Dapper.Repositories;

public class UsuarioQueryRepository : RepositoryQueryBase, IUsuarioQueryRepository
{
    public UsuarioQueryRepository(IOptions<BloggerConfiguration> configuration) : 
        base(configuration.Value.BloggerSqlConnection) { }
     
    public async Task<IEnumerable<TUsuarioViewMOdel>> GetAll<TUsuarioViewMOdel>()
    {
        string sql = @" SELECT 
                        Usuario.id AS [Id],
                        Usuario.nome AS [Nome]       
                        FROM Usuario AS Usuario WITH (NOLOCK)";


        using (var conn = GetConnection())
        {
            var result = await conn.QueryAsync<TUsuarioViewMOdel>(sql, param: null, transaction: null, null, CommandType.Text);

            return result;
        }
    }
}