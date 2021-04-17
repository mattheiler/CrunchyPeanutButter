using AutoMapper;
using CrunchyPeanutButter.Domain.Models.Foos;

namespace CrunchyPeanutButter.Application
{
    public class GetFooQueryResultProfile : Profile
    {
        public GetFooQueryResultProfile()
        {
            CreateMap<Foo, GetFooQueryResult>();
        }
    }
}