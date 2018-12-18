using System.Threading.Tasks;

namespace Xenox.Command.Handler {
	public interface ICommandHandler<in TCommand> where TCommand : ICommand {
		Task HandleAsync(TCommand command);
	}
}
