<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP6_GRUPO_7.Ejercicio2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Ejercicio 2 </title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .container {
            padding: 20px;
            border: 2px solid #007BFF;
            border-radius: 10px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.3);
            text-align: center;
            width: 400px;
        }

        h1 {
            font-size: 2em;
            color: black;
            margin: 0;
        }

        nav ul {
            list-style-type: none;
            padding: 0;
        }

        nav ul li {
            margin: 10px 0;
        }

        nav a, .action-button {
            text-decoration: none;
            font-size: 1.2em;
            color: #007BFF;
            display: block;
            padding: 10px;
            border: 1px solid #007BFF;
            border-radius: 5px;
            transition: background-color 0.3s, color 0.3s;
            text-align: center;
        }

        nav a:hover, .action-button:hover {
            background-color: #007BFF;
            color: white;
        }

        /* Estilo para el Label*/
        .mensaje {
            margin-top: 20px;
            color: Green; 
            display: block; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>INICIO</h1>

            <nav>
                <ul>
                    <li><asp:HyperLink ID="HLSeleccionar" runat="server" NavigateUrl="~/SeleccionarProductos.aspx">Seleccionar Productos</asp:HyperLink></li>
                    <li><asp:LinkButton ID="LBEliminar" runat="server" CssClass="action-button" OnClick="LBEliminar_Click">Eliminar Productos Seleccionados</asp:LinkButton></li>
                    <li><asp:HyperLink ID="HLMostrar" runat="server" NavigateUrl="~/MostrarProductos.aspx">Mostrar Producto</asp:HyperLink></li>
                </ul>
            </nav>
            <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje"></asp:Label>
        </div>
    </form>
</body>
</html>
