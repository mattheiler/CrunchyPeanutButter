using CrispyBacon.Commands;
using CrunchyPeanutButter.Domain.Models.Foos;

namespace CrunchyPeanutButter.Domain.Commands.Foos.UpdateFoo
{
    public class UpdateFooCommand : ICommand
    {
        public UpdateFooCommand(Foo foo)
        {
            Foo = foo;
        }

        public Foo Foo { get; }
    }
}