using FluentValidation;

namespace CrunchyPeanutButter.Core.Foos.CreateFoo
{
    public class CreateFooCommandValidator : AbstractValidator<CreateFooCommand>
    {
        public CreateFooCommandValidator()
        {
            RuleFor(request => request.Id).NotEmpty();
            RuleFor(request => request.Name).NotEmpty();
            RuleFor(request => request.Code).Length(8);
        }
    }
}