﻿using Newtonsoft.Json;

namespace CrunchyPeanutButter.Domain.Models.Bars
{
    [JsonObject]
    public class Ack
    {
        public Bar Bar { get; private set; }

        [JsonProperty]
        public int BarId { get; private set; }

        [JsonProperty]
        public string Name { get; set; }
    }
}