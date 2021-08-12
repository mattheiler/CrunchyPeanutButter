using FluentValidation;

namespace CrunchyPeanutButter.Core
{
    public class UpdateFooCommandValidator : AbstractValidator<UpdateFooCommand>
    {
        public UpdateFooCommandValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
            RuleFor(request => request.Args.Name).NotNull().NotEmpty();
        }
    }
}