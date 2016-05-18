using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    public class EN_NotaDocumento
    {
        public int nCodDocumento { get; set; }
        public string cTipoMov { get; set; }
        public DateTime dFecha { get; set; }
        public string cObservacion { get; set; }
        public int ncodDespacho { get; set; }
    }
}
