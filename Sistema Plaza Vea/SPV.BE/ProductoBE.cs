using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace SPV.BE
{
    [Serializable]
    public class ProductoBE
    {
        #region "Atributos"
        private Int32 _id_producto;
        private String _de_descripcion;
        private String _fe_creacion;
        private Int32 _id_usuario_creacion;
        private String _fe_cambio;
        private Int32 _id_usuario_cambio;
        private Decimal _va_stock_minimo;
        private Decimal _va_stock_maximo;
        private Decimal _va_stock_actual; 
        private Int32 _id_unidad_medida;
        private Int32 _id_estado;
        private String _de_observacion;
        #endregion

        #region "Propiedades"
        public Int32 id_producto
        {
            get { return _id_producto; }
            set { _id_producto = value; }
        }

        public String de_descripcion
        {
            get { return _de_descripcion; }
            set { _de_descripcion = value; }
        }

        public String fe_creacion
        {
            get { return _fe_creacion; }
            set { _fe_creacion = value; }
        }

        public Int32 id_usuario_creacion
        {
            get { return _id_usuario_creacion; }
            set { _id_usuario_creacion = value; }
        }

        public String fe_cambio
        {
            get { return _fe_cambio; }
            set { _fe_cambio = value; }
        }

        public Int32 id_usuario_cambio
        {
            get { return _id_usuario_cambio; }
            set { _id_usuario_cambio = value; }
        }

        public Decimal va_stock_minimo
        {
            get { return _va_stock_minimo; }
            set { _va_stock_minimo = value; }
        }

        public Decimal va_stock_maximo
        {
            get { return _va_stock_maximo; }
            set { _va_stock_maximo = value; }
        }

        public Decimal va_stock_actual
        {
            get { return _va_stock_actual; }
            set { _va_stock_actual = value; }
        }

        public Int32 id_unidad_medida
        {
            get { return _id_unidad_medida; }
            set { _id_unidad_medida = value; }
        }

        public Int32 id_estado
        {
            get { return _id_estado; }
            set { _id_estado = value; }
        }

        public String de_observacion
        {
            get { return _de_observacion; }
            set { _de_observacion = value; }
        }
        #endregion
    }

    [Serializable]
    public class ProductoBEList : List<ProductoBE>
    {
        public void Ordenar(string EmppertyName, direccionOrden Direction)
        {
            ProductoComparer dc = new ProductoComparer(EmppertyName, Direction);
            this.Sort(dc);
        }
    }

    class ProductoComparer : IComparer<ProductoBE>
    {
        string _Empp = "";
        direccionOrden _dir;

        public ProductoComparer(string EmppertyName, direccionOrden Direction)
        {
            _Empp = EmppertyName;
            _dir = Direction;
        }

        public int Compare(ProductoBE x, ProductoBE y)
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