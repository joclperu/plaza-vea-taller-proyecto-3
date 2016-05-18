using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    public class EN_OrdenDespacho : EN_General
    {
        public int ncodDespacho { get; set; }
        public int ncodTienda { get; set; }
        public int ncodDocumento { get; set; }
        public int ncodSolicitud { get; set; }
        public int ncodEstado { get; set; }
        public int ncodUsuario { get; set; }
        public DateTime dfecha { get; set; }
        public string cObservacion { get; set; }
        public string nom_estado { get; set; }

        //Detalle Orden despacho
        public List<EN_DetalleOrdenDespacho> listDet { get; set; }

    }
}
