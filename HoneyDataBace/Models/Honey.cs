using Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyDataBace.Models
{
    public class Honey : Ware
    {
        public HoneyKind Kind { get; set; }

        /// <summary>
        /// Кількість у літрах
        /// </summary>
        public float Amount { get; set; }

       
    }
}
