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

public partial class SPV_UserControl_TextBoxFecha : System.Web.UI.UserControl
{
    public delegate void TextChangedDelegate(object sender, EventArgs e);
    public event TextChangedDelegate TextChanged;

    public String Text
    {
        set { this.TxtFecha.Text = value; }
        get { return this.TxtFecha.Text; }
    }

    public String CssClass
    {
        set { this.TxtFecha.CssClass = value; }
        get { return this.TxtFecha.CssClass; }
    }

    public Boolean ReadOnly
    {
        set
        {
            if (this.TxtFecha != null)
            {
                this.TxtFecha.ReadOnly = value;
            }
            else
            {
                ViewState["_ReadOnly"] = value;
            }
        }
    }

    public void SetAtributtes(String evento, String funcion)
    {
        this.TxtFecha.Attributes.Add(evento, funcion);
    }

    public Boolean Enabled
    {
        set
        {
            if (this.TxtFecha != null)
            {
                this.TxtFecha.Enabled = value;
                this.btnFecha.Visible = value;
            }
            else
            {
                ViewState["_Enabled"] = value;
            }
        }
    }

    public bool AutoPostBack
    {
        set { this.TxtFecha.AutoPostBack = value; }
        get { return this.TxtFecha.AutoPostBack; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.btnFecha.Style["cursor"] = "pointer";
            if (ViewState["_Enabled"] != null)
            {
                this.TxtFecha.Enabled = (Boolean)ViewState["_Enabled"];
                this.btnFecha.Visible = (Boolean)ViewState["_Enabled"];
            }
        }
    }

    protected void TxtFecha_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TextChanged(sender, e);
        }
        catch (Exception ex)
        {
        }
    }
}