using FluentValidation;

namespace CrunchyPeanutButter.Application
{
    public class CreateBarCommandValidator : AbstractValidator<CreateBarCommand>
    {
        public CreateBarCommandValidator()
        {
            RuleFor(request => request.Args.Name).NotNull().NotEmpty();
        }
    }
}