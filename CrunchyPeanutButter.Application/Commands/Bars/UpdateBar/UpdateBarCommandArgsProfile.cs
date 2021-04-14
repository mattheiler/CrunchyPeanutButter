using AutoMapper;
using CrunchyPeanutButter.Domain.Models.Bars;

namespace CrunchyPeanutButter.Application.Commands.Bars
{
    public class UpdateBarCommandArgsProfile : Profile
    {
        public UpdateBarCommandArgsProfile()
        {
            CreateMap<UpdateBarCommandArgs, Bar>();
        }
    }
}