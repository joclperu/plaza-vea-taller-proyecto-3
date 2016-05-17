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

        #region Mantenimiento Cabecera Orden Compra
        public CabeceraOrdenCompraBEList GetAll(Int32 id_estado, String fe_inicio, String fe_fin, Int32 id_cabecera_orden_compra)
        {
            CabeceraOrdenCompraDA OCabeceraOrdenCompraDA = new CabeceraOrdenCompraDA();
            try
            {
                return OCabeceraOrdenCompraDA.GetAll(id_estado, fe_inicio, fe_fin, id_cabecera_orden_compra);
            }
            catch (Exception ex)
            {
                ErrorEvent(this, ex);
            }
            return null;
        }

        public CabeceraOrdenCompraBE GetById(Int32 id_cabecera_orden_compra)
        {
            CabeceraOrdenCompraDA OCabeceraOrdenCompraDA = new CabeceraOrdenCompraDA();
            try
            {
                return OCabeceraOrdenCompraDA.GetById(id_cabecera_orden_compra);
            }
            catch (Exception ex)
            {
                ErrorEvent(this, ex);
            }
            return null;
        }

        public Int32 Insertar(CabeceraOrdenCompraBE OCabeceraOrdenCompraBE)
        {
            CabeceraOrdenCompraDA OCabeceraOrdenCompraDA = new CabeceraOrdenCompraDA();
            try
            {
                return OCabeceraOrdenCompraDA.Insertar(OCabeceraOrdenCompraBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 0;
        }

        public Int32 Eliminar(CabeceraOrdenCompraBE OCabeceraOrdenCompraBE)
        {
            CabeceraOrdenCompraDA OCabeceraOrdenCompraDA = new CabeceraOrdenCompraDA();
            try
            {
                return OCabeceraOrdenCompraDA.Eliminar(OCabeceraOrdenCompraBE);
            }
            catch (Exception ex)
            {
                ErrorEvent(this, ex);
            }
            return 0;
        }

        public Int32 CambiarEstado(Int32 id_cabecera_orden_compra, Int32 id_usuario_cambio, Int32 id_tipo)
        {
            CabeceraOrdenCompraDA OCabeceraOrdenCompraDA = new CabeceraOrdenCompraDA();
            try
            {
                return OCabeceraOrdenCompraDA.CambiarEstado(id_cabecera_orden_compra, id_usuario_cambio, id_tipo);
            }
            catch (Exception ex)
            {
                ErrorEvent(this, ex);
            }
            return 0;
        }
        #endregion
    }
}