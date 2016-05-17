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
        private Int32 _id_tipo;
        private String _de_tipo;
        private Decimal _va_monto_total;
        private Int32 _id_proveedor;
        private String _de_proveedor;
        private String _de_observaciones;
        private String _fe_creacion;
        private Int32 _id_usuario_creacion;
        private String _fe_cambio;
        private Int32 _id_usuario_cambio;
        private String _fe_en_proceso;
        private String _fe_espera_justificacion;
        private String _fe_espera_stock_proveedor;
        private String _fe_espera_solicitante;
        private String _fe_anulado;
        private String _fe_pendiente_aprobacion;
        private String _fe_rechazo;
        private String _fe_aprobado;
        private String _fe_procesado;
        private String _fe_cerrado;
        private Int32 _id_estado;
        private Int32 _id_referencia;
        #endregion

        #region "Propiedades"
        public Int32 id_cabecera_orden_compra
        {
            get { return _id_cabecera_orden_compra; }
            set { _id_cabecera_orden_compra = value; }
        }

        public Int32 id_tipo
        {
            get { return _id_tipo; }
            set { _id_tipo = value; }
        }

        public String de_tipo
        {
            get { return _de_tipo; }
            set { _de_tipo = value; }
        }

        public Decimal va_monto_total
        {
            get { return _va_monto_total; }
            set { _va_monto_total = value; }
        }

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

        public String de_observaciones
        {
            get { return _de_observaciones; }
            set { _de_observaciones = value; }
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

        public String fe_en_proceso
        {
            get { return _fe_en_proceso; }
            set { _fe_en_proceso = value; }
        }

        public String fe_espera_justificacion
        {
            get { return _fe_espera_justificacion; }
            set { _fe_espera_justificacion = value; }
        }

        public String fe_espera_stock_proveedor
        {
            get { return _fe_espera_stock_proveedor; }
            set { _fe_espera_stock_proveedor = value; }
        }

        public String fe_espera_solicitante
        {
            get { return _fe_espera_solicitante; }
            set { _fe_espera_solicitante = value; }
        }

        public String fe_anulado
        {
            get { return _fe_anulado; }
            set { _fe_anulado = value; }
        }

        public String fe_pendiente_aprobacion
        {
            get { return _fe_pendiente_aprobacion; }
            set { _fe_pendiente_aprobacion = value; }
        }

        public String fe_rechazo
        {
            get { return _fe_rechazo; }
            set { _fe_rechazo = value; }
        }

        public String fe_aprobado
        {
            get { return _fe_aprobado; }
            set { _fe_aprobado = value; }
        }

        public String fe_procesado
        {
            get { return _fe_procesado; }
            set { _fe_procesado = value; }
        }

        public String fe_cerrado
        {
            get { return _fe_cerrado; }
            set { _fe_cerrado = value; }
        }

        public Int32 id_estado
        {
            get { return _id_estado; }
            set { _id_estado = value; }
        }
        private String _de_estado;

        public String de_estado
        {
            get { return _de_estado; }
            set { _de_estado = value; }
        }

        public Int32 id_referencia
        {
            get { return _id_referencia; }
            set { _id_referencia = value; }
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