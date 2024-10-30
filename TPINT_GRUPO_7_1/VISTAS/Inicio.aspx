<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="VISTAS.Inicio" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio</title>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: Arial, sans-serif;
        }

        body {
            background-color: #6CB2EB;
            display: flex;
            flex-direction: column; 
            align-items: center; 
        }

        header {
            background-color: #2C3E50;
            color: white;
            padding: 20px;
            width: 100%; 
            display: flex;
            justify-content: space-between;
            align-items: center;
            position: fixed; 
            top: 0;
            left: 0; 
        }

        .titulo {
            font-size: 24px;
            font-weight: bold;
        }

        .container {
            flex: 1;
            display: flex;
            padding: 150px 20px 20px; 
            gap: 20px;
            align-items: flex-start; 
            justify-content: center; 
            width: 1200px; 
            max-width: 100%; 
            height: 700px;
            margin: 0 auto; 
        }

        .menu {
            width: 250px;
            background-color: white;
            border-radius: 10px;
            padding: 20px;
            display: flex;
            flex-direction: column;
            gap: 10px;
            height: 500px;
            align-items:center;
            
        }

        .menu button,
        .menu input[type="submit"] {
            background: none;
            border: none;
            text-align: left;
            padding: 10px;
            font-size: 18px;
            cursor: pointer;
            transition: background-color 0.2s;
            border-radius: 5px;
            font-weight:200;
        }

        .menu button:hover,
        .menu input[type="submit"]:hover {
            background-color: #f5f5f5;
        }

        .content {
            flex: 1;
            background-color: white;
            border-radius: 10px;
            padding: 20px;
            height: 500px; 
            max-height: 80vh; 
        }

        .logout-section {
            margin-top: auto;
            display: flex;
            align-items: center;
            gap: 10px;
        }

        .logout-section:before {
            content: "↩";
            font-size: 16px;
        }

        #btnCerrarSesion {
            color: inherit;
        }

        form {
            height: 100%;
            display: flex;
            flex-direction: column;
            margin-top: 70px; 

        }
        .menu button:active,
        .menu input[type="submit"]:active {
            background-color: red;
        }
    </style>
</head>


<body>
    <form id="form1" runat="server">
        <header>
            <div class="titulo">Nombre del sistema</div>
            <span>
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario: " />
                <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de usuario" />
            </span>
        </header>
        <div class="container">
            <div class="menu">

               <%-- <asp:Button ID="btnPerfil" runat="server" Text="Perfil" OnClick="btnPerfil_Click" />
                <asp:Button ID="btnTurnosAsignados" runat="server" Text="Turnos asignados" OnClick="btnTurnosAsignados_Click" />
                <asp:Button ID="btnRegistro" runat="server" Text="Registro" OnClick="btnRegistro_Click" />
                <asp:Button ID="btnHistorial" runat="server" Text="Historial" OnClick="btnHistorial_Click" />
                <asp:Button ID="btnCalendario" runat="server" Text="Calendario" OnClick="btnCalendario_Click" />
                <div class="logout-section">
                    <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar sesión" OnClick="btnCerrarSesion_Click" />
                </div>--%>

            </div>
            <div class="content">
                <asp:PlaceHolder ID="contentPlaceholder" runat="server">
                    <h3>Bienvenido</h3>
                </asp:PlaceHolder>
            </div>
        </div>
    </form>
</body>
</html>
