using CrunchyPeanutButter.Domain.Models.Foos;
using MediatR;

namespace CrunchyPeanutButter.Application.Commands.Foos.CreateFoo
{
    public class CreateFooCommand : IRequest
    {
        public CreateFooCommand(Foo foo)
        {
            Foo = foo;
        }

        public Foo Foo { get; }
    }
}