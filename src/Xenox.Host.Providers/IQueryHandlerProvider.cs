using System;
using Xenox.Query;
using Xenox.Query.Handler;

namespace Xenox.Host.Providers {
	public interface IQueryHandlerProvider {
		IQueryHandler<TQuery> GetQueryHandler<TQuery>() where TQuery : IQuery;
		object GetQueryHandler(Type queryType);
	}
}
