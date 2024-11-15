<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarPaciente.aspx.cs" Inherits="VISTAS.ModificarPaciente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Modificar Paciente</title>
    <style>
        :root {
            --color-fondo: #6CB2EB;
            --color-header: #2C3E50;
            --color-boton: #3490dc;
            --color-boton-hover: #2779bd;
            --color-textbox: #ddd;
            --color-error: #ff6347;
            --radio-borde: 8px;
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
            min-height: 100vh;
        }

        header {
            display: flex;             
            justify-content: space-between; 
            align-items: center;       
            padding: 20px;         
            background-color: var(--color-header);
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
            min-height: calc(100vh - 80px);
        }

        .formulario-contenedor {
            display: flex;
            flex-direction: column;
            gap: 20px;
            max-width: 800px;
            width: 100%;
            margin: auto;
            padding: 40px;
            background-color: white;
            border-radius: var(--radio-borde);
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .form-columns {
            display: flex;
            gap: 40px;
        }

        .form-columna {
            flex: 1;
            display: flex;
            flex-direction: column;
            gap: 15px;
        }

        .form-group {
            display: flex;
            flex-direction: column;
        }

        .form-label {
            font-weight: bold;
            margin-bottom: 5px;
            font-size: 14px;
        }

        .form-control {
            width: 100%;
            padding: 12px;
            border: 1px solid var(--color-textbox);
            border-radius: 4px;
            font-size: 14px;
        }

        .form-control::placeholder {
            color: #757575; 
        }

        .btn-container {
            display: flex;
            justify-content: center;
            gap: 10px;
        }

        .btn {
            width: 100%;
            padding: 12px;
            background-color: var(--color-boton);
            color: white;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
        }

        .btn:hover {
            background-color: var(--color-boton-hover);
        }

        .error-message {
            color: var(--color-error);
            font-weight:bold;
            font-size:14px;
        }

        .search-container {
            display: flex;
            align-items: center;
            gap: 10px;
        }

        .btn-reset {
            background-color: #f44336; 
            width: 100%;
            padding: 12px;
            color: white;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s; 
        }

        .btn-reset:hover {
            background-color: #d32f2f;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <header>
            <div class="titulo">ABML</div>
            <asp:Label ID="lblUsuario" runat="server" Text="" /> <%--Nombre de usuario--%>
        </header>

        <%--Contenedor Principal--%>
        <div class="contenedor">
            <%--Contenedor 2--%>
            <div class="formulario-contenedor">
                <h1>Modificar Paciente</h1>
                
                <div class="search-container">
                    <asp:Label ID="lblBuscar" runat="server" CssClass="form-label" Text="Paciente:"></asp:Label>
                    <asp:TextBox ID="txtBuscar" CssClass="form-control" runat="server" placeholder="Buscar por DNI o CodPaciente"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" CssClass="btn" OnClick="btnBuscar_Click" Text="Buscar" />
                    <asp:Button ID="btnReset" runat="server" CssClass="btn-reset" OnClick="btnLimpiar_Click" Text="Limpiar" />
                    
                </div>
                <asp:Label ID="lblErrorBusqueda" runat="server" CssClass="error-message" Text=""></asp:Label>
                
                
                <%--Columnas--%>
                <div class="form-columns">
                    <!-- Columna Izquierda -->
                    <div class="form-columna">
                        <%--Nombre--%>
                        <div class="form-group">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre:" ReadOnly="true"></asp:TextBox>
                        </div>
                        <%--DNI--%>
                        <div class="form-group">
                            <asp:Label ID="lblDni" runat="server" Text="DNI:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Documento:" ReadOnly="true"></asp:TextBox>
                        </div>
                        <%--Correo Electronico--%>
                        <div class="form-group">
                            <asp:Label ID="lblEmail" runat="server" Text="E-mail:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Correo:"></asp:TextBox>                            
                        </div>
                        <%--Celular--%>
                        <div class="form-group">
                            <asp:Label ID="lblCelular" runat="server" Text="Tel/Celular:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" placeholder="Celular:"></asp:TextBox>
                        </div>
                        <%--Nacionalidad--%>
                        <div class="form-group">
                            <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="form-control" placeholder="Nacionalidad:" ReadOnly="true"></asp:TextBox>
                        </div>
                        <%--Fecha de Nacimiento--%>
                        <div class="form-group">
                            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" ReadOnly="true" placeholder="Fecha de Nacimiento:" ></asp:TextBox>
                        </div>
                        <%--Label para los mensajes de error--%>
                        <div class="error-message">
                            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" />
                        </div>
                        <%--Botones--%>
                        <div class="btn-container">
                            <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" CssClass="btn" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn-reset" />
                        </div>
                    </div>

                    <!-- Columna Derecha -->
                    <div class="form-columna">
                        <%--Apellido--%>
                        <div class="form-group">
                            <asp:Label ID="lblApellido" runat="server" Text="Apellido:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Apellido:" ReadOnly="true"></asp:TextBox>
                        </div>
                        <%--Sexo--%>
                        <div class="form-group">
                            <asp:Label ID="lblSexo" runat="server" Text="Sexo:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtSexo" runat="server" CssClass="form-control" placeholder="Sexo:" ReadOnly="true"></asp:TextBox>
                        </div>
                        <%--Provincia--%>
                        <div class="form-group">
                            <asp:Label ID="lblProvincia" runat="server" Text="Provincia:" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <%--Localidad--%>
                        <div class="form-group">
                            <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <%--Direccion--%>
                        <div class="form-group">
                            <asp:Label ID="lblDireccion" runat="server" Text="Dirección:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Dirección:"></asp:TextBox>
                        </div>
                        <%--Codigo Paciente--%>
                        <div class="form-group">
                            <asp:Label ID="lblCodPaciente" runat="server" Text="Paciente:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtCodPaciente" runat="server" CssClass="form-control" placeholder="" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
