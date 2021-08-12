using AutoMapper;
using CrunchyPeanutButter.Core.Models.Bars;

namespace CrunchyPeanutButter.Core
{
    public class CreateBarCommandArgsProfile : Profile
    {
        public CreateBarCommandArgsProfile()
        {
            CreateMap<CreateBarCommandArgs, Bar>();
        }
    }
}