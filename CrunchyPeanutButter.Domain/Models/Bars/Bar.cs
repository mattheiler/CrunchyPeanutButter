using CrispyBacon.Models;
using Newtonsoft.Json;

namespace CrunchyPeanutButter.Domain.Models.Bars
{
    [JsonObject]
    public class Bar : IAggregateRoot
    {
        public Bar(Ack ack)
        {
            Ack = ack;
        }

        private Bar()
        {
        }


        [JsonProperty]
        public int Id { get; private set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public Ack Ack { get; private set; }

        [JsonProperty]
        public Fum Fum { get; private set; } = new Fum();
    }
}