<<<<<<< HEAD
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="SPV_EvaluarPoliticaCandidato.aspx.cs" Inherits="SPV_Proveedores_SPV_EvaluarPoliticaCandidato" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="75%">
<tr><td colspan="5" style="height: 40px"><h2 align="center">EVALUAR POLITICAS CANDIDATO</h2></td></tr>
<tr><td colspan="2">
    &nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td colspan="5">
<table width="60%">
<tr><td>Convocatoria</td><td>
    <asp:DropDownList ID="ddlConvocatoria" runat="server">
    </asp:DropDownList>
    </td><td></td><td></td><td></td><td></td></tr>
<tr><td>Descripción Convocatoria</td><td>
    <asp:TextBox ID="TextBox1" runat="server" Width="180px"></asp:TextBox>
    </td><td></td><td></td><td></td><td></td></tr>
<tr><td>Razón Social Candidato</td><td>
    <asp:TextBox ID="TextBox2" runat="server" Width="180px"></asp:TextBox>
    </td><td></td><td></td><td></td><td>
    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
    </td></tr>
<tr><td></td><td></td><td></td><td></td><td></td><td></td></tr>


</table>
</td></tr>

<tr><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td></tr>
<tr>
<td colspan="5">
    <asp:GridView ID="gdvCandidatos" runat="server" DataKeyNames="ncodpropuesta,codigoConvocatoria" AutoGenerateColumns="False" OnSelectedIndexChanged="gdvCandidatos_SelectedIndexChanged">
        <Columns>
             <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True"  HeaderText="Seleccionar" />
                                                       
            <asp:BoundField DataField="Convocatoria" HeaderText="Convocatoria" SortExpression="Convocatoria" />
            <asp:BoundField DataField="tipoConvocatoria" HeaderText="Tipo Convocatoria" SortExpression="tipoConvocatoria" />
            <asp:BoundField DataField="razonSocialCandidato" HeaderText="RazonSocial Candidato" SortExpression="razonSocialCandidato" />
            <asp:BoundField DataField="rucCandidato" HeaderText="Ruc Candidato" SortExpression="rucCandidato" />
         

            <asp:HyperLinkField 
        HeaderText="Politica"
        DataTextField="rutaPoliticaPropuesta"
        datanavigateurlfields="rutaPoliticaPropuesta"
        Target="_blank" />
            
        </Columns>


    </asp:GridView>
</td>
</tr>

<tr><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td></tr>

<tr><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td></tr>
<tr><td style="height: 23px">Codigo Convocatoria :</td><td style="height: 23px">
    <asp:Label ID="lblCodigoConvocatoria" runat="server" Font-Bold="True" ForeColor="#0066FF"></asp:Label>
    </td><td style="height: 23px">Razon Social Candidato :</td><td style="height: 23px">
    <asp:Label ID="lblRazonSocial" runat="server" Font-Bold="True" ForeColor="#0066FF"></asp:Label>
    </td><td style="height: 23px"></td></tr>
<tr><td style="height: 23px">Descripcion Convocatoria :</td><td style="height: 23px">
    <asp:Label ID="lblDescripcion" runat="server" Font-Bold="True" ForeColor="#0066FF"></asp:Label>
    </td><td style="height: 23px">Ruc Candidato :</td><td style="height: 23px">
    <asp:Label ID="lblRuc" runat="server" Font-Bold="True" ForeColor="#0066FF"></asp:Label>
    </td><td style="height: 23px"></td></tr>


<tr><td style="height: 23px">
    Politica Convocatoria :</td><td style="height: 23px">
        <asp:HyperLink ID="hplDescargar" runat="server" ForeColor="#0066FF" NavigateUrl="~/SPV_Proveedores/Politicas/RH_SergioLapa.pdf" Visible="False" Target="_blank">HyperLink</asp:HyperLink>
    </td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td></tr>


<tr><td style="height: 23px">Observaciones :</td><td style="height: 23px">&nbsp;</td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td></tr>


<tr><td style="height: 23px" colspan="5">
    <asp:TextBox ID="txtObservacion" runat="server" Height="74px" TextMode="MultiLine" Width="697px"></asp:TextBox>
    </td></tr>


<tr><td style="height: 23px">Estado</td><td style="height: 23px">
    <asp:DropDownList ID="ddlEstado" runat="server">
    <asp:ListItem Value="0">Seleccione..</asp:ListItem>
            <asp:ListItem Value="1">Aprobado</asp:ListItem>
            <asp:ListItem Value="2">Rechazado</asp:ListItem>
            <asp:ListItem Value="2">Observado</asp:ListItem>
           
    </asp:DropDownList>
    </td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td></tr>


<tr><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td></tr>


