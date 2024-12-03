<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RealizarInformes.aspx.cs" Inherits="VISTAS.RealizarInformes" %>

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
        .header {
            background-color: #2a2a2a;
            color: white;
            padding: 15px;
            text-align: left;
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
    </style>
</head>
<body>
    <div class="header">
        <h2>Nombre Administrador</h2>
    </div>
    <form id="form1" runat="server">
        <div class="container">
            <div class="title">Informes</div>
            <!-- HyperLink 1 -->
            <asp:HyperLink
                ID="hlkEstadisticasComparativo"
                runat="server"
                CssClass="link"
                NavigateUrl="EstadisticasComparativoMensual.aspx"
                Text="Estadísticas de Asistencia y Ausencia: Comparativo Mensual"></asp:HyperLink>
            <!-- HyperLink 2 -->
            <asp:HyperLink
                ID="hlkEstadisticasEspecialidad"
                runat="server"
                CssClass="link"
                NavigateUrl="EstadisticaMensualEspecialidad.aspx"
                Text="Estadística Mensual de Asistencia y Ausencia: Especialidad"></asp:HyperLink>
            <!-- HyperLink 3 -->
            <asp:HyperLink
                ID="hlkAnalisisDemanda"
                runat="server"
                CssClass="link"
                NavigateUrl="AnalisisMensualDemanda.aspx"
                Text="Análisis Mensual de Demanda por Especialidad"></asp:HyperLink>
            <!-- HyperLink 4 -->
            <asp:HyperLink
                ID="hlkAnalisisCancelaciones"
                runat="server"
                CssClass="link"
                NavigateUrl="AnalisisPacientesCancelaciones.aspx"
                Text="Análisis de Pacientes con Alta Tasa de Cancelaciones"></asp:HyperLink>
            <!-- HyperLink Volver al Inicio -->
            <asp:HyperLink
                ID="hlkVolverInicio"
                runat="server"
                CssClass="link"
                NavigateUrl="Inicio.aspx"
                Text="Volver al Inicio"
                Style="background-color: #0056b3;"></asp:HyperLink>
        </div>
    </form>
    <div class="footer">
        Todos los derechos reservados Grupo 7 | Sistema de Gestión Clínica
    </div>
</body>
</html>
