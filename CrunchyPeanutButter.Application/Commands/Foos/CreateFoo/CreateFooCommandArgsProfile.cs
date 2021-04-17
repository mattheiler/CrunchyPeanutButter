using AutoMapper;
using CrunchyPeanutButter.Domain.Models.Foos;

namespace CrunchyPeanutButter.Application
{
    public class CreateFooCommandArgsProfile : Profile
    {
        public CreateFooCommandArgsProfile()
        {
            CreateMap<CreateFooCommandArgs, Foo>();
        }
    }
}