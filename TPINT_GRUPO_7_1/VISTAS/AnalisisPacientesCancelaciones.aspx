<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnalisisPacientesCancelaciones.aspx.cs" Inherits="VISTAS.AnalisisPacientesCancelaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Analisis de Pacientes Con Cancelaciones</title>
    <style>
        /* Estilos básicos */
        .table {
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
            <h1>Analisis de Pacientes Con Cancelaciones</h1>

            <!-- Selección de mes -->
        

            <!-- Tabla -->
            <table class="table">
                <thead>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <!-- GridView para mostrar ausencias -->
                            <asp:GridView ID="gvEspecialidad" runat="server" AutoGenerateColumns="False" CssClass="table" Width="1168px">
                                <Columns>
                                    <asp:TemplateField HeaderText="%"></asp:TemplateField>
                                    <asp:TemplateField HeaderText="Paciente"></asp:TemplateField>
                                    <asp:TemplateField HeaderText="Turnos Asignados"></asp:TemplateField>
                                    <asp:TemplateField HeaderText="Turnos Cancelados"></asp:TemplateField>
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


