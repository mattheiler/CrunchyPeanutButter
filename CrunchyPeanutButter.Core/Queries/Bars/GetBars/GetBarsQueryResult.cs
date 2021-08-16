using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Models.Bars;

namespace CrunchyPeanutButter.Core.GetBars
{
    // Option: use a mapping profile to get control of your maps.
    [AutoMap(typeof(Bar))]
    public class GetBarsQueryResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}