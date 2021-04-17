using AutoMapper;
using CrunchyPeanutButter.Domain.Models.Foos;

namespace CrunchyPeanutButter.Application
{
    public class GetFoosQueryResultProfile : Profile
    {
        public GetFoosQueryResultProfile()
        {
            CreateMap<Foo, GetFoosQueryResult>();
        }
    }
}