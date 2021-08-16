using System;
using FluentValidation;

namespace CrunchyPeanutButter.Core.Bars.CreateBar
{
    public class CreateBarCommandValidator : AbstractValidator<Foos.CreateFoo.CreateFooCommand>
    {
        public CreateBarCommandValidator()
        {
            RuleFor(request => request.Id).NotEmpty();
            RuleFor(request => request.Name).NotEmpty();
            RuleFor(request => request.Code).Length(8);

            throw new NotImplementedException();
        }
    }
}