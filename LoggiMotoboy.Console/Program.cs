using System;

namespace LoggiMotoboy.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var loggi = new LoggiMotoboy.API.LoggiMotoboy();

            var a = loggi.Login("", "").Result;

            var b = loggi.EstimateCreateOrder().Result;
        }
    }
}
