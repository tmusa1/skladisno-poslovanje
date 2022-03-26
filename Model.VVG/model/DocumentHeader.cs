using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.VVG.model
{
    [Table("document_header")]
    internal class DocumentHeader : BaseEntity
    {
        [JsonPropertyName("date_from")]
        [Column("date_from")]
        public DateOnly DateFrom { get; set; }

        [JsonPropertyName("date_to")]
        [Column("date_to")]
        public DateOnly DateTo { get; set; }

    }
}
