using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NeosApiLibrary.Users
{
    public class GetUser
    {
        private readonly HttpClient _httpClient;

        public GetUser(ApiClient apiClient)
        {
            _httpClient = apiClient.GetHttpClient();
        }

        public async Task<string> GetUserInfoAsync(string userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiClient.BaseUrl}/api/users/{userId}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                throw new NeosApiException($"Error while getting user info for user ID {userId}.", ex);
            }
        }
    }
}
