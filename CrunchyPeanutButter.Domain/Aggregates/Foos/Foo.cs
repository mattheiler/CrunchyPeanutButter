﻿using System.Collections.Generic;
using CrispyBacon;
using Newtonsoft.Json;

namespace CrunchyPeanutButter.Domain.Aggregates.Foos
{
    [JsonObject]
    public class Foo : IAggregateRoot
    {
        [JsonProperty]
        public int Id { get; private set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public ICollection<FooBar> Bars { get; } = new List<FooBar>();

        [JsonProperty]
        public ICollection<Baz> Bazes { get; } = new List<Baz>();
    }
}