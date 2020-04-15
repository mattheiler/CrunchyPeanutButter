namespace CrispyBacon.Events.AwsEventBridge
{
    public sealed class EventBridgePayload
    {
        internal EventBridgePayload(string content, string contentType)
        {
            Content = content;
            ContentType = contentType;
        }

        public string Content { get; }


        public string ContentType { get; }
    }
}