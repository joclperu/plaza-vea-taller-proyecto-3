using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;

namespace SPV.BL
{
    public class BL_GuiaRemision
    {
        public DA_GuiaRemision oDA_GuiaRemision;
        public DA_DetalleNotaDocumento oDA_DetalleNotadocumento;
        public List<EN_GuiaRemision> ListarIngresoMercaderia(EN_OrdenCompra oEN_OrdenCompra)
        {
            oDA_GuiaRemision = DA_GuiaRemision.getInstancia();
            return oDA_GuiaRemision.ListarIngresoMercaderia(oEN_OrdenCompra);
        }

        public int Registrar(EN_GuiaRemision objEn, List<EN_DetalleNotaDocumento> ListaDetalle,int codOc)
        {
            int codDocumento = 0;
            int result = 0;

            oDA_GuiaRemision = DA_GuiaRemision.getInstancia();
            codDocumento = oDA_GuiaRemision.Registrar(objEn);

            if (codDocumento > 0)
            {
                //ncodDespacho = oEN_NotaDocumento.ncodDespacho;
                foreach (EN_DetalleNotaDocumento item in ListaDetalle)
                {
                    item.nCodDocumento = codDocumento;
                    oDA_DetalleNotadocumento = DA_DetalleNotaDocumento.getInstancia();
                    result += oDA_DetalleNotadocumento.RegistrarIngreso(item, codOc);
                }
            }


            return result;
        }
    }
}
