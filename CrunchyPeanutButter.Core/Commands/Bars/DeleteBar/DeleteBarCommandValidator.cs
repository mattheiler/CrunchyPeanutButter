using FluentValidation;

namespace CrunchyPeanutButter.Core.Commands.Bars.DeleteBar
{
    public class DeleteBarCommandValidator : AbstractValidator<DeleteBarCommand>
    {
        public DeleteBarCommandValidator()
        {
            RuleFor(request => request.Id).NotEmpty();
        }
    }
}