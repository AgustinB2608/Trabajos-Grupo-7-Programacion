<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarTurno.aspx.cs" Inherits="VISTAS.AsignarTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Asignar Turno</title>
    <style>
        :root {
            --color-fondo: #6CB2EB; /* Color Fondo */
            --color-header: #2C3E50; /* Color fondo encabezado*/
            --color-boton: #3490dc; /* Color boton*/
            --color-boton-hover: #2779bd; /* Color boton 2 hover */
            --color-textbox: #ddd;
            --color-error: #ff6347; /* Color de texto de error */
            --color-fondo-error: #f8d7da; /* Fondo del error */
            --radio-borde: 8px; /* Radio de borde general */
        }

        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: Arial, sans-serif;
        }

        html, body {
            height: 100%;
        }

        body {
            /*font-family: Arial, sans-serif;*/
            /*background-color: #f4f4f9;*/
            /*margin: 0; /* Elimina márgenes predeterminados */
            /*padding: 0;*/
            /*box-sizing: border-box; /* Manejo correcto de márgenes y rellenos */
            background-color: var(--color-fondo);
            display: flex;
            flex-direction: column;
        }
        form {
            width: 50%; /* Ancho relativo al viewport */
            max-width: 1000px; /* Permitir mayor ancho máximo */
            /*max-width: 800px;*/
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }

        header {
            margin: 0; /* Elimina márgenes del header */
            display: flex;
            justify-content: space-between;
            align-items: center;
            width: 100vw;
            box-sizing: border-box;
            
            background-color: var(--color-header);
            padding: 20px;
            color: white;
        
        }

        .titulo {
            font-size: 24px;
            font-weight: bold;
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
        * {
            margin: 0; /* Elimina márgenes de todos los elementos */
            padding: 0; /* Elimina padding de todos los elementos */
            box-sizing: border-box; /* Mejora el manejo de dimensiones */
        }

        html, body {
            margin: 0; /* Asegura que no haya margen en todo el documento */
            padding: 0;
            height: 100%; /* Ocupa todo el alto de la ventana */
        }

    </style>
</head>
<body>
         <header>
             <div class="titulo">NovaVital</div>
             <asp:Label ID="lblUsuario" runat="server" class="titulo" />
        </header>
    <form id="form1" runat="server">
        <h1>Asignar Turno</h1>
        <label for="lblEspecialidad">Especialidad</label>
        <asp:DropDownList ID="ddlEspecialidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
        </asp:DropDownList>

        <label for="ddlMedico">Médico</label>
        <asp:DropDownList ID="ddlMedico" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMedico_SelectedIndexChanged">
        </asp:DropDownList>

        <label for="lblHorario">Horario y días de Atención</label>
        <asp:TextBox ID="txtHorario" runat="server" ReadOnly="true"></asp:TextBox>

        <label for="lblNombre">Nombre</label>
        <asp:TextBox ID="txtNombrePaciente" runat="server" Placeholder="Nombre del Paciente"></asp:TextBox>

        <label for="lblApellido">Apellido</label>
        <asp:TextBox ID="txtApellidoPaciente" runat="server" Placeholder="Apellido del Paciente"></asp:TextBox>

        <label for="lblDni">Dni</label>
        <asp:TextBox ID="txtDniPaciente" runat="server" Placeholder="DNI del Paciente"></asp:TextBox>

        <label for="lblFecha">Fecha</label>
        <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>

        <label for="lblHorario">Turnos Disponibles | hs</label>
        <asp:DropDownList ID="ddlHoraAsignada" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlHoraAsignada_SelectedIndexChanged" ></asp:DropDownList>
        <div class="error-message">
        <label for="lblMensaje"></label>

        <asp:Label ID="lblTurnoOcupado" runat="server" ForeColor="Red" Font-Size="Medium" />
        <label for="lblEstado">
            <br />
            Estado</label>
        <asp:TextBox ID="txtEstado" runat="server" Placeholder="Pendiente" ReadOnly="true"></asp:TextBox>

        <div class="button-container">
            <asp:Button ID="btnAsignar" runat="server" Text="Asignar" OnClick="btnAsignar_Click" />
        </div>
        <div class="error-message">
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Font-Size="Large" />
        </div>
</div>
        </form>
</body>
</html>
