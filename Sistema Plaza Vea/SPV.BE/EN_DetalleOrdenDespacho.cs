using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    public class EN_DetalleOrdenDespacho
    {
        public int ncodItem { get; set; }
        public int ncodDespacho { get; set; }
        public int ncodProducto { get; set; }
        public int nCantPedido { get; set; }
        public int nCantReposicion { get; set; }
        public int nCantDiferencia { get; set; }
        public string nom_producto { get; set; }
        public string nom_unidad { get; set; }

    }
}
