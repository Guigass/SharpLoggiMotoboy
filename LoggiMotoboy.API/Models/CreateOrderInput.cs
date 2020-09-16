using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggiMotoboy.API.Models
{
    public class CreateOrderInput
    {
        [JsonProperty("shopId", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShopId { get; set; }

        [JsonProperty("paymentMethod", NullValueHandling = NullValueHandling.Ignore)]
        public long? PaymentMethod { get; set; }

        [JsonProperty("trackingKey")]
        public string TrackingKey { get; set; }

        [JsonProperty("pickups")]
        public List<Pickup> Pickups { get; set; }

        [JsonProperty("packages")]
        public List<Package> Packages { get; set; }
    }
}
