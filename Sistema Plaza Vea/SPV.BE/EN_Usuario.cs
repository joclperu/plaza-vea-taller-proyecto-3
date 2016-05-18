using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    public class EN_Usuario : EN_General
    {
        public int nCodUsuario { get; set; }
        public int nCodTienda { get; set; }
        public int nCodRol { get; set; }
        public string cNombre { get; set; }
        public string cID { get; set; }
        public string cpassword { get; set; }
        public int nEstado { get; set; }
    }
}
