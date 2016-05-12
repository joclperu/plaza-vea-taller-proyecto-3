<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        ASP.NET
    </h2>
    <p>
        Para obtener más información acerca de ASP.NET, visite <a href="http://www.asp.net" title="Sitio web de ASP.NET">www.asp.net</a>.</p>
    <p>
        &nbsp;<asp:Label ID="Label1" runat="server" Text="NUMERO DE ORDEN DE COMPRA"></asp:Label>
    &nbsp;<asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnProcesar" runat="server" onclick="BtnProcesar_Click" 
            Text="PROCESAR" />
    </p>
    <p>
        <asp:TextBox ID="txtMensaje" runat="server" Width="455px"></asp:TextBox>
    </p>
    <p>
        También puede encontrar <a href="http://go.microsoft.com/fwlink/?LinkID=152368"
            title="Documentación de ASP.NET en MSDN">documentación sobre ASP.NET en MSDN</a>.
    </p>
</asp:Content>
