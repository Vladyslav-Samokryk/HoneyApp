using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyDataBace.Models
{
    /// <summary>
    /// Поставка
    /// </summary>
    public class Supply
    {
        public int Id { get; set; }

        public DateTime SupplyDate { get; set; }

        [ForeignKey(nameof(Provider))]
        public int ProviderId { get; set; }

        public Provider Provider { get; set; }

        public List<SupplyWare> Wares { get; set; }
    }
}
