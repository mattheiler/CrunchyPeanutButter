using AutoMapper;
using CrunchyPeanutButter.Core.Models.Bars;

namespace CrunchyPeanutButter.Core.Commands.Bars.CreateBar
{
    public class CreateBarCommandProfile : Profile
    {
        public CreateBarCommandProfile()
        {
            CreateMap<CreateBarCommand, Bar>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}