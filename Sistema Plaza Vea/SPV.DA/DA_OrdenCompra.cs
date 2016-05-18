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
    public class DA_OrdenCompra : DA_Base
    {

        //Patron Singleton
        private static DA_OrdenCompra Instancia = null;
        public static DA_OrdenCompra getInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new DA_OrdenCompra();
            }
            return Instancia;
        }

        /// <summary>
        /// Consulta la orden compra por id o nro
        /// </summary>
        /// <param name="oEN_OrdenCompra"></param>
        /// <returns></returns>
        public EN_OrdenCompra Consultar(EN_OrdenCompra oEN_OrdenCompra)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    using (DbCommand cmd = db.GetStoredProcCommand("sp_consultar_OrdenCompra"))
                    {

                        db.AddInParameter(cmd, "@NroOrdenCompra", DbType.String, Formateo_Texto(oEN_OrdenCompra.NroOrdenCompra));
                        db.AddInParameter(cmd, "@CodigoOc", DbType.Int32, Formateo_Numero(oEN_OrdenCompra.CodigoOC == 0 ? (object)null : oEN_OrdenCompra.CodigoOC));
                        db.AddInParameter(cmd, "@CodTienda", DbType.Int32, Formateo_Numero(oEN_OrdenCompra.codTienda));
                        conn.Open();

                        EN_OrdenCompra en_result = new EN_OrdenCompra();
                        using (IDataReader dr = db.ExecuteReader(cmd))
                        {

                            while (dr.Read())
                            {
                                if (!Convert.IsDBNull(dr["NCodigoOC"]))
                                {
                                    en_result.CodigoOC = Convert.ToInt32(dr["NCodigoOC"]);
                                    en_result.listDetOc = new DA_DetalleOrdenCompra().Listar(en_result);//Detalle Orden compra
                                    en_result.listNotasxGuia = new DA_GuiaRemision().ListarIngresoMercaderia(en_result);//Guias remision
                                }

                                if (!Convert.IsDBNull(dr["NcodSolicitud"]))
                                    en_result.codSolicitud = Convert.ToInt32(dr["NcodSolicitud"]);

                                if (!Convert.IsDBNull(dr["NcodTienda"]))
                                    en_result.codTienda = Convert.ToInt32(dr["NcodTienda"]);

                                if (!Convert.IsDBNull(dr["NcodProveedor"]))
                                    en_result.codProveedor = Convert.ToInt32(dr["NcodProveedor"]);

                                if (!Convert.IsDBNull(dr["NcodEstado"]))
                                    en_result.codEstado = Convert.ToInt32(dr["NcodEstado"]);

                                if (!Convert.IsDBNull(dr["NcodTipoOC"]))
                                    en_result.codTipoOC = Convert.ToInt32(dr["NcodTipoOC"]);

                                if (!Convert.IsDBNull(dr["CNroOrdenCompra"]))
                                    en_result.NroOrdenCompra = Convert.ToString(dr["CNroOrdenCompra"]);

                                if (!Convert.IsDBNull(dr["DFecha"]))
                                    en_result.FechaOC = Convert.ToDateTime(dr["DFecha"]);

                                if (!Convert.IsDBNull(dr["NMontoTotal"]))
                                    en_result.MontoTotal = Convert.ToDecimal(dr["NMontoTotal"]);

                                if (!Convert.IsDBNull(dr["CObservacion"]))
                                    en_result.MontoTotal = Convert.ToDecimal(dr["CObservacion"]);

                                if (!Convert.IsDBNull(dr["CDescripcion"]))
                                    en_result.nomTienda = Convert.ToString(dr["CDescripcion"]);

                                if (!Convert.IsDBNull(dr["CNombre"]))
                                    en_result.nomProveedor = Convert.ToString(dr["CNombre"]);

                                if (!Convert.IsDBNull(dr["CEmail"]))
                                    en_result.emailProveedor = Convert.ToString(dr["CEmail"]);

                                if (!Convert.IsDBNull(dr["CRUC"]))
                                    en_result.rucProveedor = Convert.ToString(dr["CRUC"]);

                                if (!Convert.IsDBNull(dr["des_estado_oc"]))
                                    en_result.desEstado = Convert.ToString(dr["des_estado_oc"]);




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
