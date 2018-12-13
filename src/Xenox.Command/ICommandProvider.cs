using System.Threading.Tasks;

namespace Xenox.Command {
	public interface ICommandProvider {
		Task<ICommand> GetCommandAsync();
	}
}
