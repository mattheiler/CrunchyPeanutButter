using MediatR;

namespace CrunchyPeanutButter.Application.Commands.Foos.DeleteFoo
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