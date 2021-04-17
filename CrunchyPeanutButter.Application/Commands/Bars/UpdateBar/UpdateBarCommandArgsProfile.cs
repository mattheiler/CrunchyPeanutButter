using AutoMapper;
using CrunchyPeanutButter.Domain.Models.Bars;

namespace CrunchyPeanutButter.Application
{
    public class UpdateBarCommandArgsProfile : Profile
    {
        public UpdateBarCommandArgsProfile()
        {
            CreateMap<UpdateBarCommandArgs, Bar>();
        }
    }
}