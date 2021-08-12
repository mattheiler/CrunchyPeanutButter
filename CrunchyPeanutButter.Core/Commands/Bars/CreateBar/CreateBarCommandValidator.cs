using FluentValidation;

namespace CrunchyPeanutButter.Core
{
    public class CreateBarCommandValidator : AbstractValidator<CreateBarCommand>
    {
        public CreateBarCommandValidator()
        {
            RuleFor(request => request.Args.Name).NotNull().NotEmpty();
        }
    }
}