using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;


namespace SPV.BL
{
    public class BL_NotaDocumento
    {
        public DA_NotaDocumento oDA_NotaDocumento;
        public DA_DetalleNotaDocumento oDA_DetalleNotadocumento;
        public List<EN_NotaDocumento> Listar(EN_NotaDocumento oEN_NotaDocumento)
        {
            oDA_NotaDocumento = DA_NotaDocumento.getInstancia();
            return oDA_NotaDocumento.Listar(oEN_NotaDocumento);
        }

        public int Registrar(EN_NotaDocumento oEN_NotaDocumento, List<EN_DetalleNotaDocumento> ListaDetalle)
        {
            int ncodDocumento = 0;
            int ncodDespacho = 0;
            int result = 0;

            oDA_NotaDocumento = DA_NotaDocumento.getInstancia();
            ncodDocumento = oDA_NotaDocumento.Registrar(oEN_NotaDocumento);

            if (ncodDocumento > 0)
            {
                ncodDespacho = oEN_NotaDocumento.ncodDespacho;
                foreach (EN_DetalleNotaDocumento item in ListaDetalle)
                {
                    item.nCodDocumento = ncodDocumento;
                    
                    oDA_DetalleNotadocumento = DA_DetalleNotaDocumento.getInstancia();
                    result += oDA_DetalleNotadocumento.Registrar(item, ncodDespacho);
                }
            }

            return result;
        }

        public EN_NotaDocumento Consultar(EN_NotaDocumento oEN_NotaDocumento)
        {
            oDA_NotaDocumento = DA_NotaDocumento.getInstancia();
            return oDA_NotaDocumento.Consultar(oEN_NotaDocumento);
        }


    }
}
