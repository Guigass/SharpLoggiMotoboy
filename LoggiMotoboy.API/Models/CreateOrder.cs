using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggiMotoboy.API.Models
{
    public class CreateOrder
    {
        [JsonProperty("createOrder")]
        public CreateOrderClass CreateOrderClass { get; set; }
    }

    public class CreateOrderClass
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("shop")]
        public Shop Shop { get; set; }

        [JsonProperty("orders")]
        public List<Order> Orders { get; set; }

        [JsonProperty("errors")]
        public List<object> Errors { get; set; }
    }

    public class Order
    {
        [JsonProperty("pk")]
        public long Pk { get; set; }

        [JsonProperty("trackingKey")]
        public string TrackingKey { get; set; }

        [JsonProperty("packages")]
        public List<PackageCreateOrder> Packages { get; set; }
    }

    public class PackageCreateOrder
    {
        [JsonProperty("pk")]
        public long Pk { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("pickupWaypoint")]
        public Waypoint PickupWaypoint { get; set; }

        [JsonProperty("waypoint")]
        public Waypoint Waypoint { get; set; }
    }

    public class Waypoint
    {
        [JsonProperty("index")]
        public long Index { get; set; }

        [JsonProperty("indexDisplay")]
        public string IndexDisplay { get; set; }

        [JsonProperty("eta")]
        public long Eta { get; set; }

        [JsonProperty("legDistance")]
        public long LegDistance { get; set; }
    }

    public class Shop
    {
        [JsonProperty("pk")]
        public long Pk { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
