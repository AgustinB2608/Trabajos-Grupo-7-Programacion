<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioReportes.aspx.cs" Inherits="VISTAS.RealizarInformes" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Realizar Informes</title>
    <style>
        body {
            background-color: #add8e6;
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            flex-direction: column;
            min-height: 100vh;
        }
        header {
            background-color: #2C3E50;
            padding: 20px;
            color: white;
            display: flex;
            justify-content: space-between;
            align-items: center;
                       
        }
        .header h2 {
            margin: 0;
        }
        .container {
            flex: 1;
            margin: 20px auto;
            max-width: 800px;
            text-align: center;
        }
        .title {
            font-size: 24px;
            color: #333;
            margin-bottom: 20px;
        }
        .link {
            display: inline-block;
            width: 60%;
            padding: 10px 20px;
            margin: 10px auto;
            font-size: 16px;
            background-color: #6b6b6b;
            color: white;
            text-align: center;
            text-decoration: none;
            border-radius: 5px;
            transition: background-color 0.3s, transform 0.2s;
        }
        .link:hover {
            background-color: #505050;
            transform: translateY(-2px);
        }
        .footer {
            text-align: center;
            font-size: 14px;
            color: #333;
            padding: 15px;
            background-color: #f0f0f0;
        }
        .titulo {
            font-size: 24px;
            font-weight: bold;
        }
        .contenedor {
            flex: 1;
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 20px;
            min-height: calc(100vh - 80px);
        }
        .auto-style1 {
            height: 8px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <header >
        <div class="titulo">NovaVital</div>
        <asp:Label ID="lblUsuario" runat="server" Text="" class="titulo"/> <%--Nombre de usuario--%>
    </header>
        <div class="contenedor">
        <div class="container">
            <div class="title" style="font-weight: bold">Reportes</div>
            <!-- HyperLink 1 -->
            <asp:HyperLink
                ID="hlkEstadisticasComparativo"
                runat="server"
                CssClass="link"
                NavigateUrl="ReporteComparativoMensual.aspx"
                Text="Reporte de Asistencia y Ausencia: Comparativo Mensual"></asp:HyperLink>
            <!-- HyperLink 2 -->
          
            <asp:HyperLink
                ID="hlkAnalisisDemanda"
                runat="server"
                CssClass="link"
                NavigateUrl="ReporteMensualDemanda.aspx"
                Text="Reporte Mensual de Demanda por Especialidad"></asp:HyperLink>
            <!-- HyperLink 4 -->
            <!-- HyperLink Volver al Inicio -->
            <asp:HyperLink
                ID="hlkVolverInicio"
                runat="server"
                CssClass="link"
                NavigateUrl="InicioAdministrador.aspx"
                Text="Volver al Inicio"
                Style="background-color: #0056b3;"></asp:HyperLink>
        </div>
        </div>
    </form>
    <div class="footer">
        Todos los derechos reservados Grupo 7 | Sistema de Gestión Clínica
    </div>

</body>
</html>
