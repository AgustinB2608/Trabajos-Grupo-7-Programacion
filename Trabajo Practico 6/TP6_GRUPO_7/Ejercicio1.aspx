﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP6_GRUPO_7.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Ejercicio Productos</title>
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

        /* Estilo para el título */
        .titulo {
            text-align: left;
            color: black;
            font-size: 2em;
            font-weight: bold;
            margin-bottom: 20px;
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
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <div class="titulo">
                <asp:Label ID="lblProductos" runat="server" Text="Productos"></asp:Label>
            </div>

            <asp:GridView ID="gvProductos" runat="server" CssClass="grid-view" AllowPaging="True" 
                AutoGenerateColumns="False" DataKeyNames="IdProducto" 
                OnRowCommand="gvProductos_RowCommand" OnPageIndexChanging="gvProductos_PageIndexChanging" 
                PageSize="10">

                <Columns>
                    <asp:TemplateField>
                       <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="EventoEdit" />
                             <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="EventoDelete" />
                       </ItemTemplate>
                    </asp:TemplateField>

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

            <div class="mensaje">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
