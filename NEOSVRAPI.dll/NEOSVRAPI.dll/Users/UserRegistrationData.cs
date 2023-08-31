using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NeosApiLibrary.Users
{
    public class UserRegistrationData
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public HttpContent ToHttpContent()
        {
            // Convert the object to JSON and create StringContent
            var json = JsonSerializer.Serialize(this);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return content;
        }
    }
}
