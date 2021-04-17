using FluentValidation;

namespace CrunchyPeanutButter.Application
{
    public class DeleteBarCommandValidator : AbstractValidator<DeleteBarCommand>
    {
        public DeleteBarCommandValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}
