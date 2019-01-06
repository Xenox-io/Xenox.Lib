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
			CommandMessageBody commandMessageBody = _serializationService.DeserializeFromObject<CommandMessageBody>(message.Body);
			System.Type commandType = _typeProvider.GetType(commandMessageBody.CommandName);
			object command = _serializationService.DeserializeFromObject(commandType, commandMessageBody.Command);
			return command as ICommand;
		}
	}
}
