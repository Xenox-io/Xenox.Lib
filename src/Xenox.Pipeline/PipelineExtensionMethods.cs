using System.Threading.Tasks;

namespace Xenox.Pipeline {
	public static class PipelineExtensionMethods {
		public static Task<TOutput> SendOn<TInput, TOutput>(
			this TInput input,
			IPipeline<TInput, TOutput> pipeline
		) {
			return pipeline.Send(input);
		}

		public static async Task<TOutput> ContinueOn<TInput, TOutput>(
			this Task<TInput> input,
			IPipeline<TInput, TOutput> pipeline
		) {
			return await pipeline.Send(await input);
		}
	}
}
