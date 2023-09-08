using System.Threading.Tasks;
using ClientConfiguration.Domain.Models;

namespace ClientConfiguration.Application.Interfaces
{
    public interface IClientEligibilityRepository
    {
        Task<ClientConfig> GetEligibilityClientConfigurationById(long id);
    }
}
