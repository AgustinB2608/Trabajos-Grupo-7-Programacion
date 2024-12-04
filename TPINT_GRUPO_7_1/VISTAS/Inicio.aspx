<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="VISTAS.Inicio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio</title>
    <style>
    :root {
        --color-fondo: #6CB2EB;
        --color-header: #2C3E50;
        --color-boton: #3490dc;
        --color-boton-hover: #2779bd;
        --color-error: #ff6347;
        --color-fondo-error: #f8d7da;
        --radio-borde: 8px;
    }

    /* Estilos generales */
    body {
        font-family: Arial, sans-serif;
        margin: 0;
        padding: 0;
        background-color: var(--color-fondo);
        height: 100vh;
        display: flex;
        flex-direction: column;
    }

    /* Estilo del encabezado */
    .header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        background-color: var(--color-header);
        color: white;
        padding: 10px 20px;
        border-radius: var(--radio-borde);
    }

    /* Contenedor principal */
    .container {
        flex-grow: 1;
        display: flex;
        justify-content: center; /* Centrar horizontalmente */
        align-items: center;    /* Centrar verticalmente */
    }

    /* Estilo del menú */
    .menu {
        width: 30%;
        margin-top: 50px;
        background-color: white;
        border-radius: var(--radio-borde);
        box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);
        padding: 20px;
    }

    .menu h2 {
        text-align: center;
        font-weight: bold;
    }

    .menu ul {
        list-style: none;
        padding: 0;
    }

    .menu ul li {
        margin: 10px 0;
    }

    .menu ul li a {
        text-decoration: none;
        color: black;
        font-weight: bold;
    }

    /* Estilo del botón */
    .logout-btn {
        margin-top: 20px;
        width: 100%;
        padding: 10px;
        background-color: var(--color-boton);
        color: white;
        border: none;
        border-radius: var(--radio-borde);
        font-size: 1rem;
        cursor: pointer;
        display: flex;
        align-items: center;
        justify-content: center;
    }

    .logout-btn:hover {
        background-color: var(--color-boton-hover);
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Encabezado -->
        <div class="header">
            <span>Nombre del sistema</span>
            <asp:Label ID="lblInicio" runat="server" Text="Bienvenido, Usuario"></asp:Label>
        </div>


        <!-- Contenedor principal -->
        <div class="container">
            <!-- Menú centrado -->
            <div class="menu">
                <h2>MENU</h2>
                <ul>
                    <li><asp:HyperLink ID="lnkPerfil" runat="server" NavigateUrl="~/Perfil.aspx">Perfil</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkTurnos" runat="server" NavigateUrl="~/ListadoTurnos.aspx">Turnos asignados</asp:HyperLink></li>
                </ul>
                <asp:Button ID="btnCerrarSesion" runat="server" CssClass="logout-btn" Text="Cerrar sesión" />
            </div>
        </div>
    </form>
</body>
</html>
