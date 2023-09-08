using FluentValidation;

namespace ClientConfiguration.Application.Queries.Client
{
    public  class GetEligibilityClientConfigByIdQueryValidator : AbstractValidator<GetEligibilityClientConfigByIdQuery>
    {
        public GetEligibilityClientConfigByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Id).NotNull();
        }
    }
}
