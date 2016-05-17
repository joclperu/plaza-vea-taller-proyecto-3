using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SPV.BL.SPV_Comun;
using SPV.BE;

public partial class SPV_UserControl_ComboProveedor : System.Web.UI.UserControl
{
    public delegate void SelectedIndexChangedDelegate(object sender, EventArgs e);
    public event SelectedIndexChangedDelegate SelectedIndexChanged;

    public String CssClass
    {
        get { return this.CboProveedor.CssClass; }
        set { this.CboProveedor.CssClass = value; }
    }
    public ListItemCollection Items
    {
        get { return this.CboProveedor.Items; }
    }
    //Propiedades
    public String SelectedValue
    {
        get { return this.CboProveedor.SelectedValue; }
        set { this.CboProveedor.SelectedValue = value; }
    }
    public String SelectedText
    {
        get { return this.CboProveedor.SelectedItem.Text; }
    }
    public bool AutoPostBack
    {
        set { this.CboProveedor.AutoPostBack = value; }
        get { return this.CboProveedor.AutoPostBack; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void CargarCombo(String Condicion)
    {
        ProveedorBEList OProveedorBEList = null;
        ProveedorBL OProveedorBL = new ProveedorBL();
        CboProveedor.Items.Clear();
        OProveedorBEList = OProveedorBL.GetAllUserControl();
        if (OProveedorBEList != null)
        {
            for (int i = 0; i < OProveedorBEList.Count; i++)
            {
                this.CboProveedor.Items.Add(new ListItem(OProveedorBEList[i].de_proveedor
                                , OProveedorBEList[i].id_proveedor.ToString()));
            }
        }
        String objeto = ConstanteBE.OBJECTO_TODOS;
        if (!Condicion.Equals(String.Empty))
        {
            if (Condicion.Equals(ConstanteBE.OBJECTO_TIPO_SELECCIONE)) { objeto = ConstanteBE.OBJECTO_SELECCIONE; }
            if (Condicion.Equals(ConstanteBE.OBJECTO_TIPO_TODOS)) { objeto = ConstanteBE.OBJECTO_TODOS; }
        }
        this.CboProveedor.Items.Insert(0, new ListItem(objeto, String.Empty));
    }

    protected void CboProveedor_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedIndexChanged(sender, e);
    }

    public bool EnabledValidacion
    {
        get { return this.CboProveedor.Enabled; }
        set { this.CboProveedor.Enabled = value; }
    }
}