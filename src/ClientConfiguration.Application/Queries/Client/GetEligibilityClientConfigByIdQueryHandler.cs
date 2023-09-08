using System.Threading;
using System.Threading.Tasks;
using ClientConfiguration.Application.Interfaces;
using ClientConfiguration.Application.Models;
using ClientConfiguration.Domain.Models;
using FluentValidation;
using MediatR;
using Serilog;

namespace ClientConfiguration.Application.Queries.Client
{
    public class GetEligibilityClientConfigByIdQueryHandler : IRequestHandler<GetEligibilityClientConfigByIdQuery, QueryResult<Domain.Models.ClientConfig>>
    {
        private readonly IValidator<GetEligibilityClientConfigByIdQuery> _validator;
        private readonly IClientEligibilityRepository _eligibilityRepository;
        private readonly ILogger _logger;

        public GetEligibilityClientConfigByIdQueryHandler(
            ILogger logger,
            IClientEligibilityRepository eligibilityRepository,
            IValidator<GetEligibilityClientConfigByIdQuery> validator)
        {
            _logger = logger;
            _eligibilityRepository = eligibilityRepository;
            _validator = validator;
        }

        public async Task<QueryResult<ClientConfig>> Handle(GetEligibilityClientConfigByIdQuery request, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(request);

            if (!validation.IsValid)
            {
                _logger.Error("Get Eligibility Client Configuration by id with id {Id} produced errors on validation {Errors}", request.Id, validation.ToString());
                return new QueryResult<Domain.Models.ClientConfig>(result: default(Domain.Models.ClientConfig), type: QueryResultTypeEnum.InvalidInput);
            }
            var clientConfiguration = await _eligibilityRepository.GetEligibilityClientConfigurationById(request.Id);

            if (clientConfiguration is null)
            {
                return new QueryResult<Domain.Models.ClientConfig>(result: clientConfiguration, type: QueryResultTypeEnum.NotFound);
            }
            return new QueryResult<Domain.Models.ClientConfig>(result: clientConfiguration, type: QueryResultTypeEnum.Success);
        }
    }
}
