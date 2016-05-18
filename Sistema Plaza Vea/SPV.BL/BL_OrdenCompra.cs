using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;


namespace SPV.BL
{
    public class BL_OrdenCompra
    {
        public DA_OrdenCompra oDA_OrdenCompra;
        public EN_OrdenCompra Consultar(EN_OrdenCompra oEN_OrdenCompra)
        {
            oDA_OrdenCompra = DA_OrdenCompra.getInstancia();
            return oDA_OrdenCompra.Consultar(oEN_OrdenCompra);            
        }
    }
}
