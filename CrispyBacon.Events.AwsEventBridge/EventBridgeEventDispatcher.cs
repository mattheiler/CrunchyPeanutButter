using System.Net.Mime;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Amazon.EventBridge;
using Amazon.EventBridge.Model;
using Microsoft.Extensions.Options;

namespace CrispyBacon.Events.AwsEventBridge
{
    public sealed class EventBridgeEventDispatcher : IEventDispatcher
    {
        private readonly IAmazonEventBridge _eb;

        private readonly IOptions<EventBridgeEventDispatcherOptions> _options;

        public EventBridgeEventDispatcher(IAmazonEventBridge eb, IOptions<EventBridgeEventDispatcherOptions> options)
        {
            _eb = eb;
            _options = options;
        }

        public async Task DispatchAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IEvent
        {
            var settings = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var content = JsonSerializer.Serialize(@event, settings);
            var contentType = MediaTypeNames.Application.Json;

            var detail = JsonSerializer.Serialize(new EventBridgePayload(content, contentType), settings);
            var detailType = @event.Name;

            var request = new PutEventsRequest
            {
                Entries =
                {
                    new PutEventsRequestEntry
                    {
                        DetailType = detailType,
                        Detail = detail,
                        EventBusName = _options.Value.EventBusName,
                        Source = _options.Value.Source
                    }
                }
            };

            await _eb.PutEventsAsync(request, cancellationToken);
        }
    }
}