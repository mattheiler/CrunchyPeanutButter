using AutoMapper;
using CrunchyPeanutButter.Domain.Models.Bars;

namespace CrunchyPeanutButter.Application.Queries.Bars
{
    public class GetBarsQueryResultProfile : Profile
    {
        public GetBarsQueryResultProfile()
        {
            CreateMap<Bar, GetBarsQueryResult>();
        }
    }
}