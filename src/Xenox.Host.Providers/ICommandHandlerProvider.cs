using System;
using Xenox.Command;
using Xenox.Command.Handler;

namespace Xenox.Host.Providers {
	public interface ICommandHandlerProvider {
		ICommandHandler<TCommand> GetCommandHandler<TCommand>() where TCommand : ICommand;
		object GetCommandHandler(Type commandType);
	}
}
