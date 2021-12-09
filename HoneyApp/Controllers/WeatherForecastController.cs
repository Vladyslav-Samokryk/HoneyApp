using HoneyDataBace.Models;
using HoneyDataBace.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HoneyApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IHoneyService _honeyService;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBillService _billService;
        private readonly IProviderService _providerService;

       public WeatherForecastController(ILogger<WeatherForecastController> logger, 
            IHoneyService honeyService, IBillService billService, IProviderService providerService)
        {
            _honeyService = honeyService;
            _logger = logger;
            _billService = billService;
            _providerService = providerService;
           
        }
        [HttpPost("AddProvider")]
        public void AddProvider(Provider provider)
        {
            _providerService.AddProvider(provider);
        }
        [HttpGet("Providers")]
        public IEnumerable<Provider> GetProviders()
        {
            return _providerService.GetAll();
        }
        [HttpPost("AddHoney")]
        public void AddHoney(string name, int prize, string description, IFormFile image)
        {
            if (image.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    image.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    Honey honey = new Honey()
                    {
                        Name = name,
                        Count = 45,
                        Price = prize,
                        ProviderId = 1,
                        Description = description,
                        Icon = fileBytes,
                        Kind = Enums.HoneyKind.Herbs,
                        Amount = 3

                    };
                    _honeyService.CreateNewWare(honey);
                }               
            }
            
         

        }
        [HttpGet("GetWares")]
        public IEnumerable<Ware> GetWares()
        {
            _logger.LogInformation("Contorller wares");
            var k = _honeyService.GetAll();
            _logger.LogInformation(k.Count().ToString());
            return k.Select(x => (Ware)x);
        }
        [HttpGet("GetRecomendWare")]
        public JsonResult GetWare()
        {
            return new JsonResult( _honeyService.GetAll().First());
        }
        [HttpGet("GetBills")]
        public JsonResult GetBills(int id)
        {
            var bills = _billService.Get().ToDictionary(x => x.Id);   // You can use your own method over here.         
            return new JsonResult(bills);

        }
        [HttpGet("image")]
        public JsonResult GetImage(int id)
        {            
            return new JsonResult(_honeyService.GetHoney(id).Icon);          
        }
        [HttpPost("orderWares")]
        public IEnumerable<Ware> GerOrderWares(IEnumerable<int> ids)
        {
            return _honeyService.GetAll().Where(x=> ids.Contains(x.Id)).Select(x => (Ware)x);
        }
        [HttpPost("newOrder")]
        public int NewOrder([FromBody]Bill bill)
        {
            return _billService.NewOrder(bill);
        }
      
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            _logger.LogInformation("Contorller get");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
