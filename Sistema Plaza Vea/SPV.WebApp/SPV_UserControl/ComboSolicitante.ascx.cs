<<<<<<< HEAD
﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SPV.BL.SPV_Seguridad;
using SPV.BE;

public partial class SPV_UserControl_ComboSolicitante : System.Web.UI.UserControl
{
    public delegate void SelectedIndexChangedDelegate(object sender, EventArgs e);
    public event SelectedIndexChangedDelegate SelectedIndexChanged;

    public String CssClass
    {
        get { return this.CboSolicitante.CssClass; }
        set { this.CboSolicitante.CssClass = value; }
    }
    public ListItemCollection Items
    {
        get { return this.CboSolicitante.Items; }
    }
    //Propiedades
    public String SelectedValue
    {
        get { return this.CboSolicitante.SelectedValue; }
        set { this.CboSolicitante.SelectedValue = value; }
    }
    public String SelectedText
    {
        get { return this.CboSolicitante.SelectedItem.Text; }
    }
    public bool AutoPostBack
    {
        set { this.CboSolicitante.AutoPostBack = value; }
        get { return this.CboSolicitante.AutoPostBack; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void CargarCombo(String Condicion, Int32 id_area)
    {
        UsuarioBEList OUsuarioBEList = null;
        UsuarioBL OUsuarioBL = new UsuarioBL();
        CboSolicitante.Items.Clear();
        OUsuarioBEList = OUsuarioBL.GetAllUserControl(id_area);
        if (OUsuarioBEList != null)
        {
            for (int i = 0; i < OUsuarioBEList.Count; i++)
            {
                this.CboSolicitante.Items.Add(new ListItem(OUsuarioBEList[i].no_login
                                , OUsuarioBEList[i].id_usuario.ToString()));
            }
        }
        String objeto = ConstanteBE.OBJECTO_TODOS;
        if (!Condicion.Equals(String.Empty))
        {
            if (Condicion.Equals(ConstanteBE.OBJECTO_TIPO_SELECCIONE)) { objeto = ConstanteBE.OBJECTO_SELECCIONE; }
            if (Condicion.Equals(ConstanteBE.OBJECTO_TIPO_TODOS)) { objeto = ConstanteBE.OBJECTO_TODOS; }
        }
        this.CboSolicitante.Items.Insert(0, new ListItem(objeto, String.Empty));
    }

    protected void CboSolicitante_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedIndexChanged(sender, e);
    }

    public bool EnabledValidacion
    {
        get { return this.CboSolicitante.Enabled; }
        set { this.CboSolicitante.Enabled = value; }
    }
=======
﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SPV.BL.SPV_Seguridad;
using SPV.BE;

public partial class SPV_UserControl_ComboSolicitante : System.Web.UI.UserControl
{
    public delegate void SelectedIndexChangedDelegate(object sender, EventArgs e);
    public event SelectedIndexChangedDelegate SelectedIndexChanged;

    public String CssClass
    {
        get { return this.CboSolicitante.CssClass; }
        set { this.CboSolicitante.CssClass = value; }
    }
    public ListItemCollection Items
    {
        get { return this.CboSolicitante.Items; }
    }
    //Propiedades
    public String SelectedValue
    {
        get { return this.CboSolicitante.SelectedValue; }
        set { this.CboSolicitante.SelectedValue = value; }
    }
    public String SelectedText
    {
        get { return this.CboSolicitante.SelectedItem.Text; }
    }
    public bool AutoPostBack
    {
        set { this.CboSolicitante.AutoPostBack = value; }
        get { return this.CboSolicitante.AutoPostBack; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void CargarCombo(String Condicion, Int32 id_area)
    {        //UsuarioBEList OUsuarioBEList = null;
        //UsuarioBL OUsuarioBL = new UsuarioBL();
        //CboSolicitante.Items.Clear();
        //OUsuarioBEList = OUsuarioBL.GetAllUserControl(id_area);
        //if (OUsuarioBEList != null)
        //{
        //    for (int i = 0; i < OUsuarioBEList.Count; i++)
        //    {
        //        this.CboSolicitante.Items.Add(new ListItem(OUsuarioBEList[i].no_login
        //                        , OUsuarioBEList[i].id_usuario.ToString()));
        //    }
        //}
        //String objeto = ConstanteBE.OBJECTO_TODOS;
        //if (!Condicion.Equals(String.Empty))
        //{
        //    if (Condicion.Equals(ConstanteBE.OBJECTO_TIPO_SELECCIONE)) { objeto = ConstanteBE.OBJECTO_SELECCIONE; }
        //    if (Condicion.Equals(ConstanteBE.OBJECTO_TIPO_TODOS)) { objeto = ConstanteBE.OBJECTO_TODOS; }
        //}
        //this.CboSolicitante.Items.Insert(0, new ListItem(objeto, String.Empty));

    }

    protected void CboSolicitante_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedIndexChanged(sender, e);
    }

    public bool EnabledValidacion
    {
        get { return this.CboSolicitante.Enabled; }
        set { this.CboSolicitante.Enabled = value; }
    }
>>>>>>> upstream/master
}