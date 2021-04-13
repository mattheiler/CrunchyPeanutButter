using AutoMapper;
using CrunchyPeanutButter.Domain.Models.Bars;

namespace CrunchyPeanutButter.Application.Queries.Bars
{
    public class GetBarQueryResultProfile : Profile
    {
        public GetBarQueryResultProfile()
        {
            CreateMap<Bar, GetBarQueryResult>();
        }
    }
}