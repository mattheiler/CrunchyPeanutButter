using MediatR;

namespace CrunchyPeanutButter.Application.Commands.Foos
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