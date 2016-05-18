using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    public class EN_GuiaRemision : EN_General
    {
        public string ncodGuiaRemision { get; set; }
        public int nCodOc { get; set; }
        public int nCodProveedor { get; set; }
        public DateTime dFecha { get; set; }

        public string cTransportista { get; set; }
        public string cPlaca { get; set; }
        public string cObservacion_gr { get; set; }

        public int nCodNotaIngreso { get; set; }
        public DateTime dFecha_nota { get; set; }
        public string NroOrdenCompra { get; set; }

    }
}
