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

public partial class SPV_UserControl_ComboMaestro : System.Web.UI.UserControl
{
    public delegate void SelectedIndexChangedDelegate(object sender, EventArgs e);
    public event SelectedIndexChangedDelegate SelectedIndexChanged;

    public String CssClass
    {
        get { return this.CboMaestro.CssClass; }
        set { this.CboMaestro.CssClass = value; }
    }
    public ListItemCollection Items
    {
        get { return this.CboMaestro.Items; }
    }
    //Propiedades
    public String SelectedValue
    {
        get { return this.CboMaestro.SelectedValue; }
        set { this.CboMaestro.SelectedValue = value; }
    }
    public String SelectedText
    {
        get { return this.CboMaestro.SelectedItem.Text; }
    }
    public bool AutoPostBack
    {
        set { this.CboMaestro.AutoPostBack = value; }
        get { return this.CboMaestro.AutoPostBack; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void CargarCombo(String Condicion, Int32 id_padre)
    {
        MaestroBEList OMaestroBEList = null;
        MaestroBL OMaestroBL = new MaestroBL();
        CboMaestro.Items.Clear();
        OMaestroBEList = OMaestroBL.GetAllUserControl(id_padre);
        if (OMaestroBEList != null)
        {
            for (int i = 0; i < OMaestroBEList.Count; i++)
            {
                this.CboMaestro.Items.Add(new ListItem(OMaestroBEList[i].de_maestro
                                , OMaestroBEList[i].id_maestro.ToString()));
            }
        }
        String objeto = ConstanteBE.OBJECTO_TODOS;
        if (!Condicion.Equals(String.Empty))
        {
            if (Condicion.Equals(ConstanteBE.OBJECTO_TIPO_SELECCIONE)) { objeto = ConstanteBE.OBJECTO_SELECCIONE; }
            if (Condicion.Equals(ConstanteBE.OBJECTO_TIPO_TODOS)) { objeto = ConstanteBE.OBJECTO_TODOS; }
        }
        this.CboMaestro.Items.Insert(0, new ListItem(objeto, String.Empty));
    }

    protected void CboMaestro_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedIndexChanged(sender, e);
    }

    public bool EnabledValidacion
    {
        get { return this.CboMaestro.Enabled; }
        set { this.CboMaestro.Enabled = value; }
    }
}