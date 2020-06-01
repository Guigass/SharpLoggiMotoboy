using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggiMotoboy.API.Models
{
    public class Package
    {
        [JsonProperty("pickupIndex")]
        public long PickupIndex { get; set; }

        [JsonProperty("address")]
        public PackageAddress Address { get; set; }

        [JsonProperty("recipient")]
        public Recipient Recipient { get; set; }

        [JsonProperty("dimensions")]
        public Dimensions Dimensions { get; set; }

        [JsonProperty("charge")]
        public Charge Charge { get; set; }
    }

    public partial class Recipient
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }

    public class PackageAddress
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

    public class Charge
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("method")]
        public long Method { get; set; }

        [JsonProperty("change")]
        public string Change { get; set; }
    }

    public class Dimensions
    {
        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("weight")]
        public long Weight { get; set; }

        [JsonProperty("length")]
        public long Length { get; set; }
    }
}
