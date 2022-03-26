using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.VVG.model
{
    internal class DocumentItems : BaseEntity
    {
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public int OrderNumber { get; set; }
        public decimal Price { get; set; }

    }
}
