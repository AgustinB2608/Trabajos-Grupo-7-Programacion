<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstadisticaMensualEspecialidad.aspx.cs" Inherits="VISTAS.EstadisticaMensualEspecialidad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Estadísticas de Asistencia y Ausencia</title>
    <style>
        /* Estilos básicos */
        .table {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
        }

        .table th, .table td {
            border: 1px solid #ddd;
            padding: 10px;
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

        h1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 20px;">
            <!-- Título -->
            <h1>Estadísticas de Asistencia y Ausencia: Comparativo Mensual Por Especialidad</h1>

            <!-- Selección de mes -->
            <div style="text-align: center; margin-bottom: 20px;">
                <label for="ddlMes">MES:</label>
                <asp:DropDownList ID="ddlMes" runat="server">
                </asp:DropDownList>
            </div>

            <!-- Tabla -->
            <table class="table">
                <thead>
                    <tr>
                        <th>AUSENCIAS: </th>
                        <th>ASISTENCIAS: </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <!-- GridView para mostrar ausencias -->
                            <asp:GridView ID="gvAusencias" runat="server" AutoGenerateColumns="False" CssClass="table">
                                <Columns>
                                    <asp:TemplateField HeaderText="%"></asp:TemplateField>
                                    <asp:TemplateField HeaderText="Especialidad"></asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td>
                            <!-- GridView para mostrar asistencias -->
                            <asp:GridView ID="gvAsistencias" runat="server" AutoGenerateColumns="False" CssClass="table">
                                <Columns>
                                    <asp:TemplateField HeaderText="%"></asp:TemplateField>
                                    <asp:TemplateField HeaderText="Especialidad"></asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

