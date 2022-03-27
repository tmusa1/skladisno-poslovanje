using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Model.VVG.model
{
    [Table("inventory")]
    public class Inventory : BaseEntity
    {
        [JsonPropertyName("quantity_avail")]
        [Column("quantity_avail")]
        public int QuantityAvail { get; set; }
    }
}
