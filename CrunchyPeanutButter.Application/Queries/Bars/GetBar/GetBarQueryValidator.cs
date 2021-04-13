using FluentValidation;

namespace CrunchyPeanutButter.Application.Queries.Bars
{
    public class GetBarQueryValidator : AbstractValidator<GetBarQuery>
    {
        public GetBarQueryValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}