using System;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Xenox.Serialization.JsonNet {
	public class JsonNetSerializationService : ISerializationService {
		private readonly JsonSerializerSettings _settings;

		public JsonNetSerializationService() {
			_settings = new JsonSerializerSettings() {
				ContractResolver = new JsonNetPrivateSetterContractResolver(),
				ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
			};
		}

		public byte[] SerializeToBytes(object data) {
			return Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(data));
		}

		public string SerializeToString(object data) {
			return JsonConvert.SerializeObject(data);
		}

		public T DeserializeFromBytes<T>(byte[] serializedData) {
			return JsonConvert.DeserializeObject<T>(Encoding.ASCII.GetString(serializedData), _settings);
		}

		public T DeserializeFromString<T>(string serializedData) {
			return JsonConvert.DeserializeObject<T>(serializedData, _settings);
		}

		public T DeserializeFromObject<T>(object serializedData) {
			if (serializedData is JObject jObject) {
				return jObject.ToObject<T>(JsonSerializer.Create(_settings));
			}
			return default(T);
		}

		public object DeserializeFromBytes(Type type, byte[] serializedData) {
			return JsonConvert.DeserializeObject(Encoding.ASCII.GetString(serializedData), type, _settings);
		}

		public object DeserializeFromString(Type type, string serializedData) {
			return JsonConvert.DeserializeObject(serializedData, type, _settings);
		}

		public object DeserializeFromObject(Type type, object serializedData) {
			if (serializedData is JObject jObject) {
				return jObject.ToObject(type, JsonSerializer.Create(_settings));
			}
			return null;
		}
	}

	public class JsonNetPrivateSetterContractResolver : DefaultContractResolver {
		protected override JsonProperty CreateProperty(
			MemberInfo member,
			MemberSerialization memberSerialization) {
			JsonProperty jsonProperty = base.CreateProperty(member, memberSerialization);
			if (!jsonProperty.Writable) {
				PropertyInfo property = member as PropertyInfo;
				if (property != null) {
					bool hasPrivateSetter = property.GetSetMethod(true) != null;
					jsonProperty.Writable = hasPrivateSetter;
				}
			}
			return jsonProperty;
		}
	}
}
