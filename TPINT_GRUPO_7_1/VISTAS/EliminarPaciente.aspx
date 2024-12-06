<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarPaciente.aspx.cs" Inherits="VISTAS.EliminarPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Eliminar Paciente</title>
    <style>
    body {
        margin: 0;
        font-family: Arial, sans-serif;
        background-color: #f4f4f9;
    }

    .header {
        background-color: #2C3E50;
        color: white;
        display: flex;
        justify-content: space-between;
        padding: 15px 20px;
        font-size: 1.2rem;
        align-items: center;
    }

    .contenedor {
        max-width: 800px;
        margin: 20px auto;
        background: #ffffff;
        padding: 20px;
        border-radius: 10px;
        box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
    }

    .titulo-pagina h1 {
        text-align: center;
        color: #333;
    }

    .formulario-eliminacion {
        margin: 20px 0;
        text-align: center;
    }

    .formulario-eliminacion label {
        font-size: 1rem;
        color: #333;
    }

    .textbox {
        width: 200px;
        padding: 10px;
        margin: 10px;
        border: 1px solid #ccc;
        border-radius: 5px;
        font-size: 1rem;
    }

    .textbox:focus {
        border-color: #3490dc;
        outline: none;
    }

    .btn {
        padding: 10px 20px;
        margin: 10px;
        background-color: #3490dc;
        color: white;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        font-size: 1rem;
    }

    .btn:hover {
        background-color: #2779bd;
    }

    .mensaje {
        text-align: center;
        margin-top: 20px;
    }

    .confirmacion {
        text-align: center;
        margin: 20px 0;
    }

    .info-paciente {
        margin: 20px 0;
    }

    .grid-view {
        width: 100%;
        border-collapse: collapse;
    }

    .grid-view th,
    .grid-view td {
        border: 1px solid #ddd;
        padding: 10px;
        text-align: left;
    }

    .grid-view th {
        background-color: #3490dc;
        color: white;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
        <!-- Encabezado -->
        <div class="header">
            <div class="titulo">Eliminar Paciente</div>
            <asp:Label ID="lblUsuario" runat="server" Text="" />
        </div>

        <!-- Contenedor principal -->
        <div class="contenedor">
            <!-- Título -->
            <div class="titulo-pagina">
                <h1>Eliminar Paciente</h1>
            </div>

            <!-- Formulario de eliminación -->
            <div class="formulario-eliminacion">
                <asp:Label ID="lblEliminar" runat="server" Text="Ingrese el código del Paciente o DNI:" />
                <br /><br />
                <asp:TextBox ID="txtEliminar" runat="server" CssClass="textbox" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn" OnClick="btnEliminar_Click" />
                <asp:Button ID="btnAtras" runat="server" Text="Atrás" CssClass="btn" PostBackUrl="~/ABMLPacientes.aspx" />
            </div>

            <!-- Mensaje -->
            <div class="mensaje">
                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
            </div>

            <!-- Confirmación -->
            <div class="confirmacion">
                <asp:Button ID="btnConfirmarEliminar" runat="server" Text="Confirmar" CssClass="btn" OnClick="btnConfirmarEliminar_Click" />
            </div>

            <!-- Información del paciente -->
            <div class="info-paciente">
                <asp:GridView ID="gvPacienteInfo" runat="server" CssClass="grid-view" />
            </div>
        </div>
    </form>
</body>
</html>
