using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace SPV.BE
{
    [Serializable]
    public class MaestroBE
    {
        #region "Atributos"
        private Int32 _id_maestro;
        private Int32 _id_padre;
        private String _de_corta_maestro;
        private String _de_maestro;
        private String _va_valor1;
        private String _va_valor2;
        private String _va_valor3;
        private String _fl_inactivo;
        private String _estado;
        private Int32 _co_usuario_crea;
        private String _fe_crea;
        private Int32 _co_usuario_cambio;
        private String _fe_cambio;
        private String _no_usuario_red;
        private String _de_ip_equipo;
        private String _de_observacion;
        #endregion

        #region "Propiedades"
        public Int32 id_maestro
        {
            get { return _id_maestro; }
            set { _id_maestro = value; }
        }

        public Int32 id_padre
        {
            get { return _id_padre; }
            set { _id_padre = value; }
        }

        public String de_corta_maestro
        {
            get { return _de_corta_maestro; }
            set { _de_corta_maestro = value; }
        }

        public String de_maestro
        {
            get { return _de_maestro; }
            set { _de_maestro = value; }
        }

        public String va_valor1
        {
            get { return _va_valor1; }
            set { _va_valor1 = value; }
        }

        public String va_valor2
        {
            get { return _va_valor2; }
            set { _va_valor2 = value; }
        }

        public String va_valor3
        {
            get { return _va_valor3; }
            set { _va_valor3 = value; }
        }

        public String fl_inactivo
        {
            get { return _fl_inactivo; }
            set { _fl_inactivo = value; }
        }

        public String estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public Int32 co_usuario_crea
        {
            get { return _co_usuario_crea; }
            set { _co_usuario_crea = value; }
        }

        public String fe_crea
        {
            get { return _fe_crea; }
            set { _fe_crea = value; }
        }

        public Int32 co_usuario_cambio
        {
            get { return _co_usuario_cambio; }
            set { _co_usuario_cambio = value; }
        }

        public String fe_cambio
        {
            get { return _fe_cambio; }
            set { _fe_cambio = value; }
        }

        public String no_usuario_red
        {
            get { return _no_usuario_red; }
            set { _no_usuario_red = value; }
        }

        public String de_ip_equipo
        {
            get { return _de_ip_equipo; }
            set { _de_ip_equipo = value; }
        }

        public String de_observacion
        {
            get { return _de_observacion; }
            set { _de_observacion = value; }
        }
        #endregion
    }

    [Serializable]
    public class MaestroBEList : List<MaestroBE>
    {
        public void Ordenar(string EmppertyName, direccionOrden Direction)
        {
            MaestroComparer dc = new MaestroComparer(EmppertyName, Direction);
            this.Sort(dc);
        }
    }

    class MaestroComparer : IComparer<MaestroBE>
    {
        string _Empp = "";
        direccionOrden _dir;

        public MaestroComparer(string EmppertyName, direccionOrden Direction)
        {
            _Empp = EmppertyName;
            _dir = Direction;
        }

        public int Compare(MaestroBE x, MaestroBE y)
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