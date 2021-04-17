using MediatR;

namespace CrunchyPeanutButter.Application
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