using Xenox.Messaging;

namespace Xenox.Command.Messaging {
	public class CommandMessage {
		public CommandMessageBody CommandMessageBody { get; }
		public HeaderCollection HeaderCollection { get; }

		public CommandMessage(
			CommandMessageBody commandMessageBody
		) {
			CommandMessageBody = commandMessageBody;
			HeaderCollection = new HeaderCollection();
		}

		public CommandMessage(
			CommandMessageBody commandMessageBody,
			HeaderCollection headerCollection
		) {
			CommandMessageBody = commandMessageBody;
			HeaderCollection = headerCollection;
		}
	}
}
