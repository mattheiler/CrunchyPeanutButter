using AutoMapper;
using CrunchyPeanutButter.Core.Models.Foos;

namespace CrunchyPeanutButter.Core
{
    public class UpdateFooCommandArgsProfile : Profile
    {
        public UpdateFooCommandArgsProfile()
        {
            CreateMap<UpdateFooCommandArgs, Foo>();
        }
    }
}