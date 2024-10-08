<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarProductos.aspx.cs" Inherits="TP6_GRUPO_7.MostrarProductos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Mostrar Productos</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            background-color: #f4f4f4;
        }

        .container {
            background-color: white;
            padding: 20px;
            border: 2px solid #007BFF;
            border-radius: 10px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.3);
            text-align: center;
            width: 600px;
        }

        h1 {
            font-size: 2em;
            color: black;
        }

        .gridview {
            margin: 20px 0;
            width: 100%;
            border-collapse: collapse;
        }

        .gridview th, .gridview td {
            border: 1px solid #007BFF;
            padding: 10px;
            text-align: center;
        }

        .gridview th {
            background-color: #007BFF;
            color: white;
        }

        .gridview td {
            background-color: #f9f9f9;
        }

        .btn {
            text-decoration: none;
            font-size: 1.2em;
            color: #007BFF;
            display: block;
            padding: 10px;
            border: 1px solid #007BFF;
            border-radius: 5px;
            width: 150px;
            margin: 20px auto 0 auto;
            transition: background-color 0.3s, color 0.3s;
        }

        .btn:hover {
            background-color: #007BFF;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Productos seleccionados</h1>

            <asp:GridView ID="GridView1" runat="server" CssClass="gridview">
            </asp:GridView>

            <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="red"></asp:Label>

            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Inicio.aspx" CssClass="btn">Volver al inicio</asp:HyperLink>
        </div>
    </form>
</body>
</html>
