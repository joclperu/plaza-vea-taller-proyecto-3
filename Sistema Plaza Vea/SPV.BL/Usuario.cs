using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SPV.BL
{
    public class Usuario
    {
        public DataTable Login(string ID, string Password)
        {
            try
            {
                SPV.BE.Usuario Usu = new SPV.BE.Usuario();
                DataTable dt = new DataTable();

                dt = Usu.Login(ID, Password);

                return dt;
            }
            catch
            {
                return null;
            }
        }
    }
}
