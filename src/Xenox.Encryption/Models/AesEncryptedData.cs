namespace Xenox.Encryption.Models {
	public class AesEncryptedData {
		public byte[] EncryptedData { get; set; }
		public byte[] Iv { get; set; }
	}
}
