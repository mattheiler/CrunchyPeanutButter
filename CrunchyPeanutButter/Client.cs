using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CrunchyPeanutButter
{
    public class Client
    {
        protected Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpRequestMessage());
        }
    }
}