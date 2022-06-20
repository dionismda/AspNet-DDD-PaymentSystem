using Shared.Commands;

namespace Shared.Handlers
{
    public interface IHandler<TCommand> where TCommand : ICommand
    {
        ICommandResult Handle(TCommand command);
    }
}
