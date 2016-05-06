using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SPV.BE
{
    public class IngresoMercaderia
    {
        string strSql;
        string strCadenaConexion;

        public IngresoMercaderia()
        {
            SPV.BE.DA_GENERAL Cadena = new SPV.BE.DA_GENERAL();
            strCadenaConexion = Cadena.ObtenerCadena();
        }

        public DataTable OrdenCompraUsuario(string OrdenCompra, string Usuario)
        {

            strSql = "usp_sel_OrdenCompraUsuario";

            try
            {
                using (SqlConnection sqlCnx = new SqlConnection(strCadenaConexion))
                {
                    sqlCnx.Open();
                    using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnx))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.Add("@OrdenCompra", SqlDbType.VarChar).Value = OrdenCompra;
                        sqlCmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario;

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

        public DataTable OrdenCompraProductos(string CodigoOrdenCompra)
        {

            strSql = "usp_sel_OrdenCompraProductos";

            try
            {
                using (SqlConnection sqlCnx = new SqlConnection(strCadenaConexion))
                {
                    sqlCnx.Open();
                    using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnx))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.Add("@CodigoOC", SqlDbType.VarChar).Value = CodigoOrdenCompra;

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

        public DataTable OrdenCompraProductosPendientes(string CodigoOrdenCompra)
        {

            strSql = "usp_sel_OrdenCompraProductosPendientes";

            try
            {
                using (SqlConnection sqlCnx = new SqlConnection(strCadenaConexion))
                {
                    sqlCnx.Open();
                    using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnx))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.Add("@CodigoOC", SqlDbType.VarChar).Value = CodigoOrdenCompra;

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
