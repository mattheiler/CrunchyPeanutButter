using FluentValidation;

namespace CrunchyPeanutButter.Application
{
    public class DeleteFooCommandValidator : AbstractValidator<DeleteFooCommand>
    {
        public DeleteFooCommandValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}