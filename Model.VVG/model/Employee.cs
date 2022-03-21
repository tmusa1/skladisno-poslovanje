using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.VVG.model
{
    internal class Employee : BaseEntity
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }

    }
}
