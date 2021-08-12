using FluentValidation;

namespace CrunchyPeanutButter.Core
{
    public class DeleteBarCommandValidator : AbstractValidator<DeleteBarCommand>
    {
        public DeleteBarCommandValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}
