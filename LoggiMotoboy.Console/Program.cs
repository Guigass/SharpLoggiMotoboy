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
            //using (var loggi = new LoggiPrestoClient("paulo.gentile@exclusivasex.com.br", "loggi2020"))
            //{
            //    var shops = loggi.AllShops().Result;

            //    var packages = new List<Package>();
            //    packages.Add(new Package
            //    {
            //        Recipient = new Recipient
            //        {
            //            Name = "Guilherme",
            //            Phone = "11999960923"
            //        },
            //        Dimensions = new Dimensions
            //        {
            //            Height = 10,
            //            Length = 10,
            //            Weight = 10,
            //            Width = 10
            //        },
            //        Address = new PackageAddress
            //        {
            //            Address = $"Rua Jacirendi, 91 - Tatuapé, São Paulo - SP, Brasil",
            //            Complement = "Apto 152a"
            //        },
            //    });

            //    var pickups = new List<Pickup>();
            //    pickups.Add(new Pickup
            //    {
            //        Address = new PickupAddress
            //        {
            //            Address = $"Rua Belem, 234 - Belenzinho, São Paulo - SP, Brasil"
            //        }
            //    });

            //    var request = new CreateOrderInput
            //    {
            //        ShopId = 5306,
            //        TrackingKey = "1234",
            //        Packages = packages,
            //        Pickups = pickups
            //    };

            //    var respLoggi = loggi.CreateOrder(request).Result;
            //}
        }
    }
}
