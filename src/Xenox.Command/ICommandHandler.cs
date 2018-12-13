using System.Threading.Tasks;

namespace Xenox.Command {
	public interface ICommandHandler<in TCommand> where TCommand : ICommand {
		Task HandleAsync(TCommand command);
	}
}
