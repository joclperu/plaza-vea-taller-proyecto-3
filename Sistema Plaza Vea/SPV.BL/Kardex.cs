using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BL
{
    public class Kardex
    {

        public void RegistraKardex(int CodNotaIngreso, int CodProducto, int CodTienda, int Cantidad, string Fecha)
        {
            SPV.BE.Kardex Kardexx = new SPV.BE.Kardex();
            Kardexx.RegistraKardex( CodNotaIngreso,  CodProducto,  CodTienda,  Cantidad,  Fecha);
        }

    }
}
