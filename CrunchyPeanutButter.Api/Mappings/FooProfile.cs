using AutoMapper;
using CrispyBacon.Collections;
using CrunchyPeanutButter.Api.Models.Foos;
using CrunchyPeanutButter.Domain.Foos;
using CrunchyPeanutButter.Domain.Foos.Commands;
using CrunchyPeanutButter.Queries.Foos;

namespace CrunchyPeanutButter.Api.Mappings
{
    public class FooProfile : Profile
    {
        public FooProfile()
        {
            CreateMap<FooDetails, FooFindResponse>();

            CreateMap<Page<FooHeader>, FooPageResponse>()
                .ForMember(response => response.PageIndex, config => config.MapFrom(page => page.Index))
                .ForMember(response => response.PageSize, config => config.MapFrom(page => page.Size));
            CreateMap<FooHeader, FooPageResponseItem>();

            CreateMap<FooCreateRequest, CreateFooCommand>();
            CreateMap<Foo, FooCreateResponse>();

            CreateMap<FooUpdateRequest, UpdateFooCommand>();
            CreateMap<Foo, FooUpdateResponse>();

            CreateMap<FooDeleteRequest, DeleteFooCommand>();
            CreateMap<bool, FooDeleteResponse>()
                .ConstructUsing(success => new FooDeleteResponse {Success = success});
        }
    }
}