<tr><td style="height: 23px" align="center" colspan="5">
    <asp:Button ID="Button1" runat="server" Text="Registrar Informe" OnClick="Button1_Click" />
&nbsp;<asp:Button ID="Button2" runat="server" Text="Salir" OnClick="Button2_Click" />
    </td></tr>


<tr>
    <td style="height: 23px" colspan="5">
    <asp:Panel ID="pnMensajeConfirm1" runat="server" BackColor="#FFFFCC" 
        BorderColor="Gray" BorderStyle="Solid" BorderWidth="2px" Height="142px" 
        HorizontalAlign="Center" Width="326px">
        <table width="50%" >
            <tr>
                <td align="center"  style="color: #FFFFFF; background-color: #FF142D;">
                    <strong>&nbsp;PROVEEDORES</strong></td>
            </tr>
            <tr>
                <td  >
                    </td>
            </tr>
            <tr>
                <td style="font-weight: normal">
                   
<%-- <asp:Label ID="lblMensajeConfirm1" runat="server" Text="Label" ForeColor="#142F4A"  style="font-family: Arial; font-size:small"  ></asp:Label>--%>
                 
                    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
                 
                </td>
            </tr>
            <tr>
                <td style="font-weight: normal">
                    &nbsp;<asp:Button ID="btnMensajeConfirm1" runat="server" 
                        style="DISPLAY: none; VISIBILITY: visible" Text="MENSAJE" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;<asp:Button ID="btCerrar" runat="server" BackColor="#FF142D" 
                        ForeColor="White" Text="Aceptar" 
                        Visible="True" Width="80px" onclick="btCerrar_Click"  />

                    &nbsp;</td>
            </tr>
        </table>
        <cc1:ModalPopupExtender ID="mpeMensajeConfirm1" runat="server"  
             PopupControlID="pnMensajeConfirm1" TargetControlID="btnMensajeConfirm1">
            
        </cc1:ModalPopupExtender>
                    <br />
                 
                                                                                    <br />
                    &nbsp;<br />
                                                                                </asp:Panel>
    
    </td>


</tr>


<tr><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td></tr>


<tr><td style="height: 23px">&nbsp;</td><td style="height: 23px">
    <asp:HiddenField ID="hdCodPropuesta" runat="server" />
    </td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td></tr>


</table>
</asp:Content>

=======
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="SPV_EvaluarPoliticaCandidato.aspx.cs" Inherits="SPV_Proveedores_SPV_EvaluarPoliticaCandidato" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="75%">
<tr><td colspan="5" style="height: 40px"><h2 align="center">EVALUAR POLITICAS CANDIDATO</h2></td></tr>
<tr><td colspan="2">
    &nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td colspan="5">
<table width="60%">
<tr><td>Convocatoria</td><td>
    <asp:DropDownList ID="ddlConvocatoria" runat="server">
    </asp:DropDownList>
    </td><td></td><td></td><td></td><td></td></tr>
<tr><td>Descripción Convocatoria</td><td>
    <asp:TextBox ID="TextBox1" runat="server" Width="180px"></asp:TextBox>
    </td><td></td><td></td><td></td><td></td></tr>
<tr><td>Razón Social Candidato</td><td>
    <asp:TextBox ID="TextBox2" runat="server" Width="180px"></asp:TextBox>
    </td><td></td><td></td><td></td><td>
    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
    </td></tr>
<tr><td></td><td></td><td></td><td></td><td></td><td></td></tr>


</table>
</td></tr>

<tr><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td></tr>
<tr>
<td colspan="5">
    <asp:GridView ID="gdvCandidatos" runat="server" DataKeyNames="ncodpropuesta,codigoConvocatoria" AutoGenerateColumns="False" OnSelectedIndexChanged="gdvCandidatos_SelectedIndexChanged">
        <Columns>
             <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True"  HeaderText="Seleccionar" />
                                                       
            <asp:BoundField DataField="Convocatoria" HeaderText="Convocatoria" SortExpression="Convocatoria" />
            <asp:BoundField DataField="tipoConvocatoria" HeaderText="Tipo Convocatoria" SortExpression="tipoConvocatoria" />
            <asp:BoundField DataField="razonSocialCandidato" HeaderText="RazonSocial Candidato" SortExpression="razonSocialCandidato" />
            <asp:BoundField DataField="rucCandidato" HeaderText="Ruc Candidato" SortExpression="rucCandidato" />
         

            <asp:HyperLinkField 
        HeaderText="Politica"
        DataTextField="rutaPoliticaPropuesta"
        datanavigateurlfields="rutaPoliticaPropuesta"
        Target="_blank" />
            
        </Columns>


    </asp:GridView>
