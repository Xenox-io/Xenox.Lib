using System.Threading.Tasks;

namespace Xenox.Query {
	public interface IQueryHandler<TQuery> where TQuery : IQuery {
		Task<object> HandleAsync(TQuery query);
	}
}
