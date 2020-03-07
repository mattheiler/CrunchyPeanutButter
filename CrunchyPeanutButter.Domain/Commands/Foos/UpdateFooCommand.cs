using CrunchyPeanutButter.Domain.Aggregates.Foos;
using MediatR;

namespace CrunchyPeanutButter.Domain.Commands.Foos
{
    public class UpdateFooCommand : IRequest<Foo>
    {
        public UpdateFooCommand(Foo foo)
        {
            Foo = foo;
        }

        public Foo Foo { get; }
    }
}