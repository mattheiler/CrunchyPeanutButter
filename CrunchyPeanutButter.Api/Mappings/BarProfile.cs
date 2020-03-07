using AutoMapper;
using CrispyBacon.Collections;
using CrunchyPeanutButter.Api.Models.Bars;
using CrunchyPeanutButter.Domain.Bars;
using CrunchyPeanutButter.Domain.Bars.Commands;
using CrunchyPeanutButter.Queries.Bars;

namespace CrunchyPeanutButter.Api.Mappings
{
    public class BarProfile : Profile
    {
        public BarProfile()
        {
            CreateMap<BarDetails, BarFindResponse>();

            CreateMap<Page<BarHeader>, BarPageResponse>()
                .ForMember(response => response.PageIndex, config => config.MapFrom(page => page.Index))
                .ForMember(response => response.PageSize, config => config.MapFrom(page => page.Size));
            CreateMap<BarHeader, BarPageResponseItem>();

            CreateMap<BarCreateRequest, CreateBarCommand>();
            CreateMap<Bar, BarCreateResponse>();

            CreateMap<BarUpdateRequest, UpdateBarCommand>();
            CreateMap<Bar, BarUpdateResponse>();

            CreateMap<BarDeleteRequest, DeleteBarCommand>();
            CreateMap<bool, BarDeleteResponse>()
                .ConstructUsing(success => new BarDeleteResponse {Success = success});
        }
    }
}