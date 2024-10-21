<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursales.aspx.cs" Inherits="VISTA.ListadoSucursales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Listado de Sucursales</title>

    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f0f4f8;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            text-align: center;
        }

        #contenedor {
            width: 80%;
            margin: 0 auto;
            padding: 30px;
            border: 1px solid #ddd;
            border-radius: 10px;
            box-shadow: 0 8px 24px rgba(0, 0, 0, 0.1);
            background-color: #fff;
            min-width: 800px;
        }

        #titulo-grupo {
            font-size: 1.5rem;
            margin-bottom: 10px;
            color: #333;
            text-transform: uppercase;
            letter-spacing: 1px;
        }

        h1 {
            margin-bottom: 20px;
            color: #007bff;
        }

        #links a {
            margin: 0 10px;
            text-decoration: none;
            color: #007bff;
            font-weight: bold;
        }

        #links a:hover {
            text-decoration: underline;
        }

        .form-grupo {
            margin-bottom: 20px;
        }

        .btn {
            margin: 5px;
            padding: 10px 15px;
            border: none;
            background-color: #007bff;
            color: #fff;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .btn:hover {
            background-color: #0056b3;
        }

        .grid-container {
            margin-top: 20px;
        }

        /* Estilos para el GridView */
        .grid-container table {
            width: 100%;
            border-collapse: collapse;
        }

        .grid-container th {
            background-color: #007bff;
            color: white;
            padding: 10px;
            text-align: left;
            border-bottom: 2px solid #0056b3;
        }

        .grid-container tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .grid-container tr:nth-child(odd) {
            background-color: #e9ecef;
        }

        .grid-container td {
            padding: 10px;
            border-bottom: 1px solid #ddd;
        }

        .grid-container tr:hover {
            background-color: #d6e9ff;
        }

        #lblMensaje {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenedor">
            <div id="titulo-grupo">GRUPO N°7</div>
            <h1>Listado de Sucursales</h1>

            <div id="links">
                <asp:HyperLink ID="hplAgregarSucursal" runat="server" NavigateUrl="AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
                <asp:HyperLink ID="hplListarSucursales" runat="server" NavigateUrl="ListadoSucursales.aspx">Listado de sucursales</asp:HyperLink>
                <asp:HyperLink ID="hplEliminarSucursal" runat="server" NavigateUrl="EliminarSucursal.aspx">Eliminar Sucursal</asp:HyperLink>
                <br />
                <br />
            </div>

            <div class="form-grupo">
                <label for="txtSucursal" style="font-size: x-large; font-style: inherit; color: #000000; font-weight: 100">Sucursal:</label>
                <asp:TextBox ID="txtSucursal" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltrar" runat="server" CssClass="btn" Text="Filtrar" OnClick="btnFiltrar_Click" />
                <asp:Button ID="btnMostrarTodos" runat="server" CssClass="btn" Text="Mostrar todos" OnClick="btnMostrarTodos_Click" />
                <br />
                <br />
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                <br />
            </div>

            <div class="grid-container">
                <asp:GridView ID="grvSucursales" runat="server"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
