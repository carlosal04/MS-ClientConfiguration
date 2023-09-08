using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ClientConfiguration.Application.Interfaces;
using ClientConfiguration.Application.Models;
using ClientConfiguration.Domain.Models;
using Dapper;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Core;

namespace ClientConfiguration.Infrastructure.SqlServer
{
    public class ClientEligibilityRepository : IClientEligibilityRepository
    {
        private readonly IOptions<EnvironmentConfiguration> _configuration;
        private readonly ILogger _logger;
        public ClientEligibilityRepository(ILogger logger, IOptions<EnvironmentConfiguration> configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<ClientConfig> GetEligibilityClientConfigurationById(long id)
        {
            try
            {
                var query = Sql.GetClientConfigByEligibilityClientConfigId.Value;
                using (var conn = new SqlConnection(this._configuration.Value.SQL_CONNECTION_STRING))
                {
                    var clientConfig = await conn.QueryAsync<ClientConfig>(query, new { ID = id });

                    return clientConfig.FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                _logger.Error($"Error while executing {nameof(GetEligibilityClientConfigurationById)}", ex.Message);
                throw;
            }
        }
    }
}
