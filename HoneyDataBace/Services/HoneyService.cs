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
   
    public class HoneyService : BaceService, IHoneyService
    {
        public HoneyService(HoneyDbContext context) : base(context)
        {

        }

        public void Update(Honey honey)
        {
            _context.Update(honey);
            _context.SaveChanges();
        }

        public void AddHoney(int id, int count)
        {
            var honey = GetHoney(id);
            honey.Count += count;
            _context.Update(honey);
            _context.SaveChanges();
        }

        public int BuyHoney(int id, int count)
        {
            var honey = GetHoney(id);
            var honeyPrice = honey.Price;
            honey.Count -= count;
            _context.Update(honey);
            _context.SaveChanges();
            return honeyPrice * count;
        }

        public void CreateNewWare(Honey honey)
        {
            honey.Count = 0;
            _context.Honeys.Add(honey);
            _context.SaveChanges();
        }

        public IEnumerable<Honey> GetAll()
        {
            return _context.Honeys.Include(x => x.Provider);
        }

        public Honey GetHoney(int id)        
          =>   _context.Honeys.Find(id);
        
    }
}
