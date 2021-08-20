using AutoMapper;
using CrunchyPeanutButter.Core.Models.Bars;

namespace CrunchyPeanutButter.Core.Commands.Bars.UpdateBar
{
    public class UpdateBarCommandProfile : Profile
    {
        public UpdateBarCommandProfile()
        {
            CreateMap<UpdateBarCommand, Bar>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}