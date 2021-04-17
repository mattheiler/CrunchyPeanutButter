using AutoMapper;
using CrunchyPeanutButter.Domain.Models.Bars;

namespace CrunchyPeanutButter.Application
{
    public class GetBarQueryResultProfile : Profile
    {
        public GetBarQueryResultProfile()
        {
            CreateMap<Bar, GetBarQueryResult>();
        }
    }
}