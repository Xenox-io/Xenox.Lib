using System.Threading.Tasks;

namespace Xenox.Encryption {
	public interface IHmacService {
		Task<byte[]> Generate(byte[] data);
		Task<bool> IsValid(byte[] hmac, byte[] data);
	}
}
