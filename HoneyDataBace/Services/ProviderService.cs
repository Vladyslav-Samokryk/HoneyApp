using HoneyDataBace.Models;
using HoneyDataBace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyDataBace.Services
{
    public class ProviderService : BaceService, IProviderService
    {
        public ProviderService(HoneyDbContext context): base(context)
        {

        }
        public void AddProvider(Provider provider)
        {
            _context.Providers.Add(provider);
            _context.SaveChanges();

        }

        public Provider Get(int id)
        {
            return _context.Providers.Find(id);
        }

        public IEnumerable<Provider> GetAll()
        {
            return _context.Providers;
        }
    }
}
