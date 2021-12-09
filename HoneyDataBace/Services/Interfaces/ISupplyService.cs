using HoneyDataBace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyDataBace.Services.Interfaces
{
    public interface ISupplyService
    {
        public bool AddSupply(Supply supply);

        public Supply GetSupply(int Id);

        public IEnumerable<Supply> GetSupplies(Provider provider);
    }
}
