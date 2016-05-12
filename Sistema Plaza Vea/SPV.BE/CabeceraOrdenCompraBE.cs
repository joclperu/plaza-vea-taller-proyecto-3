using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SPV.BE
{
    [Serializable]
    public class CabeceraOrdenCompraBE
    {
        #region "Atributos"
        private Int32 _id_cabecera_orden_compra;
        private Int32 _id_usuario_cambio;
        #endregion

        #region "Propiedades"
        public Int32 id_cabecera_orden_compra
        {
            get { return _id_cabecera_orden_compra; }
            set { _id_cabecera_orden_compra = value; }
        }

        public Int32 id_usuario_cambio
        {
            get { return _id_usuario_cambio; }
            set { _id_usuario_cambio = value; }
        }
        #endregion
    }

    #region "Lista"
    [Serializable]
    public class CabeceraOrdenCompraBEList : List<CabeceraOrdenCompraBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            CabeceraOrdenCompraCompraComparer dc = new CabeceraOrdenCompraCompraComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class CabeceraOrdenCompraCompraComparer : IComparer<CabeceraOrdenCompraBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public CabeceraOrdenCompraCompraComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(CabeceraOrdenCompraBE x, CabeceraOrdenCompraBE y)
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