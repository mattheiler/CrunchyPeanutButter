using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Models.Bars;

namespace CrunchyPeanutButter.Core.GetBar
{
    // Option: use a mapping profile to get control of your maps.
    [AutoMap(typeof(Bar))]
    public class GetBarQueryResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}