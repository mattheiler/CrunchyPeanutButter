using MediatR;

namespace CrunchyPeanutButter.Core
{
    public class CreateFooCommand : IRequest
    {
        public CreateFooCommand(CreateFooCommandArgs args)
        {
            Args = args;
        }

        public CreateFooCommandArgs Args { get; }
    }
}