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
    public class DA_OrdenDespacho : DA_Base
    {
        //Patron Singleton
        private static DA_OrdenDespacho Instancia = null;
        public static DA_OrdenDespacho getInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new DA_OrdenDespacho();
            }
            return Instancia;
        }


        public EN_OrdenDespacho Consultar(EN_OrdenDespacho oEN_OrdenDespacho)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    using (DbCommand cmd = db.GetStoredProcCommand("sp_consultar_OrdenDespacho"))
                    {
                        db.AddInParameter(cmd, "@NCodDespacho", DbType.Int32, Formateo_Numero(oEN_OrdenDespacho.ncodDespacho));
                        db.AddInParameter(cmd, "@NcodTienda", DbType.Int32, Formateo_Numero(oEN_OrdenDespacho.ncodTienda));
                        conn.Open();

                        EN_OrdenDespacho en_result = new EN_OrdenDespacho();
                        using (IDataReader dr = db.ExecuteReader(cmd))
                        {

                            while (dr.Read())
                            {
                                if (!Convert.IsDBNull(dr["NCodDespacho"]))
                                {
                                    en_result.ncodDespacho = Convert.ToInt32(dr["NCodDespacho"]);
                                    en_result.listDet = new DA_DetalleOrdenDespacho().Listar(en_result);
                                }

                                if (!Convert.IsDBNull(dr["NcodTienda"]))
                                    en_result.ncodTienda = Convert.ToInt32(dr["NcodTienda"]);

                                //if (!Convert.IsDBNull(dr["NCodDocumento"]))
                                //    en_result.ncodDocumento = Convert.ToInt32(dr["NCodDocumento"]);

                                if (!Convert.IsDBNull(dr["NCodSolicitud"]))
                                    en_result.ncodSolicitud = Convert.ToInt32(dr["NCodSolicitud"]);

                                if (!Convert.IsDBNull(dr["NCodEstado"]))
                                    en_result.ncodEstado = Convert.ToInt32(dr["NCodEstado"]);

                                if (!Convert.IsDBNull(dr["NCodUsuario"]))
                                    en_result.ncodUsuario = Convert.ToInt32(dr["NCodUsuario"]);

                                if (!Convert.IsDBNull(dr["DFecha"]))
                                    en_result.dfecha = Convert.ToDateTime(dr["DFecha"]);

                                if (!Convert.IsDBNull(dr["CObservacion"]))
                                    en_result.cObservacion = Convert.ToString(dr["CObservacion"]);


                                if (!Convert.IsDBNull(dr["des_estado"]))
                                    en_result.nom_estado = Convert.ToString(dr["des_estado"]);


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
