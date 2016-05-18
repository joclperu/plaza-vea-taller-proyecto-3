using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
namespace SPV.DA
{
    public class DA_GuiaRemision : DA_Base
    {
        //Patron Singleton
        private static DA_GuiaRemision Instancia = null;
        public static DA_GuiaRemision getInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new DA_GuiaRemision();
            }
            return Instancia;
        }

        public List<EN_GuiaRemision> ListarIngresoMercaderia(EN_OrdenCompra oEN_OrdenCompra)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    using (DbCommand cmd = db.GetStoredProcCommand("sp_listar_IngresoMercaderia_OC"))
                    {
                        db.AddInParameter(cmd, "@CodigoOc", DbType.Int32, Formateo_Numero(oEN_OrdenCompra.CodigoOC));
                        db.AddInParameter(cmd, "@NcodGuiaRemision", DbType.String, Formateo_Texto(oEN_OrdenCompra.ncodGuiaRemision));
                        conn.Open();

                        List<EN_GuiaRemision> listResult = new List<EN_GuiaRemision>();
                        using (IDataReader dr = db.ExecuteReader(cmd))
                        {

                            while (dr.Read())
                            {
                                EN_GuiaRemision obj = new EN_GuiaRemision();

                                if (!Convert.IsDBNull(dr["NcodGuiaRemision"]))
                                    obj.ncodGuiaRemision = Convert.ToString(dr["NcodGuiaRemision"]);

                                if (!Convert.IsDBNull(dr["NCodigoOC"]))
                                    obj.nCodOc = Convert.ToInt32(dr["NCodigoOC"]);

                                if (!Convert.IsDBNull(dr["Ncodproveedor"]))
                                    obj.nCodProveedor = Convert.ToInt32(dr["Ncodproveedor"]);

                                if (!Convert.IsDBNull(dr["dFecha_gr"]))
                                    obj.dFecha = Convert.ToDateTime(dr["dFecha_gr"]);

                                if (!Convert.IsDBNull(dr["CTransportista"]))
                                    obj.cTransportista = Convert.ToString(dr["CTransportista"]);

                                if (!Convert.IsDBNull(dr["CPlaca"]))
                                    obj.cPlaca = Convert.ToString(dr["CPlaca"]);

                                if (!Convert.IsDBNull(dr["CObservacion"]))
                                    obj.cObservacion_gr = Convert.ToString(dr["CObservacion"]);

                                if (!Convert.IsDBNull(dr["NCodNotaIngreso"]))
                                    obj.nCodNotaIngreso = Convert.ToInt32(dr["NCodNotaIngreso"]);

                                if (!Convert.IsDBNull(dr["dFecha_nota"]))
                                    obj.dFecha_nota = Convert.ToDateTime(dr["dFecha_nota"]);

                                if (!Convert.IsDBNull(dr["CNroOrdenCompra"]))
                                    obj.NroOrdenCompra = Convert.ToString(dr["CNroOrdenCompra"]);
                                



                                listResult.Add(obj);
                            }
                            dr.Close();
                            conn.Close();
                        }
                        return listResult;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int Registrar(EN_GuiaRemision objEn)
        {

            try
            {
                int Resultado = 0;
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DbTransaction trans = conn.BeginTransaction();
                    using (DbCommand dbCmd = db.GetStoredProcCommand("sp_ins_GuiaRemision"))
                    {
                        db.AddInParameter(dbCmd, "@codGuiaRemision", DbType.String, Formateo_Texto(objEn.ncodGuiaRemision));
                        db.AddInParameter(dbCmd, "@codigoOC", DbType.Int32, Formateo_Numero(objEn.nCodOc));
                        db.AddInParameter(dbCmd, "@codproveedor", DbType.Int32, Formateo_Numero(objEn.nCodProveedor));
                        db.AddInParameter(dbCmd, "@Transportista", DbType.String, Formateo_Texto(objEn.cTransportista));
                        db.AddInParameter(dbCmd, "@Placa", DbType.String, Formateo_Texto(objEn.cPlaca));
                        db.AddInParameter(dbCmd, "@Observacion", DbType.String, Formateo_Texto(objEn.cObservacion_gr));
                        db.AddOutParameter(dbCmd, "@NCodDocumento", DbType.Int32, 500);


                        db.ExecuteNonQuery(dbCmd, trans);
                        trans.Commit();

                        if (db.GetParameterValue(dbCmd, "@NCodDocumento") != null)
                            Resultado = Convert.ToInt32(db.GetParameterValue(dbCmd, "@NCodDocumento"));

                        conn.Close();
                        return Resultado;
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
