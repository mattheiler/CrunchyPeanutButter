using System.Net.Mime;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Amazon.EventBridge;
using Amazon.EventBridge.Model;
using Microsoft.Extensions.Options;

namespace CrispyBacon.Events.AwsEventBridge
{
    public sealed class AwsEventBridgeDomainEventHandler<T> : IDomainEventHandler<T> where T : IDomainEvent
    {
        private readonly IAmazonEventBridge _eb;

        private readonly IOptions<AwsEventBridgeDomainEventHandlerOptions> _options;

        internal AwsEventBridgeDomainEventHandler(IAmazonEventBridge eb, IOptions<AwsEventBridgeDomainEventHandlerOptions> options)
        {
            _eb = eb;
            _options = options;
        }

        public async Task Handle(T @event, CancellationToken cancellationToken)
        {
            var settings = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var content = JsonSerializer.Serialize(@event, settings);
            var detail = JsonSerializer.Serialize(new AwsEventBridgeDomainEvent(content, MediaTypeNames.Application.Json), settings);

            // TODO inject a transformer as a mediator to do the serialization

            var request = new PutEventsRequest
            {
                Entries =
                {
                    new PutEventsRequestEntry
                    {
                        DetailType = typeof(T).GetCustomAttribute<DomainEventAttribute>()?.Name ?? typeof(T).Name,
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