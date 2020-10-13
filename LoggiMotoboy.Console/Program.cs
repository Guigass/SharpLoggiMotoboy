using LoggiMotoboy.API;
using LoggiMotoboy.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LoggiMotoboy.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var loggi = new LoggiPrestoClient())
            {
                var login = loggi.Login("paulo.gentile@exclusivasex.com.br", "loggi2020").Result;

                var shops = loggi.AllShops().Result;

                var packages = new List<Package>();
                packages.Add(new Package
                {
                    PickupIndex = 0,
                    Recipient = new Recipient
                    {
                        Name = "Guilherme",
                        Phone = "11999960923"
                    },
                    Address = new PackageAddress
                    {
                        Address = $"Rua Jacirendi, 91 - Tatuapé, São Paulo - SP, Brasil",
                        Complement = "Apto 152a"
                    },
                });

                var pickups = new List<Pickup>();
                pickups.Add(new Pickup
                {
                    Address = new PickupAddress
                    {
                        Address = $"Rua Belem, 234 - Belenzinho, São Paulo - SP, Brasil"
                    }
                });

                var request = new CreateOrderInput
                {
                    //ShopId = 5306,
                    PaymentMethod = 5306,
                    TrackingKey = "1234",
                    Packages = packages,
                    Pickups = pickups
                };

                var respLoggi = loggi.CreateOrderCorp(request).Result;
            }
        }
    }
}
