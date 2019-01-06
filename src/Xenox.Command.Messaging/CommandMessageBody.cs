namespace Xenox.Command.Messaging {
	public class CommandMessageBody {
		public string CommandName { get; }
		public object Command { get; }

		public CommandMessageBody(
			string commandName,
			object command
		) {
			CommandName = commandName;
			Command = command;
		}
	}
}
