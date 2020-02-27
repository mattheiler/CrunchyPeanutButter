using MediatR;

namespace CrunchyPeanutButter.Domain.Commands.Bars
{
    public class DeleteBarCommand : IRequest<bool>
    {
        public DeleteBarCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}