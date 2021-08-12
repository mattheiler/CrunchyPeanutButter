using FluentValidation;

namespace CrunchyPeanutButter.Core
{
    public class GetBarQueryValidator : AbstractValidator<GetBarQuery>
    {
        public GetBarQueryValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}