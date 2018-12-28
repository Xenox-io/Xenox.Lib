using System;
using System.Threading.Tasks;
using Xenox.Command.Handler.Provider;

namespace Xenox.Command.Dispatcher {
	public class CommandDispatcher : ICommandDispatcher {
		private readonly ICommandHandlerProvider _commandHandlerProvider;

		public CommandDispatcher(ICommandHandlerProvider commandHandlerProvider) {
			_commandHandlerProvider = commandHandlerProvider;
		}

		public Task DispatchAsync(ICommand command) {
			Type commandType = command.GetType();
			dynamic commandHandler = _commandHandlerProvider.GetCommandHandler(commandType);
			return commandHandler.HandleAsync((dynamic)command);
		}
	}
}
