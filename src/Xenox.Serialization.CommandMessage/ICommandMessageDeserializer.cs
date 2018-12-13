using Xenox.Command;

namespace Xenox.Serialization.CommandMessage {
	public interface ICommandMessageDeserializer {
		ICommand DeserializeCommandMessage(byte[] serializedCommandMessage);
	}
}
