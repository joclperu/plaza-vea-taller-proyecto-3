using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    public class EN_DetalleNotaIngreso : EN_General
    {
        public int NCoddetNotaIngreso { get; set; }
        public int NCodNotaIngreso { get; set; }
        public string NCodGuiaRemision { get; set; }
        public int NCodProducto { get; set; }
        public int NCantidad { get; set; }
        public int NCodTienda { get; set; }
        public int NcodOC { get; set; }
        public string Product_name { get; set; }
        public string und_medida { get; set; }

        

    }
}
