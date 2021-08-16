using FluentValidation;

namespace CrunchyPeanutButter.Core.Bars.DeleteBar
{
    public class DeleteBarCommandValidator : AbstractValidator<Foos.DeleteFoo.DeleteFooCommand>
    {
        public DeleteBarCommandValidator()
        {
            RuleFor(request => request.Id).NotEmpty();
        }
    }
}