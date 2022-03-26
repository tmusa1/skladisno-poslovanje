using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.VVG.model
{
    [Table("company")]
    internal class Company : BaseEntity
    {
        [JsonPropertyName("company_name")]
        [Column("name")]
        public string? CompanyName { get; set; }

        [JsonPropertyName("address")]
        [Column("address")]
        public string? Address { get; set; }

        [JsonPropertyName("contact")]
        [Column("contact")]
        public string? Contact { get; set; }
    }
}
