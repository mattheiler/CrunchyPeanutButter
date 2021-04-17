using System.Threading.Tasks;

namespace CrunchyPeanutButter.ApiClient.Abstractions
{
    public interface ICrunchyPeanutButter
    {
        Task<GetBarResponse> GetBarAsync(GetBarRequest request);

        Task<GetBarsResponse> GetBarsAsync(GetBarsRequest request);

        Task<CreateBarResponse> CreateBarAsync(CreateBarRequest request);

        Task<UpdateBarResponse> UpdateBarAsync(UpdateBarRequest request);

        Task<DeleteBarResponse> DeleteBarAsync(DeleteBarRequest request);

        Task<GetFooResponse> GetFooAsync(GetFooRequest request);

        Task<GetFoosResponse> GetFoosAsync(GetFoosRequest request);

        Task<CreateFooResponse> CreateFooAsync(CreateFooRequest request);

        Task<UpdateFooResponse> UpdateFooAsync(UpdateFooRequest request);

        Task<DeleteFooResponse> DeleteFooAsync(DeleteFooRequest request);
    }
}