using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace HoneyDataBace.Models
{   
    public class BillItem
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Bill))]
        public int BillId { get; set; }
       

        public string Name { get; set; }
        public int Count { get; set; }
        public int Prize { get; set; }
    }
}
