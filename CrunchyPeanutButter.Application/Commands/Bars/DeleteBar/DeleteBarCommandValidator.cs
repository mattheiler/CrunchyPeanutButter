using FluentValidation;

namespace CrunchyPeanutButter.Application.Commands.Bars
{
    public class DeleteBarCommandValidator : AbstractValidator<DeleteBarCommand>
    {
        public DeleteBarCommandValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}
