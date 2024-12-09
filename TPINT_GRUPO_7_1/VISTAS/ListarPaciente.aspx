<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarPaciente.aspx.cs" Inherits="VISTAS.ListarPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listar Paciente</title>
   <style>
   body {
    background-color: #6CB2EB; /* Color azul del fondo */
    margin: 0;                 /* Elimina los márgenes por defecto del body */
    font-family: Arial, sans-serif; /* Define una fuente por defecto */
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
            font-size: 24px;
            font-weight: bold;
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

    .titulo {
            font-size: 24px;
            font-weight: bold;
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

    /* Contenedor del GridView */
.grid-container {
    overflow-x: auto;    /* Agrega scroll horizontal si el contenido excede el ancho */
    margin-top: 20px;    /* Espacio superior para separación */
}

/* GridView */
.grid-view {
    width: 100%;         /* Hace que el GridView use el 100% del ancho del contenedor */
    min-width: 900px;    /* Ancho mínimo para evitar que las columnas se compriman demasiado */
    border-collapse: collapse;
}

/* Encabezado de la tabla */
.grid-view th {
    background-color: #3490dc;
    color: white;
    padding: 10px;
}

/* Celdas de la tabla */
.grid-view td {
    padding: 10px;
    border: 1px solid #ddd;
}
</style>

</head>
<body>
    <form id="form1" runat="server">
        <!-- Encabezado -->
        <div class="header">
            <div class="titulo">NovaVital</div>
            <asp:Label ID="lblUsuario" runat="server" />
        </div>

        <!-- Contenedor principal -->
        <div class="contenedor">
            <h1>Listar Paciente</h1>
            
            <!-- Formulario de búsqueda -->
            <div class="form-grupo">
                <label for="txtListar" class="label">Ingrese el DNI del paciente:</label>
                <asp:TextBox ID="txtListar" runat="server" CssClass="textbox" Width="200px" />
                <asp:Button ID="btnFiltrar" runat="server" CssClass="btn" Text="Filtrar" OnClick="btnFiltrar_Click" />
                <asp:Button ID="btnMostrarTodos" runat="server" CssClass="btn" Text="Mostrar Todos" OnClick="btnMostrarTodos_Click" />
            </div>

            <!-- Tabla de pacientes -->
            <div class="grid-container">
                <asp:GridView ID="gvPaciente" runat="server" CssClass="grid-view" />
            </div>

            <!-- Mensaje -->
            <div class="mensaje">
                <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje-texto" ForeColor="Red" />
            </div>

            <!-- Botón volver -->
            <div class="boton-volver">
                <asp:Button ID="btnAtras" runat="server" CssClass="btn" Text="Atrás" OnClick="btnAtras_Click" />
            </div>
        </div>
    </form>
</body>

</html>
