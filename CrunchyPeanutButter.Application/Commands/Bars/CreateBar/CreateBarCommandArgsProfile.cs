using AutoMapper;
using CrunchyPeanutButter.Domain.Models.Bars;

namespace CrunchyPeanutButter.Application.Commands.Bars
{
    public class CreateBarCommandArgsProfile : Profile
    {
        public CreateBarCommandArgsProfile()
        {
            CreateMap<CreateBarCommandArgs, Bar>();
        }
    }
}