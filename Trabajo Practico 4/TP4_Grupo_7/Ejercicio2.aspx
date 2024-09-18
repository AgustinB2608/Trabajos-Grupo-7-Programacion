<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP4_Grupo_7.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Filtro de Productos</title>

    <style type="text/css">
        /*Estilos generales*/
        .contenedor {
            display: flex;
            flex-direction: column;
            align-items: center;
            margin-top: 20px;
        }
        /**/
        .grupo-formulario {
            margin-bottom: 15px;
        }
        /*Para que midan lo mismo seteo el ancho en 90px y lo alineo a la izq.*/
        .grupo-formulario label {
            display: inline-block;
            width: 90px; 
            text-align: left; 
        }
        /*Diseño input*/
        .grupo-formulario input {
            padding: 4px 0 4px 0;
            font-size: 14px;
        }
        /*Diseño del select*/
        .grupo-formulario select {
            padding: 4px 0 4px 0;
            font-size: 14px;
        }
        /*Estilos de los botones */
        .contenedor-botones {
            margin: 10px;
        }
        /*Centrado de la tabla*/
        .tabla {
            margin: 20px auto;
        }
        /* Estilos de la tabla */
        .tabla th,
        .tabla td {
            border: 1px solid black;
            padding: 4px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <div class="grupo-formulario">
                <label for="ddlProducto">ID Producto:</label>
                <asp:DropDownList ID="ddlProducto" runat="server">
                    <asp:ListItem Value="1">Igual a:</asp:ListItem>
                    <asp:ListItem Value="2">Mayor a:</asp:ListItem>
                    <asp:ListItem Value="3">Menor a:</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtProducto" runat="server"></asp:TextBox>
            </div>
            <div class="grupo-formulario">
                <label for="ddlCategoria">ID Categoria:</label>
                <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="true">
                    <asp:ListItem Value="1">Igual a:</asp:ListItem>
                    <asp:ListItem Value="2">Mayor a:</asp:ListItem>
                    <asp:ListItem Value="3">Menor a:</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtCategoria" runat="server"></asp:TextBox>
            </div>
            <div class="contenedor-botones">
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
                <asp:Button ID="btnQuitar" runat="server" Text="Quitar Filtro" OnClick="btnQuitar_Click" />
            </div>
            <!--GridView para mostrar los productos-->
            <asp:GridView ID="GvProductos" runat="server" AutoGenerateColumns="False" CssClass="tabla">
                <Columns>
                    <%--/*Columnas de la tabla*/--%>
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
