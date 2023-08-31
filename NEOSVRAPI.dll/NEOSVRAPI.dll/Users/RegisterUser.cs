using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NeosApiLibrary.Users
{
    public class RegisterUser
    {
        private readonly HttpClient _httpClient;

        public RegisterUser(ApiClient apiClient)
        {
            _httpClient = apiClient.GetHttpClient();
        }

        public async Task<string> RegisterNewUserAsync(UserRegistrationData userData)
        {
            try
            {
                var response = await _httpClient.PostAsync($"{ApiClient.BaseUrl}/api/users", userData.ToHttpContent());
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                throw new NeosApiException("Error while registering a new user.", ex);
            }
        }
    }
}
