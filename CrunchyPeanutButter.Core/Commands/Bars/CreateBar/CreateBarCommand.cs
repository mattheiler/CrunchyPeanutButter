using MediatR;

namespace CrunchyPeanutButter.Core
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