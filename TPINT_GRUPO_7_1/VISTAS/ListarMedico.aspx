﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarMedicos.aspx.cs" Inherits="VISTAS.ListarMedicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body {
        margin: 0;
        font-family: Arial, sans-serif;
        background-color: #6CB2EB;
        }

        .header {
            background-color: #2C3E50;
            color: white;
            display: flex;
            justify-content: space-between;
            padding: 15px 20px;
            font-weight: bold;
            align-items: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <span>Menu Administrador</span>
            <span>Nombre Administrador</span>
        </div>
        <div id="contenedor">
            <h1>Listado de Medicos</h1>

            <div class="form-grupo">
                <label for="txtMedicos" style="font-size: x-large; font-style: inherit; color: #000000; font-weight: 100">Medicos:</label>
                <asp:TextBox ID="txtSucursal" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltrar" runat="server" CssClass="btn" Text="Filtrar" />
                <asp:Button ID="btnMostrarTodos" runat="server" CssClass="btn" Text="Mostrar todos" />
                <br />
                <br />
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                <br />
            </div>

            <div class="grid-container">
                <asp:GridView ID="grvMedicos" runat="server"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>