using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggiMotoboy.API.Models
{
    public class RetrieveOrderPK
    {
        [JsonProperty("retrieveOrderWithPk")]
        public RetrieveOrderClass RetrieveOrderClass { get; set; }
    }

    public class RetrieveOrderClass
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusDisplay")]
        public string StatusDisplay { get; set; }

        [JsonProperty("originalEta")]
        public long OriginalEta { get; set; }

        [JsonProperty("totalTime")]
        public object TotalTime { get; set; }

        [JsonProperty("pricing")]
        public Pricing Pricing { get; set; }

        [JsonProperty("currentDriverPosition")]
        public object CurrentDriverPosition { get; set; }

        [JsonProperty("packages")]
        public List<PackageRetrieveOrder> Packages { get; set; }
    }

    public class PackageRetrieveOrder
    {
        [JsonProperty("pk")]
        public long Pk { get; set; }

        [JsonProperty("shareds")]
        public Shareds Shareds { get; set; }
    }

    public class Shareds
    {
        [JsonProperty("edges")]
        public List<Edge> Edges { get; set; }
    }

    public class Edge
    {
        [JsonProperty("node")]
        public Node Node { get; set; }
    }

    public class Node
    {
        [JsonProperty("trackingUrl")]
        public string TrackingUrl { get; set; }
    }

    public class Pricing
    {
        [JsonProperty("totalCm")]
        public string TotalCm { get; set; }
    }

    public partial class RetrieveOrdersWithTrackingKey
    {
        [JsonProperty("retrieveOrdersWithTrackingKey")]
        public List<RetrieveOrdersWithTrackingKeyClass> RetrieveOrdersWithTrackingKeyClass { get; set; }
    }

    public partial class RetrieveOrdersWithTrackingKeyClass
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusDisplay")]
        public string StatusDisplay { get; set; }

        [JsonProperty("originalEta")]
        public long OriginalEta { get; set; }

        [JsonProperty("totalTime")]
        public object TotalTime { get; set; }

        [JsonProperty("pricing")]
        public Pricing Pricing { get; set; }

        [JsonProperty("packages")]
        public List<PackageRetiveOrder> Packages { get; set; }

        [JsonProperty("currentDriverPosition")]
        public object CurrentDriverPosition { get; set; }
    }

    public partial class PackageRetiveOrder
    {
        [JsonProperty("pk")]
        public long Pk { get; set; }

        [JsonProperty("shareds")]
        public Shareds Shareds { get; set; }
    }
}
