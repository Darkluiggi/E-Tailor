using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tailor.Entity
{
    public class ModelBase
    {
        public ModelBase()
        {
            estado = true;
        }

        public bool estado { get; set; }
    }
}
