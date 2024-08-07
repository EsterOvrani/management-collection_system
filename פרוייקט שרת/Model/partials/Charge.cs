using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Charge : BaseEntity
    {
        public TypeCharge TypeCharge { get; set; }
        public Family Family { get; set; }
        public Child Child { get; set; }
    }


}
