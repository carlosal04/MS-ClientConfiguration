using ClientConfiguration.Application.Models;
using MediatR;

namespace ClientConfiguration.Application.Commands.Example
{
    public class UpdateExampleNameCommand : IRequest<CommandResult<bool>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}