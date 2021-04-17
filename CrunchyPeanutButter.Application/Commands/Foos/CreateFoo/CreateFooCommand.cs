using MediatR;

namespace CrunchyPeanutButter.Application
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