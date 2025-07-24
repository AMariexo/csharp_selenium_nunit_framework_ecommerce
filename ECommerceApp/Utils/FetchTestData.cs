using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerceApp.Utils
{
    public class LoginData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string IncorrectUsername { get; set; }
        public string IncorrectPassword { get; set; }
    }

    public class ReturnTestData
    {
        public static async Task<LoginData> GetLoginDataAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:3000/login");

            var contentType = response.Content.Headers.ContentType.MediaType;

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();


            //the property names in the test data file is 'lowercase' and the get/set parameters are upper case - this will allow for the property names to case insensitive
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<LoginData>(json, options);
        }
    }
}
