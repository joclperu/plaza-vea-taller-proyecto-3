using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SPV.BE;

namespace SPV.DA.SPV_Compras
{
    public class DetalleOrdenCompraDA
    {
        #region Mantenimiento Detalle Orden Compra
        public DetalleOrdenCompraBEList GetAll(Int32 id_cabecera_orden_compra)
        {
            DetalleOrdenCompraBEList Lista = new DetalleOrdenCompraBEList();
            IDataReader DReader = null;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_sps_bandeja_detalle_orden_compra";
                    db.AddParameter("@id_cabecera_orden_compra", DbType.Int32, ParameterDirection.Input, id_cabecera_orden_compra);
                    DReader = db.GetDataReader();
                }
                while (DReader.Read())
                {
                    DetalleOrdenCompraBE ODetalleOrdenCompraBE = CrearEntidad(DReader);
                    Lista.Add(ODetalleOrdenCompraBE);
                }
                DReader.Close();
            }
            catch
            {
                if (DReader != null && !DReader.IsClosed) { DReader.Close(); }
                throw;
            }
            return Lista;
        }

        public DetalleOrdenCompraBE GetById(Int32 id_detalle_orden_compra)
        {
            DetalleOrdenCompraBE ODetalleOrdenCompraBE = new DetalleOrdenCompraBE();
            IDataReader DReader = null;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_sps_detalle_orden_compra_x_id";
                    db.AddParameter("@id_detalle_orden_compra", DbType.Int32, ParameterDirection.Input, id_detalle_orden_compra);
                    DReader = db.GetDataReader();
                }
                while (DReader.Read())
                {
                    ODetalleOrdenCompraBE = CrearEntidadById(DReader);
                }
                DReader.Close();
            }
            catch
            {
                if (DReader != null && !DReader.IsClosed) { DReader.Close(); }
                throw;
            }
            return ODetalleOrdenCompraBE;
        }

        public Int32 Eliminar(DetalleOrdenCompraBE ODetalleOrdenCompraBE)
        {
            Int32 res = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_spd_detalle_orden_compra";
                    db.AddParameter("@id_detalle_orden_compra", DbType.Int32, ParameterDirection.Input, ODetalleOrdenCompraBE.id_detalle_orden_compra);
                    db.AddParameter("@id_usuario_cambio", DbType.Int32, ParameterDirection.Input, ODetalleOrdenCompraBE.id_usuario_cambio);
                    res = Int32.Parse(db.ExecuteScalar().ToString());
                }
            }
            catch { throw; }
            return res;
        }

        public Int32 Modificar(DetalleOrdenCompraBE ODetalleOrdenCompraBE)
        {
            Int32 res = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_spu_detalle_orden_compra";
                    db.AddParameter("@id_detalle_orden_compra", DbType.Int32, ParameterDirection.Input, ODetalleOrdenCompraBE.id_detalle_orden_compra);
                    db.AddParameter("@va_cantidad", DbType.Decimal, ParameterDirection.Input, ODetalleOrdenCompraBE.va_cantidad);
                    db.AddParameter("@id_usuario_cambio", DbType.Int32, ParameterDirection.Input, ODetalleOrdenCompraBE.id_usuario_cambio);
                    res = Int32.Parse(db.ExecuteScalar().ToString());
                }
            }
            catch { throw; }
            return res;
        }
        #endregion

        #region Constructores
        private DetalleOrdenCompraBE CrearEntidad(IDataReader DReader)
        {
            DetalleOrdenCompraBE ODetalleOrdenCompraBE = new DetalleOrdenCompraBE();
            int Indice;

            Indice = DReader.GetOrdinal("id_detalle_orden_compra");
            if (!DReader.IsDBNull(Indice)) { ODetalleOrdenCompraBE.id_detalle_orden_compra = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("de_producto");
            ODetalleOrdenCompraBE.de_producto = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("va_cantidad");
            if (!DReader.IsDBNull(Indice)) { ODetalleOrdenCompraBE.va_cantidad = DReader.GetDecimal(Indice); }

            Indice = DReader.GetOrdinal("de_estado");
            ODetalleOrdenCompraBE.de_estado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            return ODetalleOrdenCompraBE;
        }

        private DetalleOrdenCompraBE CrearEntidadById(IDataReader DReader)
        {
            DetalleOrdenCompraBE ODetalleOrdenCompraBE = new DetalleOrdenCompraBE();
            int Indice;

            Indice = DReader.GetOrdinal("id_detalle_orden_compra");
            if (!DReader.IsDBNull(Indice)) { ODetalleOrdenCompraBE.id_detalle_orden_compra = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("id_cabecera_orden_compra");
            if (!DReader.IsDBNull(Indice)) { ODetalleOrdenCompraBE.id_cabecera_orden_compra = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("id_producto");
            if (!DReader.IsDBNull(Indice)) { ODetalleOrdenCompraBE.id_producto = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("va_cantidad");
            if (!DReader.IsDBNull(Indice)) { ODetalleOrdenCompraBE.va_cantidad = DReader.GetDecimal(Indice); }

            return ODetalleOrdenCompraBE;
        }
        #endregion
    }
}