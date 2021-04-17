using MediatR;

namespace CrunchyPeanutButter.Application
{
    public class UpdateFooCommand : IRequest
    {
        public UpdateFooCommand(int id, UpdateFooCommandArgs args)
        {
            Id = id;
            Args = args;
        }

        public int Id { get; }

        public UpdateFooCommandArgs Args { get; }
    }
}