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
using SPV.BE;
using System.Configuration;

namespace SPV.DA
{
    public class DA_NotaIngreso : DA_Base
    {

        //Patron Singleton
        private static DA_NotaIngreso Instancia = null;
        public static DA_NotaIngreso getInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new DA_NotaIngreso();
            }
            return Instancia;
        }

        public int Registrar(EN_NotaIngreso objEn)
        {

            try
            {
                int Resultado = 0;
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DbTransaction trans = conn.BeginTransaction();
                    using (DbCommand dbCmd = db.GetStoredProcCommand("sp_ins_Notaingreso"))
                    {
                        db.AddInParameter(dbCmd, "@codGuiaRemision", DbType.String, Formateo_Texto(objEn.NCodGuiaRemision));
                        db.AddOutParameter(dbCmd, "@CodNotaIngreso", DbType.Int32, 500);
                        db.ExecuteNonQuery(dbCmd, trans);
                        trans.Commit();

                        if (db.GetParameterValue(dbCmd, "@CodNotaIngreso") != null)
                            Resultado = Convert.ToInt32(db.GetParameterValue(dbCmd, "@CodNotaIngreso"));

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

        public int Eliminar(EN_NotaIngreso objEn)
        {

            try
            {
                int Resultado = 0;
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DbTransaction trans = conn.BeginTransaction();
                    using (DbCommand dbCmd = db.GetStoredProcCommand("sp_borrar_NotaIngreso"))
                    {
                        db.AddInParameter(dbCmd, "@NCodNotaIngreso", DbType.Int32, Formateo_Numero(objEn.NCodNotaIngreso));
                        db.AddInParameter(dbCmd, "@NCodTienda", DbType.Int32, Formateo_Numero(objEn.nCodTienda));
                        db.ExecuteNonQuery(dbCmd, trans);
                        trans.Commit();
                        Resultado = 1;
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
