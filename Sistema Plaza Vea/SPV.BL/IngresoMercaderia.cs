using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SPV.BL
{
    public class IngresoMercaderia
    {
        public DataTable OrdenCompraUsuario(string OrdenCompra, string Usuario)
        {
            try
            {
                SPV.BE.IngresoMercaderia Merca = new SPV.BE.IngresoMercaderia();
                DataTable dt = new DataTable();

                dt = Merca.OrdenCompraUsuario(OrdenCompra,Usuario );

                return dt;
            }
            catch
            {
                return null;
            }
        }

        public DataTable OrdenCompraProductos(string CodigoOrdenCompra)
        {
            try
            {
                SPV.BE.IngresoMercaderia Merca = new SPV.BE.IngresoMercaderia();
                DataTable dt = new DataTable();

                dt = Merca.OrdenCompraProductos(CodigoOrdenCompra);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        public DataTable OrdenCompraProductosPendientes(string CodigoOrdenCompra)
        {
            try
            {
                SPV.BE.IngresoMercaderia Merca = new SPV.BE.IngresoMercaderia();
                DataTable dt = new DataTable();

                dt = Merca.OrdenCompraProductos(CodigoOrdenCompra);

                return dt;
            }
            catch
            {
                return null;
            }
        }


    }
}
