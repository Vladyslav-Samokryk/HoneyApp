using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyDataBace.Models
{
    /// <summary>
    /// Товар що поставляється
    /// </summary>
    public class SupplyWare 
    {
        public int Id { get; set; }
        public int WareId { get; set; }
        public int Count { get; set; }

        [ForeignKey(nameof(Supply))]
        public int SupplyId { get; set; }

        public Supply Supply { get; set; }

    }
}
