using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace SPV.BE
{
    [Serializable]
    public class AreaBE
    {
        #region "Atributos"
        private Int32 _id_area;
        private String _de_area;
        #endregion

        #region "Propiedades"
        public Int32 id_area
        {
            get { return _id_area; }
            set { _id_area = value; }
        }

        public String de_area
        {
            get { return _de_area; }
            set { _de_area = value; }
        }
        #endregion
    }

    [Serializable]
    public class AreaBEList : List<AreaBE>
    {
        public void Ordenar(string EmppertyName, direccionOrden Direction)
        {
            AreaComparer dc = new AreaComparer(EmppertyName, Direction);
            this.Sort(dc);
        }
    }

    class AreaComparer : IComparer<AreaBE>
    {
        string _Empp = "";
        direccionOrden _dir;

        public AreaComparer(string EmppertyName, direccionOrden Direction)
        {
            _Empp = EmppertyName;
            _dir = Direction;
        }

        public int Compare(AreaBE x, AreaBE y)
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