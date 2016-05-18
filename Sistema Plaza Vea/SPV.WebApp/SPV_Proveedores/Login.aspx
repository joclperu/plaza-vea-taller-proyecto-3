<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body background="../Images/background2.jpg" >
    <form id="frmLogin" runat="server">
    <div>
    <table width="50%">  
    <tr><td></td><td></td><td></td><td></td></tr>     
    <tr><td><asp:Label ID="lbl_Usuario" runat="server" Text="Usuario"></asp:Label></td><td> <asp:TextBox ID="txt_Usuario" runat="server" Width="120px" MaxLength="12" AutoComplete="off" ></asp:TextBox></td><td></td><td></td></tr> 
    <tr><td><asp:Label ID="lbl_Password" runat="server" Text="Password"></asp:Label></td><td> <asp:TextBox ID="txt_Password" runat="server" Width="120px" MaxLength="20" TextMode="Password" AutoComplete="off" ></asp:TextBox></td><td></td><td></td></tr> 
    <tr><td>&nbsp;</td><td> <asp:Button ID="btn_Ingresar" runat="server" 
            Text="Ingresar" onclick="btn_Ingresar_Click"/></td><td></td><td></td></tr> 
                
                       <%-- <tr>
                            <td align="left" style="width:400px; height:32px" colspan="2">
                                <asp:Label ID="Label2" runat="server" Text="Login" Font-Bold="True"></asp:Label>
                            </td>
                            <td align="left" style="width:200px">                            
                            </td>
                            <td style="width:200px">
                            </td>                                                
                            <td style="width:200px">
                            </td>
                        </tr>
                        <tr>
                            <td width="1000px" height="10px" valign="top" align="left" colspan="5">
                                <asp:Image ID="img_Linea" runat="server" Height="1px" Width="225px"
                                    ImageUrl="~/Imagenes/bg_titulo.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px; height:32px">
                                <asp:Label ID="lbl_Usuario" runat="server" Text="Usuario"></asp:Label>
                            </td>
                            <td align="left" style="width:300px; height:32px">                                
                                <asp:TextBox ID="txt_Usuario" runat="server" Width="120px" MaxLength="12"></asp:TextBox>
                            </td>
                            <td align="left" style="width:200px">                            
                            </td>
                            <td style="width:200px">
                            </td>                                                
                            <td style="width:200px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px; height:32px">
                                <asp:Label ID="lbl_Password" runat="server" Text="Password"></asp:Label>
                            </td>
                            <td align="left" style="width:300px; height:32px">                                
                                <asp:TextBox ID="txt_Password" runat="server" Width="120px" MaxLength="20" TextMode="Password"></asp:TextBox>                            
                            </td>
                            <td style="width:200px">                            
                            </td>
                            <td style="width:200px">
                            </td>
                            <td style="width:200px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px; height:32px">
                            </td>
                            <td align="left" style="width:300px; height:32px">                                
                                <asp:Button ID="btn_Ingresar" runat="server" Text="Ingresar" onclick="btn_Ingresar_Click" 
                                    />
                            </td>
                            <td style="width:200px">
                            </td>
                            <td style="width:200px">
                            </td>
                            <td style="width:200px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width:100px; height:32px">
                            </td>
                            <td style="width:900px; height:32px" colspan="4" align="left">                                
                                <asp:Label ID="lbl_Mensaje" runat="server" ForeColor="Red"></asp:Label>
                            </td>                                        
                        </tr>--%>
                       
    <tr><td>&nbsp;</td><td> <asp:Label ID="lbl_Mensaje" runat="server" ForeColor="Red"></asp:Label></td><td></td><td></td></tr> 
                
                       </table>
    
    </div>
    </form>
</body>
</html>
