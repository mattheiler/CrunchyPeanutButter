using AutoMapper;
using CrunchyPeanutButter.Domain.Models.Foos;

namespace CrunchyPeanutButter.Application.Queries.Foos
{
    public class GetFooQueryResultProfile : Profile
    {
        public GetFooQueryResultProfile()
        {
            CreateMap<Foo, GetFooQueryResult>();
        }
    }
}