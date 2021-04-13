using FluentValidation;

namespace CrunchyPeanutButter.Application.Commands.Bars
{
    public class CreateBarCommandValidator : AbstractValidator<CreateBarCommand>
    {
        public CreateBarCommandValidator()
        {
            RuleFor(cmd => cmd.Args.Name).NotNull();
        }
    }
}