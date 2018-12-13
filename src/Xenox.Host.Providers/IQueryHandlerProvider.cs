using System;
using Xenox.Query;

namespace Xenox.Host.Providers {
	public interface IQueryHandlerProvider {
		IQueryHandler<TQuery> GetQueryHandler<TQuery>() where TQuery : IQuery;
		object GetQueryHandler(Type queryType);
	}
}
