using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SPV.BE;

namespace SPV.DA.SPV_Compras
{
    public class CabeceraOrdenCompraDA
    {
        public Int32 CerrarOrdenCompra(Int32 id_cabecera_orden_compra, Int32 id_usuario_cambio)
        {
            Int32 res = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_spu_cerrar_cabecera_orden_compra";
                    db.AddParameter("@id_cabecera_orden_compra", DbType.Int32, ParameterDirection.Input, id_cabecera_orden_compra);
                    db.AddParameter("@id_usuario_cambio", DbType.Int32, ParameterDirection.Input, id_usuario_cambio);
                    res = Int32.Parse(db.ExecuteScalar().ToString());
                }
            }
            catch { throw; }
            return res;
        }

        #region Mantenimiento Cabecera Orden Compra
        public CabeceraOrdenCompraBEList GetAll(Int32 id_estado, String fe_inicio, String fe_fin, Int32 id_cabecera_orden_compra)
        {
            CabeceraOrdenCompraBEList Lista = new CabeceraOrdenCompraBEList();
            IDataReader DReader = null;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_sps_bandeja_cabecera_orden_compra";
                    db.AddParameter("@id_estado", DbType.Int32, ParameterDirection.Input, id_estado);
                    db.AddParameter("@fe_inicio", DbType.String, ParameterDirection.Input, fe_inicio);
                    db.AddParameter("@fe_fin", DbType.String, ParameterDirection.Input, fe_fin);
                    db.AddParameter("@id_cabecera_orden_compra", DbType.Int32, ParameterDirection.Input, id_cabecera_orden_compra);
                    DReader = db.GetDataReader();
                }
                while (DReader.Read())
                {
                    CabeceraOrdenCompraBE OCabeceraOrdenCompraBE = CrearEntidad(DReader);
                    Lista.Add(OCabeceraOrdenCompraBE);
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

        public CabeceraOrdenCompraBE GetById(Int32 id_cabecera_orden_compra)
        {
            CabeceraOrdenCompraBE OCabeceraOrdenCompraBE = new CabeceraOrdenCompraBE();
            IDataReader DReader = null;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_sps_cabecera_orden_compra_x_id";
                    db.AddParameter("@id_cabecera_orden_compra", DbType.Int32, ParameterDirection.Input, id_cabecera_orden_compra);
                    DReader = db.GetDataReader();
                }
                while (DReader.Read())
                {
                    OCabeceraOrdenCompraBE = CrearEntidadById(DReader);
                }
                DReader.Close();
            }
            catch
            {
                if (DReader != null && !DReader.IsClosed) { DReader.Close(); }
                throw;
            }
            return OCabeceraOrdenCompraBE;
        }

        public Int32 Insertar(CabeceraOrdenCompraBE OCabeceraOrdenCompraBE)
        {
            Int32 res = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_spi_cabecera_orden_compra";
                    db.AddParameter("@id_tipo", DbType.Int32, ParameterDirection.Input, OCabeceraOrdenCompraBE.id_tipo);
                    db.AddParameter("@id_referencia", DbType.Int32, ParameterDirection.Input, OCabeceraOrdenCompraBE.id_referencia);
                    db.AddParameter("@id_usuario_cambio", DbType.Int32, ParameterDirection.Input, OCabeceraOrdenCompraBE.id_usuario_cambio);
                    res = Int32.Parse(db.ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public Int32 Eliminar(CabeceraOrdenCompraBE OCabeceraOrdenCompraBE)
        {
            Int32 res = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_spd_cabecera_orden_compra";
                    db.AddParameter("@id_cabecera_orden_compra", DbType.Int32, ParameterDirection.Input, OCabeceraOrdenCompraBE.id_cabecera_orden_compra);
                    db.AddParameter("@id_usuario_cambio", DbType.Int32, ParameterDirection.Input, OCabeceraOrdenCompraBE.id_usuario_cambio);
                    res = Int32.Parse(db.ExecuteScalar().ToString());
                }
            }
            catch { throw; }
            return res;
        }

        public Int32 CambiarEstado(Int32 id_cabecera_orden_compra, Int32 id_usuario_cambio, Int32 id_tipo)
        {
            Int32 res = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_spu_estado_cabecera_orden_compra";
                    db.AddParameter("@id_cabecera_orden_compra", DbType.Int32, ParameterDirection.Input, id_cabecera_orden_compra);
                    db.AddParameter("@id_usuario_cambio", DbType.Int32, ParameterDirection.Input, id_usuario_cambio);
                    db.AddParameter("@id_tipo", DbType.Int32, ParameterDirection.Input, id_tipo);
                    res = Int32.Parse(db.ExecuteScalar().ToString());
                }
            }
            catch { throw; }
            return res;
        }
        #endregion

        #region Constructores
        private CabeceraOrdenCompraBE CrearEntidad(IDataReader DReader)
        {
            CabeceraOrdenCompraBE OCabeceraOrdenCompraBE = new CabeceraOrdenCompraBE();
            int Indice;

            Indice = DReader.GetOrdinal("id_cabecera_orden_compra");
            if (!DReader.IsDBNull(Indice)) { OCabeceraOrdenCompraBE.id_cabecera_orden_compra = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("de_estado");
            OCabeceraOrdenCompraBE.de_estado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_creacion");
            OCabeceraOrdenCompraBE.fe_creacion = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_cambio");
            OCabeceraOrdenCompraBE.fe_cambio = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_en_proceso");
            OCabeceraOrdenCompraBE.fe_en_proceso = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_espera_justificacion");
            OCabeceraOrdenCompraBE.fe_espera_justificacion = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_anulado");
            OCabeceraOrdenCompraBE.fe_anulado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_espera_solicitante");
            OCabeceraOrdenCompraBE.fe_espera_solicitante = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_pendiente_aprobacion");
            OCabeceraOrdenCompraBE.fe_pendiente_aprobacion = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_rechazo");
            OCabeceraOrdenCompraBE.fe_rechazo = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_aprobado");
            OCabeceraOrdenCompraBE.fe_aprobado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("de_tipo");
            OCabeceraOrdenCompraBE.de_tipo = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("id_referencia");
            if (!DReader.IsDBNull(Indice)) { OCabeceraOrdenCompraBE.id_referencia = DReader.GetInt32(Indice); }

            return OCabeceraOrdenCompraBE;
        }

        private CabeceraOrdenCompraBE CrearEntidadById(IDataReader DReader)
        {
            CabeceraOrdenCompraBE OCabeceraOrdenCompraBE = new CabeceraOrdenCompraBE();
            int Indice;

            Indice = DReader.GetOrdinal("id_cabecera_orden_compra");
            if (!DReader.IsDBNull(Indice)) { OCabeceraOrdenCompraBE.id_cabecera_orden_compra = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("de_estado");
            OCabeceraOrdenCompraBE.de_estado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_creacion");
            OCabeceraOrdenCompraBE.fe_creacion = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_en_proceso");
            OCabeceraOrdenCompraBE.fe_en_proceso = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_espera_justificacion");
            OCabeceraOrdenCompraBE.fe_espera_justificacion = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_anulado");
            OCabeceraOrdenCompraBE.fe_anulado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_espera_solicitante");
            OCabeceraOrdenCompraBE.fe_espera_solicitante = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_pendiente_aprobacion");
            OCabeceraOrdenCompraBE.fe_pendiente_aprobacion = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_rechazo");
            OCabeceraOrdenCompraBE.fe_rechazo = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_aprobado");
            OCabeceraOrdenCompraBE.fe_aprobado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("de_observaciones");
            OCabeceraOrdenCompraBE.de_observaciones = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("id_estado");
            if (!DReader.IsDBNull(Indice)) { OCabeceraOrdenCompraBE.id_estado = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("id_tipo");
            if (!DReader.IsDBNull(Indice)) { OCabeceraOrdenCompraBE.id_tipo = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("id_proveedor");
            if (!DReader.IsDBNull(Indice)) { OCabeceraOrdenCompraBE.id_proveedor = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("id_referencia");
            if (!DReader.IsDBNull(Indice)) { OCabeceraOrdenCompraBE.id_referencia = DReader.GetInt32(Indice); }

            return OCabeceraOrdenCompraBE;
        }
        #endregion
    }
}