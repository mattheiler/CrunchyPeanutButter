using FluentValidation;

namespace CrunchyPeanutButter.Core
{
    public class DeleteFooCommandValidator : AbstractValidator<DeleteFooCommand>
    {
        public DeleteFooCommandValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}