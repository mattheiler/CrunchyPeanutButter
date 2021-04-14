using FluentValidation;

namespace CrunchyPeanutButter.Application.Queries.Bars
{
    public class GetBarsQueryValidator : AbstractValidator<GetBarsQuery>
    {
        public GetBarsQueryValidator()
        {
            RuleFor(request => request.Params.PageIndex).GreaterThanOrEqualTo(0);
            RuleFor(request => request.Params.PageSize).GreaterThan(0);
        }
    }
}
