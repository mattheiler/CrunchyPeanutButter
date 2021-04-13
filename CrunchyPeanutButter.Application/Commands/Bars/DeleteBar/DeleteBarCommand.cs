using MediatR;

namespace CrunchyPeanutButter.Application.Commands.Bars
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