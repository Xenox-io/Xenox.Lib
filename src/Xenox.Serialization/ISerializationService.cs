using System;

namespace Xenox.Serialization {
	public interface ISerializationService {
		byte[] SerializeToBytes(object data);
		string SerializeToString(object data);
		T DeserializeFromBytes<T>(byte[] serializedData);
		T DeserializeFromString<T>(string serializedData);
		T DeserializeFromObject<T>(object serializedData);
		object DeserializeFromBytes(Type type, byte[] serializedData);
		object DeserializeFromString(Type type, string serializedData);
		object DeserializeFromObject(Type type, object serializedData);
	}
}
