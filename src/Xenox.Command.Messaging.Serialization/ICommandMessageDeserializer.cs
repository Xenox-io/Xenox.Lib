using Xenox.Messaging;

namespace Xenox.Command.Messaging.Serialization {
	public interface ICommandMessageDeserializer {
		ICommand DeserializeCommandFromMessage(Message message);
	}
}
