using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineUnitTestWebApi
{
    static class InitDBUnitTestWebApi
    {
        public static void InitDataBase()
        {
            SqlDAO DL = new SqlDAO(FlightCenterConfig.strConn);
            string SQL = "DELETE FROM Tickets";
            DL.ExecuteSqlNonQuery(SQL);
            SQL = "DELETE FROM Customers";
            DL.ExecuteSqlNonQuery(SQL);
            SQL = "DELETE FROM Flights";
            DL.ExecuteSqlNonQuery(SQL);
            SQL = "DELETE FROM AirlineCompanies";
            DL.ExecuteSqlNonQuery(SQL);
            SQL = "DELETE FROM Countries";
            DL.ExecuteSqlNonQuery(SQL);
            SQL = "DBCC CHECKIDENT ('Customers', RESEED, 0)";
            DL.ExecuteSqlNonQuery(SQL);
            SQL = "DBCC CHECKIDENT ('Countries', RESEED, 0)";
            DL.ExecuteSqlNonQuery(SQL);
            SQL = "DBCC CHECKIDENT ('AirlineCompanies', RESEED, 0)";
            DL.ExecuteSqlNonQuery(SQL);
            SQL = "DBCC CHECKIDENT ('Flights', RESEED, 0)";
            DL.ExecuteSqlNonQuery(SQL);
            SQL = "DBCC CHECKIDENT ('Tickets', RESEED, 0)";
            DL.ExecuteSqlNonQuery(SQL);
        }
       public static void SetDB()
        {
            SqlDAO DL = new SqlDAO(FlightCenterConfig.strConn);
            StringBuilder sb = new StringBuilder();
            sb.Append($"INSERT INTO Customers(USER_NAME, PASSWORD, FIRST_NAME, LAST_NAME, ADDRESS, PHONE_NO, CREDIT_CARD_NUMBER)");
            sb.Append($" values('{ TestResource.Customer1_USER_NAME}', '{ TestResource.Customer1_PASSWORD}', '{ TestResource.Customer1_FIRST_NAME}', '{ TestResource.Customer1_LAST_NAME}','{ TestResource.Customer1_ADDRESS}', '{ TestResource.Customer1_PHONE_NO}', '{ TestResource.Customer1_CREDIT_CARD_NUMBER}')");
            string SQL1 = sb.ToString();
            DL.ExecuteSqlNonQuery(SQL1);

            string SQL2 = $"INSERT INTO Countries(COUNTRY_NAME) values('{ TestResource.CreateNewCountry1_AddCountry_COUNTRY_NAME}')";
            DL.ExecuteSqlNonQuery(SQL2);

            string SQL3 = $"INSERT INTO Countries(COUNTRY_NAME) values('{ TestResource.CreateNewCountry2_AddCountry_COUNTRY_NAME}')";
            DL.ExecuteSqlNonQuery(SQL2);

            sb = new StringBuilder();
            sb.Append($"INSERT INTO AirlineCompanies(AIRLINE_NAME, USER_NAME, PASSWORD, COUNTRY_CODE)");
            sb.Append($" values('{ TestResource.AirlineCompany1_AIRLINE_NAME}', '{ TestResource.AirlineCompany1_USER_NAME}', '{ TestResource.AirlineCompany1_PASSWORD}', {1})");
            string SQL4 = sb.ToString();
            DL.ExecuteSqlNonQuery(SQL4);

            sb = new StringBuilder();
            sb.Append($"INSERT INTO Flights(AIRLINECOMPANY_ID, ORIGIN_COUNTRY_CODE, DESTINATION_COUNTRY_CODE, DEPARTURE_TIME, LANDING_TIME, REMANING_TICKETS, TOTAL_TICKETS)");
            sb.Append($" values({1}, {1}, {2}, '{ TestResource.CreateNewFlight_DEPARTURE_TIME}', '{TestResource.CreateNewFlight_LANDING_TIME}', {100}, {100})");
            string SQL5 = sb.ToString();
            DL.ExecuteSqlNonQuery(SQL5);

        }
    }
}
