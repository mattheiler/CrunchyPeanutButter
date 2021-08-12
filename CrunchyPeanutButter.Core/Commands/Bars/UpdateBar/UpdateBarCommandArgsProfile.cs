using AutoMapper;
using CrunchyPeanutButter.Core.Models.Bars;

namespace CrunchyPeanutButter.Core
{
    public class UpdateBarCommandArgsProfile : Profile
    {
        public UpdateBarCommandArgsProfile()
        {
            CreateMap<UpdateBarCommandArgs, Bar>();
        }
    }
}