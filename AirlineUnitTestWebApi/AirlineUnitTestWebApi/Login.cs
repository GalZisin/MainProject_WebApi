using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AirlineUnitTestWebApi
{
    public class Login
    {
        LoginRequest login = null;
        private const string URL = "http://localhost:57588/api/Login/UserLogin";
     
        public void GetToken(string username ,string password)
        {
            login = new LoginRequest
            {
                Username = username,
                Password = password
            };

            //// POST REQUEST
            HttpClient client_post = new HttpClient();

            client_post.BaseAddress = new Uri(URL);
            client_post.DefaultRequestHeaders.Accept.Clear();
            client_post.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            var response_post = client_post.PostAsJsonAsync(
             URL, login).Result;

            string responseString = response_post.Content.ReadAsStringAsync().Result;

            string token = JsonConvert.DeserializeObject<string>(responseString);

            TestResource.token = token;
        }
    }
}
