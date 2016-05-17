<%@ Import Namespace="SPV.BE" %>
<%@ Language="C#" 
    MasterPageFile="~/Principal.master" 
    AutoEventWireup="true" 
    CodeFile="SPV_Requerimiento_Compra_Lista.aspx.cs" 
    Inherits="SPV_Compras_SPV_Requerimiento_Compra_Lista" 
    Theme="Default"%>

<%@ MasterType VirtualPath="~/Principal.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../SPV_UserControl/TextBoxFecha.ascx" TagName="TextBoxFecha" TagPrefix="uc1" %>
<%@ Register Src="~/SPV_UserControl/ComboArea.ascx" TagName="ComboArea" TagPrefix="uc3" %>
<%@ Register Src="~/SPV_UserControl/ComboSolicitante.ascx" TagName="ComboSolicitante" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
        var mstrError = "";
        function Fc_Limpiar() {
            
            return false;
        }

        function Fc_Buscar() {
            
            if (mstrError != "") {
                alert(mstrError);
                mstrError = "";
                return false;
            }
            return true;
        }

        function Fc_SeleccionaItemAsig(valor) {
            if (document.getElementById("<%=this.txhCadenaSel.ClientID %>").value == '') { document.getElementById("<%=this.txhCadenaSel.ClientID %>").value = '|' }
            if (document.getElementById("<%=this.txhCadenaSel.ClientID %>").value.indexOf('|' + valor + '|') > -1) {
                var posicion1 = document.getElementById("<%=this.txhCadenaSel.ClientID %>").value.indexOf('|' + valor + '|');
                var posicion2 = String('|' + valor + '|').lastIndexOf('|');
                document.getElementById("<%=this.txhCadenaSel.ClientID %>").value = document.getElementById("<%=this.txhCadenaSel.ClientID %>").value.substring(0, posicion1) + document.getElementById("<%=this.txhCadenaSel.ClientID %>").value.substring(eval(posicion1) + eval(posicion2), document.getElementById("<%=this.txhCadenaSel.ClientID %>").value.length);
            }
            else {
                document.getElementById("<%=this.txhCadenaSel.ClientID %>").value = document.getElementById("<%=this.txhCadenaSel.ClientID %>").value + valor + '|';
            }
        }
        function Fc_SelecDeselecTodos() {
            if (document.getElementById("<%=this.txhNroFilas.ClientID %>").value > 0) {
                if (document.getElementById("<%=this.txhFlagChekTodos.ClientID %>").value == '1') {
                    document.getElementById("<%=this.txhFlagChekTodos.ClientID %>").value = ''
                    document.getElementById("<%=this.txhCadenaSel.ClientID %>").value = '';
                    for (i = 2 ; i < eval(document.getElementById("<%=this.txhNroFilas.ClientID %>").value) + 2 ; i++) {
                        var iLen = String('0' + String(i)).length;
                        var cadena = String('0' + String(i)).substring(iLen, iLen - 2);
                        document.getElementById("<%=this.GrwData.ClientID %>" + "_ctl" + cadena + "_chkSel").checked = false
                    }
                }
                else {
                    document.getElementById("<%=this.txhFlagChekTodos.ClientID %>").value = '1'
                    document.getElementById("<%=this.txhCadenaSel.ClientID %>").value = document.getElementById("<%=this.txhCadenaTotal.ClientID %>").value;
                    for (i = 2 ; i < eval(eval(document.getElementById("<%=this.txhNroFilas.ClientID %>").value) + 2) ; i++) {
                        var iLen = String('0' + String(i)).length;
                        var cadena = String('0' + String(i)).substring(iLen, iLen - 2);
                        var objCheck = document.getElementById("<%=this.GrwData.ClientID %>" + "_ctl" + cadena + "_chkSel");
                        if (objCheck.disabled == false) { objCheck.checked = true }
                    }
                }
            }
        }

        function Fc_Procesar(){
            if (fc_Trim(document.getElementById("<%=this.txhCadenaSel.ClientID %>").value) == ""  ){
                mstrError += mstrAsigneVarios;
            }
            if (fc_Trim(document.getElementById("<%=this.txhCadenaSel.ClientID %>").value) == "|") {
                mstrError += mstrAsigneVarios;
            }

            if (mstrError != "") {
                alert(mstrError);
                mstrError="";
                return false;
            }

            return confirm(mstrSeguroGrabar);
        }
    </script>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr valign="bottom" >
            <td style="width:30%">
                <table id="Table1" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td class="TabCabeceraOn">Lista de Requerimientos de Compra</td>                        
                    </tr>
                </table>
            </td>
            <td style="width:70%" align="right">
                <table id="Table2" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td align="right">
                            <asp:imagebutton id="BtnProcesar" runat="server" imageurl="../images/iconos/b-confirmar1.png"
                                ToolTip="PROCESAR" onclick="BtnProcesar_Click" onclientclick="javascript:return Fc_Procesar();"
                                onmouseover="javascript:this.src='../Images/iconos/b-confirmar2.png'" 
                                onmouseout="javascript:this.src='../Images/iconos/b-confirmar1.png'" />
                                            
                            <asp:imagebutton id="BtnBuscar" runat="server" imageurl="~/Images/iconos/b-buscar.gif" 
                                ToolTip="Buscar" onclick="BtnBuscar_Click" onclientclick="javascript:return Fc_Buscar();"
                                onmouseover="javascript:this.src='../Images/iconos/b-buscar2.gif'" 
                                onmouseout="javascript:this.src='../Images/iconos/b-buscar.gif'" />
                
                            <asp:imagebutton id="BtnLimpiar" runat="server" causesvalidation="False" imageurl="~/Images/iconos/b-limpiar.gif"
                                ToolTip="Limpiar" OnClientClick="javascript:return Fc_Limpiar();" 
                                onmouseover="javascript:this.src='../Images/iconos/b-limpiar2.gif'" 
                                onmouseout="javascript:this.src='../Images/iconos/b-limpiar.gif'"/>

                            <asp:ImageButton ID="BtnRegresar" runat="server" onclick="BtnRegresar_Click" ImageUrl="~/Images/iconos/b-regresar.gif" ToolTip="Regresar"
                                onmouseover="javascript:this.src='../Images/iconos/b-regresar2.gif'" onmouseout="javascript:this.src='../Images/iconos/b-regresar.gif'" />
                        </td>
                    </tr>
                </table> 
            </td>
        </tr>
    </table>
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr style="width: 100%">
            <!-- Cabecera -->
            <td><img alt="" width="100%" src="../Images/Mantenimiento/fbarr.gif" /></td>
        </tr>
        <tr style="width: 100%">
            <td style="background-color: #ffffff; vertical-align: top; height: 470px;width: 100%;">
                <table cellpadding="1" cellspacing="1" style="margin-left:5px; margin-right:5px;width: 99%;" border="0">  
                    <tr>
                        <td><asp:Label ID="lbl" runat="server" SkinID="lblcb" >CRITERIOS DE BUSQUEDA</asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:updatepanel id="upBusqueda" runat="server">
                                <contenttemplate>
                                    <table border="0" style="width: 100%" cellspacing="1" cellpadding="2" class="cbusqueda">
                                        <tr>
                                            <td style="width:10%">´Área</td>
                                            <td style="width:20%"><uc3:ComboArea Width="50%" ID="cboArea" runat="server" OnSelectedIndexChanged="cboArea_SelectedIndexChanged" AutoPostBack="true"/></td>
                                            <td style="width:10%">Solicitante</td>
                                            <td style="width:20%"><uc4:ComboSolicitante Width="50%" ID="cboSolicitante" runat="server" OnSelectedIndexChanged="cboSolicitante_SelectedIndexChanged"/></td>                                        </tr>
                                        <tr>
                                            <td style="width:10%">Fecha Inicio</td>
                                            <td style="width:10%"><uc1:TextBoxFecha ID="TxtFecIni" runat="server" /></td>
                                            <td style="width:10%">Fecha Fin</td>
                                            <td style="width:10%"><uc1:TextBoxFecha ID="TxtFecFin" runat="server" /></td>
                                            <td style="width:10%">Nro Requerimiento</td>
                                            <td style="width:10%"><asp:TextBox ID="txtNumSerie" MaxLength="10" runat="server" Width="90%"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </contenttemplate>   
                                    <triggers><asp:AsyncPostBackTrigger ControlID="cboArea" EventName="SelectedIndexChanged" /></triggers>                                 
                                </asp:updatepanel>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/iconos/fbusqueda.gif" Width="100%" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="padding-top:15px;">
                            <asp:UpdatePanel ID="upMantenimiento" runat="server">
                                <contenttemplate>
                                    <asp:HiddenField ID="txhCadenaSel" runat="server" />
                                    <asp:HiddenField ID="txhCadenaTotal" runat="server" />
                                    <asp:HiddenField ID="txhFlagChekTodos" runat="server" />
                                    <asp:HiddenField ID="txhNroFilas" runat="server" />
                                    <asp:hiddenfield runat="server" id="Txhid_cabecera_requerimiento_compra" />
                                    <asp:GridView id="GrwData" runat="server" SkinID="Grilla" Width="100%" OnRowDataBound="GrwData_RowDataBound" 
                                        OnPageIndexChanging="GrwData_PageIndexChanging" DataKeyNames="id_cabecera_requerimiento_compra" AutoGenerateColumns="False" 
                                        AllowPaging="True" AllowSorting="True" OnSorting="GrwData_Sorting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sel." SortExpression="id_cabecera_requerimiento_compra">
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <HeaderTemplate>
                                                    <asp:CheckBox  ID="chkSelCabecera" runat="server"/>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                <asp:CheckBox  ID="chkSel" runat="server"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Núm. Req." SortExpression="id_cabecera_requerimiento_compra">
                                                <ItemStyle Width="10%" horizontalalign="left"/>
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraRequerimientoCompraBE)Container.DataItem).id_cabecera_requerimiento_compra%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Solicitante" SortExpression="de_solicitante">
                                                <ItemStyle Width="10%" horizontalalign="Center"/>
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraRequerimientoCompraBE)Container.DataItem).de_solicitante%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Estado" SortExpression="de_estado">
                                                <ItemStyle Width="10%" horizontalalign="Center"/>
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraRequerimientoCompraBE)Container.DataItem).de_estado%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Crea" SortExpression="fe_creacion">
                                                <ItemStyle Width="5%" horizontalalign="center"/>
                                                <HeaderStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraRequerimientoCompraBE)Container.DataItem).fe_creacion%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Cambio" SortExpression="fe_cambio">
                                                <ItemStyle Width="8%" horizontalalign="left" />
                                                <HeaderStyle Width="8%" />
                                                <HeaderStyle Width="8%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraRequerimientoCompraBE)Container.DataItem).fe_cambio%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec En Proc" SortExpression="fe_en_proceso">
                                                <ItemStyle Width="12%" horizontalalign="left" />
                                                <HeaderStyle Width="12%" />
                                                <HeaderStyle Width="12%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraRequerimientoCompraBE)Container.DataItem).fe_en_proceso%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Espera Justificación" SortExpression="fe_espera_justificacion">
                                                <ItemStyle Width="8%" horizontalalign="center" />
                                                <HeaderStyle Width="8%" />
                                                <HeaderStyle Width="8%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraRequerimientoCompraBE)Container.DataItem).fe_espera_justificacion%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Anulado" SortExpression="fe_anulado">
                                                <ItemStyle Width="12%" horizontalalign="left" />
                                                <HeaderStyle Width="12%" />
                                                <HeaderStyle Width="12%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraRequerimientoCompraBE)Container.DataItem).fe_anulado%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Espera Cotización" SortExpression="fe_espera_cotizacion">
                                                <ItemStyle Width="8%" horizontalalign="center" />
                                                <HeaderStyle Width="8%" />
                                                <HeaderStyle Width="8%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraRequerimientoCompraBE)Container.DataItem).fe_espera_cotizacion%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Cotizado" SortExpression="fe_cotizado">
                                                <ItemStyle Width="10%" horizontalalign="right" />
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraRequerimientoCompraBE)Container.DataItem).fe_cotizado%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Espera Solicitante" SortExpression="fe_espera_solicitante">
                                                <ItemStyle Width="10%" horizontalalign="right" />
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraRequerimientoCompraBE)Container.DataItem).fe_espera_solicitante%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Pendiente Aprobación" SortExpression="fe_pendiente_aprobacion">
                                                <ItemStyle Width="10%" horizontalalign="right" />
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraRequerimientoCompraBE)Container.DataItem).fe_pendiente_aprobacion%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Rechazado" SortExpression="fe_rechazado">
                                                <ItemStyle Width="10%" horizontalalign="right" />
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraRequerimientoCompraBE)Container.DataItem).fe_rechazado%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Aprobado" SortExpression="fe_aprobado">
                                                <ItemStyle Width="10%" horizontalalign="right" />
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraRequerimientoCompraBE)Container.DataItem).fe_aprobado%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </contenttemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>  
            </td>
        </tr>
         <tr>
            <!-- Pie -->
            <td><img alt="" src="../Images/Mantenimiento/fba.gif" Width="100%" /></td>
        </tr>
    </table>
    <script type="text/javascript">
        setTabCabeceraOn("0");
    </script>
</asp:Content>