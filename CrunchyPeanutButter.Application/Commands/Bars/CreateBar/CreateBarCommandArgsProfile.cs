using AutoMapper;
using CrunchyPeanutButter.Domain.Models.Bars;

namespace CrunchyPeanutButter.Application
{
    public class CreateBarCommandArgsProfile : Profile
    {
        public CreateBarCommandArgsProfile()
        {
            CreateMap<CreateBarCommandArgs, Bar>();
        }
    }
}