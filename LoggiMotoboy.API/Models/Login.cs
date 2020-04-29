using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggiMotoboy.API.Models
{
    public class RetornoLogin
    {
        [JsonProperty("login")]
        public LoginClass Login { get; set; }
    }

    public class LoginClass
    {
        [JsonProperty("user")]
        public UserClass User { get; set; }
    }

    public class UserClass
    {
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
    }
}
