using System.ComponentModel.DataAnnotations.Schema;

namespace HoneyDataBace.Models
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Ware : BaceWare
    {
        /// <summary>
        /// Кількість товару на складі
        /// </summary>
        public int Count { get; set; }

        public int Price { get; set; }

        [ForeignKey(nameof(Provider))]
        public int ProviderId { get; set; }

        public Provider Provider { get; set; }

        public byte[] Icon { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }
    }
}
