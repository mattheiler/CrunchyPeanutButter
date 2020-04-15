using CrispyBacon.Commands;

namespace CrunchyPeanutButter.Domain.Commands.Bars
{
    public class DeleteBarCommand : ICommand<bool>
    {
        public DeleteBarCommand(in long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}