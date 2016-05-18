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
//using SPV.BL.SPV_Comun;
using SPV.BE;

public partial class SPV_UserControl_ComboArea : System.Web.UI.UserControl
{
    public delegate void SelectedIndexChangedDelegate(object sender, EventArgs e);
    public event SelectedIndexChangedDelegate SelectedIndexChanged;

    public String CssClass
    {
        get { return this.CboArea.CssClass; }
        set { this.CboArea.CssClass = value; }
    }
    public ListItemCollection Items
    {
        get { return this.CboArea.Items; }
    }
    //Propiedades
    public String SelectedValue
    {
        get { return this.CboArea.SelectedValue; }
        set { this.CboArea.SelectedValue = value; }
    }
    public String SelectedText
    {
        get { return this.CboArea.SelectedItem.Text; }
    }
    public bool AutoPostBack
    {
        set { this.CboArea.AutoPostBack = value; }
        get { return this.CboArea.AutoPostBack; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void CargarCombo(String Condicion)
    {
        //AreaBEList OAreaBEList = null;
        //AreaBL OAreaBL = new AreaBL();
        //CboArea.Items.Clear();
        //OAreaBEList = OAreaBL.GetAllUserControl();
        //if (OAreaBEList != null)
        //{
        //    for (int i = 0; i < OAreaBEList.Count; i++)
        //    {
        //        this.CboArea.Items.Add(new ListItem(OAreaBEList[i].de_area
        //                        , OAreaBEList[i].id_area.ToString()));
        //    }
        //}
        //String objeto = ConstanteBE.OBJECTO_TODOS;
        //if (!Condicion.Equals(String.Empty))
        //{
        //    if (Condicion.Equals(ConstanteBE.OBJECTO_TIPO_SELECCIONE)) { objeto = ConstanteBE.OBJECTO_SELECCIONE; }
        //    if (Condicion.Equals(ConstanteBE.OBJECTO_TIPO_TODOS)) { objeto = ConstanteBE.OBJECTO_TODOS; }
        //}
        //this.CboArea.Items.Insert(0, new ListItem(objeto, String.Empty));
    }

    protected void CboArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedIndexChanged(sender, e);
    }

    public bool EnabledValidacion
    {
        get { return this.CboArea.Enabled; }
        set { this.CboArea.Enabled = value; }
    }
}