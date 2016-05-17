using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;

namespace SPV.BL
{
    public class BL_DetalleNotaDocumento
    {
        public DA_DetalleNotaDocumento ODA_DetalleNotaDocumento;
        public List<EN_DetalleNotaDocumento> Listar(int ncodDocumento)
        {
            ODA_DetalleNotaDocumento = DA_DetalleNotaDocumento.getInstancia();
            return ODA_DetalleNotaDocumento.Listar(ncodDocumento);
        }
    }
}
