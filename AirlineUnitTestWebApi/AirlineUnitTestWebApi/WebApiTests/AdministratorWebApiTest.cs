using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirlineUnitTestWebApi
{
    [TestClass]
    public class AdministratorWebApiTest
    {
        private const string URL = "http://localhost:57588/api/AdministratorFacade/createcustomer";
        public void GetAdministratorToken()
        {
            Login login = new Login();
            login.GetToken(TestResource.Administrator_USER_NAME, TestResource.Administrator_PASSWORD);
        }
        [TestMethod]
        public void AdministratorFacade_CreateNewCustomer_AddCustomer()
        {
            InitDBUnitTestWebApi.InitDataBase();
            InitDBUnitTestWebApi.SetDB();
            GetAdministratorToken();

            // POST REQUEST
            HttpClient client_post = new HttpClient();

            client_post.DefaultRequestHeaders.Accept.Clear();
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(TestResource.token);
            string ss = Convert.ToBase64String(plainTextBytes);

            AuthenticationHeaderValue ahv = new AuthenticationHeaderValue("Bearer", TestResource.token);
            client_post.DefaultRequestHeaders.Authorization = ahv;

            client_post.BaseAddress = new Uri(URL);
           
            client_post.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Customer customer = new Customer
            {
                FIRST_NAME = TestResource.Customer2_FIRST_NAME,
                LAST_NAME = TestResource.Customer2_LAST_NAME,
                USER_NAME = TestResource.Customer2_USER_NAME,
                PASSWORD = TestResource.Customer2_PASSWORD,
                ADDRESS = TestResource.Customer2_ADDRESS,
                PHONE_NO = TestResource.Customer2_PHONE_NO,
                CREDIT_CARD_NUMBER = TestResource.Customer2_CREDIT_CARD_NUMBER
            };
        

            var response_post = client_post.PostAsJsonAsync(
                 URL, customer).Result;

            Customer c = response_post.Content.ReadAsAsync<Customer>().Result;
          
            Assert.AreNotEqual(null, c);
        }
    }
}
