using System;
using System.Collections.Generic;
using System.Text;
using SPV.BE;
using SPV.DA.SPV_Compras;

namespace SPV.BL.SPV_Compras
{
    public class DetalleRequerimientoCompraBL
    {
        public delegate void ErrorDelegate(object sender, Exception ex);
        public event ErrorDelegate ErrorEvent;

        #region Mantenimiento Detalle Requerimiento Compra
        public DetalleRequerimientoCompraBEList GetAll(Int32 id_cabecera_requerimiento_compra)
        {
            DetalleRequerimientoCompraDA ODetalleRequerimientoCompraDA = new DetalleRequerimientoCompraDA();
            try
            {
                return ODetalleRequerimientoCompraDA.GetAll(id_cabecera_requerimiento_compra);
            }
            catch (Exception ex)
            {
                ErrorEvent(this, ex);
            }
            return null;
        }

        public DetalleRequerimientoCompraBE GetById(Int32 id_detalle_requerimiento_compra)
        {
            DetalleRequerimientoCompraDA ODetalleRequerimientoCompraDA = new DetalleRequerimientoCompraDA();
            try
            {
                return ODetalleRequerimientoCompraDA.GetById(id_detalle_requerimiento_compra);
            }
            catch (Exception ex)
            {
                ErrorEvent(this, ex);
            }
            return null;
        }

        public Int32 Insertar(DetalleRequerimientoCompraBE ODetalleRequerimientoCompraBE)
        {
            DetalleRequerimientoCompraDA ODetalleRequerimientoCompraDA = new DetalleRequerimientoCompraDA();
            try
            {
                return ODetalleRequerimientoCompraDA.Insertar(ODetalleRequerimientoCompraBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 0;
        }

        public Int32 Eliminar(DetalleRequerimientoCompraBE ODetalleRequerimientoCompraBE)
        {
            DetalleRequerimientoCompraDA ODetalleRequerimientoCompraDA = new DetalleRequerimientoCompraDA();
            try
            {
                return ODetalleRequerimientoCompraDA.Eliminar(ODetalleRequerimientoCompraBE);
            }
            catch (Exception ex)
            {
                ErrorEvent(this, ex);
            }
            return 0;
        }

        public Int32 Modificar(DetalleRequerimientoCompraBE ODetalleRequerimientoCompraBE)
        {
            DetalleRequerimientoCompraDA ODetalleRequerimientoCompraDA = new DetalleRequerimientoCompraDA();
            try
            {
                return ODetalleRequerimientoCompraDA.Modificar(ODetalleRequerimientoCompraBE);
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