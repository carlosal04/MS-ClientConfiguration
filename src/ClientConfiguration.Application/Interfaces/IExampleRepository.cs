using System.Threading.Tasks;

namespace ClientConfiguration.Application.Interfaces
{
    public interface IExampleRepository
    {
        Task<int> UpdateExampleNameById(int id, string name);
    }
}