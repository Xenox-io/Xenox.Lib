using System.Threading.Tasks;
using Xenox.Encryption.Models;

namespace Xenox.Encryption {
	public interface IAesEncryptionService {
		Task<AesEncryptedData> Encrypt(byte[] data);
		Task<byte[]> Decrypt(AesEncryptedData aesEncryptedData);
	}
}
