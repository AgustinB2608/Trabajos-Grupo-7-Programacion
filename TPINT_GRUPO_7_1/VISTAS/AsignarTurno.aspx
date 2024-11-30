<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarTurno.aspx.cs" Inherits="VISTAS.AsignarTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Asignar Turno</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            margin: 0;
            padding: 0;
        }
        form {
            max-width: 800px;
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }
        h1 {
            text-align: center;
            color: #333;
            font-size: 24px;
            margin-bottom: 20px;
        }
        label {
            font-size: 14px;
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
            color: #555;
        }
        select, input[type="text"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 14px;
        }

        .button-container {
            text-align: center;
            margin-top: 20px;
        }

        #btnAsignar {
            background-color: #555;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        #btnAsignar:hover {
            background-color: #45a049;
        }

        #GridView1 {
            width: 100%;
            margin-top: 20px;
            border-collapse: collapse;
        }
        #GridView1 th, #GridView1 td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: left;
        }
        #GridView1 th {
            background-color: #f0f0f0;
        }
        .center {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblUsuario" runat="server" Text="" />
        <h1>Asignar Turno</h1>
        <label for="ddlMedico">Médico</label>
        <asp:DropDownList ID="ddlMedico" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMedico_SelectedIndexChanged">
        </asp:DropDownList>

        <label for="lblEspecialidad">Especialidad</label>
        <asp:DropDownList ID="ddlEspecialidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
        </asp:DropDownList>

        <label for="lblFecha">Fecha</label>
        <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>

        <label for="lblHorario">Horario de Atención</label>
        <asp:TextBox ID="txtHorario" runat="server" ReadOnly="true"></asp:TextBox>

        <label for="lblNombre">Nombre</label>
        <asp:TextBox ID="txtNombrePaciente" runat="server" Placeholder="Nombre del Paciente"></asp:TextBox>

        <label for="lblApellido">Apellido</label>
        <asp:TextBox ID="txtApellidoPaciente" runat="server" Placeholder="Apellido del Paciente"></asp:TextBox>

        <label for="lblDni">Dni</label>
        <asp:TextBox ID="txtDniPaciente" runat="server" Placeholder="DNI del Paciente"></asp:TextBox>


        <label for="lblHorario">Turnos Disponibles | hs</label>
        <asp:DropDownList ID="ddlHoraAsignada" runat="server" AutoPostBack="True" ></asp:DropDownList>

        <label for="lblEstado">Estado</label>
        <asp:TextBox ID="txtEstado" runat="server" Placeholder="Pendiente" ReadOnly="true"></asp:TextBox>

        <div class="button-container">
            <asp:Button ID="btnAsignar" runat="server" Text="Asignar" OnClick="btnAsignar_Click" />
        </div>
        <div class="error-message">
            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" />
        </div>
        <div class="exito-message">
            <asp:Label ID="lblExito" runat="server" Text="" ForeColor="Green" />
        </div>
        <h1 class="center">Turnos Asignados</h1>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
