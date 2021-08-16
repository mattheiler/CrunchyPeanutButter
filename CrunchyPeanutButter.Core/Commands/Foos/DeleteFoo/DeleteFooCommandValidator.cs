using FluentValidation;

namespace CrunchyPeanutButter.Core.Commands.Foos.DeleteFoo
{
    public class DeleteFooCommandValidator : AbstractValidator<DeleteFooCommand>
    {
        public DeleteFooCommandValidator()
        {
            RuleFor(request => request.Id).NotEmpty();
        }
    }
}