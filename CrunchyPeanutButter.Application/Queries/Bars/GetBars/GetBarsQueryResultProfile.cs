using AutoMapper;
using CrunchyPeanutButter.Domain.Models.Bars;

namespace CrunchyPeanutButter.Application
{
    public class GetBarsQueryResultProfile : Profile
    {
        public GetBarsQueryResultProfile()
        {
            CreateMap<Bar, GetBarsQueryResult>();
        }
    }
}