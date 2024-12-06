<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarContraseñaConDni.aspx.cs" Inherits="VISTAS.RecuperarContraseñaConDni" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<style>
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
            background-color: #6CB2EB;
            display: flex;
            flex-direction: column;
        }

        header {
            background-color: #2C3E50;
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
            border-radius: 8px;
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
            border: 1px solid #ddd;
            border-radius: 4px;
            font-size: 14px;
        }

        .btn-iniciar {
            width: 100%;
            padding: 12px;
            background-color: #3490dc;
            color: white;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
            margin: 15px 0;
        }

        .btn-iniciar:hover {
            background-color: #2779bd;
        }

        .links {
            margin-top: 15px;
            font-size: 14px;
            display: flex;
            flex-direction: column;
            gap: 10px;  
        }

        .hyperlink {
            color: #3490dc;
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
                
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Ingrese su DNI" />
                <asp:TextBox ID="txtLegajo" runat="server" CssClass="form-control" placeholder="Ingrese su Legajo" />
                <asp:TextBox ID="txtContrasenaRecuperada" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Contraseña" ReadOnly="True" />
                <asp:Button ID="btnRecuperar" runat="server" Text="Recuperar" CssClass="btn-iniciar" OnClick="btnRecuperar_Click" /> <%--Evento para verificar datos--%>
                
                <div class="links">
                    <asp:HyperLink ID="VolverInicio" runat="server" NavigateUrl="~/Login.aspx" CssClass="hyperlink">Volver a iniciar sesion.</asp:HyperLink>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
