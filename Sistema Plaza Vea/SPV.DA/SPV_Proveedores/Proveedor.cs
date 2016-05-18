using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace SPV.DA.SPV_Proveedores
{
   public class Proveedor
    {
        #region Connection
        public class Connection
        {
            public static string ObtenerCadena()
            {
                //return "Data Source=192.168.248.4;Initial Catalog=control_personal_2013;User ID=consulta_personal;Password=d8con2016;Persist Security Info=True";
                return "Data Source=SERGIOLAPA-PC; Initial Catalog=BD_SPV; user=sa; password=ABCDabcd1234";
                // <add name="SPVConecctionString" connectionString="Data Source=SERGIOLAPA-PC; Initial Catalog=BD_SPV; user=sa; password=ABCDabcd1234" providerName="System.Data.SqlClient"/>
            }
        }
        #endregion


        #region ListaCandidatos
       
            public  DataSet ListarCandidatoPropuesta( int ncodconvocatoria, string cdescripconvocatoria, string crazonsocialCandidato)
            {
            //@ncodconvocatoria int,
           // @cdescripconvocatoria varchar(50),
           // @crazonsocialCandidato varchar(50)



                object objCodconvocatoria = DBNull.Value;
                if (ncodconvocatoria > 0)
                    objCodconvocatoria =ncodconvocatoria ;
                object objDescripConvocatoria = DBNull.Value;
                if (cdescripconvocatoria.ToString().Length > 0)
                    objDescripConvocatoria = cdescripconvocatoria;
                object objRazSocialCandidato = DBNull.Value;
                if (crazonsocialCandidato.ToString().Length > 0)
                    objRazSocialCandidato = crazonsocialCandidato;
               
                //return objAccesoBD.ejecutarConsulta(
                //    "PA_AREA_LISTAR_PAGINADO_X_DESCRIPCION",
                //    pstrDescripcionArea,
                //    ((pintNumeroPagina - 1) * pintNumeroFilasPorPagina) + 1,
                //    pintNumeroPagina * pintNumeroFilasPorPagina);


               // intLimiteInferior = ((intLimiteInferior - 1) * 5) + 1;

                string strSql = "Proveedor.listarCandidatopropuesta";
                try
                {
                    using (SqlConnection sqlCnx = new SqlConnection(Connection.ObtenerCadena()))
                    {
                        sqlCnx.Open();
                        using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnx))
                        {
                            //sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.Add("@ncodconvocatoria", SqlDbType.Int).Value = objCodconvocatoria;
                            sqlCmd.Parameters.Add("@cdescripconvocatoria", SqlDbType.VarChar,50).Value = objDescripConvocatoria;
                            sqlCmd.Parameters.Add("@crazonsocialCandidato", SqlDbType.VarChar, 50).Value = objRazSocialCandidato;

                            sqlCmd.ExecuteNonQuery();

                            //strTipoMensaje = "0";
                            //strMensaje = "ok";

                            DataSet ds = new DataSet();
                            SqlDataAdapter da = new SqlDataAdapter();
                            DataTable dt = new DataTable();
                            da.SelectCommand = sqlCmd;
                            da.Fill(ds);
                           // dt = ds.Tables[0];
                            sqlCnx.Close();

                            return ds;
                        }
                    }
                }
                catch (Exception e)
                {
                    //Datos para el Mensaje
                    //strTipoMensaje = "1";
                    //strMensaje = "Error en la consulta." + e.Message.ToString();

                    return null;
                }

            }


            public DataSet ListarConvocatoria()
            {

                string strSql = "Proveedor.ListarConvocatoria";
                try
                {
                    using (SqlConnection sqlCnx = new SqlConnection(Connection.ObtenerCadena()))
                    {
                        sqlCnx.Open();
                        using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnx))
                        {
                            //sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                           

                            sqlCmd.ExecuteNonQuery();

                            //strTipoMensaje = "0";
                            //strMensaje = "ok";

                            DataSet ds = new DataSet();
                            SqlDataAdapter da = new SqlDataAdapter();
                            DataTable dt = new DataTable();
                            da.SelectCommand = sqlCmd;
                            da.Fill(ds);
                            // dt = ds.Tables[0];
                            sqlCnx.Close();

                            return ds;
                        }
                    }
                }
                catch (Exception e)
                {
                    //Datos para el Mensaje
                    //strTipoMensaje = "1";
                    //strMensaje = "Error en la consulta." + e.Message.ToString();

                    return null;
                }

            }



            public void RegistrarInforme(int NCODPROPUESTA ,string CESTADO, string COBSERVACION)
            {
               /* @NCODPROPUESTA INT,
                @CESTADO CHAR(1),
                @COBSERVACION VARCHAR(100)*/


                SqlConnection cn = new SqlConnection(Connection.ObtenerCadena());
                SqlCommand cmd = new SqlCommand("Proveedor.RegistrarInforme", cn);


                cmd.CommandType = CommandType.StoredProcedure;
                //creamos los parametros que usaremos
                cmd.Parameters.Add("@NCODPROPUESTA", SqlDbType.Int);
                cmd.Parameters.Add("@CESTADO", SqlDbType.Char,1);
                cmd.Parameters.Add("@COBSERVACION", SqlDbType.VarChar,100);

                cmd.Parameters["@NCODPROPUESTA"].Value = NCODPROPUESTA;
                cmd.Parameters["@CESTADO"].Value = CESTADO;
                cmd.Parameters["@COBSERVACION"].Value = COBSERVACION;
               

                
               //abrimos conexion
                cn.Open();
                cmd.ExecuteNonQuery();
               // int t = Convert.ToInt32(cmd.ExecuteScalar());
                //ejecutamos la instruccion con ExcecuteNonQuerry indicando que no retorna registros.
                //cmd.ExecuteNonQuery();
                //lbl.Text = "Indicador actualizado...";
                //cerramos conexion
                cn.Close();
                //return t;


            }

            public DataSet ListarConvocatoriaParametros(int ncodtipoconvocatoria, string cfechainicio, string cfechafin,int ncodcatproducto)
            {
               
                object objncodtipoconvocatoria = DBNull.Value;
                if (ncodtipoconvocatoria > 0)
                    objncodtipoconvocatoria = ncodtipoconvocatoria;
                object objcfechainicio = DBNull.Value;
                if (cfechainicio.ToString().Length > 0)
                    objcfechainicio = cfechainicio;
                object objcfechafin = DBNull.Value;
                if (cfechafin.ToString().Length > 0)
                    objcfechafin = cfechafin;
                object objncodcatproducto = DBNull.Value;
                if (ncodcatproducto > 0)
                    objncodcatproducto = ncodcatproducto;



                string strSql = "Proveedor.listarConvocatoriaParametros";
                try
                {
                    using (SqlConnection sqlCnx = new SqlConnection(Connection.ObtenerCadena()))
                    {
                        sqlCnx.Open();
                        using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnx))
                        {


                            //sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.Add("@ncodtipoconvocatoria", SqlDbType.Int).Value = objncodtipoconvocatoria;
                            sqlCmd.Parameters.Add("@cfechainicio", SqlDbType.VarChar, 10).Value = objcfechainicio;
                            sqlCmd.Parameters.Add("@cfechafin", SqlDbType.VarChar, 10).Value = objcfechafin;
                            sqlCmd.Parameters.Add("@ncodcatproducto", SqlDbType.Int).Value = objncodcatproducto;
                            sqlCmd.ExecuteNonQuery();

                            //strTipoMensaje = "0";
                            //strMensaje = "ok";

                            DataSet ds = new DataSet();
                            SqlDataAdapter da = new SqlDataAdapter();
                            DataTable dt = new DataTable();
                            da.SelectCommand = sqlCmd;
                            da.Fill(ds);
                            // dt = ds.Tables[0];
                            sqlCnx.Close();

                            return ds;
                        }
                    }
                }
                catch (Exception e)
                {
                    //Datos para el Mensaje
                    //strTipoMensaje = "1";
                    //strMensaje = "Error en la consulta." + e.Message.ToString();

                    return null;
                }

            }


            public DataSet ListarCategoriaProductos()
            {

                string strSql = "Proveedor.listarCategoriaProductos";
                try
                {
                    using (SqlConnection sqlCnx = new SqlConnection(Connection.ObtenerCadena()))
                    {
                        sqlCnx.Open();
                        using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnx))
                        {


                            //sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.ExecuteNonQuery();

                            //strTipoMensaje = "0";
                            //strMensaje = "ok";

                            DataSet ds = new DataSet();
                            SqlDataAdapter da = new SqlDataAdapter();
                            DataTable dt = new DataTable();
                            da.SelectCommand = sqlCmd;
                            da.Fill(ds);
                            // dt = ds.Tables[0];
                            sqlCnx.Close();

                            return ds;
                        }
                    }
                }
                catch (Exception e)
                {
                    //Datos para el Mensaje
                    //strTipoMensaje = "1";
                    //strMensaje = "Error en la consulta." + e.Message.ToString();

                    return null;
                }

            }
            public void RegistrarPropuesta(int NCODCONVOCATORIA,int NCODCANDIDATO, int NMONTOTOTAL)
            {
               
                SqlConnection cn = new SqlConnection(Connection.ObtenerCadena());
                SqlCommand cmd = new SqlCommand("[Proveedor].[RegistrarPropuesta]", cn);


                cmd.CommandType = CommandType.StoredProcedure;
                //creamos los parametros que usaremos
                cmd.Parameters.Add("@NCODCONVOCATORIA", SqlDbType.Int);
                cmd.Parameters.Add("@NCODCANDIDATO", SqlDbType.Int);
                cmd.Parameters.Add("@NMONTOTOTAL", SqlDbType.Int);

                cmd.Parameters["@NCODCONVOCATORIA"].Value = NCODCONVOCATORIA;
                cmd.Parameters["@NCODCANDIDATO"].Value = NCODCANDIDATO;
                cmd.Parameters["@NMONTOTOTAL"].Value = NMONTOTOTAL;


                //abrimos conexion
                cn.Open();
                cmd.ExecuteNonQuery();
                
                cn.Close();
              


            }

            public DataSet ValidarRegistroPropuesta(int ncodconvocatoria,int ncodcandidato)
            {

                string strSql = "Proveedor.ValidarRegistroPropuesta";
                try
                {
                    using (SqlConnection sqlCnx = new SqlConnection(Connection.ObtenerCadena()))
                    {
                        sqlCnx.Open();
                        using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnx))
                        {


                            //sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.Add("@ncodconvocatoria", SqlDbType.Int).Value = ncodconvocatoria;
                            sqlCmd.Parameters.Add("@ncodcandidato", SqlDbType.Int).Value = ncodcandidato;
                            sqlCmd.ExecuteNonQuery();

                            //strTipoMensaje = "0";
                            //strMensaje = "ok";

                            DataSet ds = new DataSet();
                            SqlDataAdapter da = new SqlDataAdapter();
                            DataTable dt = new DataTable();
                            da.SelectCommand = sqlCmd;
                            da.Fill(ds);
                            // dt = ds.Tables[0];
                            sqlCnx.Close();

                            return ds;
                        }
                    }
                }
                catch (Exception e)
                {
                    //Datos para el Mensaje
                    //strTipoMensaje = "1";
                    //strMensaje = "Error en la consulta." + e.Message.ToString();

                    return null;
                }

            }

        #endregion

    }
}
