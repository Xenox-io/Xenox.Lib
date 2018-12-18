using System;
using Xenox.Command;
using Xenox.Command.Info;
using Xenox.Messaging;
using Xenox.Reflection;

namespace Xenox.Serialization.CommandMessage {
	public class CommandMessageDeserializer : ICommandMessageDeserializer {
		private readonly ITypeProvider _typeProvider;
		private readonly ISerializationService _serializationService;

		public CommandMessageDeserializer(
			ITypeProvider typeProvider,
			ISerializationService serializationService
		) {
			_typeProvider = typeProvider;
			_serializationService = serializationService;
		}

		public ICommand DeserializeCommandMessage(byte[] serializedCommandMessage) {
			Message message = _serializationService.DeserializeFromBytes<Message>(serializedCommandMessage);
			CommandInfo commandInfo = _serializationService.DeserializeFromObject<CommandInfo>(message.Body);
			Type commandType = _typeProvider.GetType(commandInfo.Name);
			object command = _serializationService.DeserializeFromString(commandType, commandInfo.Data);
			return command as ICommand;
		}
	}
}
