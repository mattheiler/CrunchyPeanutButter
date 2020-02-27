using MediatR;

namespace CrunchyPeanutButter.Domain.Commands.Foos
{
    public class DeleteFooCommand : IRequest<bool>
    {
        public DeleteFooCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}