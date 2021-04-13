using AutoMapper;
using CrunchyPeanutButter.Domain.Models.Foos;

namespace CrunchyPeanutButter.Application.Queries.Foos
{
    public class FooProfile : Profile
    {
        public FooProfile()
        {
            CreateMap<Foo, FooViewModel>();
        }
    }
}