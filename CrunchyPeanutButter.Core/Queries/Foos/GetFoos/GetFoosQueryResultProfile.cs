using AutoMapper;
using CrunchyPeanutButter.Core.Models.Foos;

namespace CrunchyPeanutButter.Core
{
    public class GetFoosQueryResultProfile : Profile
    {
        public GetFoosQueryResultProfile()
        {
            CreateMap<Foo, GetFoosQueryResult>();
        }
    }
}