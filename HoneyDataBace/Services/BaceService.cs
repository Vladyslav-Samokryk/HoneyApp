using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyDataBace.Services
{
    public class BaceService
    {
        protected readonly HoneyDbContext _context;

        public BaceService(HoneyDbContext context)
        {
            _context = context;
        }
    }
}
