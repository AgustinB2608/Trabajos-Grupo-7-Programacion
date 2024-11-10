<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMLPacientes.aspx.cs" Inherits="VISTAS.ABMLPacientes" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestión de Personal Médico</title>
    <style>
        body {
            margin: 0;
            font-family: Arial, sans-serif;
            background-color: #6CB2EB;
        }

        .header {
            background-color: #2C3E50;
            color: white;
            display: flex;
            justify-content: space-between;
            padding: 15px 20px;
            font-weight: bold;
            align-items: center;
        }

        .container {
            max-width: 900px;
            margin: 30px auto;
            padding: 30px;
            background-color: #E1EFFF;
            border-radius: 15px;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
        }

        /* Formulario */
        .form-container {
            background-color: #4296E0;
            padding: 20px;
            border-radius: 10px;
            color: white;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        /* Contenedor de formulario con dos columnas */
        .form-content {
            display: flex;
            gap: 20px;
        }

        .form-column {
            width: 50%;
            display: flex;
            flex-direction: column;
            gap: 15px;
        }

        .form-group label {
            display: block;
            font-weight: bold;
            font-size: 14px;
            margin-bottom: 5px;
        }

        .form-control {
            width: 100%;
            padding: 8px;
            border-radius: 4px;
            border: 1px solid #ccc;
            font-size: 14px;
        }

        /* Seccion inferior */
        .lower-section {
            display: flex;
            justify-content: space-between;
            align-items: flex-start;
            margin-top: 20px;
        }

        .lower-section .left-form {
            width: 65%; 
            display: flex;
            flex-direction: column;
            gap: 15px;
        }

        .lower-section .right-buttons { 
            display: flex;
            flex-direction: column;
            gap: 10px;
            align-items: stretch; 
            
            margin-top: 50px; 
        }

        .config-button {
            background-color: #2C3E50;
            color: white;
            border: none;
            padding: 10px;
            border-radius: 8px;
            cursor: pointer;
            font-size: 14px;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            gap: 8px;
        }

        .config-button:hover {
            background-color: #1A252F;
        }
        <system.webServer>
    <directoryBrowse enabled="true" />
</system.webServer>
        .auto-style1 {
            padding: 8px;
            border-radius: 4px;
            border: 1px solid #ccc;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <span>Menu Administrador</span>
            <span>Nombre Administrador</span>
        </div>

        <div class="container">
            <div class="form-container">
                <h1>Gestión de Personal Médico</h1>
                <div class="form-content"> 
                    <!-- Columna izquierda -->
                    <div class="form-column">
                        <div class="form-group">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblDni" runat="server" Text="DNI:"></asp:Label>
                            <asp:TextBox ID="txtDni" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            Direccion:<asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblEmail" runat="server" Text="E-mail:"></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblCelular" runat="server" Text="Tel/Celular:"></asp:Label>
                            <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:"></asp:Label>
                            <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <!-- Columna derecha -->
                    <div class="form-column">
                        <div class="form-group">
                            <asp:Label ID="lblSexo" runat="server" Text="Sexo:"></asp:Label>
                            <br />
                            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="auto-style1" Height="29px" Width="546px">
                                <asp:ListItem>Femenino</asp:ListItem>
                                <asp:ListItem>Masculino</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblProvincia" runat="server" Text="Provincia:"></asp:Label>
                            <br />
                            <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-control">
                                <asp:ListItem>arg</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:"></asp:Label>
                            <br />
                            <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="form-control">
                                <asp:ListItem>dawd</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <label for="fechaNacimiento">Fecha Nacimiento:</label>&nbsp;
                      &nbsp;
                        </div>
                        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                        <br />
                        <br />
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click1" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnListar" runat="server" Text="Listar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnListar0" runat="server" Text="Cancelar" />
                    </div>
                </div>

                <!-- Seccion inferior con dos columnas -->
                </div>
            </div>
    </form>
</body>
</html>


