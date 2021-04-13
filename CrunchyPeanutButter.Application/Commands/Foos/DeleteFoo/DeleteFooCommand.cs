using MediatR;

namespace CrunchyPeanutButter.Application.Commands.Foos
{
    public class DeleteFooCommand : IRequest
    {
        public DeleteFooCommand(in long id)
        {
            Id = id;
        }

        public long Id { get; private set; }
    }
}