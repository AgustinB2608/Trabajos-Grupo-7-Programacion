<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarProductos.aspx.cs" Inherits="TP6_GRUPO_7.SeleccionarProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }

        /* Estilo para centrar el contenido*/
        .contenedor {
            width: 80%;
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        

        /* Estilo para el GridView */
        .grid-view {
            width: 100%;
            border-collapse: collapse;
            font-size: 14px;
        }

        .grid-view th, .grid-view td {
            border: 1px solid #000; 
            padding: 8px;
        }

        .grid-view th {
            background-color: #0033cc;
            color: white;
            text-align: center;
            font-weight: bold;
        }

        /* Estilo para el mensaje */
        .mensaje {
            margin-top: 20px;
            padding: 10px;
            border: 1px solid #000;
            font-size: 16px;
            text-align: center;
            border-radius: 5px;
            background-color: #f0f0f0;
        }

        /* Estilo para el enlace "Volver al Inicio" */
        .btn-volver {
            display: inline-block;
            padding: 10px 20px;
            background-color: #0033cc;
            color: white;
            text-decoration: none;
            border-radius: 5px;
            margin-top: 20px;
        }

        .btn-volver:hover {
            background-color: #002299;
        }

        /* Estilo para separar el mensaje del botón */
        .mensaje-container {
            text-align: center;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">

            <asp:GridView ID="gvProductos" runat="server" CssClass="grid-view" AllowPaging="True" 
                AutoGenerateColumns="False" DataKeyNames="IdProducto,NombreProducto,CantidadPorUnidad,PrecioUnidad"
                PageSize="14"   AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged" >
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

           <div class="mensaje-container">
                <div class="mensaje">
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </div>
                <asp:HyperLink ID="HLVolverInicio" runat="server" CssClass="btn-volver" NavigateUrl="~/Inicio.aspx">Volver al Inicio</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>

