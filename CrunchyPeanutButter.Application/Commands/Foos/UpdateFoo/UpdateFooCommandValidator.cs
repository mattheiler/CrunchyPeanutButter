using FluentValidation;

namespace CrunchyPeanutButter.Application.Commands.Foos
{
    public class UpdateFooCommandValidator : AbstractValidator<UpdateFooCommand>
    {
        public UpdateFooCommandValidator()
        {
            RuleFor(cmd => cmd.Args.Name).NotNull();
        }
    }
}