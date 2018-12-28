using Xenox.Command.Serialization;
using Xenox.Messaging;
using Xenox.Serialization;
using Xenox.Type.Provider;

namespace Xenox.Command.Messaging.Serialization {
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

		public ICommand DeserializeCommandFromMessage(Message message) {
			SerializableCommand serializableCommand = _serializationService.DeserializeFromObject<SerializableCommand>(message.Body);
			System.Type commandType = _typeProvider.GetType(serializableCommand.Name);
			object command = _serializationService.DeserializeFromString(commandType, serializableCommand.Data);
			return command as ICommand;
		}
	}
}
