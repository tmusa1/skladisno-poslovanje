using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.VVG.model
{
    internal class DocumentHeader : BaseEntity
    {
        public DateTime Time_From { get; set; }
        public DateTime Time_To { get; set; }

    }
}
