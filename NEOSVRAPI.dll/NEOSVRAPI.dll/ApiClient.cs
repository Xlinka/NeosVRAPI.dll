using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NeosApiLibrary
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.neos.com"; // Adjust the actual API base URL

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
