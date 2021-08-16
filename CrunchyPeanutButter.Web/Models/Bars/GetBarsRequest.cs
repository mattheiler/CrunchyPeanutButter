using AutoMapper;
using CrunchyPeanutButter.Core.Queries.Bars.GetBars;

namespace CrunchyPeanutButter.Web.Models.Bars
{
    [AutoMap(typeof(GetBarsQuery), ReverseMap = true)]
    public class GetBarsRequest
    {
        public int Offset { get; set; }

        public int Limit { get; set; }
    }
}