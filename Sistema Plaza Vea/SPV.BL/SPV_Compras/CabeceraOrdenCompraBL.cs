using System;
using System.Collections.Generic;
using System.Text;
using SPV.BE;
using SPV.DA.SPV_Compras;

namespace SPV.BL.SPV_Compras
{
    public class CabeceraOrdenCompraBL
    {
        public delegate void ErrorDelegate(object sender, Exception ex);
        public event ErrorDelegate ErrorEvent;

        public Int32 CerrarOrdenCompra(Int32 id_cabecera_orden_compra, Int32 id_usuario_cambio)
        {
            CabeceraOrdenCompraDA OCabeceraOrdenCompraDA = new CabeceraOrdenCompraDA();
            try
            {
                return OCabeceraOrdenCompraDA.CerrarOrdenCompra(id_cabecera_orden_compra, id_usuario_cambio);
            }
            catch (Exception ex)
            {
                ErrorEvent(this, ex);
            }
            return 0;
        }
    }
}