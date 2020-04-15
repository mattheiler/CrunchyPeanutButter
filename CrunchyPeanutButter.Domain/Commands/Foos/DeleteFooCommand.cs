using CrispyBacon.Commands;

namespace CrunchyPeanutButter.Domain.Commands.Foos
{
    public class DeleteFooCommand : ICommand<bool>
    {
        public DeleteFooCommand(in long id)
        {
            Id = id;
        }

        public long Id { get; private set; }
    }
}