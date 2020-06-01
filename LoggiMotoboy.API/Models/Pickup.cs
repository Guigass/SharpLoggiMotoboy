using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggiMotoboy.API.Models
{
    public class Pickup
    {
        [JsonProperty("address")]
        public PickupAddress Address { get; set; }
    }

    public class PickupAddress
    {
        [JsonProperty("lat")]
        public double? Lat { get; set; }

        [JsonProperty("lng")]
        public double? Lng { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("complement")]
        public string Complement { get; set; }
    }
}
