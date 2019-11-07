using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirlineUnitTestWebApi
{
    [TestClass]
    public class AnonymousWebApiTest
    {
        private const string URL = "http://localhost:57588/api/AnonymousFacade/allflights";
        [TestMethod]
        public void AnonymouseFacade_GetAllFlightsWebApi_FlightsReceived()
        {
            InitDBUnitTestWebApi.InitDataBase();
            InitDBUnitTestWebApi.SetDB();
            //GetAirlineCompanyToken();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("");
            string ss = Convert.ToBase64String(plainTextBytes);

            AuthenticationHeaderValue ahv = new AuthenticationHeaderValue("Bearer", "");
            client.DefaultRequestHeaders.Authorization = ahv;

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.BaseAddress = new Uri(URL);

            var response = client.GetAsync("").Result;
            // List data response.
            bool iss = response.IsSuccessStatusCode;
            IList<Flight> flights = response.Content.ReadAsAsync<IList<Flight>>().Result;


            Assert.AreNotEqual(null, flights);
            Assert.AreEqual(TestResource.CreateNewFlight_LANDING_TIME, flights[0].LANDING_TIME);
            Assert.AreEqual(TestResource.CreateNewFlight_DEPARTURE_TIME, flights[0].DEPARTURE_TIME);
            Assert.AreEqual(2, flights[0].DESTINATION_COUNTRY_CODE);
            Assert.AreEqual(1, flights[0].AIRLINECOMPANY_ID);
            Assert.AreEqual(1, flights[0].ORIGIN_COUNTRY_CODE);
            Assert.AreEqual(100, flights[0].REMANING_TICKETS);
            Assert.AreEqual(TestResource.CreateNewFlight_TOTAL_TICKETS, flights[0].TOTAL_TICKETS);
        }
    }
}
