using Newtonsoft.Json;
using RevolutAPI.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders.Objects
{
    public class IndustryData
    {

        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("booking_id")]
        public string BookingId { get; set; }
        [JsonProperty("fulfillment_date")]
        public DateTime FulfillmentDate { get; set; }
        [JsonProperty("ticket_type")]
        public string TicketType { get; set; }
        [JsonProperty("crs_code")]
        public string CrsCode { get; set; }
        [JsonProperty("ticket_change_indicator")]
        public string TicketChangeIndicator { get; set; }
        [JsonProperty("refundability")]
        public string Refundability { get; set; }
        [JsonProperty("passengers")]
        public List<Passenger> Passengers { get; set; }
        [JsonProperty("journey_legs")]
        public List<JourneyLeg> JourneyLegs { get; set; }
        [JsonProperty("booking_url")]
        public string BookingUrl { get; set; }


        public class JourneyLeg
        {
            [JsonProperty("sequence")]
            public int Sequence { get; set; }
            [JsonProperty("departure_airport_code")]
            public string DepartureAirportCode { get; set; }
            [JsonProperty("arrival_airport_code")]
            public string ArrivalAirportCode { get; set; }
            [JsonProperty("flight_number")]
            public string FlightNumber { get; set; }
            [JsonProperty("fare_base_code")]
            public string FareBaseCode { get; set; }
            [JsonProperty("travel_date")]
            public DateTime TravelDate { get; set; }
            [JsonProperty("airline_name")]
            public string AirlineName { get; set; }
            [JsonProperty("airline_code")]
            public string AirlineCode { get; set; }
        }
    }
}
