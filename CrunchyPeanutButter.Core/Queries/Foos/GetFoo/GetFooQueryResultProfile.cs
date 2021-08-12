using AutoMapper;
using CrunchyPeanutButter.Core.Models.Foos;

namespace CrunchyPeanutButter.Core
{
    public class GetFooQueryResultProfile : Profile
    {
        public GetFooQueryResultProfile()
        {
            CreateMap<Foo, GetFooQueryResult>();
        }
    }
}