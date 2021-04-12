using MediatR;

namespace CrispyBacon.Commands
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
    {
    }
}