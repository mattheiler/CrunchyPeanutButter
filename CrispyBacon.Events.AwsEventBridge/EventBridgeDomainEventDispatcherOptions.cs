namespace CrispyBacon.Events.AwsEventBridge
{
    public sealed class EventBridgeDomainEventDispatcherOptions
    {
        public string EventBusName { get; set; }

        public string Source { get; set; }
    }
}