using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace SPV.BE
{
    [Serializable]
    public class ProveedorBE
    {
        #region "Atributos"
        private Int32 _id_proveedor;
        private String _de_proveedor;
        #endregion

        #region "Propiedades"
        public Int32 id_proveedor
        {
            get { return _id_proveedor; }
            set { _id_proveedor = value; }
        }

        public String de_proveedor
        {
            get { return _de_proveedor; }
            set { _de_proveedor = value; }
        }
        #endregion
    }

    [Serializable]
    public class ProveedorBEList : List<ProveedorBE>
    {
        public void Ordenar(string EmppertyName, direccionOrden Direction)
        {
            ProveedorComparer dc = new ProveedorComparer(EmppertyName, Direction);
            this.Sort(dc);
        }
    }

    class ProveedorComparer : IComparer<ProveedorBE>
    {
        string _Empp = "";
        direccionOrden _dir;

        public ProveedorComparer(string EmppertyName, direccionOrden Direction)
        {
            _Empp = EmppertyName;
            _dir = Direction;
        }

        public int Compare(ProveedorBE x, ProveedorBE y)
        {
            /*if (!(x.GetType().ToString() == y.GetType().ToString()))
            {
                throw new ArgumentException("Objects must be of the same type");
            }*/

            PropertyInfo EmppertyX = x.GetType().GetProperty(_Empp);
            PropertyInfo EmppertyY = y.GetType().GetProperty(_Empp);

            object px = EmppertyX.GetValue(x, null);
            object py = EmppertyY.GetValue(y, null);

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
}