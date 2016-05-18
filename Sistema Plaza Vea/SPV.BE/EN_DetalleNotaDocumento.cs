using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    public class EN_DetalleNotaDocumento : EN_General
    {
        public int nCodItem { get; set; }
        public int nCodDocumento { get; set; }
        public int NCodProducto { get; set; }
        public int NCantidad { get; set; }
        public int ncodTienda { get; set; }
        public string nom_unidad { get; set; }
        public string nom_producto { get; set; }
        public int NcodOC { get; set; }
    }
}
