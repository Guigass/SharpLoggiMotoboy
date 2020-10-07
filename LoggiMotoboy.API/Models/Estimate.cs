using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggiMotoboy.API.Models
{
    public partial class Estimate
    {
        [JsonProperty("estimate")]
        public EstimateClass EstimateClass { get; set; }
    }

    public partial class EstimateClass
    {
        [JsonProperty("packages")]
        public Package[] Packages { get; set; }

        [JsonProperty("routeOptimized")]
        public bool RouteOptimized { get; set; }

        [JsonProperty("normal")]
        public Normal Normal { get; set; }

        [JsonProperty("optimized")]
        public Normal Optimized { get; set; }
    }

    public partial class Normal
    {
        [JsonProperty("cost")]
        public double Cost { get; set; }

        [JsonProperty("distance")]
        public long Distance { get; set; }

        [JsonProperty("eta")]
        public long Eta { get; set; }
    }
}
