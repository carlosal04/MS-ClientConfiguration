using ClientConfiguration.Application.Models;
using MediatR;

namespace ClientConfiguration.Application.Commands.Readiness
{
    public class PerformReadinessCheckCommand : IRequest<CommandResult<string>>
    {
    }
}
