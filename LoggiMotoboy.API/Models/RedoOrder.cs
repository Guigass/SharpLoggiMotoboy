using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggiMotoboy.API.Models
{
    public partial class RedoOrder
    {
        [JsonProperty("redoOrder")]
        public RedoOrderClass RedoOrderClass { get; set; }
    }

    public partial class RedoOrderClass
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("order")]
        public Order Order { get; set; }
    }
}
