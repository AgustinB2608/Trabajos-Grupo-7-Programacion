<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMLPacientes.aspx.cs" Inherits="VISTAS.ABMLPacientes" UnobtrusiveValidationMode="none" %>

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
                width: 80%; 
                max-width: 600px; 
                margin: 0 auto; 
                padding: 20px;
                box-sizing: border-box;
            }
            
            .form-container {
                background-color: #4296E0;
                padding: 15px;
                border-radius: 8px;
                width: 300px; 
                color: white;
                box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            }

            .form-container h1 {
                text-align: center;
                margin-bottom: 15px;
                font-size: 18px; 
            }

            .form-group {
                margin-bottom: 10px;
            }

            .form-group label {
                display: block;
                font-weight: bold;
                font-size: 12px; 
                margin-bottom: 5px;
            }

            .form-group input[type="text"],
            .form-group input[type="email"],
            .form-group select {
                width: 100%;
                padding: 6px; 
                font-size: 12px; 
                border: none;
                border-radius: 4px;
            }

            .gender-group {
                display: flex;
                align-items: center;
                margin-bottom: 10px;
                font-size: 12px; 
            }

            .gender-group input[type="radio"] {
                margin-right: 5px;
            }

            .button-group .button-group {
                background-color: #2C3E50;
                color: white; 
                border: none;
                padding: 8px;
                border-radius: 4px;
                cursor: pointer;
                font-size: 12px; 
                width: 80px;
            }
            
            .button-groupdos .button-groupdos {
                background-color: #2C3E50;
                color: white;
                border: none;
                padding: 8px;
                margin-top: 5px;
                border-radius: 4px;
                cursor: pointer;
                font-size: 12px; 
                width: 80px;
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
                <h1>Gestión de Pacientes</h1>
                
                <div class="form-group">
                    <label for="dni">DNI:</label>
                    <input type="text" id="txtDni" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDni">Ingrese dni</asp:RequiredFieldValidator>
                </div>
                
                <div class="form-group">
                    <label for="nombre">Nombre:</label>
                    <input type="text" id="txtNombre" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre">Ingrese Nombre</asp:RequiredFieldValidator>
                </div>
                
                <div class="form-group">
                    <label for="apellido">Apellido:</label>
                    <input type="text" id="txtApellido" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido">Ingrese Apellido</asp:RequiredFieldValidator>
                </div>
                
                <div class="form-group">
                    <label for="mail">Mail:</label>
                    <input type="email" id="txtMail" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtMail">Ingrese Apellido</asp:RequiredFieldValidator>
                </div>
                
                <div class="gender-group">
                    <label>Sexo:</label>
                    <asp:RadioButtonList ID="rblSexo" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Femenino" Value="Femenino"></asp:ListItem>
                        <asp:ListItem Text="Masculino" Value="Masculino"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="rblSexo" InitialValue="" ErrorMessage="Seleccione una opción" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>


                <div class="form-group">
                    <label for="fechaNacimiento">Fecha Nacimiento:</label>
                    <input type="date" id="fechaNacimiento" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvFechaNacimiento" ControlToValidate="fechaNacimiento" runat="server">Ingrese fecha de nacimiento</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="nacionalidad">Nacionalidad:</label>
                    <select id="ddlNacionalidad" runat="server">
                        <option value="">Seleccionar</option>
                    </select>
                    <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="ddlNacionalidad">Seleccione una nacionalidad</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="provincia">Provincia:</label>
                    <select id="ddlProvincia" runat="server">
                        <option value="">Seleccionar</option>
                    </select>
                    <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia">Seleccione Provincia</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="localidad">Localidad:</label>
                    <select id="ddlLocalidad" runat="server">
                        <option value="">Seleccionar</option>
                    </select>
                    <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad">Seleccione Localidad</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="direccion">Dirección:</label>
                    <input type="text" id="txtDireccion" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion">Ingrese Direccion</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="telefono">Teléfono:</label>
                    <input type="text" id="txtTelefono" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono">Ingrese Telefono</asp:RequiredFieldValidator>
                </div>

                <div class="button-group">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button-group" />
                    <asp:Button ID="btnListar" runat="server" Text="Listar" CssClass="button-group" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="button-group" />
                </div>
                <div class="button-groupdos">
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="button-groupdos" />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="button-groupdos" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
