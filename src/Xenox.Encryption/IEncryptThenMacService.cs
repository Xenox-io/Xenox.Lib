using System.Threading.Tasks;
using Xenox.Encryption.Models;

namespace Xenox.Encryption {
	public interface IEncryptThenMacService {
		Task<EncryptThenMacData> EncryptThenMac(byte[] data);
		Task<byte[]> ValidateAndDecrypt(EncryptThenMacData encryptThenMacData);
	}
}
