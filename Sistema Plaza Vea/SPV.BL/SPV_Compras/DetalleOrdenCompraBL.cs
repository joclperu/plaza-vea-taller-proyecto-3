using System;
using System.Collections.Generic;
using System.Text;
using SPV.BE;
using SPV.DA.SPV_Compras;

namespace SPV.BL.SPV_Compras
{
    public class DetalleOrdenCompraBL
    {
        public delegate void ErrorDelegate(object sender, Exception ex);
        public event ErrorDelegate ErrorEvent;

        #region Mantenimiento Detalle Orden Compra
        public DetalleOrdenCompraBEList GetAll(Int32 id_cabecera_orden_compra)
        {
            DetalleOrdenCompraDA ODetalleOrdenCompraDA = new DetalleOrdenCompraDA();
            try
            {
                return ODetalleOrdenCompraDA.GetAll(id_cabecera_orden_compra);
            }
            catch (Exception ex)
            {
                ErrorEvent(this, ex);
            }
            return null;
        }

        public DetalleOrdenCompraBE GetById(Int32 id_detalle_orden_compra)
        {
            DetalleOrdenCompraDA ODetalleOrdenCompraDA = new DetalleOrdenCompraDA();
            try
            {
                return ODetalleOrdenCompraDA.GetById(id_detalle_orden_compra);
            }
            catch (Exception ex)
            {
                ErrorEvent(this, ex);
            }
            return null;
        }

        public Int32 Eliminar(DetalleOrdenCompraBE ODetalleOrdenCompraBE)
        {
            DetalleOrdenCompraDA ODetalleOrdenCompraDA = new DetalleOrdenCompraDA();
            try
            {
                return ODetalleOrdenCompraDA.Eliminar(ODetalleOrdenCompraBE);
            }
            catch (Exception ex)
            {
                ErrorEvent(this, ex);
            }
            return 0;
        }

        public Int32 Modificar(DetalleOrdenCompraBE ODetalleOrdenCompraBE)
        {
            DetalleOrdenCompraDA ODetalleOrdenCompraDA = new DetalleOrdenCompraDA();
            try
            {
                return ODetalleOrdenCompraDA.Modificar(ODetalleOrdenCompraBE);
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