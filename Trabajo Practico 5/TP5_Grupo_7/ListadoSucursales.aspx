<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursales.aspx.cs" Inherits="TP5_Grupo_7.ListadoSucursales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Listado de Sucursales - TP5 Grupo 7</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            text-align: center;
        }

        #contenedor {
            width: 80%;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.3);
            min-width:800px;

        }

        #titulo-grupo {
            font-size: 1rem;
            color: #555;
            margin-bottom: 10px;
            letter-spacing: 2px;
        }

        h1 {
            font-size: 1.6rem; 
            color: #333;
            margin-bottom: 20px; 
        }

        .form-grupo {
            margin-bottom: 15px;
            text-align: left; 
        }

        .form-grupo label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }

        .form-grupo input[type="text"] {
            width: 20%;
            padding: 5px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 0.8rem;
            box-sizing: border-box;
        }

        .form-grupo input[type="text"]:focus {
            border-color: #007bff;
            outline: none;
        }

        .btn {
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            font-size: 0.8rem;
            padding: 5px 10px;
            cursor: pointer;
        }

        .btn:hover {
            background-color: #0056b3;
        }

        #mensaje {
            margin-top: 20px;
            font-size: 0.8rem;
        }

        #links {
            display: flex;
            margin-bottom: 15px;
            justify-content:center;
        }

        #links a {
            color: #007bff;
            text-decoration: none;
            transition: color 0.3s ease;
            font-size: 0.8rem;
            margin: 0 2rem; 
        }

        #links a:hover {
            color: #0056b3;
        }

        .grid-container {
            max-height: 250px;
            overflow-y: auto; 
            border: 1px solid black;
        }

        #lblMensaje {
            margin-top: 5px;
            font-size: 0.8rem;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenedor"> 
            <div id="titulo-grupo">GRUPO N°7</div>
            <h1>Listado de sucursales</h1> 

            <div id="links">
                <asp:HyperLink ID="hplAgregarSucursal" runat="server" NavigateUrl="AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
                <asp:HyperLink ID="hplListarSucursales" runat="server" NavigateUrl="ListadoSucursales.aspx">Listado de sucursales</asp:HyperLink>
                <asp:HyperLink ID="hplEliminarSucursal" runat="server" NavigateUrl="EliminarSucursal.aspx">Eliminar Sucursal</asp:HyperLink>
            </div>
            <div class="form-grupo"> 
                <label for="txtSucursal">Sucursal:</label>
                <asp:TextBox ID="txtSucursal" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltrar" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Filtrar" />
                <asp:Button ID="btnMostrarTodos" runat="server" CssClass="btn" OnClick="btnMostrarTodos_Click" Text="Mostrar todos" />
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>

            </div>
            <div class="grid-container">
                <asp:GridView ID="grvSucursales" runat="server"></asp:GridView>
            </div>



        </div>
    </form>
</body>
</html>
