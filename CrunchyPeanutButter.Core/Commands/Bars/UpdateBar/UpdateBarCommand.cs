using MediatR;

namespace CrunchyPeanutButter.Core
{
    public class UpdateBarCommand : IRequest
    {
        public UpdateBarCommand(int id, UpdateBarCommandArgs args)
        {
            Id = id;
            Args = args;
        }

        public int Id { get; }

        public UpdateBarCommandArgs Args { get; }
    }
}