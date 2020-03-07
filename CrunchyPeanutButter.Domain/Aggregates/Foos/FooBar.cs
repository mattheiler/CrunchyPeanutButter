using CrunchyPeanutButter.Domain.Aggregates.Bars;
using Newtonsoft.Json;

namespace CrunchyPeanutButter.Domain.Aggregates.Foos
{
    [JsonObject]
    public class FooBar
    {
        private FooBar(Bar bar)
        {
            Bar = bar;
        }


        private FooBar()
        {
        }

        public Foo Foo { get; private set; }

        [JsonProperty]
        public int FooId { get; private set; }

        // TODO hide this, but expose the bar ID....
        public Bar Bar { get; private set; }

        [JsonProperty]
        public int BarId { get; private set; }
    }
}