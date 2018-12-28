using System.Threading.Tasks;

namespace Xenox.Command.Messaging.Processor {
	public interface ICommandMessageProcessor {
		Task ProcessMessageAsCommand(byte[] messageBytes);
	}
}
