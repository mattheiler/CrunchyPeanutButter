using AutoMapper;
using CrunchyPeanutButter.Domain.Models.Foos;

namespace CrunchyPeanutButter.Application.Commands.Foos
{
    public class UpdateFooCommandArgsProfile : Profile
    {
        public UpdateFooCommandArgsProfile()
        {
            CreateMap<UpdateFooCommandArgs, Foo>();
        }
    }
}