<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="SPV_EvaluarPoliticaCandidato.aspx.cs" Inherits="SPV_Proveedores_SPV_EvaluarPoliticaCandidato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="75%">
<tr><td><br /></td><td></td><td></td><td></td><td></td></tr>
<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>
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
            <asp:BoundField DataField="rutaPoliticaPropuesta" HeaderText="Politica" SortExpression="rutaPoliticaPropuesta" />
            
        </Columns>


    </asp:GridView>
</td>
</tr>

<tr><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td></tr>

<tr><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td></tr>
<tr><td style="height: 23px">Codigo Convocatoria</td><td style="height: 23px">
    <asp:Label ID="lblCodigoConvocatoria" runat="server" Font-Bold="True" ForeColor="#0066FF"></asp:Label>
    </td><td style="height: 23px">Razon Social Candidato</td><td style="height: 23px">
    <asp:Label ID="lblRazonSocial" runat="server" Font-Bold="True" ForeColor="#0066FF"></asp:Label>
    </td><td style="height: 23px"></td></tr>
<tr><td style="height: 23px">Descripcion Convocatoria</td><td style="height: 23px">
    <asp:Label ID="lblDescripcion" runat="server" Font-Bold="True" ForeColor="#0066FF"></asp:Label>
    </td><td style="height: 23px">Ruc Candidato</td><td style="height: 23px">
    <asp:Label ID="lblRuc" runat="server" Font-Bold="True" ForeColor="#0066FF"></asp:Label>
    </td><td style="height: 23px"></td></tr>


<tr><td style="height: 23px">
    Politica Convocatoria</td><td style="height: 23px">
        &nbsp;</td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td></tr>


<tr><td style="height: 23px">Observciones</td><td style="height: 23px">
    <asp:HyperLink ID="hplDescargar" runat="server">HyperLink</asp:HyperLink>
    </td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td></tr>


<tr><td style="height: 23px" colspan="5">
    <asp:TextBox ID="TextBox3" runat="server" Height="74px" TextMode="MultiLine" Width="697px"></asp:TextBox>
    </td></tr>


<tr><td style="height: 23px">Estado</td><td style="height: 23px">
    <asp:DropDownList ID="DropDownList1" runat="server">
    <asp:ListItem Value="0">Seleccione..</asp:ListItem>
            <asp:ListItem Value="1">Aprobado</asp:ListItem>
            <asp:ListItem Value="2">Desaprobado</asp:ListItem>
           
    </asp:DropDownList>
    </td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td></tr>


<tr><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td><td style="height: 23px"></td></tr>


<tr><td style="height: 23px" align="center" colspan="5">
    <asp:Button ID="Button1" runat="server" Text="Registrar Informe" />
&nbsp;<asp:Button ID="Button2" runat="server" Text="Salir" />
    </td></tr>


<tr><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td></tr>


<tr><td style="height: 23px">&nbsp;</td><td style="height: 23px">
    <asp:HiddenField ID="hdCodPropuesta" runat="server" />
    </td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td><td style="height: 23px">&nbsp;</td></tr>


</table>
</asp:Content>

