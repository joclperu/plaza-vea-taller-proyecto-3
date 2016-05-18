using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using SPV.DA;

namespace SPV.BL
{
    public class BL_Tienda
    {
        public List<EN_Tienda> Listar() 
        {
            return new DA_Tienda().Listar();
        }
    }
}
