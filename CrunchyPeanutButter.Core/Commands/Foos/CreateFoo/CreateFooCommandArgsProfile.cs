using AutoMapper;
using CrunchyPeanutButter.Core.Models.Foos;

namespace CrunchyPeanutButter.Core
{
    public class CreateFooCommandArgsProfile : Profile
    {
        public CreateFooCommandArgsProfile()
        {
            CreateMap<CreateFooCommandArgs, Foo>();
        }
    }
}