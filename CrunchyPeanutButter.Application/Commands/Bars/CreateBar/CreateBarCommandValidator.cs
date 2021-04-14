using FluentValidation;

namespace CrunchyPeanutButter.Application.Commands.Bars
{
    public class CreateBarCommandValidator : AbstractValidator<CreateBarCommand>
    {
        public CreateBarCommandValidator()
        {
            RuleFor(request => request.Args.Name).NotNull().NotEmpty();
        }
    }
}