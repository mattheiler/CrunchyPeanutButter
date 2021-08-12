using FluentValidation;

namespace CrunchyPeanutButter.Core
{
    public class GetFooQueryValidator : AbstractValidator<GetFooQuery>
    {
        public GetFooQueryValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}