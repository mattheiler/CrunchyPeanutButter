using MediatR;

namespace CrunchyPeanutButter.Application
{
    public class CreateBarCommand : IRequest
    {
        public CreateBarCommand(CreateBarCommandArgs args)
        {
            Args = args;
        }

        public CreateBarCommandArgs Args { get; }
    }
}