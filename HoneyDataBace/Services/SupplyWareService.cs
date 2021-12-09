using HoneyDataBace.Models;
using HoneyDataBace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyDataBace.Services
{
    public class SupplyWareService : BaceService, ISupplyWareService
    {
        private readonly IHoneyService _honeyService;
        public SupplyWareService(HoneyDbContext context, IHoneyService honeyService): base(context)
        {
            _honeyService = honeyService;
        }
        public void AddWare(SupplyWare ware)
        {
            _context.Add(ware);
            _honeyService.AddHoney(ware.WareId, ware.Count);
            _context.SaveChanges();
        }
    }
}
