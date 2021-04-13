using FluentValidation;

namespace CrunchyPeanutButter.Application.Commands.Foos
{
    public class DeleteFooCommandValidator : AbstractValidator<DeleteFooCommand>
    {
        public DeleteFooCommandValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}