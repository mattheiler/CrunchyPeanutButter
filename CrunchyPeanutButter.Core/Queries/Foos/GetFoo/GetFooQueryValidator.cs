using FluentValidation;

namespace CrunchyPeanutButter.Core.GetFoo
{
    public class GetFooQueryValidator : AbstractValidator<GetFooQuery>
    {
        public GetFooQueryValidator()
        {
            RuleFor(request => request.Id).NotEmpty();
        }
    }
}