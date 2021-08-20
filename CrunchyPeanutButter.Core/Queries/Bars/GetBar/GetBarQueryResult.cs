using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Models.Bars;

namespace CrunchyPeanutButter.Core.Queries.Bars.GetBar
{
    [AutoMap(typeof(Bar))]
    public class GetBarQueryResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}