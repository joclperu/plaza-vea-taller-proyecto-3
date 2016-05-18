using System;
using System.Collections.Generic;
using System.Text;
using SPV.BE;
using System.Data;

namespace SPV.DA.SPV_Seguridad
{
    public class UsuarioDA
    {
<<<<<<< HEAD
        public UsuarioBE ValidaLogeoUsuario(String usuario, String pass)
        {
            UsuarioBE oUsuario = null;
            int Indice;
            IDataReader reader = null;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "[general].[spv_sps_login]";
                    db.AddParameter("@va_no_login", DbType.String, ParameterDirection.Input, usuario);
                    db.AddParameter("@va_no_password", DbType.String, ParameterDirection.Input, pass);
                    reader = db.GetDataReader();
                }

                if (reader.Read())
                {
                    oUsuario = new UsuarioBE();

                    Indice = reader.GetOrdinal("id_usuario");
                    if (!reader.IsDBNull(Indice)) { oUsuario.id_usuario = reader.GetInt32(Indice); }

                    Indice = reader.GetOrdinal("no_login");
                    oUsuario.no_login = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

                    Indice = reader.GetOrdinal("no_password");
                    oUsuario.no_password = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

                    Indice = reader.GetOrdinal("no_usuario");
                    oUsuario.no_usuario = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

                    Indice = reader.GetOrdinal("no_apellido_paterno");
                    oUsuario.no_apellido_paterno = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

                    Indice = reader.GetOrdinal("no_apellido_materno");
                    oUsuario.no_apellido_materno = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

                    Indice = reader.GetOrdinal("fl_inactivo");
                    oUsuario.fl_inactivo = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

                    Indice = reader.GetOrdinal("id_rol");
                    if (!reader.IsDBNull(Indice)) { oUsuario.id_rol = reader.GetInt32(Indice); }

                    Indice = reader.GetOrdinal("rol");
                    oUsuario.rol = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

                    Indice = reader.GetOrdinal("id_area");
                    if (!reader.IsDBNull(Indice)) { oUsuario.id_area = reader.GetInt32(Indice); }

                   /* Indice = reader.GetOrdinal("no_area");
                    oUsuario.no_area = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);*/

                    Indice = reader.GetOrdinal("id_empresa");
                    if (!reader.IsDBNull(Indice)) { oUsuario.id_empresa = reader.GetInt32(Indice); }

                    /*Indice = reader.GetOrdinal("no_empresa");
                    oUsuario.no_empresa = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);*/

                    Indice = reader.GetOrdinal("fl_usuario");
                    oUsuario.fl_usuario = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);
                }
                reader.Close();
            }
            catch
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                throw;
            }
            return oUsuario;
        }

        public UsuarioBEList GetAllUserControlArea(Int32 id_area)
        {
            UsuarioBEList Lista = new UsuarioBEList();
            IDataReader DReader = null;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "general.spv_sps_usercontrol_usuario";
                    db.AddParameter("@id_area", DbType.Int32, ParameterDirection.Input, id_area);
                    DReader = db.GetDataReader();
                }
                while (DReader.Read())
                {
                    UsuarioBE OUsuarioBE = CrearEntidadUserControl(DReader);
                    Lista.Add(OUsuarioBE);
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

        #region Constructores
        private UsuarioBE CrearEntidadUserControl(IDataReader DReader)
        {
            UsuarioBE OUsuarioBE = new UsuarioBE();
            int Indice;

            Indice = DReader.GetOrdinal("id_usuario");
            if (!DReader.IsDBNull(Indice)) { OUsuarioBE.id_usuario = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("no_login");
            OUsuarioBE.no_login = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            return OUsuarioBE;
        }
        #endregion
=======
        //public UsuarioBE ValidaLogeoUsuario(String usuario, String pass)
        //{
        //    UsuarioBE oUsuario = null;
        //    int Indice;
        //    IDataReader reader = null;
        //    try
        //    {
        //        //using (Database db = new Database())
        //        //{
        //        //    db.ProcedureName = "[general].[spv_sps_login]";
        //        //    db.AddParameter("@va_no_login", DbType.String, ParameterDirection.Input, usuario);
        //        //    db.AddParameter("@va_no_password", DbType.String, ParameterDirection.Input, pass);
        //        //    reader = db.GetDataReader();
        //        //}

        //        if (reader.Read())
        //        {
        //            oUsuario = new UsuarioBE();

        //            Indice = reader.GetOrdinal("id_usuario");
        //            if (!reader.IsDBNull(Indice)) { oUsuario.id_usuario = reader.GetInt32(Indice); }

        //            Indice = reader.GetOrdinal("no_login");
        //            oUsuario.no_login = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

        //            Indice = reader.GetOrdinal("no_password");
        //            oUsuario.no_password = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

        //            Indice = reader.GetOrdinal("no_usuario");
        //            oUsuario.no_usuario = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

        //            Indice = reader.GetOrdinal("no_apellido_paterno");
        //            oUsuario.no_apellido_paterno = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

        //            Indice = reader.GetOrdinal("no_apellido_materno");
        //            oUsuario.no_apellido_materno = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

        //            Indice = reader.GetOrdinal("fl_inactivo");
        //            oUsuario.fl_inactivo = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

        //            Indice = reader.GetOrdinal("id_rol");
        //            if (!reader.IsDBNull(Indice)) { oUsuario.id_rol = reader.GetInt32(Indice); }

        //            Indice = reader.GetOrdinal("rol");
        //            oUsuario.rol = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

        //            Indice = reader.GetOrdinal("id_area");
        //            if (!reader.IsDBNull(Indice)) { oUsuario.id_area = reader.GetInt32(Indice); }

        //           /* Indice = reader.GetOrdinal("no_area");
        //            oUsuario.no_area = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);*/

        //            Indice = reader.GetOrdinal("id_empresa");
        //            if (!reader.IsDBNull(Indice)) { oUsuario.id_empresa = reader.GetInt32(Indice); }

        //            /*Indice = reader.GetOrdinal("no_empresa");
        //            oUsuario.no_empresa = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);*/

        //            Indice = reader.GetOrdinal("fl_usuario");
        //            oUsuario.fl_usuario = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);
        //        }
        //        reader.Close();
        //    }
        //    catch
        //    {
        //        if (reader != null && !reader.IsClosed) reader.Close();
        //        throw;
        //    }
        //    return oUsuario;
        //}        
>>>>>>> upstream/master
    }
}