using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SPV.BE;

namespace SPV.DA.SPV_Compras
{
    public class DetalleRequerimientoCompraDA
    {
        #region Mantenimiento Detalle Requerimiento Compra
        public DetalleRequerimientoCompraBEList GetAll(Int32 id_cabecera_requerimiento_compra)
        {
            DetalleRequerimientoCompraBEList Lista = new DetalleRequerimientoCompraBEList();
            IDataReader DReader = null;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_sps_bandeja_detalle_requerimiento_compra";
                    db.AddParameter("@id_cabecera_requerimiento_compra", DbType.Int32, ParameterDirection.Input, id_cabecera_requerimiento_compra);
                    DReader = db.GetDataReader();
                }
                while (DReader.Read())
                {
                    DetalleRequerimientoCompraBE ODetalleRequerimientoCompraBE = CrearEntidad(DReader);
                    Lista.Add(ODetalleRequerimientoCompraBE);
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

        public DetalleRequerimientoCompraBE GetById(Int32 id_detalle_requerimiento_compra)
        {
            DetalleRequerimientoCompraBE ODetalleRequerimientoCompraBE = new DetalleRequerimientoCompraBE();
            IDataReader DReader = null;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_sps_detalle_requerimiento_compra_x_id";
                    db.AddParameter("@id_detalle_requerimiento_compra", DbType.Int32, ParameterDirection.Input, id_detalle_requerimiento_compra);
                    DReader = db.GetDataReader();
                }
                while (DReader.Read())
                {
                    ODetalleRequerimientoCompraBE = CrearEntidadById(DReader);
                }
                DReader.Close();
            }
            catch
            {
                if (DReader != null && !DReader.IsClosed) { DReader.Close(); }
                throw;
            }
            return ODetalleRequerimientoCompraBE;
        }

        public Int32 Insertar(DetalleRequerimientoCompraBE ODetalleRequerimientoCompraBE)
        {
            Int32 res = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_spi_detalle_requerimiento_compra";
                    db.AddParameter("@id_cabecera_requerimiento_compra", DbType.Int32, ParameterDirection.Input, ODetalleRequerimientoCompraBE.id_cabecera_requerimiento_compra);
                    db.AddParameter("@id_producto", DbType.Int32, ParameterDirection.Input, ODetalleRequerimientoCompraBE.id_producto);
                    db.AddParameter("@va_cantidad", DbType.Decimal, ParameterDirection.Input, ODetalleRequerimientoCompraBE.va_cantidad);
                    db.AddParameter("@id_usuario_creacion", DbType.Int32, ParameterDirection.Input, ODetalleRequerimientoCompraBE.id_usuario_creacion);
                    res = Int32.Parse(db.ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public Int32 Eliminar(DetalleRequerimientoCompraBE ODetalleRequerimientoCompraBE)
        {
            Int32 res = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_spd_detalle_requerimiento_compra";
                    db.AddParameter("@id_detalle_requerimiento_compra", DbType.Int32, ParameterDirection.Input, ODetalleRequerimientoCompraBE.id_detalle_requerimiento_compra);
                    db.AddParameter("@id_usuario_cambio", DbType.Int32, ParameterDirection.Input, ODetalleRequerimientoCompraBE.id_usuario_cambio);
                    res = Int32.Parse(db.ExecuteScalar().ToString());
                }
            }
            catch { throw; }
            return res;
        }

        public Int32 Modificar(DetalleRequerimientoCompraBE ODetalleRequerimientoCompraBE)
        {
            Int32 res = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_spu_detalle_requerimiento_compra";
                    db.AddParameter("@id_detalle_requerimiento_compra", DbType.Int32, ParameterDirection.Input, ODetalleRequerimientoCompraBE.id_detalle_requerimiento_compra);
                    db.AddParameter("@va_cantidad", DbType.Decimal, ParameterDirection.Input, ODetalleRequerimientoCompraBE.va_cantidad);
                    db.AddParameter("@id_usuario_cambio", DbType.Int32, ParameterDirection.Input, ODetalleRequerimientoCompraBE.id_usuario_cambio);
                    res = Int32.Parse(db.ExecuteScalar().ToString());
                }
            }
            catch { throw; }
            return res;
        }
        #endregion

        #region Constructores
        private DetalleRequerimientoCompraBE CrearEntidad(IDataReader DReader)
        {
            DetalleRequerimientoCompraBE ODetalleRequerimientoCompraBE = new DetalleRequerimientoCompraBE();
            int Indice;

            Indice = DReader.GetOrdinal("id_detalle_requerimiento_compra");
            if (!DReader.IsDBNull(Indice)) { ODetalleRequerimientoCompraBE.id_detalle_requerimiento_compra = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("de_producto");
            ODetalleRequerimientoCompraBE.de_producto = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("va_cantidad");
            if (!DReader.IsDBNull(Indice)) { ODetalleRequerimientoCompraBE.va_cantidad = DReader.GetDecimal(Indice); }

            Indice = DReader.GetOrdinal("de_estado");
            ODetalleRequerimientoCompraBE.de_estado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("de_proveedor");
            ODetalleRequerimientoCompraBE.de_proveedor = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);    

            return ODetalleRequerimientoCompraBE;
        }

        private DetalleRequerimientoCompraBE CrearEntidadById(IDataReader DReader)
        {
            DetalleRequerimientoCompraBE ODetalleRequerimientoCompraBE = new DetalleRequerimientoCompraBE();
            int Indice;

            Indice = DReader.GetOrdinal("id_detalle_requerimiento_compra");
            if (!DReader.IsDBNull(Indice)) { ODetalleRequerimientoCompraBE.id_detalle_requerimiento_compra = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("id_cabecera_requerimiento_compra");
            if (!DReader.IsDBNull(Indice)) { ODetalleRequerimientoCompraBE.id_cabecera_requerimiento_compra = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("id_producto");
            if (!DReader.IsDBNull(Indice)) { ODetalleRequerimientoCompraBE.id_producto = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("va_cantidad");
            if (!DReader.IsDBNull(Indice)) { ODetalleRequerimientoCompraBE.va_cantidad = DReader.GetDecimal(Indice); }

            return ODetalleRequerimientoCompraBE;
        }
        #endregion
    }
}