using FluentValidation;

namespace CrunchyPeanutButter.Core.Bars.UpdateBar
{
    public class UpdateBarCommandValidator : AbstractValidator<Foos.UpdateFoo.UpdateFooCommand>
    {
        public UpdateBarCommandValidator()
        {
            RuleFor(request => request.Id).NotEmpty();
            RuleFor(request => request.Name).NotEmpty();
            RuleFor(request => request.Code).Length(8);
        }
    }
}