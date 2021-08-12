using MediatR;

namespace CrunchyPeanutButter.Core
{
    public class DeleteBarCommand : IRequest
    {
        public DeleteBarCommand(in long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}