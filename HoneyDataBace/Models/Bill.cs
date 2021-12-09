using System;
using System.Collections.Generic;

namespace HoneyDataBace.Models
{
    public class Bill
    {       
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public  List<BillItem> Items { get; set; }
    }
}
