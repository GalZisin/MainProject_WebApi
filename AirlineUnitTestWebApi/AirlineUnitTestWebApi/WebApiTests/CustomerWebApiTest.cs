using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirlineUnitTestWebApi
{
    [TestClass]
    public class CustomerWebApiTest
    {
        private const string URL = "http://localhost:57588/api/CustomerFacade/purchaseticket";

        public void GetCustomerToken()
        {
            Login login = new Login();
            login.GetToken(TestResource.Customer1_USER_NAME, TestResource.Customer1_PASSWORD);
        }
        [TestMethod]
        public void CustomerFacade_AddTicketWebApi_TicketAdded()
        {
            InitDBUnitTestWebApi.InitDataBase();
            InitDBUnitTestWebApi.SetDB();
            GetCustomerToken();
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

            Flight flight = new Flight
            {
                ID = 1,
                ORIGIN_COUNTRY_CODE = 1,
                DESTINATION_COUNTRY_CODE = 2,
                AIRLINECOMPANY_ID = 1,
                DEPARTURE_TIME = TestResource.CreateNewFlight_DEPARTURE_TIME,
                LANDING_TIME = TestResource.CreateNewFlight_LANDING_TIME,
                REMANING_TICKETS = TestResource.CreateNewFlight_REMANING_TICKETS,
                TOTAL_TICKETS = TestResource.CreateNewFlight_TOTAL_TICKETS
            };


            var response_post = client_post.PostAsJsonAsync(
                 URL, flight).Result;

            Ticket ticket = response_post.Content.ReadAsAsync<Ticket>().Result;

            Assert.AreNotEqual(null, ticket);
            Assert.AreEqual(flight.ID, ticket.FLIGHT_ID);
        }
    }
}
