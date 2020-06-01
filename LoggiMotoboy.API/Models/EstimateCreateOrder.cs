using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggiMotoboy.API.Models
{
    public partial class EstimateCreateOrder
    {
        [JsonProperty("estimateCreateOrder")]
        public EstimateCreateOrderClass EstimateCreateOrderEstimateCreateOrder { get; set; }
    }

    public partial class EstimateCreateOrderClass
    {
        [JsonProperty("totalEstimate")]
        public TotalEstimate TotalEstimate { get; set; }

        [JsonProperty("ordersEstimate")]
        public OrdersEstimate[] OrdersEstimate { get; set; }

        [JsonProperty("packagesWithErrors")]
        public object[] PackagesWithErrors { get; set; }
    }

    public partial class OrdersEstimate
    {
        [JsonProperty("packages")]
        public List<PackageEstimate> Packages { get; set; }

        [JsonProperty("optimized")]
        public Optimized Optimized { get; set; }
    }

    public partial class Optimized
    {
        [JsonProperty("cost")]
        public string Cost { get; set; }

        [JsonProperty("eta")]
        public long Eta { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }
    }

    public partial class PackageEstimate
    {
        [JsonProperty("isReturn")]
        public bool IsReturn { get; set; }

        [JsonProperty("cost")]
        public string Cost { get; set; }

        [JsonProperty("eta")]
        public long Eta { get; set; }

        [JsonProperty("outOfCoverageArea")]
        public bool OutOfCoverageArea { get; set; }

        [JsonProperty("outOfCityCover")]
        public bool OutOfCityCover { get; set; }

        [JsonProperty("originalIndex")]
        public long OriginalIndex { get; set; }

        [JsonProperty("resolvedAddress")]
        public string ResolvedAddress { get; set; }
    }

    public partial class TotalEstimate
    {
        [JsonProperty("totalCost")]
        public string TotalCost { get; set; }

        [JsonProperty("totalEta")]
        public long TotalEta { get; set; }

        [JsonProperty("totalDistance")]
        public double TotalDistance { get; set; }
    }
}
