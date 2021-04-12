using CrispyBacon.Commands;
using CrunchyPeanutButter.Domain.Models.Foos;

namespace CrunchyPeanutButter.Domain.Commands.Foos.CreateFoo
{
    public class CreateFooCommand : ICommand
    {
        public CreateFooCommand(Foo foo)
        {
            Foo = foo;
        }

        public Foo Foo { get; }
    }
}