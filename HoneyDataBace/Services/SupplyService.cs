using HoneyDataBace.Models;
using HoneyDataBace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyDataBace.Services
{
    public class SupplyService : BaceService, ISupplyService
    {
        private readonly ISupplyWareService _supplyWareService;
        public SupplyService(HoneyDbContext context, ISupplyWareService supplyWareService) : base(context)
        {
            _supplyWareService = supplyWareService;
        }
        public bool AddSupply(Supply supply)
        {
            if (_context.Providers.Any(x => x.Id == supply.ProviderId))
            {
                var sn = new Supply()
                { SupplyDate = supply.SupplyDate, ProviderId = supply.ProviderId};

                _context.Add(sn);
                _context.SaveChanges();
                foreach (var item in supply.Wares)
                {
                    item.SupplyId = sn.Id;
                    _supplyWareService.AddWare(item);
                }
                
                _context.SaveChanges();

                return true;

            }
            else
                return false;
        }

        public IEnumerable<Supply> GetSupplies(Provider provider)
        {
           return  _context.Supplies.Where(x => x.ProviderId == provider.Id);
        }

        public Supply GetSupply(int Id)
        {
            return _context.Supplies.Find(Id);
        }
    }
}
