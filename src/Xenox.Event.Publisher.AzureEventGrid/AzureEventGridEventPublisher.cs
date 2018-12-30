using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using Newtonsoft.Json.Linq;

namespace Xenox.Event.Publisher.AzureEventGrid {
	public class AzureEventGridEventPublisher : IEventPublisher {
		private readonly AzureEventGridConfiguration _configuration;
		private readonly EventGridClient _client;

		public AzureEventGridEventPublisher(AzureEventGridConfiguration configuration) {
			_configuration = configuration;
			_client = new EventGridClient(new TopicCredentials(_configuration.TopicKey));
		}

		public Task PublishAsync(IEnumerable<IEvent> events) {
			List<EventGridEvent> eventGridEvents = events.Select(e => {
				Type eventType = e.GetType();
				PropertyInfo eventIdInfo = eventType.GetProperties().Where(p => p.Name.Equals("Id")).FirstOrDefault();
				string eventId = ((eventIdInfo != null)
					? eventIdInfo.GetValue(e).ToString()
					: Guid.NewGuid().ToString()
				);
				return new EventGridEvent() {
					Id = eventId,
					EventType = eventType.FullName,
					Data = JObject.FromObject(e),
					EventTime = DateTime.Now,
					Subject = _configuration.Subject,
					DataVersion = eventType.Assembly.GetName().Version.ToString()
				};
			}).ToList();
			return _client.PublishEventsAsync(_configuration.TopicHostname, eventGridEvents);
		}
	}

	public class AzureEventGridConfiguration {
		public string TopicHostname { get; set; }
		public string TopicKey { get; set; }
		public string Subject { get; set; }
	}
}
