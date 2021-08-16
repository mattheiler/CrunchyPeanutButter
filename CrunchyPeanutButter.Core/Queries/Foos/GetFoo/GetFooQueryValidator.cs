using FluentValidation;

namespace CrunchyPeanutButter.Core.Queries.Foos.GetFoo
{
    public class GetFooQueryValidator : AbstractValidator<GetFooQuery>
    {
        public GetFooQueryValidator()
        {
            RuleFor(request => request.Id).NotEmpty();
        }
    }
}