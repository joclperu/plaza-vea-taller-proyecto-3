using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SPV.BE;

namespace SPV.DA.SPV_Compras
{
    public class CabeceraOrdenCompraDA
    {
        public Int32 CerrarOrdenCompra(Int32 id_cabecera_orden_compra, Int32 id_usuario_cambio)
        {
            Int32 res = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_spu_cerrar_cabecera_orden_compra";
                    db.AddParameter("@id_cabecera_orden_compra", DbType.Int32, ParameterDirection.Input, id_cabecera_orden_compra);
                    db.AddParameter("@id_usuario_cambio", DbType.Int32, ParameterDirection.Input, id_usuario_cambio);
                    res = Int32.Parse(db.ExecuteScalar().ToString());
                }
            }
            catch { throw; }
            return res;
        }
    }
}