using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;

namespace SPV.BL
{
    public class BL_Producto
    {

        public List<EN_Producto> Listar(EN_Producto oEN_Producto)
        {
            return new DA_Producto().Listar(oEN_Producto);
        }

        public List<EN_Producto> ListarDetalleProducto(EN_Producto oEN_Producto)
        {
            return new DA_Producto().ListarDetalleProducto(oEN_Producto);
        }

        public EN_Producto Consultar(EN_Producto oEN_Producto)
        {
            return new DA_Producto().Consultar(oEN_Producto);
        }

    }
}
