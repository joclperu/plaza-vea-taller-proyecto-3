using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SPV.BE
{
    public class Usuario
    {
        string strSql;
        string strCadenaConexion;

        public Usuario()
        {
            SPV.BE.DA_GENERAL Cadena = new SPV.BE.DA_GENERAL();
            strCadenaConexion = Cadena.ObtenerCadena();
        }

        public DataTable Login(string ID, string Password)
        {

            strSql = "usp_sel_login";

            try
            {
                using (SqlConnection sqlCnx = new SqlConnection(strCadenaConexion))
                {
                    sqlCnx.Open();
                    using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnx))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
                        sqlCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;

                        sqlCmd.ExecuteNonQuery();

                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();
                        DataTable dt = new DataTable();
                        da.SelectCommand = sqlCmd;
                        da.Fill(ds);
                        dt = ds.Tables[0];
                        sqlCnx.Close();

                        return dt;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }



    }
}
