using System;
using System.Threading.Tasks;
using Xenox.Domain;

namespace Xenox.Persistence.AggregateRootStore {
	public interface IAggregateRootStore<T> where T : AggregateRoot {
		Task<T> LoadAsync(Guid id);
		Task SaveAsync(T t);
	}
}
