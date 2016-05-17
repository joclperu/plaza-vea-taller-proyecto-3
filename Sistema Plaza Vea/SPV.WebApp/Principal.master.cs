using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;
using SPV.WebEvents;
using SPV.BE;

public partial class Principal : System.Web.UI.MasterPage
{
    #region "Atributos y Propiedades"
    private bool _onError;
    public bool onError
    {
        get { return this._onError; }
        set { this._onError = value; }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.lblNombreUsuario.Text = Profile.UserName;
            CargarMenu();
        }
    }

    #region Métodos y Botones
    protected void BtnCerrarSesion_OnClick(object sender, EventArgs e)
    {
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect(FormsAuthentication.LoginUrl, false);
        Response.End();
    }
    
    private void CargarMenu()
    {
        //Padres
        MenuItem mnuItem = new MenuItem();
        mnuItem.Text = "COMPRAS";
        mnuItem.ToolTip = "EXPANDIR COMPRAS";
        mnuItem.Selectable = false;

        //Hijos
        MenuItem mnuItem2 = new MenuItem();
        mnuItem2.Text = "REGISTRO DE MERCADERÍA";
        mnuItem2.NavigateUrl = "~/Pages/RegistroIngresoMercaderia.aspx";
        mnuItem.ChildItems.Add(mnuItem2);



        Menu1.Items.Add(mnuItem);

        //Padres
        mnuItem = new MenuItem();
        mnuItem.Text = "INVENTARIO";
        mnuItem.ToolTip = "EXPANDIR INVENTARIO";
        mnuItem.Selectable = false;

        //Hijos
        mnuItem2 = new MenuItem();
        mnuItem2.Text = "SALIDA DE MERCADERÍA";
        mnuItem2.NavigateUrl = "~/Pages/SalidaMercaderia.aspx";
        mnuItem.ChildItems.Add(mnuItem2);


        //Hijos
        mnuItem2 = new MenuItem();
        mnuItem2.Text = "PRODUCTOS";
        mnuItem2.NavigateUrl = "~/Pages/ConsultaProductos.aspx";
        mnuItem.ChildItems.Add(mnuItem2);


        Menu1.Items.Add(mnuItem);


        #region Genera Menú
        //Menu1.Items[0].Enabled = false;
        //Menu1.Items[0].ChildItems[0].Enabled = false;
        //Menu1.Items[1].Enabled = false;
        //Menu1.Items[2].Enabled = false;
        //Menu1.Items[3].Enabled = false;

        #region "Menú compras"
        //Menu1.Items[0].Text = "COMPRAS";
        //Menu1.Items[0].ToolTip = "COMPRAS";
        //Menu1.Items[0].Value = "COMPRAS";
        //Menu1.Items[0].ChildItems[0].NavigateUrl = "~/Pages/RegistroIngresoMercaderia.aspx";
        //Menu1.Items[0].ChildItems[0].Text = "REQUERIMIENTO DE COMPRAS";
        //Menu1.Items[0].ChildItems[0].ToolTip = "REQUERIMIENTO DE COMPRAS";
        //Menu1.Items[0].ChildItems[0].Value = "REQUERIMIENTO DE COMPRAS";
        #endregion

        //Menu1.Items[1].Text = "PROVEEDORES";
        //Menu1.Items[1].ToolTip = "PROVEEDORES";
        //Menu1.Items[1].Value = "PROVEEDORES";

        //Menu1.Items[2].Text = "INVENTARIOS";
        //Menu1.Items[2].ToolTip = "INVENTARIOS";
        //Menu1.Items[2].Value = "INVENTARIOS";

     
        //Menu1.Items[3].Text = " RR.HH";
        //Menu1.Items[3].ToolTip = "RR.HH";
        //Menu1.Items[3].Value = "RR.HH";

        #endregion
        
        #region Inicia Perfil
        //Int32 id_rol = 0;
        //Int32.TryParse(Profile.id_rol.ToString(),out id_rol);
        //if (id_rol == 1)//Perfil COMPRAS
        //{
        //    Menu1.Items[0].Enabled = true;
        //    Menu1.Items[0].ChildItems[0].Enabled = true;
        //}
        //else if (id_rol == 2) //Perfil PROVEEDORES
        //{
        //    Menu1.Items[1].Enabled = true;
        //}
        //else if (id_rol == 3)//Perfil INVENTARIOS
        //{
        //    Menu1.Items[2].Enabled = true;
        //}
        //else if (id_rol == 4)//Perfil RRHH
        //{
        //    Menu1.Items[3].Enabled = true;
        //}
        #endregion        
    }
    #endregion

    #region "Excepciones"
    public void Transaction_ErrorEvent(object sender, Exception ex)
    {
        TransactionFailureEvent input = new TransactionFailureEvent(sender, Profile.Usuario.CUSR_ID, ex.Message);
        input.Raise();
        onError = true;
    }

    public void Web_ErrorEvent(object sender, Exception ex)
    {
        WebFailureEvent input = new WebFailureEvent(sender, Profile.Usuario.CUSR_ID, ex.Message);
        input.Raise();
        onError = true;
    }
    #endregion
}
