using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    public class EN_DetalleOrdenCompra : EN_General
    {
        public int nCodigoDetOC { get; set; }
        public int nCodigoOC { get; set; }        
        public int nCodProducto { get; set; }
        public int nCantPedido { get; set; }
        public int nCantReposicion { get; set; }
        public int nCantDiferencia { get; set; }
        public string cObservacion { get; set; }
        public string nNomProducto { get; set; }
        public string cUnidadMedida { get; set; }
    }
}
