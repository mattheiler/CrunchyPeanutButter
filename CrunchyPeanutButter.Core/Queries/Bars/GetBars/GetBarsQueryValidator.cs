using FluentValidation;

namespace CrunchyPeanutButter.Core.Queries.Bars.GetBars
{
    public class GetBarsQueryValidator : AbstractValidator<GetBarsQuery>
    {
        public GetBarsQueryValidator()
        {
            RuleFor(request => request.Offset).GreaterThanOrEqualTo(0);
            RuleFor(request => request.Limit).GreaterThan(0).LessThanOrEqualTo(20);
        }
    }
}