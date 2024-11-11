<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMLMedicos.aspx.cs" Inherits="VISTAS.ABMLMedicos"   %>

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
                            <br />
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblDni" runat="server" Text="DNI:"></asp:Label>
                            <asp:TextBox ID="txtDni" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblLegajo" runat="server" Text="Legajo:"></asp:Label>
                            <asp:TextBox ID="txtLegajo" runat="server" CssClass="form-control"></asp:TextBox>
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
                            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblProvincia" runat="server" Text="Provincia:"></asp:Label>
                            <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:"></asp:Label>
                            <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblDireccion" runat="server" Text="Direccion:"></asp:Label>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="fechaNacimiento">Fecha Nacimiento:</label>
                            <input type="date" id="fechaNacimiento" runat="server" class="form-control" />
                        </div>
                    </div>
                </div>

                <!-- Seccion inferior con dos columnas -->
                <div class="lower-section">
                        <!-- Parte izquierda: Especialidad, Dias de Atencion, Horario -->
                        <div class="left-form">
                            <div class="form-group">
                                <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad:"></asp:Label>
                                <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblDiasAtencion" runat="server" Text="Días de Atención:"></asp:Label>
                                <asp:DropDownList ID="ddlDiasAtencion" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblHorario" runat="server" Text="Horario:"></asp:Label>
                                <asp:DropDownList ID="ddlHorario" runat="server" CssClass="form-control"></asp:DropDownList>
                                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                            </div>
                        </div>

                        <!-- Parte derecha: Botones -->
                        <div class="right-buttons">
                            <div class="config-button">
                                <asp:Button ID="btnConfigUsuario" runat="server" Text="Configurar Usuario" CssClass="config-button"></asp:Button>
                                <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" CssClass="config-button" />
                                <asp:HyperLink ID="hlkListar" runat="server" CssClass="config-button">Listar</asp:HyperLink>
                                <asp:HyperLink ID="hlkEliminar" runat="server" CssClass="config-button">Eliminar</asp:HyperLink>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>


