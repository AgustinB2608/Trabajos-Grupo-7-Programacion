<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnalisisPacientesCancelaciones.aspx.cs" Inherits="VISTAS.AnalisisPacientesCancelaciones" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <title>Análisis de Pacientes</title>
    <style>
        /* Estilos básicos para la tabla */
        .table {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
        }
        .table th, .table td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: center;
        }
        .table th {
            background-color: #f4f4f4;
            font-weight: bold;
        }
        .btn {
            padding: 10px 20px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        .btn:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Título -->
            <h1>Análisis de Pacientes con Alta Tasa de Cancelaciones</h1>
            
            <!-- Filtro de prioridad -->
            <label for="ddlPrioridad">Prioridad:</label>
            <asp:DropDownList ID="ddlPrioridad" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPrioridad_SelectedIndexChanged">
                <asp:ListItem Text="Alta" Value="Alta"></asp:ListItem>
                <asp:ListItem Text="Baja" Value="Baja"></asp:ListItem>
            </asp:DropDownList>

            <!-- Botón para actualizar -->
            <asp:Button ID="btnFiltrar" runat="server" CssClass="btn" Text="Filtrar" OnClick="btnFiltrar_Click" />

            <!-- Tabla de pacientes -->
        </div>
    </form>
</body>
</html>
