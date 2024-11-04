<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioAdministrador.aspx.cs" Inherits="VISTAS.InicioAdministrador" %>

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
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .menu-item {
            display: flex;
            align-items: center;
            margin-bottom: 20px;
        }

        .menu-item img {
            width: 50px;
            height: 50px;
            margin-right: 15px;
        }

        .menu-item a {
            text-decoration: none;
            color: #1565C0; 
            font-size: 18px;
            font-weight: bold;
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
            <span>Menu Administrador</span>
            <span>Nombre Administrador</span>
        </div>

        <div class="container">
            <h1>Sistema de Administración</h1>
            <div class="menu-box">
                <div class="menu-item">
                    <img src="Imgs/personal_injury_24dp_5F6368.jpg" alt="Paciente"/>
                    <asp:HyperLink ID="hlkAbmlPacientes" runat="server" NavigateUrl="~/ABMLPacientes.aspx">Altas Bajas Modificaciones Y Listado de Pacientes</asp:HyperLink>
                </div>
                <div class="menu-item">
                    <img src="Imgs/doctor.jpg" alt="Medico" />
                    <asp:HyperLink ID="hlkAbmlMedicos" runat="server" NavigateUrl="~/ABMLMedicos.aspx">Altas Bajas Modificaciones Y Listado de Medicos</asp:HyperLink>
                </div>
                <div class="menu-item">
                    <img src="Imgs/turno-nocturno.jpg" alt="Turno" />
                    <asp:HyperLink ID="hlkTurno" runat="server">Asignar Turno</asp:HyperLink>
                </div>
                <div class="menu-item">
                    <img src="Imgs/prescripcion-medica.jpg" alt="Informe" />
                    <asp:HyperLink ID="hlkInforme" runat="server" NavigateUrl="~/RealizarInformes.aspx">Realizar Informe</asp:HyperLink>
                </div>
            </div>

            <asp:HyperLink ID="hlkCerrarSesion" runat="server" NavigateUrl="~/Login.aspx" CssClass="logout-button">Cerrar sesión</asp:HyperLink>
        </div>
    </form>
</body>
</html>
