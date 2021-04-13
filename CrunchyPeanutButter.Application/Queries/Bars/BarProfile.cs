using AutoMapper;
using CrunchyPeanutButter.Domain.Models.Bars;

namespace CrunchyPeanutButter.Application.Queries.Bars
{
    public class BarProfile : Profile
    {
        public BarProfile()
        {
            CreateMap<Bar, BarViewModel>();
        }
    }
}