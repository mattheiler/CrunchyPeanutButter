using FluentValidation;

namespace CrunchyPeanutButter.Application.Commands.Bars
{
    public class GetFoosQueryValidator : AbstractValidator<UpdateBarCommand>
    {
        public GetFoosQueryValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
            RuleFor(request => request.Args.Name).NotNull();
        }
    }
}