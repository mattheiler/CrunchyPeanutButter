namespace CrispyBacon.Events.AwsEventBridge
{
    public class AwsEventBridgeDomainEventHandlerOptions
    {
        public string EventBusName { get; set; }

        public string Source { get; set; }
    }
}