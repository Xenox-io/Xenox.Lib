﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Xenox.Command;
using Xenox.Command.Handler;

namespace Xenox.Host.Providers.DependencyInjection {
	public class CommandHandlerProvider : ICommandHandlerProvider {
		private static readonly Type CommandHandlerOpenType = typeof(ICommandHandler<>);
		private readonly IServiceProvider _serviceProvider;

		public CommandHandlerProvider(IServiceProvider serviceProvider) {
			_serviceProvider = serviceProvider;
		}

		public ICommandHandler<TCommand> GetCommandHandler<TCommand>() where TCommand : ICommand {
			return _serviceProvider.GetService<ICommandHandler<TCommand>>();
		}

		public object GetCommandHandler(Type commandType) {
			Type handlerType = CommandHandlerOpenType.MakeGenericType(commandType);
			return _serviceProvider.GetService(handlerType);
		}
	}
}
