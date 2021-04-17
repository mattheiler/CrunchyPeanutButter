using System.Collections.Generic;
using System.Threading.Tasks;
using CrunchyPeanutButter.ApiClient.Abstractions;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;

namespace CrunchyPeanutButter.ApiClient
{
    public class CrunchyPeanutButterProxy : ICrunchyPeanutButter
    {
        private readonly IOptions<CrunchyPeanutButterProxyOptions> _options;

        public CrunchyPeanutButterProxy(IOptions<CrunchyPeanutButterProxyOptions> options)
        {
            _options = options;
        }

        public Task<GetBarResponse> GetBarAsync(GetBarRequest request)
        {
            return _options.Value.BaseUrl.AppendPathSegments("bars", request.Id).GetJsonAsync<GetBarResponse>();
        }

        public async Task<GetBarsResponse> GetBarsAsync(GetBarsRequest request)
        {
            return await _options.Value.BaseUrl.AppendPathSegments("bars").SetQueryParams(request).GetJsonAsync<GetBarsResponse>();
        }

        public async Task<CreateBarResponse> CreateBarAsync(CreateBarRequest request)
        {
            var response = await _options.Value.BaseUrl.AppendPathSegments("bars").PostJsonAsync(request);
            return await response.GetJsonAsync<CreateBarResponse>();
        }

        public async Task<UpdateBarResponse> UpdateBarAsync(UpdateBarRequest request)
        {
            var response = await _options.Value.BaseUrl.AppendPathSegments("bars", request.Id).PutJsonAsync(request);
            return await response.GetJsonAsync<UpdateBarResponse>();
        }

        public async Task<DeleteBarResponse> DeleteBarAsync(DeleteBarRequest request)
        {
            var response = await _options.Value.BaseUrl.AppendPathSegments("bars", request.Id).DeleteAsync();
            return await response.GetJsonAsync<DeleteBarResponse>();
        }

        public Task<GetFooResponse> GetFooAsync(GetFooRequest request)
        {
            return _options.Value.BaseUrl.AppendPathSegments("foos", request.Id).GetJsonAsync<GetFooResponse>();
        }

        public async Task<GetFoosResponse> GetFoosAsync(GetFoosRequest request)
        {
            return await _options.Value.BaseUrl.AppendPathSegments("foos").SetQueryParams(request).GetJsonAsync<GetFoosResponse>();
        }

        public async Task<CreateFooResponse> CreateFooAsync(CreateFooRequest request)
        {
            var response = await _options.Value.BaseUrl.AppendPathSegments("foos").PostJsonAsync(request);
            return await response.GetJsonAsync<CreateFooResponse>();
        }

        public async Task<UpdateFooResponse> UpdateFooAsync(UpdateFooRequest request)
        {
            var response = await _options.Value.BaseUrl.AppendPathSegments("foos", request.Id).PutJsonAsync(request);
            return await response.GetJsonAsync<UpdateFooResponse>();
        }

        public async Task<DeleteFooResponse> DeleteFooAsync(DeleteFooRequest request)
        {
            var response = await _options.Value.BaseUrl.AppendPathSegments("foos", request.Id).DeleteAsync();
            return await response.GetJsonAsync<DeleteFooResponse>();
        }
    }
}