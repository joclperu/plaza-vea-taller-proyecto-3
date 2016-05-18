using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;

namespace SPV.BL
{
    public class BL_Usuario
    {
        public DA_Usuario oDA_Usuario;
        public EN_Usuario Login(string cod_usr, string pwd_usr)
        {
            oDA_Usuario = DA_Usuario.getInstancia();
            return oDA_Usuario.Login(cod_usr, pwd_usr);
        }
    }
}
