using FluentValidation;

namespace CrunchyPeanutButter.Application
{
    public class GetBarQueryValidator : AbstractValidator<GetBarQuery>
    {
        public GetBarQueryValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}