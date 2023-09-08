using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ClientConfiguration.Application.Interfaces;
using ClientConfiguration.Application.Models;
using ClientConfiguration.Domain.Models;
using Dapper;
using Microsoft.Extensions.Options;

namespace ClientConfiguration.Infrastructure.SqlServer
{
    public class ClientEligibilityRepository : IClientEligibilityRepository
    {
        private readonly IOptions<EnvironmentConfiguration> _configuration;

        public ClientEligibilityRepository(IOptions<EnvironmentConfiguration> configuration)
        {
            _configuration = configuration;
        }

        public async Task<ClientConfigDTO> GetEligibilityClientConfigurationById(long id)
        {
            var query = Sql.GetClientConfigByEligibilityClientConfigId.Value;
            using (var conn = new SqlConnection(this._configuration.Value.SQL_CONNECTION_STRING))
            {
                var clientConfig = await conn.QueryAsync<ClientConfigDTO>(query, new { ID = id });

                return clientConfig.FirstOrDefault();
            }
        }
    }
}
