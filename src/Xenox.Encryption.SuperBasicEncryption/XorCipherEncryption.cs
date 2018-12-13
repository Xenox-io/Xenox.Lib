using System.Security.Cryptography;
using System.Threading.Tasks;
using Xenox.Encryption.Models;

namespace Xenox.Encryption.SuperBasicEncryption {
	public class XorCipherEncryption : IAesEncryptionService {
		public Task<AesEncryptedData> Encrypt(byte[] data) {
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create()) {
				byte[] cipher = new byte[16];
				randomNumberGenerator.GetNonZeroBytes(cipher);
				byte[] aesEncryptedData = XorCipher(data, cipher);
				return Task.FromResult(new AesEncryptedData() {
					EncryptedData = aesEncryptedData,
					Iv = cipher
				});
			}
		}

		public Task<byte[]> Decrypt(AesEncryptedData aesEncryptedData) {
			return Task.FromResult(
				XorCipher(aesEncryptedData.EncryptedData, aesEncryptedData.Iv)
			);
		}

		private static byte[] XorCipher(byte[] data, byte[] cipher) {
			int dataLength = data.Length;
			int cipherLength = cipher.Length;
			byte[] xorData = new byte[dataLength];
			for (int i = 0; i < dataLength; i ++) {
				xorData[i] = (byte)(data[i] ^ cipher[i % cipherLength]);
			}
			return xorData;
		}
	}
}
