using System.Collections.Generic;
using Newtonsoft.Json;

namespace CrunchyPeanutButter.Domain.Models.Foos
{
    [JsonObject]
    public class Baz
    {
        [JsonProperty]
        public int Id { get; private set; }

        public Foo Foo { get; private set; }

        [JsonProperty]
        public int FooId { get; private set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public ICollection<Qux> Quxes { get; } = new List<Qux>();
    }
}