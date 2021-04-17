using FluentValidation;

namespace CrunchyPeanutButter.Application
{
    public class CreateFooCommandValidator : AbstractValidator<CreateFooCommand>
    {
        public CreateFooCommandValidator()
        {
            RuleFor(request => request.Args.Name).NotNull().NotEmpty();
        }
    }
}