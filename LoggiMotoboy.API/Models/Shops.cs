using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggiMotoboy.API.Models
{

    public class RetornoShops
    {
        [JsonProperty("allShops")]
        public AllShops AllShops { get; set; }
    }

    public class AllShops
    {
        [JsonProperty("edges")]
        public Edge[] Edges { get; set; }
    }

    public class Edge
    {
        [JsonProperty("node")]
        public Node Node { get; set; }
    }

    public class Node
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pickupInstructions")]
        public string PickupInstructions { get; set; }

        [JsonProperty("pk")]
        public long Pk { get; set; }

        [JsonProperty("pricingAreaDiscount")]
        public PricingAreaDiscount PricingAreaDiscount { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("chargeOptions")]
        public ChargeOption[] ChargeOptions { get; set; }

        [JsonProperty("externalId")]
        public string ExternalId { get; set; }
    }

    public class Address
    {
        [JsonProperty("pos")]
        public string Pos { get; set; }

        [JsonProperty("addressSt")]
        public string AddressSt { get; set; }

        [JsonProperty("addressData")]
        public string AddressData { get; set; }
    }

    public class ChargeOption
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class PricingAreaDiscount
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("percentage")]
        public string Percentage { get; set; }
    }
}
