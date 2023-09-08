using ClientConfiguration.Application.Models;
using MediatR;

namespace ClientConfiguration.Application.Queries.Client
{
    public class GetEligibilityClientConfigByIdQuery : IRequest<QueryResult<Domain.Models.ClientConfigDTO>>
    {
        public int Id { get; set; }
    }
}
