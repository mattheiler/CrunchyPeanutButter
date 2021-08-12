using AutoMapper;
using CrunchyPeanutButter.Core.Models.Bars;

namespace CrunchyPeanutButter.Core
{
    public class GetBarQueryResultProfile : Profile
    {
        public GetBarQueryResultProfile()
        {
            CreateMap<Bar, GetBarQueryResult>();
        }
    }
}