using HoneyDataBace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyDataBace.Services.Interfaces
{
    public interface IProviderService
    {
        Provider Get(int id);
        void AddProvider(Provider provider);
        IEnumerable<Provider> GetAll();
    }
}
