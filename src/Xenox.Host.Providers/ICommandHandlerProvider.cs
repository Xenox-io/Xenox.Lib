using System;
using Xenox.Command;

namespace Xenox.Host.Providers {
	public interface ICommandHandlerProvider {
		ICommandHandler<TCommand> GetCommandHandler<TCommand>() where TCommand : ICommand;
		object GetCommandHandler(Type commandType);
	}
}
