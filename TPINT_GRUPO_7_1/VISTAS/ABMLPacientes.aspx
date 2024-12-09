<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMLPacientes.aspx.cs" Inherits="VISTAS.ABMLPacientes1" %>

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

        /* Header */
        .header {
            background-color: #2C3E50;
            color: white;
            display: flex;
            justify-content: space-between;
            padding: 15px 20px;
            font-weight: bold;
            align-items: center;
        }

        .titulo {
            font-size: 24px;
            font-weight: bold;
        }

        /* Container */
        .container {
            text-align: center;
            padding: 20px;
        }

        h1 {
            color: white;
        }

        /* Menu Box */
        .menu-box {
            background-color: white;
            border-radius: 10px;
            border: 1px solid gray;
            padding: 20px;
            width: 50%;
            margin: 0 auto;
            text-align: center;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .menu-item {
            margin-bottom: 20px;
            text-align: center; /* Asegura que los elementos dentro estén centrados */
        }

        .menu-item a {
            text-decoration: none;
            color: #1565C0;
            font-size: 18px;
            font-weight: bold;
            display: inline-block; /* Asegura que los enlaces se comporten como bloques alineados */
            text-align: center;
        }

        .logout-button {
            margin-top: 20px;
            padding: 10px 20px;
            background-color: white;
            color: #4A90E2;
            border: 1px solid #808080;
            border-radius: 10px;
            cursor: pointer;
            text-decoration: none;
            display: inline-block;
        }
    </style>
    

</head>
<body>
    <form id="form1" runat="server">
         <div class="header">
            <div class="titulo">NovaVital</div>
            <asp:Label ID="lblUsuario" runat="server" />
        </div>
        
        <div class="container">
            <h1>Sistema de Administración</h1>
            <div class="menu-box">
                <div class="menu-item">
                    <asp:HyperLink ID="hlkAñadirPaciente" runat="server" NavigateUrl="~/AñadirPaciente.aspx">Agregar Paciente</asp:HyperLink>
                </div>
                <div class="menu-item">
                    <asp:HyperLink ID="hlkEliminarPaciente" runat="server" NavigateUrl="~/EliminarPaciente.aspx">Eliminar Paciente</asp:HyperLink>
                </div>
                <div class="menu-item">
                    <asp:HyperLink ID="hlkModificarPaciente" runat="server" NavigateUrl="~/ModificarPaciente.aspx">Modificar Paciente</asp:HyperLink>
                </div>
                <div class="menu-item">
                    <asp:HyperLink ID="hlkListarPaciente" runat="server" NavigateUrl="~/ListarPaciente.aspx">Listar Paciente</asp:HyperLink>
                </div>
            </div>

            <asp:HyperLink ID="hlkVolverAtras" runat="server" NavigateUrl="~/InicioAdministrador.aspx" CssClass="logout-button">Volver Atras</asp:HyperLink>
        </div>
    </form>
</body>
</html>
