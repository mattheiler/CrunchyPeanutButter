using FluentValidation;

namespace CrunchyPeanutButter.Core.Queries.Foos.GetFoos
{
    public class GetFoosQueryValidator : AbstractValidator<GetFoosQuery>
    {
        public GetFoosQueryValidator()
        {
            RuleFor(request => request.Offset).GreaterThanOrEqualTo(0);
            RuleFor(request => request.Limit).GreaterThan(0).LessThanOrEqualTo(20);
        }
    }
}