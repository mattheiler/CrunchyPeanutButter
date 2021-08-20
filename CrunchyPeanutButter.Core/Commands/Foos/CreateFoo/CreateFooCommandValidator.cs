using FluentValidation;

namespace CrunchyPeanutButter.Core.Commands.Foos.CreateFoo
{
    public class CreateFooCommandValidator : AbstractValidator<CreateFooCommand>
    {
        public CreateFooCommandValidator()
        {
            RuleFor(request => request.Name).NotEmpty();
            RuleFor(request => request.Code).Length(8);
        }
    }
}