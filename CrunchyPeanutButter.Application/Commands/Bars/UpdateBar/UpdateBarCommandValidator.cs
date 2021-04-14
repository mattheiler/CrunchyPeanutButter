using FluentValidation;

namespace CrunchyPeanutButter.Application.Commands.Bars
{
    public class UpdateBarCommandValidator : AbstractValidator<UpdateBarCommand>
    {
        public UpdateBarCommandValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
            RuleFor(request => request.Args.Name).NotNull().NotEmpty();
        }
    }
}