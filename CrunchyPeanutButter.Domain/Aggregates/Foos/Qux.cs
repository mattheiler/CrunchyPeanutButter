using Newtonsoft.Json;

namespace CrunchyPeanutButter.Domain.Aggregates.Foos
{
    [JsonObject]
    public class Qux
    {
        [JsonProperty]
        public int Id { get; private set; }

        public Baz Baz { get; private set; }

        [JsonProperty]
        public int BazId { get; private set; }

        [JsonProperty]
        public string Name { get; set; }
    }
}