<%@ Import Namespace="SPV.BE" %>
<%@ Language="C#" 
    MasterPageFile="~/Principal.master" 
    AutoEventWireup="true" 
    CodeFile="SPV_SolicitudCompra_Lista.aspx.cs" 
    Inherits="SPV_Compras_SPV_SolicitudCompra_Lista" %>

<%@ MasterType VirtualPath="~/Principal.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                        <td class="TabCabeceraOn">Lista de Solicitudes de Compra</td>                        
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
                        <td valign="top" style="padding-top:15px;">
                            <asp:UpdatePanel ID="upMantenimiento" runat="server">
                                <contenttemplate>
                                    <asp:HiddenField ID="txhCadenaSel" runat="server" />
                                    <asp:HiddenField ID="txhCadenaTotal" runat="server" />
                                    <asp:HiddenField ID="txhFlagChekTodos" runat="server" />
                                    <asp:HiddenField ID="txhNroFilas" runat="server" />
                                    <asp:hiddenfield runat="server" id="Txhid_ncodsolicitud" />
                                    <asp:GridView id="GrwData" runat="server" SkinID="Grilla" Width="100%" OnRowDataBound="GrwData_RowDataBound" 
                                        OnPageIndexChanging="GrwData_PageIndexChanging" DataKeyNames="ncodsolicitud" AutoGenerateColumns="False" 
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
                                             <asp:TemplateField HeaderText="Número Solicitud" SortExpression="ncodsolicitud">
                                                <ItemStyle Width="10%" horizontalalign="left"/>
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((SolicitudCompraBE)Container.DataItem).ncodsolicitud%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha" SortExpression="defecha">
                                                <ItemStyle Width="10%" horizontalalign="Center"/>
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((SolicitudCompraBE)Container.DataItem).defecha%>
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