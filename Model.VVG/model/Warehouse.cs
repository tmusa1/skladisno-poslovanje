using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Model.VVG.model
{
    [Table("warehouse")]
    public class Warehouse : BaseEntity
    {
        [JsonPropertyName("name")]
        [Column("name")]
        public string? Name { get; set; }
    }
}
