using System.Threading.Tasks;
using Xenox.Command.Dispatcher;
using Xenox.Command.Messaging.Serialization;
using Xenox.Messaging;
using Xenox.Serialization;

namespace Xenox.Command.Messaging.Processor {
	public class CommandMessageProcessor : ICommandMessageProcessor {
		private readonly ISerializationService _serializationService;
		private readonly ICommandMessageDeserializer _commandMessageDeserializer;
		private readonly ICommandDispatcher _commandDispatcher;

		public CommandMessageProcessor(
			ISerializationService serializationService,
			ICommandMessageDeserializer commandMessageDeserializer,
			ICommandDispatcher commandDispatcher
		) {
			_serializationService = serializationService;
			_commandMessageDeserializer = commandMessageDeserializer;
			_commandDispatcher = commandDispatcher;
		}

		public Task ProcessMessageAsCommand(byte[] messageBytes) {
			Message message = _serializationService.DeserializeFromBytes<Message>(messageBytes);
			ICommand command = _commandMessageDeserializer.DeserializeCommandFromMessage(message);
			return _commandDispatcher.DispatchAsync(command);
		}
	}
}
