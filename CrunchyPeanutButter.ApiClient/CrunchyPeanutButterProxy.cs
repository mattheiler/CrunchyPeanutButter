using System.Collections.Generic;
using System.Threading.Tasks;
using CrunchyPeanutButter.ApiClient.Abstractions;
using CrunchyPeanutButter.ApiClient.Abstractions.Models;
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

        public Task<Bar> GetBarAsync(int id)
        {
            return _options.Value.BaseUrl.AppendPathSegments("bars", id).GetJsonAsync<Bar>();
        }

        public async Task<IReadOnlyCollection<Bar>> GetBarsAsync(int? pageIndex = default, int? pageSize = default)
        {
            return await _options.Value.BaseUrl.AppendPathSegments("bars").SetQueryParams(new { pageIndex, pageSize }).GetJsonAsync<Bar[]>();
        }

        public Task CreateBarAsync(Bar bar)
        {
            return _options.Value.BaseUrl.AppendPathSegments("bars").PostJsonAsync(bar);
        }

        public Task UpdateBarAsync(int id, Bar bar)
        {
            return _options.Value.BaseUrl.AppendPathSegments("bars", id).PutJsonAsync(bar);
        }

        public Task DeleteBarAsync(int id)
        {
            return _options.Value.BaseUrl.AppendPathSegments("bars", id).DeleteAsync();
        }

        public Task<Foo> GetFooAsync(int id)
        {
            return _options.Value.BaseUrl.AppendPathSegments("foos", id).GetJsonAsync<Foo>();
        }

        public async Task<IReadOnlyCollection<Foo>> GetFoosAsync(int? pageIndex = default, int? pageSize = default)
        {
            return await _options.Value.BaseUrl.AppendPathSegments("foos").SetQueryParams(new { pageIndex, pageSize }).GetJsonAsync<Foo[]>();
        }

        public Task CreateFooAsync(Foo foo)
        {
            return _options.Value.BaseUrl.AppendPathSegments("foos").PostJsonAsync(foo);
        }

        public Task UpdateFooAsync(int id, Foo foo)
        {
            return _options.Value.BaseUrl.AppendPathSegments("foos", id).PutJsonAsync(foo);
        }

        public Task DeleteFooAsync(int id)
        {
            return _options.Value.BaseUrl.AppendPathSegments("foos", id).DeleteAsync();
        }
    }
}