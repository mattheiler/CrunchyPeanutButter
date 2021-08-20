using AutoMapper;
using CrunchyPeanutButter.Core.Models.Foos;

namespace CrunchyPeanutButter.Core.Commands.Foos.UpdateFoo
{
    public class UpdateFooCommandProfile : Profile
    {
        public UpdateFooCommandProfile()
        {
            CreateMap<UpdateFooCommand, Foo>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}