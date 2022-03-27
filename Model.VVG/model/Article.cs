using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.VVG.model
{
    [Table("article")]
    public class Article : BaseEntity
    {
        [JsonPropertyName("name")]
        [Column("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        [Column("description")]
        public string? Description { get; set; }

    }
}
