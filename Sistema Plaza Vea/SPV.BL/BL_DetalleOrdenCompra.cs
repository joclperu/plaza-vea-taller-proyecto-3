using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;

namespace SPV.BL
{
    public class BL_DetalleOrdenCompra
    {
        public DA_DetalleOrdenCompra oDA_DetalleOrdenCompra;
        public List<EN_DetalleOrdenCompra> Listar(EN_OrdenCompra oEN_OrdenCompra)
        {
            oDA_DetalleOrdenCompra = DA_DetalleOrdenCompra.getInstancia();
            return oDA_DetalleOrdenCompra.Listar(oEN_OrdenCompra);
        }
    }
}
