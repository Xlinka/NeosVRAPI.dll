using System.Net.Http.Headers;

namespace NeosApiLibrary
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        public const string BaseUrl = "https://api.neos.com"; 

        public ApiClient(string accessToken)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        public HttpClient GetHttpClient()
        {
            return _httpClient;
        }
    }
}
