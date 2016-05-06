using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SPV.BL
{
    public class Tienda
    {
        public void ActualizaStockTiendaProducto(string Fecha, int CodTienda, int CodProducto, int Cantidad)
        {
            SPV.BE.Tienda Tiend = new SPV.BE.Tienda();
            Tiend.ActualizaStockTiendaProducto(Fecha, CodTienda, CodProducto, Cantidad);
        }

    }
}
