using ClientConfiguration.Application.Models;
using ClientConfiguration.Domain.Models;
using MediatR;

namespace ClientConfiguration.Application.Queries.Example
{
    public class GetExampleByIdQuery : IRequest<QueryResult<Domain.Models.Example>>
    {
        public int Id { get; set; }
    }
}