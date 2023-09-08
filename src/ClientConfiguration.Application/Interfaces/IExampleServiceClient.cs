using ClientConfiguration.Domain.Models;
using System.Threading.Tasks;

namespace ClientConfiguration.Application.Interfaces
{
    public interface IExampleServiceClient
    {
        Task<Example> GetExampleById(int id);
    }
}