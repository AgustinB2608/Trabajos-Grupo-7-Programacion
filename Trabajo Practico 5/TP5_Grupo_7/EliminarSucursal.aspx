﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarSucursal.aspx.cs" Inherits="TP5_Grupo_7.EliminarSucursal" UnobtrusiveValidationMode="None"%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Eliminar Sucursal</title>

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
            padding: 60px 70px;
            border: 1px solid #ccc;
            border-radius: 10px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.3);
            max-height:250px;
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
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 1rem;
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
            font-size: 1rem;
            padding: 10px 20px;
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
            justify-content: space-between;
            margin-bottom: 15px;
        }

        #links a {
            color: #007bff;
            text-decoration: none;
            transition: color 0.3s ease;
            font-size: 0.8rem;
        }

        #links a:hover {
            color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenedor">
            <div id="titulo-grupo">GRUPO N°7</div>
            <h1>Eliminar Sucursal</h1>

            <div id="links">
                <asp:HyperLink ID="hplAgregarSucursal" runat="server" NavigateUrl="AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
                <asp:HyperLink ID="hplListarSucursales" runat="server" NavigateUrl="ListadoSucursales.aspx">Listado de Sucursales</asp:HyperLink>
                <asp:HyperLink ID="hplEliminarSucursal" runat="server" NavigateUrl="EliminarSucursal.aspx">Eliminar Sucursal</asp:HyperLink>
            </div>

            <div class="form-grupo">
                <label for="txtID">Ingresar ID sucursal:</label>
                <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revID" runat="server" ControlToValidate="txtID" ErrorMessage="Ingrese solo números" ValidationExpression="^[0-9]*$" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>

            <asp:Button ID="btnEliminar" runat="server" CssClass="btn" Text="Eliminar" OnClick="btnEliminar_Click" />

            <div id="mensaje">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>