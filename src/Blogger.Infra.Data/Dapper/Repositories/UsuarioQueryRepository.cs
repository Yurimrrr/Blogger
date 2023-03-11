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
     
    public async Task<IEnumerable<TExpertiseViewModel>> GetAll<TExpertiseViewModel>()
    {
        string sql = @" SELECT 
                        Expertise.id AS [Id],
                        Expertise.nome AS [Nome]       
                        FROM Expertise AS Expertise WITH (NOLOCK)";


        using (var conn = GetConnection())
        {
            var selectResult = await conn.QueryAsync<TExpertiseViewModel>(sql, param: null, transaction: null, null, CommandType.Text);

            return selectResult;
        }
    }
}