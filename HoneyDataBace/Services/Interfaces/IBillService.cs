using HoneyDataBace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyDataBace.Services.Interfaces
{
    public interface IBillService
    {
        public IEnumerable<Bill> Get();

        public int NewOrder(Bill bill);
    }
}
