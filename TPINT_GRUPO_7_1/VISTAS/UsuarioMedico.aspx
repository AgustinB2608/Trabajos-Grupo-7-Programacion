<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioMedico.aspx.cs" Inherits="VISTAS.UsuarioMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body {
            margin: 0;
            font-family: Arial, sans-serif;
            background-color: #6CB2EB;
        }

        /* Header */
        .header {
            background-color: #2C3E50;
            color: white;
            display: flex;
            justify-content: space-between;
            padding: 15px 20px;
            font-weight: bold;
            align-items: center;
        }

        /* Container */
        .container {
            text-align: center;
            padding: 20px;
        }

        h1 {
            color: white;
        }

        /* Menu Box */
        .menu-box {
            background-color: white;
            border-radius: 10px;
            border: 1px solid gray;
            padding: 20px;
            width: 50%;
            margin: 0 auto;
            text-align: center;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        /* Menu Item */
        .menu-item {
            margin-bottom: 20px;
            text-align: center;
        }

        /* Label Style */
        .menu-item label {
            font-weight: bold;
            color: #2C3E50;
            font-size: 16px;
            display: block;
            margin-bottom: 5px;
        }

        /* TextBox Style */
        .menu-item input[type="text"],
        .menu-item input[type="password"] {
            width: 80%;
            padding: 8px;
            font-size: 14px;
            border: 1px solid #D1D1D1;
            border-radius: 5px;
            box-shadow: inset 0 1px 3px rgba(0, 0, 0, 0.1);
        }

        .menu-item a {
            text-decoration: none;
            color: #1565C0;
            font-size: 18px;
            font-weight: bold;
            display: inline-block;
            text-align: center;
        }

        /* Button Style */
        .logout-button {
            margin-top: 20px;
            padding: 10px 20px;
            background-color: white;
            color: #4A90E2;
            border: 1px solid #808080;
            border-radius: 10px;
            cursor: pointer;
            text-decoration: none;
            display: inline-block;
        }

        /* Save Button Style */
        #btnGuardar {
            background-color: #4A90E2;
            color: white;
            font-size: 16px;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        #btnGuardar:hover {
            background-color: #357ABD;
        }

        .mensaje-exito {
            color: green;
            font-weight: bold;
        }

        .mensaje-error {
            color: red;
            font-weight: bold;
        }

        .titulo {
            font-size: 24px;
            font-weight: bold;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
             <div class="titulo">NovaVital</div>
            <asp:Label ID="lblUsuario" runat="server" class="titulo" />
        </div>

        <div class="container">
            <h1>Registro de Usuario de Medico</h1>
            <div class="menu-box">
                <div class="menu-item">
                    Codigo Medico:<br />
                    <asp:TextBox ID="txtCodigoMedico" runat="server" CssClass="textbox"></asp:TextBox>
                </div>
                <div class="menu-item">
                    <asp:Label ID="lblContraseña" runat="server" CssClass="label" Text="Contraseña:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
                </div>
                <div class="menu-item">
                    Nombre Medico:<br />
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="textbox"></asp:TextBox>
                </div>
                                <div class="menu-item">
                    Apellido Medico:<br />
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="textbox"></asp:TextBox>
                </div>
            </div>

            <asp:Button ID="btnGuardar" runat="server"  Text="Guardar" OnClick="btnGuardar_Click" />

            <asp:HyperLink ID="hlkVolverAtras" runat="server" NavigateUrl="~/ABMLMedicos.aspx" CssClass="logout-button">Volver Atras</asp:HyperLink>

            <br />

            <asp:Label ID="lblMensaje1" runat="server" Visible="False" CssClass="mensaje-exito"></asp:Label>
            <asp:Label ID="lblMensaje2" runat="server" Visible="False" CssClass="mensaje-error"></asp:Label>
        </div>
    </form>
</body>
</html>  
