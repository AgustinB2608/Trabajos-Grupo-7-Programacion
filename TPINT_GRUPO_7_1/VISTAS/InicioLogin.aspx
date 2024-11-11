<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioLogin.aspx.cs" Inherits="VISTAS.InicioLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Inicio de sesión</title>
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
            background-color: var(--color-fondo);
            display: flex;
            flex-direction: column;
        }

        header {
            background-color: var(--color-header);
            padding: 20px;
            color: white;
        }

        .titulo {
            font-size: 24px;
            font-weight: bold;
        }

        .contenedor {
            flex: 1;
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 20px;
        }

        .login {
            width: 400px;
            background: white;
            padding: 30px;
            border-radius: var(--radio-borde);
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            text-align: center;
        }

        .logo {
            width: 80px;
            height: 80px;
            background: #000;
            border-radius: 50%;
            margin: 0 auto 20px;
            display: flex;
            align-items: center;
            justify-content: center;
            color: white;
        }

        .form-control {
            width: 100%;
            padding: 12px;
            margin: 10px 0;
            border: 1px solid var(--color-textbox);
            border-radius: 4px;
            font-size: 14px;
        }

        .btn-iniciar {
            width: 100%;
            padding: 12px;
            background-color: var(--color-boton);
            color: white;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
            margin: 15px 0;
        }

        .btn-iniciar:hover {
            background-color: var(--color-boton-hover);
        }

        .links {
            margin-top: 15px;
            font-size: 14px;
            display: flex;
            flex-direction: column;
            gap: 10px;
        }

        .hyperlink {
            color: var(--color-boton);
            text-decoration: none;
            display: block;
        }

        .hyperlink:hover {
            text-decoration: underline;
        }

        form {
            height: 100%;
            display: flex;
            flex-direction: column;
        }


        .error-message {
            color: var(--color-error);
            border-radius: 4px;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div class="titulo">Nombre del sistema</div>
        </header>
        
        <div class="contenedor">
            <div class="login">
                <div class="logo">Logo</div>
                
                <asp:TextBox ID="txtLegajo" runat="server" CssClass="form-control" placeholder="Ingrese su legajo" />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Ingrese su contraseña" />
                
                <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión" CssClass="btn-iniciar" OnClick="btnLogin_Click" />

                <div class="error-message">
                    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" />
                </div>

                <div class="links">
                    <asp:HyperLink ID="OlvidoContrasena" runat="server" NavigateUrl="~/RecuperarContrasena.aspx" CssClass="hyperlink">¿Olvidaste tu contraseña?</asp:HyperLink>
                    <asp:HyperLink ID="OlvidoLegajo" runat="server" NavigateUrl="~/RecuperarLegajo.aspx" CssClass="hyperlink">¿Olvidaste tu legajo?</asp:HyperLink>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
