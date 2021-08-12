using AutoMapper;
using CrunchyPeanutButter.Core.Models.Bars;

namespace CrunchyPeanutButter.Core
{
    public class GetBarsQueryResultProfile : Profile
    {
        public GetBarsQueryResultProfile()
        {
            CreateMap<Bar, GetBarsQueryResult>();
        }
    }
}