using HoneyDataBace.Models;
using HoneyDataBace.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyDataBace.Services
{
    public class BillService : BaceService, IBillService
    {     
        public BillService(HoneyDbContext context): base(context)
        {

        }
        public IEnumerable<Bill> Get()
        {
            return _context.Bills.Include(x => x.Items);
        }

        public int NewOrder(Bill bill)
        {
           var id =  _context.Add(bill).Entity.Id;
            _context.SaveChanges();
            return id;
        }
    }
}
