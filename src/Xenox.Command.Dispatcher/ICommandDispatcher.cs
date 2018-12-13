using System.Threading.Tasks;

namespace Xenox.Command.Dispatcher {
	public interface ICommandDispatcher {
		Task DispatchAsync(ICommand command);
	}
}
