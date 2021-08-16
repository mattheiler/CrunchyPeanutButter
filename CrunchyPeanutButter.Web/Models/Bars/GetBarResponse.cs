using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Queries.Bars.GetBar;

namespace CrunchyPeanutButter.Web.Models.Bars
{
    [AutoMap(typeof(GetBarQueryResult))]
    public class GetBarResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}