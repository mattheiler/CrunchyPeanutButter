using FluentValidation;

namespace CrunchyPeanutButter.Application.Queries.Foos
{
    public class GetFoosQueryValidator : AbstractValidator<GetFoosQuery>
    {
        public GetFoosQueryValidator()
        {
            RuleFor(request => request.Params.PageIndex).GreaterThanOrEqualTo(0);
            RuleFor(request => request.Params.PageSize).GreaterThan(0);
        }
    }
}