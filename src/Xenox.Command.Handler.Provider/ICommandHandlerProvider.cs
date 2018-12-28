using System;

namespace Xenox.Command.Handler.Provider {
	public interface ICommandHandlerProvider {
		ICommandHandler<TCommand> GetCommandHandler<TCommand>() where TCommand : ICommand;
		object GetCommandHandler(Type commandType);
	}
}
