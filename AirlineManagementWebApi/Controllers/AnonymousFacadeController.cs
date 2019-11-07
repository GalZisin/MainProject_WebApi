using AirlineManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AirlineManagementWebApi.Controllers
{
    public class AnonymousFacadeController : ApiController
    {
        private FlyingCenterSystem FCS;
        /// <summary>
        /// Get all flights
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Flight))]
        [Route("api/AnonymousFacade/allflights")]
        [HttpGet]
        public IHttpActionResult GetAllFlights()
        {
            FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            IAnonymousUserFacade anonymousFacade = FCS.GetFacade(null) as IAnonymousUserFacade;
            IList<Flight> flights = anonymousFacade.GetAllFlights();
            if (flights.Count == 0)
            {
                return NotFound();
            }
            return Ok(flights);
        }
        /// <summary>
        /// Get all airline companies
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(AirlineCompany))]
        [Route("api/AnonymousFacade/allairlinecompanies")]
        [HttpGet]
        public IHttpActionResult GetAllAirlineCompanies()
        {
            FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            IAnonymousUserFacade anonymousFacade = FCS.GetFacade(null) as IAnonymousUserFacade;
            IList<AirlineCompany> airlineCompanies = anonymousFacade.GetAllAirlineCompanies();
            if (airlineCompanies.Count == 0)
            {
                return NotFound();
            }
            return Ok(airlineCompanies);
        }
        /// <summary>
        /// Get flights by vacancy
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Flight))]
        [Route("api/AnonymousFacade/gebyvacancy/{id}")]
        [HttpGet]
        public IHttpActionResult GetAllFlightsVacancy()
        {
            FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            IAnonymousUserFacade anonymousFacade = FCS.GetFacade(null) as IAnonymousUserFacade;
            Dictionary<Flight, int> flights = anonymousFacade.GetAllFlightsByVacancy();

            if (flights.Count == 0)
            {
                return NotFound();
            }
            return Ok(flights);
        }
        /// <summary>
        /// Get flight by id
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Flight))]
        [Route("api/AnonymousFacade/gebyid/{id}")]
        [HttpGet]
        public IHttpActionResult GetFlightById(int flightId)
        {
            FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            IAnonymousUserFacade anonymousFacade = FCS.GetFacade(null) as IAnonymousUserFacade;
            Flight flight = anonymousFacade.GetFlightById(flightId);

            if (flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }
        /// <summary>
        /// Get flights by origin country code
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Flight))]
        [Route("api/AnonymousFacade/getbyorigincountrycode/{countryCode}")]
        [HttpGet]
        public IHttpActionResult GetFlightsByOriginCountry(int countryCode)
        {
            FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            IAnonymousUserFacade anonymousFacade = FCS.GetFacade(null) as IAnonymousUserFacade;
            IList<Flight> flights = anonymousFacade.GetFlightsByOriginCountry(countryCode);

            if (flights.Count == 0)
            {
                return NotFound();
            }
            return Ok(flights);
        }
        /// <summary>
        /// Get flights by destination country code (Query parameters)
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Flight))]
        [Route("api/AnonymousFacade/getbydestinationcountrycode/search")]
        [HttpGet]
        public IHttpActionResult GetFlightsByDestinationCountry(int countryCode = 0)
        {
            IHttpActionResult res = null;
            IList<Flight> flights = null;
            FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            IAnonymousUserFacade anonymousFacade = FCS.GetFacade(null) as IAnonymousUserFacade;
            if (countryCode != 0)
            {
                flights = anonymousFacade.GetFlightsByDestinationCountry(countryCode);
                res = Ok(flights);
            }
            else if ((countryCode != 0 && flights.Count == 0) || countryCode == 0)
            {
                res = NotFound();
            }

            return res;
        }
        /// <summary>
        /// Get flights by departure date
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Flight))]
        [Route("api/AnonymousFacade/getbydeparturedate/{departureDate}")]
        [HttpGet]
        public IHttpActionResult GetFlightsByDepatrureDate(DateTime departureDate)
        {
            FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            IAnonymousUserFacade anonymousFacade = FCS.GetFacade(null) as IAnonymousUserFacade;
            IList<Flight> flights = anonymousFacade.GetFlightsByDepatrureDate(departureDate);

            if (flights.Count == 0)
            {
                return NotFound();
            }
            return Ok(flights);
        }
        /// <summary>
        /// Get flights by landinge date
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Flight))]
        [Route("api/AnonymousFacade/getbylandingdate/{landingeDate}")]
        [HttpGet]
        public IHttpActionResult GetFlightsByLandingDate(DateTime landingeDate)
        {
            FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            IAnonymousUserFacade anonymousFacade = FCS.GetFacade(null) as IAnonymousUserFacade;
            IList<Flight> flights = anonymousFacade.GetFlightsByLandingDate(landingeDate);

            if (flights.Count == 0)
            {
                return NotFound();
            }
            return Ok(flights);
        }
    }
}
