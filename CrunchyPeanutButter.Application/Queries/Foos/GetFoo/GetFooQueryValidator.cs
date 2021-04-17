using FluentValidation;

namespace CrunchyPeanutButter.Application
{
    public class GetFooQueryValidator : AbstractValidator<GetFooQuery>
    {
        public GetFooQueryValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}