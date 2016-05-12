using System;
using System.Collections.Generic;
using System.Text;
using SPV.BE;
using SPV.DA.SPV_Compras;

namespace SPV.BL.SPV_Compras
{
    public class CabeceraRequerimientoCompraBL
    {
        public delegate void ErrorDelegate(object sender, Exception ex);
        public event ErrorDelegate ErrorEvent;

        #region Mantenimiento Cabecera Requerimiento Compra
        public CabeceraRequerimientoCompraBEList GetAll(Int32 id_solicitante, Int32 id_estado, String fe_inicio, String fe_fin, Int32 id_cabecera_requerimiento_compra)
        {
            CabeceraRequerimientoCompraDA OCabeceraRequerimientoCompraDA = new CabeceraRequerimientoCompraDA();
            try
            {
                return OCabeceraRequerimientoCompraDA.GetAll(id_solicitante, id_estado, fe_inicio, fe_fin, id_cabecera_requerimiento_compra);
            }
            catch (Exception ex)
            {
                ErrorEvent(this, ex);
            }
            return null;
        }

        public CabeceraRequerimientoCompraBE GetById(Int32 id_cabecera_requerimiento_compra)
        {
            CabeceraRequerimientoCompraDA OCabeceraRequerimientoCompraDA = new CabeceraRequerimientoCompraDA();
            try
            {
                return OCabeceraRequerimientoCompraDA.GetById(id_cabecera_requerimiento_compra);
            }
            catch (Exception ex)
            {
                ErrorEvent(this, ex);
            }
            return null;
        }

        public Int32 Insertar(CabeceraRequerimientoCompraBE OCabeceraRequerimientoCompraBE)
        {
            CabeceraRequerimientoCompraDA OCabeceraRequerimientoCompraDA = new CabeceraRequerimientoCompraDA();
            try
            {
                return OCabeceraRequerimientoCompraDA.Insertar(OCabeceraRequerimientoCompraBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 0;
        }

        public Int32 Eliminar(CabeceraRequerimientoCompraBE OCabeceraRequerimientoCompraBE)
        {
            CabeceraRequerimientoCompraDA OCabeceraRequerimientoCompraDA = new CabeceraRequerimientoCompraDA();
            try
            {
                return OCabeceraRequerimientoCompraDA.Eliminar(OCabeceraRequerimientoCompraBE);
            }
            catch (Exception ex)
            {
                ErrorEvent(this, ex);
            }
            return 0;
        }

        public Int32 CambiarEstado(Int32 id_cabecera_requerimiento_compra, Int32 id_usuario_cambio, Int32 id_tipo)
        {
            CabeceraRequerimientoCompraDA OCabeceraRequerimientoCompraDA = new CabeceraRequerimientoCompraDA();
            try
            {
                return OCabeceraRequerimientoCompraDA.CambiarEstado(id_cabecera_requerimiento_compra, id_usuario_cambio, id_tipo);
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