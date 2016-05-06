using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SPV.BL
{
    public class OrdenCompra
    {
        public void ActualizaDetalleOrdenCompra(int CodigoOC, int CodProducto, int Cantidad)
        {
            SPV.BE.OrdenCompra OC = new SPV.BE.OrdenCompra();
            OC.ActualizaDetalleOrdenCompra(CodigoOC, CodProducto, Cantidad);
        }

        public void ActualizaEstadoOrdenCompra(int CodigoOC)
        {
            SPV.BE.OrdenCompra OC = new SPV.BE.OrdenCompra();
            OC.ActualizaEstadoOrdenCompra(CodigoOC);
        }

    }
}
