using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using SPV.BE;
using System.Configuration;

namespace SPV.DA
{
    public class DA_Usuario : DA_Base
    {

        //Patron Singleton
        private static DA_Usuario Instancia = null;
        public static DA_Usuario getInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new DA_Usuario();
            }
            return Instancia;
        }

        public EN_Usuario Login(string cod_usr, string pwd_usr)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    using (DbCommand cmd = db.GetStoredProcCommand("usp_sel_login"))
                    {

                        db.AddInParameter(cmd, "@ID", DbType.String, Formateo_Texto(cod_usr));
                        db.AddInParameter(cmd, "@Password", DbType.String, Formateo_Texto(pwd_usr));
                        conn.Open();

                        EN_Usuario oEN_Usuario = new EN_Usuario();
                        using (IDataReader dr = db.ExecuteReader(cmd))
                        {

                            while (dr.Read())
                            {
                                if (!Convert.IsDBNull(dr["NCodUsuario"]))
                                    oEN_Usuario.nCodUsuario = Convert.ToInt32(dr["NCodUsuario"]);

                                if (!Convert.IsDBNull(dr["NCodTienda"]))
                                    oEN_Usuario.nCodTienda = Convert.ToInt32(dr["NCodTienda"]);

                                if (!Convert.IsDBNull(dr["NCodRol"]))
                                    oEN_Usuario.nCodRol = Convert.ToInt32(dr["NCodRol"]);

                                if (!Convert.IsDBNull(dr["CNombre"]))
                                    oEN_Usuario.cNombre = Convert.ToString(dr["CNombre"]);

                                if (!Convert.IsDBNull(dr["CID"]))
                                    oEN_Usuario.cID = Convert.ToString(dr["CID"]);

                                if (!Convert.IsDBNull(dr["CPassword"]))
                                    oEN_Usuario.cpassword = Convert.ToString(dr["CPassword"]);

                                if (!Convert.IsDBNull(dr["NEstado"]))
                                    oEN_Usuario.nEstado = Convert.ToInt32(dr["NEstado"]);

                                if (!Convert.IsDBNull(dr["Rol"]))
                                    oEN_Usuario.nNomRol = Convert.ToString(dr["Rol"]);
                            }
                            dr.Close();
                            conn.Close();
                        }
                        return oEN_Usuario;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
