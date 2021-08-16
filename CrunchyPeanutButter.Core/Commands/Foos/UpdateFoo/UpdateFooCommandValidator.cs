using FluentValidation;

namespace CrunchyPeanutButter.Core.Commands.Foos.UpdateFoo
{
    public class UpdateFooCommandValidator : AbstractValidator<UpdateFooCommand>
    {
        public UpdateFooCommandValidator()
        {
            RuleFor(request => request.Id).NotEmpty();
            RuleFor(request => request.Name).NotEmpty();
            RuleFor(request => request.Code).Length(8);
        }
    }
}