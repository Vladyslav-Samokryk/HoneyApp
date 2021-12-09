using HoneyDataBace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyDataBace.Services.Interfaces
{
    public interface IHoneyService
    {
        public Honey GetHoney(int id);

        public void CreateNewWare(Honey honey);

        public void AddHoney(int id, int count);

        public int BuyHoney(int id, int count);

        public IEnumerable<Honey> GetAll();

        public void Update(Honey honey);
    }
}
