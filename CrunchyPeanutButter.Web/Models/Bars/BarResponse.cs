using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Queries.Bars.GetBar;
using CrunchyPeanutButter.Core.Queries.Bars.GetBars;

namespace CrunchyPeanutButter.Web.Models.Bars
{
    [AutoMap(typeof(GetBarQueryResult))]
    [AutoMap(typeof(GetBarsQueryResult))]
    public class BarResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}