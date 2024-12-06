<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="VISTAS.ModificarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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

        .error-message{
            color: red;
        }

        .exito-message{
            color: green;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">

        <header>
            <div class="titulo">Modificar Usuario</div>
            <asp:Label ID="lblUsuario" runat="server" Text="" /> <%--Nombre de usuario--%>
        </header>

        <%--Contenedor Principal--%>
        <div class="contenedor">
            <%--Contenedor 2--%>
            <div class="formulario-contenedor">
                <h1>Modificar Usuario</h1>
                
                <%--Columnas--%>
                <div class="form-columns">
                    <div class="form-columna">
                        <%--Codigo--%>
                        <div class="form-group">
                            <asp:Label ID="lblCodigo" runat="server" Text="Codigo:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" ReadOnly = "true" placeholder="Codigo " ></asp:TextBox>
                        </div>
                        <%--Contraseña--%>
                         <div class="form-group">
                            <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" placeholder="Ingresar Contraseña" ></asp:TextBox>                            
                        </div>
                        <div class="error-message">
                            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" />
                        </div>
                        <div class="exito-message">
                            <asp:Label ID="lblExito" runat="server" CssClass="exito-message" Text=""></asp:Label>
                        </div>
                        <div class="btn-container">
                            <asp:Button ID="btnAceptar" runat="server" Text="Guardar" CssClass="btn" OnClick="btnAceptar_Click"  />
                            <asp:Button ID="btnVolverAtras" runat="server" Text="Volver Atras" CssClass="btn" OnClick="btnVolverAtras_Click" />
                        </div>
                        
                    </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
