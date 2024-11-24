<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AñadirPaciente.aspx.cs" Inherits="VISTAS.ABMLPacientes" UnobtrusiveValidationMode="None" %>

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

        .btn {
            display: inline-block;
            background-color: #2C3E50;
            color: white;
            border: none;
            padding: 12px 25px;
            margin: 5px;
            border-radius: 8px;
            cursor: pointer;
            font-size: 14px;
            text-align: center;
            text-decoration: none; /* Para el hipervínculo */
        }

        .btn:hover {
            background-color: #1A252F;
        }
        .auto-style1 {
            width: 50%;
            display: flex;
            flex-direction: column;
            gap: 15px;
            margin-left: 40px;
            margin-top: 3px;
        }
        .auto-style2 {
            width: 50%;
            display: flex;
            flex-direction: column;
            gap: 15px;
            margin-right: 37px;
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
                <h1>Añadir Paciente</h1>
                <div class="form-content"> 
                    <!-- Columna izquierda -->
                    <div class="auto-style2">
                        <div class="form-group">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" 
                              ErrorMessage="El nombre es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RfvApellido" runat="server" ControlToValidate="txtApellido" 
                             ErrorMessage="El apellido es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblDni" runat="server" Text="DNI:"></asp:Label>
                            <asp:TextBox ID="txtDni" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDni" 
                             ErrorMessage="El DNI es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblDireccion" runat="server" Text="Direccion:"></asp:Label>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" 
                             ErrorMessage="La dirección es obligatoria" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblEmail" runat="server" Text="E-mail:"></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" 
                            ErrorMessage="El email es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblCelular" runat="server" Text="Tel/Celular:"></asp:Label>
                            <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCelular" runat="server" ControlToValidate="txtCelular" 
                            ErrorMessage="El número de celular es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                       


                        <div class="form-group">
                            <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:"></asp:Label>
                            <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="txtNacionalidad" 
                            ErrorMessage="La nacionalidad es obligatoria" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                        </div>
                    </div>

                    <!-- Columna derecha -->
                    <div class="auto-style1">
                        <div class="form-group">
                            <asp:Label ID="lblSexo" runat="server" Text="Sexo:"></asp:Label>
                            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblProvincia" runat="server" Text="Provincia:"></asp:Label>
                            <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:"></asp:Label>
                            <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="form-control"></asp:DropDownList>
                            <br />
                        </div>

                        <div class="form-group">
                            <br />
                            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha Nacimiento:"></asp:Label>
                            &nbsp;&nbsp;
                            <br />
&nbsp;&nbsp;
                            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                            <br />
                            <asp:Label ID="lblMensajeFecha" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                    </div>
                </div>

                <!-- Seccion inferior con botones alineados -->
                <div class="form-group" style="text-align: center; margin-top: 20px;">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click1" CssClass="btn" />
                    <asp:HyperLink ID="btnAtras" runat="server" NavigateUrl="~/InicioAdministrador.aspx" CssClass="btn">Atrás</asp:HyperLink>

                    <asp:Label ID="lblMensajeConfirmacion" runat="server" Visible="False" CssClass="mensaje-exito"></asp:Label>
                    
                </div>
            </div>
        </div>
    </form>
</body>
</html>
