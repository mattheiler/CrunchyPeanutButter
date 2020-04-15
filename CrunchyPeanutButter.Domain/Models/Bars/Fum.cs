using Newtonsoft.Json;

namespace CrunchyPeanutButter.Domain.Models.Bars
{
    [JsonObject]
    public class Fum
    {
        [JsonProperty]
        public string Name { get; set; }
    }
}