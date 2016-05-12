<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TextBoxFecha.ascx.cs" Inherits="SPV_UserControl_TextBoxFecha" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:TextBox ID="TxtFecha" runat="server" Columns="11" MaxLength="10" OnTextChanged="TxtFecha_TextChanged"></asp:TextBox>
<asp:Image ID="btnFecha" runat="server" ImageUrl="~/Images/iconos/calendario.gif" ImageAlign="AbsMiddle" ToolTip="Calendario"  />
<cc1:CalendarExtender ID="ceFecha" runat="server" Format="dd/MM/yyyy" TargetControlID="TxtFecha" PopupButtonID="btnFecha" />
<cc1:MaskedEditExtender ID="meFecha" runat="server"
        MaskType="Date" Mask="99/99/9999" UserDateFormat="DayMonthYear"
        ClearMaskOnLostFocus="true" ErrorTooltipEnabled="true" MessageValidatorTip="true"
        ClearTextOnInvalid="true" TargetControlID="txtFecha" >
</cc1:MaskedEditExtender>