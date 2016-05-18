using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    public class EN_OrdenCompra : EN_General
    {
        public int CodigoOC { get; set; }
        public int codSolicitud { get; set; }
        public int codTienda { get; set; }
        public int codProveedor { get; set; }
        public int codEstado { get; set; }
        public int codTipoOC { get; set; }
        public string NroOrdenCompra { get; set; }
        public DateTime FechaOC { get; set; }
        public Decimal MontoTotal { get; set; }
        public string Observacion { get; set; }
        public string desEstado { get; set; }
        public string ncodGuiaRemision { get; set; }

        //Datos Tienda
        public string nomTienda { get; set; }

        //Proveedor
        public string nomProveedor { get; set; }
        public string emailProveedor { get; set; }
        public string rucProveedor { get; set; }

        //Detalle Orden Compra
        public List<EN_DetalleOrdenCompra> listDetOc { get; set; }

        //Detalle Notas Ingreso de las guias remision de la oc
        public List<EN_GuiaRemision> listNotasxGuia { get; set; }


    }
}
