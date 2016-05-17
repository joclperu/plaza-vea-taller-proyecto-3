using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SPV.BE
{
    [Serializable]
    public class DetalleOrdenCompraBE
    {
        #region "Atributos"
        private Int32 _id_detalle_orden_compra;
        private Int32 _id_cabecera_orden_compra;
        private Int32 _id_producto;
        private String _de_producto;
        private Decimal _va_cantidad;
        private Int32 _id_estado;
        private String _de_estado;
        private String _fe_creacion;
        private Int32 _id_usuario_creacion;
        private String _de_usuario_creacion;
        private String _fe_cambio;
        private Int32 _id_usuario_cambio;
        private String _de_usuario_cambio;

        private String _de_proveedor;
        #endregion

        #region "Propiedades"
        public Int32 id_detalle_orden_compra
        {
            get { return _id_detalle_orden_compra; }
            set { _id_detalle_orden_compra = value; }
        }

        public Int32 id_cabecera_orden_compra
        {
            get { return _id_cabecera_orden_compra; }
            set { _id_cabecera_orden_compra = value; }
        }

        public Int32 id_producto
        {
            get { return _id_producto; }
            set { _id_producto = value; }
        }

        public String de_producto
        {
            get { return _de_producto; }
            set { _de_producto = value; }
        }

        public Decimal va_cantidad
        {
            get { return _va_cantidad; }
            set { _va_cantidad = value; }
        }

        public Int32 id_estado
        {
            get { return _id_estado; }
            set { _id_estado = value; }
        }

        public String de_estado
        {
            get { return _de_estado; }
            set { _de_estado = value; }
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

        public String de_usuario_creacion
        {
            get { return _de_usuario_creacion; }
            set { _de_usuario_creacion = value; }
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

        public String de_usuario_cambio
        {
            get { return _de_usuario_cambio; }
            set { _de_usuario_cambio = value; }
        }

        public String de_proveedor
        {
            get { return _de_proveedor; }
            set { _de_proveedor = value; }
        }
        #endregion
    }

    #region "Lista"
    [Serializable]
    public class DetalleOrdenCompraBEList : List<DetalleOrdenCompraBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            DetalleOrdenCompraComparer dc = new DetalleOrdenCompraComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class DetalleOrdenCompraComparer : IComparer<DetalleOrdenCompraBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public DetalleOrdenCompraComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(DetalleOrdenCompraBE x, DetalleOrdenCompraBE y)
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