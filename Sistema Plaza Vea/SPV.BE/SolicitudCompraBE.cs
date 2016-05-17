using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SPV.BE
{
    [Serializable]
    public class SolicitudCompraBE
    {
        #region "Atributos"
        private Int32 _ncodsolicitud;
        private String _defecha;
        #endregion

        #region "Propiedades"
        public Int32 ncodsolicitud
        {
            get { return _ncodsolicitud; }
            set { _ncodsolicitud = value; }
        }

        public String defecha
        {
            get { return _defecha; }
            set { _defecha = value; }
        }
        #endregion
    }

    #region "Lista"
    [Serializable]
    public class SolicitudCompraBEList : List<SolicitudCompraBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            SolicitudCompraComparer dc = new SolicitudCompraComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class SolicitudCompraComparer : IComparer<SolicitudCompraBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public SolicitudCompraComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(SolicitudCompraBE x, SolicitudCompraBE y)
        {
            /*if (!(x.GetType().ToString() == y.GetType().ToString()))
            {
                throw new ArgumentException("Objects must be of the same type");
            }*/

            PropertyInfo propertyX = x.GetType().GetProperty(_prop);
            PropertyInfo propertyY = y.GetType().GetProperty(_prop);

            object px = propertyX.GetValue(x, null);
            object py = propertyY.GetValue(y, null);

            if (px == null && py == null)
            {
                return 0;
            }
            else if (px != null && py == null)
            {
                if (_dir == direccionOrden.Ascending)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else if (px == null && py != null)
            {
                if (_dir == direccionOrden.Ascending)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else if (px.GetType().GetInterface("IComparable") != null)
            {
                if (_dir == direccionOrden.Ascending)
                {
                    return ((IComparable)px).CompareTo(py);
                }
                else
                {
                    return ((IComparable)py).CompareTo(px);
                }
            }
            else
            {
                return 0;
            }
        }
    }
    #endregion
}