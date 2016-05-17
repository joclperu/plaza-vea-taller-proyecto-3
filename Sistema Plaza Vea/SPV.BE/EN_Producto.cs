using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    public class EN_Producto : EN_General
    {
        public int NcodTienda { get; set; }
        public int NCodProducto { get; set; }
        public string CDescripcion { get; set; }
        public string CMarca { get; set; }
        public DateTime DFecha { get; set; }
        public int NStock{ get; set; }
        public int NStockMinimo { get; set; }
        public int NStockMaximo { get; set; }
        public string CUnidadMedida { get; set; }
        public string nom_tienda { get; set; }
        public string NcodGuiaRemision { get; set; }
        public int recibida { get; set; }
        public int solicitada { get; set; }
        public string nom_proveedor { get; set; }

    }
}
