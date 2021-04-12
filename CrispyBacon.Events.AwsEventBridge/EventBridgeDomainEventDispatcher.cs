using System.Net.Mime;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Amazon.EventBridge;
using Amazon.EventBridge.Model;
using Microsoft.Extensions.Options;

namespace CrispyBacon.Events.AwsEventBridge
{
    public sealed class EventBridgeDomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IAmazonEventBridge _eb;

        private readonly IOptions<EventBridgeDomainEventDispatcherOptions> _options;

        public EventBridgeDomainEventDispatcher(IAmazonEventBridge eb, IOptions<EventBridgeDomainEventDispatcherOptions> options)
        {
            _eb = eb;
            _options = options;
        }

        public async Task DispatchAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IDomainEvent
        {
            var settings = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var content = JsonSerializer.Serialize(@event, settings);
            var detail = JsonSerializer.Serialize(content, settings);
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