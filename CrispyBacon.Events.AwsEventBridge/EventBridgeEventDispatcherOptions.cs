namespace CrispyBacon.Events.AwsEventBridge
{
    public sealed class EventBridgeEventDispatcherOptions
    {
        public string EventBusName { get; set; }

        public string Source { get; set; }
    }
}