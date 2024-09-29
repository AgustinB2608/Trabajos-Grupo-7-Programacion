<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP6_GRUPO_7.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblProductos" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Productos"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="gvProductos" runat="server" CssClass="grid-view" AllowPaging="True" AutoGenerateColumns="False"  DataKeyNames="IdProducto,NombreProducto,CantidadPorUnidad,PrecioUnidad" >
            <Columns>
                <asp:TemplateField HeaderText="Id Producto">
                    <ItemTemplate>
                        <asp:Label ID="lblIdProducto" runat="server" Text='<%# Bind("IdProducto") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre Producto">
                    <ItemTemplate>
                        <asp:Label ID="lblNombreProducto" runat="server" Text='<%# Bind("NombreProducto") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cantidad Por Unidad">
                    <ItemTemplate>
                        <asp:Label ID="lblCantidadPorUnidad" runat="server" Text='<%# Bind("CantidadPorUnidad") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Precio Unidad">
                    <ItemTemplate>
                        <asp:Label ID="lblPrecioUnidad" runat="server" Text='<%# Bind("PrecioUnidad") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
    </form>
</body>
</html>
