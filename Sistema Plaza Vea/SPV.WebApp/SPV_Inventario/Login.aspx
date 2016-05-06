<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body background="Images/Flash/Login.jpg" >
    <form id="frmLogin" runat="server">
    

    <div id="fading" runat="server" style="position: absolute; left: 95px; top: 250px; width: 79%; height:80px; background-color: Transparent; z-index: 1;" align="center" >
    <table>  
    <tr>
        <td>
            <asp:Label ID="lbl_Usuario" runat="server" Text="Usuario" ForeColor="Black" Font-Size="15px" Font-Names="Arial" Font-Bold="True"></asp:Label>
        </td>
        <td style="width:230px;"> 
            <asp:TextBox ID="txt_Usuario" runat="server" Width="100%" MaxLength="12" AutoComplete="off" ></asp:TextBox>
        </td>
        </tr> 
    <tr><td>
        <asp:Label ID="lbl_Password" runat="server" Text="Password" ForeColor="Black" Font-Size="15px" Font-Names="Arial" Font-Bold="True"></asp:Label>

     </td><td> 
         <asp:TextBox ID="txt_Password" runat="server" Width="100%" MaxLength="20" TextMode="Password" AutoComplete="off" ></asp:TextBox></td></tr> 
    <tr><td>&nbsp;</td><td align="right"> <asp:Button ID="btn_Ingresar" runat="server" 
            Text="Ingresar" onclick="btn_Ingresar_Click"/></td></tr> 
                
                       
    <tr><td colspan="2"> <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label></td></tr> 
                
                       </table>
    
    </div>
    </form>
</body>
</html>
