using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Models.Bars;

namespace CrunchyPeanutButter.Core.Queries.Bars.GetBars
{
    [AutoMap(typeof(Bar))]
    public class GetBarsQueryResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}