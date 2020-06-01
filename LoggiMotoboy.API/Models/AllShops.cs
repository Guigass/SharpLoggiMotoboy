using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggiMotoboy.API.Models
{
    public partial class AllShops
    {
        [JsonProperty("allShops")]
        public AllShopsClass AllShopsAllShops { get; set; }
    }

    public partial class AllShopsClass
    {
        [JsonProperty("edges")]
        public List<ShopEdge> Edges { get; set; }
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

    public class ShopAddress
    {
        [JsonProperty("pos")]
        public string Pos { get; set; }

        [JsonProperty("addressSt")]
        public string AddressSt { get; set; }

        [JsonProperty("addressData")]
        public string AddressData { get; set; }
    }

    public class ShopEdge
    {
        [JsonProperty("node")]
        public ShopNode Node { get; set; }
    }

    public class ShopNode
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
        public ShopAddress Address { get; set; }

        [JsonProperty("chargeOptions")]
        public List<ChargeOption> ChargeOptions { get; set; }

        [JsonProperty("externalId")]
        public string ExternalId { get; set; }
    }
}
