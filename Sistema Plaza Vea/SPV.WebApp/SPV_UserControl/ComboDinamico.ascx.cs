using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SPV.BE;

public partial class SPV_UserControl_ComboDinamico : System.Web.UI.UserControl
{
    public delegate void SelectedIndexChangedDelegate(object sender, EventArgs e);
    public event SelectedIndexChangedDelegate SelectedIndexChanged;

    #region "Propiedades"
    public String CssClass
    {
        set { ViewState["CssClass"] = value; }
    }

    public String CssClassText
    {
        set { ViewState["CssClassText"] = value; }
    }

    public Unit Width
    {
        set { ViewState["Width"] = value; }
    }

    public Unit WidthText
    {
        set { ViewState["WidthText"] = value; }
    }

    public String DataValueField
    {
        set
        {
            ViewState[String.Format("{0}_DataValueField", this.ClientID)] = value;

            if (ViewState[String.Format("{0}_DataValueField", this.ClientID)] != null &&
                ViewState[String.Format("{0}_DataTextField", this.ClientID)] != null &&
                ViewState[String.Format("{0}_DataSource", this.ClientID)] != null)
            {
                DataBind();
            }
        }
    }

    public String DataTextField
    {
        set
        {
            ViewState[String.Format("{0}_DataTextField", this.ClientID)] = value;

            if (ViewState[String.Format("{0}_DataValueField", this.ClientID)] != null &&
                ViewState[String.Format("{0}_DataTextField", this.ClientID)] != null &&
                ViewState[String.Format("{0}_DataSource", this.ClientID)] != null)
            {
                DataBind();
            }
        }
    }

    public Object DataSource
    {
        set
        {
            ViewState[String.Format("{0}_DataSource", this.ClientID)] = value;

            if (ViewState[String.Format("{0}_DataValueField", this.ClientID)] != null &&
                ViewState[String.Format("{0}_DataTextField", this.ClientID)] != null &&
                ViewState[String.Format("{0}_DataSource", this.ClientID)] != null)
            {
                DataBind();
            }
        }
    }

    public String SelectedValue
    {
        get { return this.CboListado.SelectedValue; }
        set
        {
            if (this.CboListado.Items.FindByValue(value) != null)
            {
                this.CboListado.SelectedValue = value;
            }
        }
    }

    public void SetAttribute(String attribute, String value)
    {
        ViewState["attribute"] = attribute;
        ViewState["value"] = value;
    }

    public void Enabled(bool Condicion)
    {
        CboListado.Enabled = Condicion;
        TxtFiltro.Enabled = Condicion;
    }

    public void AutoPostBack(bool Value)
    {
        this.CboListado.AutoPostBack = Value;
    }
    #endregion

    private void DataBind()
    {
        String _DataValueField = (String)ViewState[String.Format("{0}_DataValueField", this.ClientID)];
        String _DataTextField = (String)ViewState[String.Format("{0}_DataTextField", this.ClientID)];
        Object _DataSource = (Object)ViewState[String.Format("{0}_DataSource", this.ClientID)];

        this.CboListado.Items.Clear();
        this.CboListado.DataSource = _DataSource;
        this.CboListado.DataTextField = _DataTextField;
        this.CboListado.DataValueField = _DataValueField;
        this.CboListado.DataBind();

        this.CboListado.Items.Insert(0, new ListItem());
        this.CboListado.Items[0].Text = ConstanteBE.OBJECTO_SELECCIONE;
        this.CboListado.Items[0].Value = String.Empty;

        this.TxtFiltro.Text = "";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Trigger.Style["display"] = "none";

        if (!Page.IsPostBack)
        {
            this.TxtFiltro.Attributes["onchange"] = String.Format("javascript: document.getElementById('{0}').value = document.getElementById('{1}').value; " +
                                                                    "document.getElementById('{1}').value = ''; document.getElementById('{2}').click();"
                                                                    , this.TxhSelectedValue.ClientID, this.CboListado.ClientID, this.Trigger.ClientID);
            this.TxtFiltro.Attributes["onkeypress"] = String.Format("javascript: return fc_ControlaEventoKeyPress(event, '{0}');", this.Trigger.ClientID);
            this.TxtFiltro.Attributes["onkeyup"] = String.Format("javascript: return fc_DisparaEventoClick(event, '{0}');", this.Trigger.ClientID);

            if (ViewState["Width"] != null) this.CboListado.Width = (Unit)ViewState["Width"];
            if (ViewState["WidthText"] != null) this.TxtFiltro.Width = (Unit)ViewState["WidthText"];
            if (ViewState["CssClass"] != null) this.CboListado.CssClass = (String)ViewState["CssClass"];
            if (ViewState["CssClassText"] != null) this.TxtFiltro.CssClass = (String)ViewState["CssClassText"];
            if (ViewState["attribute"] != null && ViewState["value"] != null)
            {
                this.CboListado.Attributes[(String)ViewState["attribute"]] = (String)ViewState["value"];
            }
        }
    }

    protected void Trigger_CheckedChanged(object sender, EventArgs e)
    {
        this.Trigger.Style["display"] = "none";
        String _DataValueField = (String)ViewState[String.Format("{0}_DataValueField", this.ClientID)];
        String _DataTextField = (String)ViewState[String.Format("{0}_DataTextField", this.ClientID)];
        Object _DataSource = (Object)ViewState[String.Format("{0}_DataSource", this.ClientID)];

        String _selectedValue = String.Empty;
        if (_DataValueField != null && _DataTextField != null)
        {
            this.CboListado.Items.Clear();
            this.CboListado.DataSource = _DataSource;
            this.CboListado.DataTextField = _DataTextField;
            this.CboListado.DataValueField = _DataValueField;
            this.CboListado.DataBind();

            ListItemCollection oListaResultado = new ListItemCollection();
            oListaResultado.Add(new ListItem("-- Seleccione --", ""));

            for (int i = 0; i < this.CboListado.Items.Count; i++)
            {
                if (this.CboListado.Items[i].Text.ToUpper().IndexOf(this.TxtFiltro.Text.ToUpper()) == 0
                    && !this.TxtFiltro.Text.Trim().Equals(String.Empty))
                {
                    if (_selectedValue.Equals(String.Empty)) _selectedValue = this.CboListado.Items[i].Value;
                    oListaResultado.Add(this.CboListado.Items[i]);
                }
                else if (this.TxtFiltro.Text.Trim().Equals(String.Empty))
                {
                    oListaResultado.Add(this.CboListado.Items[i]);
                }
            }
            this.CboListado.Items.Clear();
            this.CboListado.DataSource = oListaResultado;
            this.CboListado.DataTextField = "Text";
            this.CboListado.DataValueField = "Value";
            this.CboListado.DataBind();

            if (!_selectedValue.Trim().Equals(String.Empty))
            {
                this.CboListado.SelectedValue = _selectedValue;
            }
            this.TxtFiltro.Focus();
        }
    }

    protected void CboListado_SelectedIndexChanged(object sender, EventArgs e)
    {
        //SelectedIndexChanged(sender, e);
    }
}