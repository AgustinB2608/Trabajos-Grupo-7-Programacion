<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RealizarInformes.aspx.cs" Inherits="VISTAS.RealizarInformes" %>

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
            position: relative;
        }

        .header img {
            height: 20px; 
            width: auto; 
            vertical-align: middle; 
            color: white;
        }

        .admin-button {
            display: flex;
            align-items: center;
            font-size: 14px;
            color: white;
            background-color: transparent;
            border: none;
            cursor: pointer;
        }

        .admin-button img {
            height: 15px;
            margin-right: 5px;
        }

        .container {
            text-align: center;
            padding: 20px;
        }

        h1 {
            width: 271px;
            height: 55px;
            flex-shrink: 0;
            border-radius: 10px;
            background: var(--Background-Disabled-Default, #D9D9D9);
            color: #FFF;
        }
        
        .menu-box {
            width: 70%;
            margin: 0 auto;
            flex-shrink: 0;
        }

        .menu-item {
            background-color: #807979;
            color: white;
            border-radius: 10px;
            padding: 15px;
            margin: 10px 0;
            font-size: 20px;
            font-weight: bold;
            cursor: pointer;
            text-align: left;
            display: flex;
            align-content: center;
            justify-content: center;
        }

        .menu-item:hover {
            background-color: #3A3A3A;
        }

        .menu-item a {
            color: white;
            text-decoration: none;
            width: 100%;
            text-align: center;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <asp:HyperLink ID="hlkVolverAtras" runat="server" NavigateUrl="~/InicioAdministrador.aspx" ImageUrl="~/imgs/flecha-izquierda.png">&lt;-</asp:HyperLink>
            <span>Nombre Administrador</span>
        </div>
        
        <div class="container">
            <h1 >Informes</h1>

            <div class="menu-box">
                <div class="menu-item">
                    <asp:HyperLink ID="hlkComparativoMensual" runat="server" NavigateUrl="~/EstadisticaMensual.aspx">Estadísticas de Asistencia y Ausencia: Comparativo Mensual</asp:HyperLink>
                </div>
                <div class="menu-item">
                    <asp:HyperLink ID="hlkEspecialidad" runat="server" NavigateUrl="~/EstadisticaEspecialidad.aspx">Estadística Mensual de Asistencia y Ausencia: Especialidad</asp:HyperLink>
                </div>
                <div class="menu-item">
                    <asp:HyperLink ID="hlkDemandaMensual" runat="server" NavigateUrl="~/EstadisticaDemanda.aspx">Análisis Mensual de Demanda por Especialidad</asp:HyperLink>
                </div>
                <div class="menu-item">
                    <asp:HyperLink ID="hlkCancelaciones" runat="server">Análisis de Pacientes con Alta Tasa de Cancelaciones</asp:HyperLink>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
