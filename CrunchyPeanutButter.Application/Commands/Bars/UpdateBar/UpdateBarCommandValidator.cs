using FluentValidation;

namespace CrunchyPeanutButter.Application.Commands.Bars
{
    public class UpdateBarCommandValidator : AbstractValidator<UpdateBarCommand>
    {
        public UpdateBarCommandValidator()
        {
            RuleFor(cmd => cmd.Args.Name).NotNull();
        }
    }
}