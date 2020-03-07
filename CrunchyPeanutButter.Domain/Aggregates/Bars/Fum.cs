using Newtonsoft.Json;

namespace CrunchyPeanutButter.Domain.Aggregates.Bars
{
    [JsonObject]
    public class Fum
    {
        [JsonProperty]
        public string Name { get; set; }
    }
}