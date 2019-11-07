using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineUnitTestWebApi
{
    public class Ticket
    {
        public long ID { get; set; }
        public long FLIGHT_ID { get; set; }
        public long CUSTOMER_ID { get; set; }
    }
}
