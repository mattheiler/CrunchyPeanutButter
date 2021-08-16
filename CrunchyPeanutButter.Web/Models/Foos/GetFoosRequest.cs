using AutoMapper;
using CrunchyPeanutButter.Core.Queries.Foos.GetFoos;


namespace CrunchyPeanutButter.Web.Models.Foos
{
    [AutoMap(typeof(GetFoosQuery), ReverseMap = true)]
    public class GetFoosRequest
    {
        public int Offset { get; set; }

        public int Limit { get; set; }
    }
}