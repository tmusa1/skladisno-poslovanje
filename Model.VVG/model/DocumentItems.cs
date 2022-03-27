using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.VVG.model
{
    [Table("document_items")]
    public class DocumentItems : BaseEntity
    {
        [JsonPropertyName("quantity")]
        [Column("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("description")]
        [Column("description")]
        public string? Description { get; set; }

        [JsonPropertyName("order_number")]
        [Column("order_number")]
        public int OrderNumber { get; set; }

        [JsonPropertyName("price")]
        [Column("price")]
        public decimal Price { get; set; }

    }
}
