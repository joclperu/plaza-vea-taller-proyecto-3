<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCandidato.master" AutoEventWireup="true" CodeFile="SPV_ListarConvocatorias.aspx.cs" Inherits="SPV_Proveedores_SPV_ListarConvocatorias" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   
        <asp:Panel ID="pnlBusqueda" runat="server" CssClass="panel" Width="100%">
       
                <table width="98%">
                    <tr>
                        <td class="tituloPagina">
                            Convocatorias</td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td colspan="6">
                                        <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label></td>
                                </tr>
                                <tr style="color: #000000">
                                    <td colspan="2">
                                        Tipo:<asp:DropDownList ID="ddlTipoConvocatoria" runat="server">
                                            <asp:ListItem Value="0">Todos..</asp:ListItem>
                                            <asp:ListItem Value="1">Producto</asp:ListItem>
                                            <asp:ListItem Value="2">Servicio</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    <td colspan="2">
                                        &nbsp;Fecha Iniciio<asp:TextBox ID="txtFechaInicio" runat="server" MaxLength="10" Width="90px"></asp:TextBox>
                                        </td>
                                    <td align="right">
                                        Fecha fin<asp:TextBox ID="txtFechaFin" runat="server" MaxLength="10" Width="90px"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        Categoria:<asp:DropDownList ID="ddlCategoria" runat="server" Width="143px">
                                        </asp:DropDownList>
                                        <asp:Button ID="btnBuscar" runat="server" CssClass="boton"  CausesValidation="false"
                                            Text="Buscar" OnClick="btnBuscar_Click" /></td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:GridView ID="gdvConvocatorias" runat="server" AutoGenerateColumns="False" CssClass="grillaDatos"
                                            EmptyDataText="Ninguna atención encontrada para los codigos ingresados." Width="100%" OnSelectedIndexChanged="gdvConvocatorias_SelectedIndexChanged" >
                                            <Columns>
                                                <asp:BoundField DataField="CODIGO" HeaderText="CODIGO"  />
                                                 <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION"  />
                                                 <asp:BoundField DataField="FECHA INICIO" HeaderText="FECHA INICIO"  />
                                                 <asp:BoundField DataField="FECHA FIN" HeaderText="FECHA FIN"  />
                                                 <asp:BoundField DataField="CATEGORIA PRODUCTO" HeaderText="CATEGORIA PRODUCTO"  />
                                            <asp:CommandField SelectText="agregar propuesta" ShowSelectButton="True" 
                                                        HeaderText="Borrar" />
                                            </Columns>



                                            
                                        </asp:GridView>
                                     
                                         </td>
                                </tr>
                            </table>
                            
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 400px">
                            <asp:Panel ID="pnlRegistrarPropuesta" runat="server"  GroupingText="Registrar propuesta"
                                Width="50%" BackColor="#FFCC99">
                                <table width="50%">
                                    <tr>
                                        <td width="25%" colspan="4" style="width: 50%">
                                            <asp:Label ID="lblmsjeModal" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="25%">&nbsp;</td>
                                        <td style="width: 25%">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td width="25%">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="25%">Codigo Convocatoria: </td>
                                        <td style="width: 25%">
                                            <asp:TextBox ID="txtConvocatoria" runat="server" MaxLength="50"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td width="25%">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="25%">
                                            Fecha:
                                            </td>
                                        <td>
                                            <asp:TextBox ID="txtFecha" runat="server" MaxLength="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td width="25%">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="25%">
                                            Descripcion:
                                            </td>
                                        <td>
                                            <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="50" Width="220px"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td width="25%">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="25%">Categoria Producto</td>
                                        <td>
                                            <asp:TextBox ID="txtCategoriaProducto" runat="server" MaxLength="50" Width="119px"></asp:TextBox>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="~/SPV_Proveedores/Politicas/RH_SergioLapa.pdf">DescargarPolítica</asp:HyperLink>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td width="25%">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="25%">Candidato</td>
                                        <td>
                                            <asp:TextBox ID="txtCandidato" runat="server" MaxLength="50"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td width="25%">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="25%">Ruc</td>
                                        <td>
                                            <asp:TextBox ID="txtRuc" runat="server" MaxLength="50"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td width="25%">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="25%">Razon Social</td>
                                        <td>
                                            <asp:TextBox ID="txtRazonSocial" runat="server" MaxLength="50" Width="220px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td width="25%">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="25%">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td width="25%">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="25%">Propuesta</td>
                                        <td>
                                            <asp:FileUpload ID="fupPropuesta" runat="server" />
                                        </td>
                                        <td>&nbsp;</td>
                                        <td width="25%">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="25%">Monto</td>
                                        <td>
                                            <asp:TextBox ID="txtMonto" runat="server" MaxLength="50" Width="118px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td width="25%">&nbsp;</td>
                                    </tr>
                                     <tr>
                                        <td width="25%"><asp:Button ID="btnMensajeConfirm1" runat="server" 
                        style="DISPLAY: none; VISIBILITY: visible" Text="MENSAJE" /></td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td width="25%">&nbsp;</td>
                                    </tr>

          

                                    
                                    <tr>
                                        <td colspan="4" style="width: 50%" width="25%">
                                            <asp:Button ID="btnGrabar0" runat="server" CssClass="boton" Text="Grabar" Width="162px" OnClick="btnGrabar0_Click" />
                                            <asp:Button ID="btnCancelar0" runat="server" CssClass="boton" Text="Cancelar" Width="162px" />
                                        </td>
                                    </tr>

                                    
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                
        
             <cc1:ModalPopupExtender ID="mpeRegistrarPropuesta" runat="server" BackgroundCssClass="modalBackground"
             PopupControlID="pnlRegistrarPropuesta" TargetControlID="btnMensajeConfirm1"> 
            
        </cc1:ModalPopupExtender>

        </asp:Panel>
                             


</asp:Content>

