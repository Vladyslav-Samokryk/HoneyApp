using HoneyDataBace.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace HoneyDataBace
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new HoneyDbContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HoneyAppDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //var provoder = new Models.Provider() { Name = "AliExpress" };
            //new ProviderService(context).AddProvider(provoder);
          
            //var timer = new Stopwatch();
            //timer.Start();
            //new SupplyService(context, new SupplyWareService(context, new HoneyService(context))).AddSupply(new Models.Supply
            //{
            //    ProviderId = 1,
            //    SupplyDate = DateTime.Now,
            //    Wares = new List<Models.SupplyWare>()
            //    {
            //        new Models.SupplyWare(){  Count = 15, WareId = 1},
            //        new Models.SupplyWare(){  Count = 23, WareId = 1}
            //    }
            //}) ;
            //timer.Stop();
            //Console.WriteLine(timer.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
