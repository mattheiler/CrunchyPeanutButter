using CrispyBacon.Commands;

namespace CrunchyPeanutButter.Domain.Commands.Bars.DeleteBar
{
    public class DeleteBarCommand : ICommand
    {
        public DeleteBarCommand(in long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}