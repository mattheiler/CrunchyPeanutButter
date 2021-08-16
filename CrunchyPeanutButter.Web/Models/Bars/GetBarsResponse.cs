using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Queries.Bars.GetBars;

namespace CrunchyPeanutButter.Web.Models.Bars
{
    [AutoMap(typeof(GetBarsQueryResult))]
    public class GetBarsResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}