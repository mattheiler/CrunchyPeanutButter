using CrispyBacon.Commands;

namespace CrunchyPeanutButter.Domain.Commands.Foos.DeleteFoo
{
    public class DeleteFooCommand : ICommand
    {
        public DeleteFooCommand(in long id)
        {
            Id = id;
        }

        public long Id { get; private set; }
    }
}