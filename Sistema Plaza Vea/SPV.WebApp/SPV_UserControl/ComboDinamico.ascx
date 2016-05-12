<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ComboDinamico.ascx.cs" Inherits="SPV_UserControl_ComboDinamico" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:UpdatePanel ID="upListado" runat="server" UpdateMode="conditional">
    <ContentTemplate>
        <asp:HiddenField ID="TxhSelectedValue" runat="server" />
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td><asp:TextBox ID="TxtFiltro" runat="server" AutoPostBack="true" OnTextChanged="Trigger_CheckedChanged" MaxLength="20"></asp:TextBox>&nbsp;&nbsp;</td>
                <td><asp:DropDownList ID="CboListado" runat="server" OnSelectedIndexChanged="CboListado_SelectedIndexChanged" ><asp:ListItem Text="-- Seleccione --" Value=""></asp:ListItem></asp:DropDownList></td>
            </tr>
        </table>
    </ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="TxtFiltro" EventName="TextChanged" />
</Triggers>
</asp:UpdatePanel>
<asp:CheckBox ID="Trigger" AutoPostBack="true" runat="server" OnCheckedChanged="Trigger_CheckedChanged" />