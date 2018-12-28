using System;

namespace Xenox.Query.Handler.Provider {
	public interface IQueryHandlerProvider {
		IQueryHandler<TQuery> GetQueryHandler<TQuery>() where TQuery : IQuery;
		object GetQueryHandler(Type queryType);
	}
}
