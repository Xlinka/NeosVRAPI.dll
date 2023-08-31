using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NeosApiLibrary.UserSessions
{
    public class UserSessionsLogin
    {
        private readonly HttpClient _httpClient;

        public UserSessionsLogin(ApiClient apiClient)
        {
            _httpClient = apiClient.GetHttpClient();
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            try
            {
                var loginData = new
                {
                    username,
                    password
                };

                var json = JsonSerializer.Serialize(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{ApiClient.BaseUrl}/api/userSessions", content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                throw new NeosApiException("Error while logging in.", ex);
            }
        }
    }
}
