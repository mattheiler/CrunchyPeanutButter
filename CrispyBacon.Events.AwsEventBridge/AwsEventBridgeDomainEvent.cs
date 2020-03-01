namespace CrispyBacon.Events.AwsEventBridge
{
    public sealed class AwsEventBridgeDomainEvent
    {
        internal AwsEventBridgeDomainEvent(string content, string contentType)
        {
            Content = content;
            ContentType = contentType;
        }

        public string Content { get; }


        public string ContentType { get; }
    }
}