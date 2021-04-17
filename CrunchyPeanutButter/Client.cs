using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace CrunchyPeanutButter
{
    public partial class Client
    {
        partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings)
        {
        }

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
        {
        }

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, StringBuilder urlBuilder)
        {
        }

        partial void ProcessResponse(HttpClient client, HttpResponseMessage response)
        {
        }
    }
}