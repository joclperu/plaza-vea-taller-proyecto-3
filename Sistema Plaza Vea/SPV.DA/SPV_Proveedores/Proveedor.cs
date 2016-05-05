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



            public static int ContarSolicitud(int intCodGerencia, string strFecha, int intTipoAtencion, string strNombres)
            {
                object objCodGerencia = DBNull.Value;
                if (intCodGerencia > 0)
                    objCodGerencia = intCodGerencia;
                object objFecha = DBNull.Value;
                if (strFecha.Length > 0)
                    objFecha = strFecha;
                object objTipoAtencion = DBNull.Value;
                if (intTipoAtencion > 0)
                    objTipoAtencion = intTipoAtencion;
                object objNombres = DBNull.Value;
                if (strNombres.Length > 0)
                    objNombres = strNombres;


                int intCantSolicitud;
                string strSql = "SOLICITUD_OBTENER_CANTIDAD";
                try
                {
                    using (SqlConnection sqlCnx = new SqlConnection(Connection.ObtenerCadena()))
                    {
                        sqlCnx.Open();
                        using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnx))
                        {
                            //sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            //sqlCmd.Parameters.Add("@LimiteInferior", SqlDbType.Int).Value = intLimiteInferior;
                            sqlCmd.Parameters.Add("@CodGerencia", SqlDbType.Int).Value = objCodGerencia;
                            sqlCmd.Parameters.Add("@FechaProgramacion", SqlDbType.VarChar, 10).Value = objFecha;
                            sqlCmd.Parameters.Add("@tipoAtencion", SqlDbType.Int).Value = objTipoAtencion;
                            sqlCmd.Parameters.Add("@nombres", SqlDbType.VarChar, 100).Value = objNombres;

                            intCantSolicitud = Convert.ToInt32(sqlCmd.ExecuteScalar());

                            return intCantSolicitud;
                        }
                    }
                }
                catch (Exception e)
                {
                    //Datos para el Mensaje
                    //strTipoMensaje = "1";
                    //strMensaje = "Error en la consulta." + e.Message.ToString();

                    return 0;
                }

            }


        
        #endregion

    }
}
