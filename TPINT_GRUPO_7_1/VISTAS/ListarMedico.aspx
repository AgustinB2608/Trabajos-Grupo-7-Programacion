<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarMedico.aspx.cs" Inherits="VISTAS.ListarMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
    body {
        margin: 0;
        font-family: Arial, sans-serif;
        background-color: #f4f4f9;
    }

    .header {
        background-color: #2C3E50;
        color: white;
        padding: 15px 20px;
        font-size: 1.2rem;
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

    .contenedor {
    max-width: 100%;         /* Ajusta el ancho máximo al 100% del contenedor padre */
    padding: 20px;           /* Espaciado interno para mayor separación */
    background-color: #fff;  /* Color de fondo blanco */
    border-radius: 10px;     /* Bordes redondeados */
    overflow-x: auto;        /* Agrega scroll horizontal si el contenido es muy ancho */
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); /* Sombra para darle profundidad */
}
    }

    .titulo {
    font-size: 24px;
    font-weight: bold;
    }

    h1 {
        text-align: center;
        color: #333;
    }

    .form-grupo {
        margin: 20px 0;
        text-align: center;
    }

    .label {
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

    .grid-container {
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

    .mensaje {
        text-align: center;
        margin: 20px 0;
    }

    .mensaje-texto {
        font-size: 1rem;
    }

    .boton-volver {
        text-align: center;
        margin-top: 20px;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
        <!-- Encabezado -->
        <div class="header">
            <div class="titulo">Listar Medicos</div>
            <asp:Label ID="lblUsuario" runat="server" />
        </div>

        <!-- Contenedor principal -->
        <div class="contenedor">
            <h1>Listado de Médicos</h1>

            <!-- Filtro -->
            <div class="form-grupo">
                <label for="txtMedico" class="label">Médicos:</label>
                <asp:TextBox ID="txtMedico" runat="server" CssClass="textbox" />
                <asp:Button ID="btnFiltrar" runat="server" CssClass="btn" Text="Filtrar" OnClick="btnFiltrar_Click1" />
                <asp:Button ID="btnMostrarTodos" runat="server" CssClass="btn" Text="Mostrar todos" OnClick="btnMostrarTodos_Click" />
            </div>

            <!-- Mensaje -->
            <div class="mensaje">
                <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje-texto" />
            </div>

            <!-- Tabla de médicos -->
            <div class="grid-container">
                <asp:GridView ID="grvMedicos" runat="server" CssClass="grid-view" />
            </div>

            <!-- Mensaje adicional -->
            <div class="mensaje-adicional">
                <asp:Label ID="lblMensaje1" runat="server" CssClass="mensaje-texto" ForeColor="Red" />
            </div>

            <!-- Botón volver -->
            <div class="boton-volver">
                <asp:Button ID="btnVolver" runat="server" CssClass="btn" PostBackUrl="~/ABMLMedicos.aspx" Text="Volver atrás" />
            </div>
        </div>
    </form>
</body>
</html>