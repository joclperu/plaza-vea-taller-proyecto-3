using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    public class EN_NotaIngreso : EN_General
    {
        public int NCodNotaIngreso { get; set; }
        public string NCodGuiaRemision { get; set; }
        public DateTime DFecha { get; set; }
        public int nCodTienda { get; set; }
    }
}
