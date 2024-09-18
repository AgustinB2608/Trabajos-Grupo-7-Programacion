<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP4_Grupo_7.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Filtro de Productos</title>
    <style type="text/css">
        .container {
            display: flex;
            flex-direction: column;
            align-items: center;
            margin-top: 20px;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-group label {
            margin-right: 10px;
        }
        .form-group input,
        .form-group select {
            padding: 8px;
            margin-top: 5px;
            font-size: 14px;
        }
        .form-group input {
            width: 250px;
        }
        .form-group select {
            width: 120px;
        }
        .btn-container {
            margin: 20px;
        }
        .btn-container button {
            padding: 10px 20px;
            font-size: 14px;
            margin: 0 10px;
        }
        .miTabla {
            width: 80%;
            margin: 20px auto;
            border-collapse: collapse;
        }
        .miTabla th,
        .miTabla td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: center;
        }
        .miTabla th {
            background-color: #f4f4f4;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-group">
                <label for="ddlProducto">IdProducto:</label>
                <asp:DropDownList ID="ddlProducto" runat="server">
                    <asp:ListItem Value="1">Igual a:</asp:ListItem>
                    <asp:ListItem Value="2">Mayor a:</asp:ListItem>
                    <asp:ListItem Value="3">Menor a:</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtProducto" runat="server" CssClass="auto-style1"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="ddlCategoria">IdCategoria:</label>
                <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="true">
                    <asp:ListItem Value="1">Igual a:</asp:ListItem>
                    <asp:ListItem Value="2">Mayor a:</asp:ListItem>
                    <asp:ListItem Value="3">Menor a:</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtCategoria" runat="server"></asp:TextBox>
            </div>
            <div class="btn-container">
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
                <asp:Button ID="btnQuitar" runat="server" Text="Quitar Filtro" OnClick="btnQuitar_Click" />
            </div>
            <asp:GridView ID="GvProductos" runat="server" AutoGenerateColumns="False" CssClass="miTabla">
                <Columns>
                    <asp:BoundField DataField="IdProducto" HeaderText="ID" />
                    <asp:BoundField DataField="NombreProducto" HeaderText="Nombre Producto" />
                    <asp:BoundField DataField="IdCategoría" HeaderText="ID Categoría" />
                    <asp:BoundField DataField="CantidadPorUnidad" HeaderText="Cantidad x Unidad" />
                    <asp:BoundField DataField="PrecioUnidad" HeaderText="Precio Unidad" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
