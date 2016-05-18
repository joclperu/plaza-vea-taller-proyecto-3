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
    public class DA_NotaDocumento : DA_Base
    {
        //Patron Singleton
        private static DA_NotaDocumento Instancia = null;
        public static DA_NotaDocumento getInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new DA_NotaDocumento();
            }
            return Instancia;
        }


        public List<EN_NotaDocumento> Listar(EN_NotaDocumento oEN_NotaDocumento)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    using (DbCommand cmd = db.GetStoredProcCommand("sp_listar_NotasDocumento"))
                    {
                        db.AddInParameter(cmd, "@ctipoMov", DbType.String, Formateo_Texto(oEN_NotaDocumento.cTipoMov));
                        db.AddInParameter(cmd, "@NCodDespacho", DbType.Int32, Formateo_Numero(oEN_NotaDocumento.ncodDespacho));
                        conn.Open();

                        List<EN_NotaDocumento> listResult = new List<EN_NotaDocumento>();
                        using (IDataReader dr = db.ExecuteReader(cmd))
                        {

                            while (dr.Read())
                            {
                                EN_NotaDocumento obj = new EN_NotaDocumento();

                                if (!Convert.IsDBNull(dr["NCodDocumento"]))
                                    obj.nCodDocumento = Convert.ToInt32(dr["NCodDocumento"]);

                                if (!Convert.IsDBNull(dr["CTipoMov"]))
                                    obj.cTipoMov = Convert.ToString(dr["CTipoMov"]);

                                if (!Convert.IsDBNull(dr["DFecha"]))
                                    obj.dFecha = Convert.ToDateTime(dr["DFecha"]);

                                if (!Convert.IsDBNull(dr["Observacion"]))
                                    obj.cObservacion = Convert.ToString(dr["Observacion"]);

                                if (!Convert.IsDBNull(dr["NCodDespacho"]))
                                    obj.ncodDespacho = Convert.ToInt32(dr["NCodDespacho"]);


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


        public int Registrar(EN_NotaDocumento objEn)
        {

            try
            {
                int Resultado = 0;
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DbTransaction trans = conn.BeginTransaction();
                    using (DbCommand dbCmd = db.GetStoredProcCommand("sp_Registrar_Documento"))
                    {
                        db.AddInParameter(dbCmd, "@CTipoMov", DbType.String, Formateo_Texto(objEn.cTipoMov));
                        db.AddInParameter(dbCmd, "@Observacion", DbType.String, Formateo_Texto(objEn.cObservacion));
                        db.AddInParameter(dbCmd, "@NcodDespacho", DbType.Int32, Formateo_Numero(objEn.ncodDespacho));
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


        public EN_NotaDocumento Consultar(EN_NotaDocumento oEN_NotaDocumento)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    using (DbCommand cmd = db.GetStoredProcCommand("sp_Consultar_NotaDocumento"))
                    {

                        db.AddInParameter(cmd, "@NCodDocumento", DbType.String, Formateo_Numero(oEN_NotaDocumento.nCodDocumento));
                        conn.Open();

                        EN_NotaDocumento en_result = new EN_NotaDocumento();
                        using (IDataReader dr = db.ExecuteReader(cmd))
                        {

                            while (dr.Read())
                            {
                                if (!Convert.IsDBNull(dr["NCodDocumento"]))
                                    en_result.nCodDocumento = Convert.ToInt32(dr["NCodDocumento"]);

                                if (!Convert.IsDBNull(dr["DFecha"]))
                                    en_result.dFecha = Convert.ToDateTime(dr["DFecha"]);

                                if (!Convert.IsDBNull(dr["Observacion"]))
                                    en_result.cObservacion = Convert.ToString(dr["Observacion"]);
                            }
                            dr.Close();
                            conn.Close();
                        }
                        return en_result;
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
