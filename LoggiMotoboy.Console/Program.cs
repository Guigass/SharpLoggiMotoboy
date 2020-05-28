using LoggiMotoboy.API.Models;
using Newtonsoft.Json;
using System;

namespace LoggiMotoboy.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var loggi = new API.LoggiMotoboy("", ""))
            {
                var b = loggi.AllShops().Result;

                foreach (var item in b.Data.AllShops.Edges)
                {
                    var adress = JsonConvert.DeserializeObject<AddressData>(item.Node.Address.AddressData);
                }
            }
        }
    }
}
