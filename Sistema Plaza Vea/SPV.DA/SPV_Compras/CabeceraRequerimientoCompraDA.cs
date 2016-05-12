using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SPV.BE;

namespace SPV.DA.SPV_Compras
{
    public class CabeceraRequerimientoCompraDA
    {
        #region Mantenimiento Cabecera Requerimiento Compra
        public CabeceraRequerimientoCompraBEList GetAll(Int32 id_solicitante, Int32 id_estado, String fe_inicio, String fe_fin, Int32 id_cabecera_requerimiento_compra)
        {
            CabeceraRequerimientoCompraBEList Lista = new CabeceraRequerimientoCompraBEList();
            IDataReader DReader = null;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_sps_bandeja_cabecera_requerimiento_compra";
                    db.AddParameter("@id_solicitante", DbType.Int32, ParameterDirection.Input, id_solicitante);
                    db.AddParameter("@id_estado", DbType.Int32, ParameterDirection.Input, id_estado);
                    db.AddParameter("@fe_inicio", DbType.String, ParameterDirection.Input, fe_inicio);
                    db.AddParameter("@fe_fin", DbType.String, ParameterDirection.Input, fe_fin);
                    db.AddParameter("@id_cabecera_requerimiento_compra", DbType.Int32, ParameterDirection.Input, id_cabecera_requerimiento_compra);
                    DReader = db.GetDataReader();
                }
                while (DReader.Read())
                {
                    CabeceraRequerimientoCompraBE OCabeceraRequerimientoCompraBE = CrearEntidad(DReader);
                    Lista.Add(OCabeceraRequerimientoCompraBE);
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

        public CabeceraRequerimientoCompraBE GetById(Int32 id_cabecera_requerimiento_compra)
        {
            CabeceraRequerimientoCompraBE OCabeceraRequerimientoCompraBE = new CabeceraRequerimientoCompraBE();
            IDataReader DReader = null;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_sps_cabecera_requerimiento_compra_x_id";
                    db.AddParameter("@id_cabecera_requerimiento_compra", DbType.Int32, ParameterDirection.Input, id_cabecera_requerimiento_compra);
                    DReader = db.GetDataReader();
                }
                while (DReader.Read())
                {
                    OCabeceraRequerimientoCompraBE = CrearEntidadById(DReader);
                }
                DReader.Close();
            }
            catch
            {
                if (DReader != null && !DReader.IsClosed) { DReader.Close(); }
                throw;
            }
            return OCabeceraRequerimientoCompraBE;
        }

        public Int32 Insertar(CabeceraRequerimientoCompraBE OCabeceraRequerimientoCompraBE)
        {
            Int32 res = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_spi_cabecera_requerimiento_compra";
                    db.AddParameter("@id_solicitante", DbType.Int32, ParameterDirection.Input, OCabeceraRequerimientoCompraBE.id_solicitante);
                    db.AddParameter("@id_usuario_creacion", DbType.Int32, ParameterDirection.Input, OCabeceraRequerimientoCompraBE.id_usuario_creacion);
                    db.AddParameter("@de_observacion", DbType.String, ParameterDirection.Input, OCabeceraRequerimientoCompraBE.de_observacion);
                    res = Int32.Parse(db.ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public Int32 Eliminar(CabeceraRequerimientoCompraBE OCabeceraRequerimientoCompraBE)
        {
            Int32 res = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_spd_cabecera_requerimiento_compra";
                    db.AddParameter("@id_cabecera_requerimiento_compra", DbType.Int32, ParameterDirection.Input, OCabeceraRequerimientoCompraBE.id_cabecera_requerimiento_compra);
                    db.AddParameter("@id_usuario_cambio", DbType.Int32, ParameterDirection.Input, OCabeceraRequerimientoCompraBE.id_usuario_cambio);
                    res = Int32.Parse(db.ExecuteScalar().ToString());
                }
            }
            catch { throw; }
            return res;
        }

