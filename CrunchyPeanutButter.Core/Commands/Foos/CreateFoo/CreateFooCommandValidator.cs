using FluentValidation;

namespace CrunchyPeanutButter.Core
{
    public class CreateFooCommandValidator : AbstractValidator<CreateFooCommand>
    {
        public CreateFooCommandValidator()
        {
            RuleFor(request => request.Args.Name).NotNull().NotEmpty();
        }
    }
}