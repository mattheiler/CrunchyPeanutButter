using AutoMapper;
using CrunchyPeanutButter.Domain.Models.Foos;

namespace CrunchyPeanutButter.Application
{
    public class UpdateFooCommandArgsProfile : Profile
    {
        public UpdateFooCommandArgsProfile()
        {
            CreateMap<UpdateFooCommandArgs, Foo>();
        }
    }
}