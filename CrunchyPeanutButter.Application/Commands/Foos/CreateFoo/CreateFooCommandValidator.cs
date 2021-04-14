using FluentValidation;

namespace CrunchyPeanutButter.Application.Commands.Foos
{
    public class CreateFooCommandValidator : AbstractValidator<CreateFooCommand>
    {
        public CreateFooCommandValidator()
        {
            RuleFor(request => request.Args.Name).NotNull().NotEmpty();
        }
    }
}