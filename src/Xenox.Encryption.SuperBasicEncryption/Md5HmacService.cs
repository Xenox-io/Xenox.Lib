using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Xenox.Encryption.SuperBasicEncryption {
	public class Md5HmacService : IHmacService {
		public Task<byte[]> Generate(byte[] data) {
			using (MD5 md5 = MD5.Create()) {
				return Task.FromResult(md5.ComputeHash(data));
			}
		}

		public Task<bool> IsValid(byte[] hmac, byte[] data) {
			using (MD5 md5 = MD5.Create()) {
				byte[] hash = md5.ComputeHash(data);
				return Task.FromResult(Encoding.ASCII.GetString(hmac) == Encoding.ASCII.GetString(hash));
			}
		}
	}
}
