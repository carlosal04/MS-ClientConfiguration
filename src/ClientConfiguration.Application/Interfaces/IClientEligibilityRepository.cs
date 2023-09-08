using System.Threading.Tasks;
using ClientConfiguration.Domain.Models;

namespace ClientConfiguration.Application.Interfaces
{
    public interface IClientEligibilityRepository
    {
        Task<ClientConfigDTO> GetEligibilityClientConfigurationById(long id);
    }
}
