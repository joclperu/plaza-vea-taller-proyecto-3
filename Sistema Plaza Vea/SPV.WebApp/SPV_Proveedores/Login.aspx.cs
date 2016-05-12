using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Ingresar_Click(object sender, EventArgs e)
    {
       if (txt_Usuario.Text.ToUpper() == "IMFSOFT" && txt_Password.Text == "123")
       {
            Session["usuario"] = "IMFSOFT";
            Session["ruc"] = "10103377833";
            Session["razonsocial"] = "IMFSOFT";
            Session["ncodcandidato"] = "1";

            Response.Redirect("SPV_ListarConvocatorias.aspx");
            
       }
       if (txt_Usuario.Text.ToUpper() == "SUCAMEC" && txt_Password.Text == "123")
       {
           Session["usuario"] = "SUCAMEC";
           Session["ruc"] = "20101578528";
           Session["razonsocial"] = "SUCAMEC";
           Session["ncodcandidato"] = "2";

           Response.Redirect("SPV_ListarConvocatorias.aspx");
       }
       if (txt_Usuario.Text.ToUpper() == "OURLIM" && txt_Password.Text == "123")
       {
           Session["usuario"] = "OURLIM";
           Session["ruc"] = "12458756987";
           Session["razonsocial"] = "OURLIM";
           Session["ncodcandidato"] = "3";

           Response.Redirect("SPV_ListarConvocatorias.aspx");

       }

       
       
    }
}