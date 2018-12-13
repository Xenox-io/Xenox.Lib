using System;
using System.Threading.Tasks;
using Xenox.Serialization;
using Xenox.Encryption.Models;

namespace Xenox.Encryption {
	public class EncryptThenMacService : IEncryptThenMacService {
		private readonly IAesEncryptionService _aesEncryptionService;
		private readonly IHmacService _hmacService;
		private readonly ISerializationService _serializationService;

		public EncryptThenMacService(IAesEncryptionService aesEncryptionService, IHmacService hmacService, ISerializationService serializationService) {
			_aesEncryptionService = aesEncryptionService;
			_hmacService = hmacService;
			_serializationService = serializationService;
		}

		public async Task<EncryptThenMacData> EncryptThenMac(byte[] data) {
			AesEncryptedData aesEncryptedData = await _aesEncryptionService.Encrypt(data);
			byte[] serializedAesEncryptedData = _serializationService.SerializeToBytes(aesEncryptedData);
			byte[] hmac = await _hmacService.Generate(serializedAesEncryptedData);
			return new EncryptThenMacData() {
				Data = Convert.ToBase64String(serializedAesEncryptedData),
				Hmac = Convert.ToBase64String(hmac)
			};
		}

		public async Task<byte[]> ValidateAndDecrypt(EncryptThenMacData encryptThenMacData) {
			byte[] data = Convert.FromBase64String(encryptThenMacData.Data);
			byte[] hmac = Convert.FromBase64String(encryptThenMacData.Hmac);
			if (!await _hmacService.IsValid(hmac, data)) {
				throw new Exception("HMAC is not valid.");
			}
			AesEncryptedData aesEncryptedData = _serializationService.DeserializeFromBytes<AesEncryptedData>(data);
			return await _aesEncryptionService.Decrypt(aesEncryptedData);
		}
	}
}
