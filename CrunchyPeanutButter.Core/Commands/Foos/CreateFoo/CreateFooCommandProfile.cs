using AutoMapper;
using CrunchyPeanutButter.Core.Models.Foos;

namespace CrunchyPeanutButter.Core.Commands.Foos.CreateFoo
{
    public class CreateFooCommandProfile : Profile
    {
        public CreateFooCommandProfile()
        {
            CreateMap<CreateFooCommand, Foo>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}