using MediatR;

namespace CrunchyPeanutButter.Domain.Commands.Foos
{
    public class DeleteFooCommand : IRequest<bool>
    {
        public DeleteFooCommand(in long id)
        {
            Id = id;
        }

        public long Id { get; private set; }
    }
}