using MediatR;

namespace CrunchyPeanutButter.Core
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