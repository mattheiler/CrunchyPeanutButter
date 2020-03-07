using MediatR;

namespace CrunchyPeanutButter.Domain.Commands.Bars
{
    public class DeleteBarCommand : IRequest<bool>
    {
        public DeleteBarCommand(in long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}