        public Int32 CambiarEstado(Int32 id_cabecera_requerimiento_compra, Int32 id_usuario_cambio, Int32 id_tipo)
        {
            Int32 res = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_spu_estado_cabecera_requerimiento_compra";
                    db.AddParameter("@id_cabecera_requerimiento_compra", DbType.Int32, ParameterDirection.Input, id_cabecera_requerimiento_compra);
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
        private CabeceraRequerimientoCompraBE CrearEntidad(IDataReader DReader)
        {
            CabeceraRequerimientoCompraBE OCabeceraRequerimientoCompraBE = new CabeceraRequerimientoCompraBE();
            int Indice;

            Indice = DReader.GetOrdinal("id_cabecera_requerimiento_compra");
            if (!DReader.IsDBNull(Indice)) { OCabeceraRequerimientoCompraBE.id_cabecera_requerimiento_compra = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("de_solicitante");
            OCabeceraRequerimientoCompraBE.de_solicitante = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("de_estado");
            OCabeceraRequerimientoCompraBE.de_estado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_creacion");
            OCabeceraRequerimientoCompraBE.fe_creacion = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_cambio");
            OCabeceraRequerimientoCompraBE.fe_cambio = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_en_proceso");
            OCabeceraRequerimientoCompraBE.fe_en_proceso = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_espera_justificacion");
            OCabeceraRequerimientoCompraBE.fe_espera_justificacion = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_anulado");
            OCabeceraRequerimientoCompraBE.fe_anulado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_espera_cotizacion");
            OCabeceraRequerimientoCompraBE.fe_espera_cotizacion = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_cotizado");
            OCabeceraRequerimientoCompraBE.fe_cotizado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_espera_solicitante");
            OCabeceraRequerimientoCompraBE.fe_espera_solicitante = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_pendiente_aprobacion");
            OCabeceraRequerimientoCompraBE.fe_pendiente_aprobacion = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_rechazado");
            OCabeceraRequerimientoCompraBE.fe_rechazado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_aprobado");
            OCabeceraRequerimientoCompraBE.fe_aprobado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            return OCabeceraRequerimientoCompraBE;
        }

        private CabeceraRequerimientoCompraBE CrearEntidadById(IDataReader DReader)
        {
            CabeceraRequerimientoCompraBE OCabeceraRequerimientoCompraBE = new CabeceraRequerimientoCompraBE();
            int Indice;

            Indice = DReader.GetOrdinal("id_cabecera_requerimiento_compra");
            if (!DReader.IsDBNull(Indice)) { OCabeceraRequerimientoCompraBE.id_cabecera_requerimiento_compra = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("de_solicitante");
            OCabeceraRequerimientoCompraBE.de_solicitante = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("de_estado");
            OCabeceraRequerimientoCompraBE.de_estado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_creacion");
            OCabeceraRequerimientoCompraBE.fe_creacion = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_en_proceso");
            OCabeceraRequerimientoCompraBE.fe_en_proceso = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_espera_justificacion");
            OCabeceraRequerimientoCompraBE.fe_espera_justificacion = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_anulado");
            OCabeceraRequerimientoCompraBE.fe_anulado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_espera_cotizacion");
            OCabeceraRequerimientoCompraBE.fe_espera_cotizacion = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_cotizado");
            OCabeceraRequerimientoCompraBE.fe_cotizado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_espera_solicitante");
            OCabeceraRequerimientoCompraBE.fe_espera_solicitante = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_pendiente_aprobacion");
            OCabeceraRequerimientoCompraBE.fe_pendiente_aprobacion = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_rechazado");
            OCabeceraRequerimientoCompraBE.fe_rechazado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("fe_aprobado");
            OCabeceraRequerimientoCompraBE.fe_aprobado = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("de_observacion");
            OCabeceraRequerimientoCompraBE.de_observacion = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            Indice = DReader.GetOrdinal("id_area");
            if (!DReader.IsDBNull(Indice)) { OCabeceraRequerimientoCompraBE.id_area = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("id_estado");
            if (!DReader.IsDBNull(Indice)) { OCabeceraRequerimientoCompraBE.id_estado = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("id_solicitante");
            if (!DReader.IsDBNull(Indice)) { OCabeceraRequerimientoCompraBE.id_solicitante = DReader.GetInt32(Indice); }

            return OCabeceraRequerimientoCompraBE;
        }
        #endregion
    }
}