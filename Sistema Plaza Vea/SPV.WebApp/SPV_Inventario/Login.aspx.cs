using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Ingresar_Click(object sender, EventArgs e)
    {

        if (txt_Usuario.Text.Trim() == "")
        {
            lblMensaje.Text = "Ingrese usuario";
            txt_Usuario.Focus();
            return;
        }

        if (txt_Password.Text.Trim() == "")
        {
            lblMensaje.Text = "Ingrese contraseña";
            txt_Password.Focus();
            return;
        }


        Logica.Usuario UsuarioL = new Logica.Usuario();
        DataTable dt = new DataTable();
        dt = UsuarioL.Login(txt_Usuario.Text , txt_Password.Text);

        if (dt.Rows.Count < 1)
        {
            lblMensaje.Text = "Usuario y/o Contraseña invalida";
            return;
        }

        Session["usuario"] = dt.Rows[0]["Nombre"].ToString();
        Session["CodUsu"] = dt.Rows[0]["CodUsuario"].ToString();
        Session["Rol"] = dt.Rows[0]["Rol"].ToString();

        Response.Redirect("Menu.aspx");
   
    }
}