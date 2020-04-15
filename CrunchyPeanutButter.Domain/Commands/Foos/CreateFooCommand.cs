using CrispyBacon.Commands;
using CrunchyPeanutButter.Domain.Models.Foos;

namespace CrunchyPeanutButter.Domain.Commands.Foos
{
    public class CreateFooCommand : ICommand<Foo>
    {
        public CreateFooCommand(Foo foo)
        {
            Foo = foo;
        }

        public Foo Foo { get; }
    }
}