</td>
</tr>

<tr><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td></tr>

<tr><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td></tr>
<tr><td style="height: 23px">Codigo Convocatoria :</td><td style="height: 23px">
    <asp:Label ID="lblCodigoConvocatoria" runat="server" Font-Bold="True" ForeColor="#0066FF"></asp:Label>
    </td><td style="height: 23px">Razon Social Candidato :</td><td style="height: 23px">
    <asp:Label ID="lblRazonSocial" runat="server" Font-Bold="True" ForeColor="#0066FF"></asp:Label>
    </td><td style="height: 23px"></td></tr>
<tr><td style="height: 23px">Descripcion Convocatoria :</td><td style="height: 23px">
    <asp:Label ID="lblDescripcion" runat="server" Font-Bold="True" ForeColor="#0066FF"></asp:Label>
    </td><td style="height: 23px">Ruc Candidato :</td><td style="height: 23px">
    <asp:Label ID="lblRuc" runat="server" Font-Bold="True" ForeColor="#0066FF"></asp:Label>
    </td><td style="height: 23px"></td></tr>



<tr><td style="height: 23px">
    Politica Convocatoria :</td><td style="height: 23px">
        <asp:HyperLink ID="hplDescargar" runat="server" ForeColor="#0066FF" NavigateUrl="~/SPV_Proveedores/Politicas/RH_SergioLapa.pdf" Visible="False" Target="_blank">HyperLink</asp:HyperLink>
    </td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td></tr>


<tr><td style="height: 23px">Observaciones :</td><td style="height: 23px">&nbsp;</td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td></tr>


<tr><td style="height: 23px" colspan="5">
    <asp:TextBox ID="txtObservacion" runat="server" Height="74px" TextMode="MultiLine" Width="697px"></asp:TextBox>
    </td></tr>


<tr><td style="height: 23px">Estado</td><td style="height: 23px">
    <asp:DropDownList ID="ddlEstado" runat="server">
    <asp:ListItem Value="0">Seleccione..</asp:ListItem>
            <asp:ListItem Value="1">Aprobado</asp:ListItem>
            <asp:ListItem Value="2">Rechazado</asp:ListItem>
            <asp:ListItem Value="2">Observado</asp:ListItem>
           
    </asp:DropDownList>
    </td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td></tr>


<tr><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td></tr>


<tr><td style="height: 23px" align="center" colspan="5">
    <asp:Button ID="Button1" runat="server" Text="Registrar Informe" OnClick="Button1_Click" />
&nbsp;<asp:Button ID="Button2" runat="server" Text="Salir" OnClick="Button2_Click" />
    </td></tr>


<tr>
    <td style="height: 23px" colspan="5">
    <asp:Panel ID="pnMensajeConfirm1" runat="server" BackColor="#FFFFCC" 
        BorderColor="Gray" BorderStyle="Solid" BorderWidth="2px" Height="142px" 
        HorizontalAlign="Center" Width="326px">
        <table width="50%" >
            <tr>
                <td align="center"  style="color: #FFFFFF; background-color: #FF142D;">
                    <strong>&nbsp;PROVEEDORES</strong></td>
            </tr>
            <tr>
                <td  >
                    </td>
            </tr>
            <tr>
                <td style="font-weight: normal">
                   
<%-- <asp:Label ID="lblMensajeConfirm1" runat="server" Text="Label" ForeColor="#142F4A"  style="font-family: Arial; font-size:small"  ></asp:Label>--%>
                 
                    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
                 
                </td>
            </tr>
            <tr>
                <td style="font-weight: normal">
                    &nbsp;<asp:Button ID="btnMensajeConfirm1" runat="server" 
                        style="DISPLAY: none; VISIBILITY: visible" Text="MENSAJE" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;<asp:Button ID="btCerrar" runat="server" BackColor="#FF142D" 
                        ForeColor="White" Text="Aceptar" 
                        Visible="True" Width="80px" onclick="btCerrar_Click"  />

                    &nbsp;</td>
            </tr>
        </table>
        <cc1:ModalPopupExtender ID="mpeMensajeConfirm1" runat="server"  
             PopupControlID="pnMensajeConfirm1" TargetControlID="btnMensajeConfirm1">
            
        </cc1:ModalPopupExtender>
                    <br />
                 
                                                                                    <br />
                    &nbsp;<br />
                                                                                </asp:Panel>
    
    </td>


</tr>


<tr><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td></tr>


<tr><td style="height: 23px">&nbsp;</td><td style="height: 23px">
    <asp:HiddenField ID="hdCodPropuesta" runat="server" />
    </td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td></tr>


</table>
</asp:Content>

>>>>>>> upstream/master
