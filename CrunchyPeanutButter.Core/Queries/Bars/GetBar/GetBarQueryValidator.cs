using FluentValidation;

namespace CrunchyPeanutButter.Core.Queries.Bars.GetBar
{
    public class GetBarQueryValidator : AbstractValidator<GetBarQuery>
    {
        public GetBarQueryValidator()
        {
            RuleFor(request => request.Id).NotEmpty();
        }
    }
}