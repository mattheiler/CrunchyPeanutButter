using CrispyBacon.Commands;
using CrunchyPeanutButter.Domain.Models.Foos;

namespace CrunchyPeanutButter.Domain.Commands.Foos
{
    public class UpdateFooCommand : ICommand<Foo>
    {
        public UpdateFooCommand(Foo foo)
        {
            Foo = foo;
        }

        public Foo Foo { get; }
    }
}