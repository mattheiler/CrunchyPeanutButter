using FluentValidation;

namespace CrunchyPeanutButter.Core.GetBar
{
    public class GetBarQueryValidator : AbstractValidator<GetBarQuery>
    {
        public GetBarQueryValidator()
        {
            RuleFor(request => request.Id).NotEmpty();
        }
    }
}