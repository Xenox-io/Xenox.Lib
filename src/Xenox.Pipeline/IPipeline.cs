using System.Threading.Tasks;

namespace Xenox.Pipeline {
	public interface IPipeline<in TInput, TOutput> {
		Task<TOutput> Send(TInput input);
	}
}
