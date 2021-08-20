using FluentValidation;

namespace CrunchyPeanutButter.Core.Commands.Bars.CreateBar
{
    public class CreateBarCommandValidator : AbstractValidator<CreateBarCommand>
    {
        public CreateBarCommandValidator()
        {
            RuleFor(request => request.Name).NotEmpty();
            RuleFor(request => request.Code).Length(8);
        }
    }
}