using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_Air
{

    public class Segments
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public CabinClass FlightCabinClass { get; set; }
        public DateTime PreferredDepartureTime { get; set; }
        public DateTime PreferredArrivalTime { get; set; }
        public Segments()
        {

        }
    }
    public class FareRule
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Airline { get; set; }
        public string FareBasisCode { get; set; }
        public List<string> FareRuleDetail { get; set; }
        public string FareRestriction { get; set; }
        public string AirlineCode { get; set; }
        public string ValidatingAirline { get; set; }
        public FareRule()
        {
            FareRuleDetail = new List<string>();
        }
    }
    public class Airport
    {
        public string AirportCode { get; set; }
        public string AirportName { get; set; }
        public string Terminal { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public Airport() { }
    }
    public class Origin
    {
        public Airport Airport { get; set; }
        public Origin()
        {
            Airport = new Airport();
        }
    }
    public class Destination
    {
        public Airport Airport { get; set; }
        public Destination()
        {
            Airport = new Airport();
        }
    }
    public class Airline
    {
        public string AirlineCode { get; set; }
        public string AirlineName { get; set; }
        public string FlightNumber { get; set; }
        public string FareClass { get; set; }
        public string OperatingCarrier { get; set; }
        public Airline() { }
    }
    public class AirSearchRequest
    {
        public string EndUserIp { get; set; }
        public string TokenId { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public int InfantCount { get; set; }
        public bool DirectFlight { get; set; }
        public bool OneStopFlight { get; set; }
        public JourneyType JourneyType { get; set; }
        public string PreferredAirlines { get; set; }
        public List<Segments> Segments { get; set; }

        public string Sources { get; set; }
        public AirSearchRequest()
        {
            Segments = new List<Segments>();
        }
    }

    public class AirSearchResponse
    {

    }
}

