<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AgenciaAutos.Presentacion.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Marca</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtMarca"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Precio</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPrecio"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" ID="btnInsertar" Text="Agregar Auto" OnClick="btnInsertar_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView runat="server" ID="grvAutos" AutoGenerateColumns="false" DataKeyNames="AutoId" AllowPaging="true"
                            Pagesize="1" OnRowDeleting="grvAutos_RowDeleting"
                            OnRowCancelingEdit="grvAutos_RowCancelingEdit" OnRowEditing="grvAutos_RowEditing" OnRowUpdating="grvAutos_RowUpdating" 
                            OnPageIndexChanging="grvAutos_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="Marca">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMarca" runat="server" Text='<%#Bind("Marca")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEditMarca" runat="server" Text='<%#Bind("Marca")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Precio">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrecio" runat="server" Text='<%#Bind("Precio")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEditPrecio" runat="server" Text='<%#Bind("Precio")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comprar">
                                    <ItemTemplate>
                                        <asp:Button ID="btnComprar" runat="server" Text="Comprar" OnClick="btnComprar_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkEliminar" runat="server" Text="Eliminar" CommandName="Delete"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="linkEditar" runat="server" Text="Editar" CommandName="Edit"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
