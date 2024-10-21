<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarSucursal.aspx.cs" Inherits="VISTA.AgregarSucursal" UnobtrusiveValidationMode="None" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Agregar Sucursal</title>

    <style>
        body {
            margin: 0;
            padding: 0;
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
        }

        #contenedor {
            max-width: 600px;
            margin: 50px auto;
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
            padding: 30px;
        }

        #header {
            text-align: center;
            font-size: 1.2rem;
            color: #333;
            margin-bottom: 20px;
            letter-spacing: 1px;
            text-transform: uppercase;
        }

        #links {
            text-align: center;
            margin-bottom: 15px;
        }

        #links a {
            margin: 0 10px;
            color: #007bff;
            font-size: 0.9rem;
            text-decoration: none;
            transition: color 0.3s ease;
        }

        #links a:hover {
            color: #0056b3;
        }

        .grupo-formulario {
            margin-bottom: 15px;
        }

        .grupo-formulario label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
            color: #555;
        }

        .grupo-formulario input[type="text"],
        .grupo-formulario select {
            width: 100%;
            padding: 12px;
            margin-top: 5px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }

        .grupo-formulario textarea {
            width: 100%;
            padding: 12px;
            margin-top: 5px;
            border: 1px solid #ccc;
            border-radius: 5px;
            resize: none;
            height: 80px;
            box-sizing: border-box;
        }

        input:focus, select:focus, textarea:focus {
            border-color: #007bff;
            outline: none;
        }

        #BtnAceptar {
            display: block;
            width: 100%;
            background-color: #007bff;
            color: #fff;
            padding: 12px;
            border: none;
            border-radius: 5px;
            font-size: 1rem;
            cursor: pointer;
            margin-top: 15px;
            transition: background-color 0.3s ease;
        }

        #BtnAceptar:hover {
            background-color: #0056b3;
        }

        #MensajeConfirmacion {
            text-align: center;
            margin-top: 15px;
            font-size: 1rem;
        }

        .error-text {
            color: red;
            font-size: 0.8rem;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenedor">
            <div id="header">Grupo N°7</div>

            <div id="links">
                <asp:HyperLink ID="hplAgregarSucursal" runat="server" NavigateUrl="AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
                <asp:HyperLink ID="hplListarSucursales" runat="server" NavigateUrl="ListadoSucursales.aspx">Listado de Sucursales</asp:HyperLink>
                <asp:HyperLink ID="hplEliminarSucursal" runat="server" NavigateUrl="EliminarSucursal.aspx">Eliminar Sucursal</asp:HyperLink>
            </div>

            <div class="grupo-formulario">
                <label for="TxtSucursal">Nombre Sucursal:</label>
                <asp:TextBox ID="TxtSucursal" runat="server" />
                <asp:RequiredFieldValidator ID="rfvNombreSucursal" runat="server"
                    ControlToValidate="TxtSucursal" ErrorMessage="* Campo obligatorio" 
                    CssClass="error-text" Display="Dynamic" />
            </div>

            <div class="grupo-formulario">
                <label for="TxtDescripcion">Descripción:</label>
                <asp:TextBox ID="TxtDescripcion" runat="server" TextMode="MultiLine" />
                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server"
                    ControlToValidate="TxtDescripcion" ErrorMessage="* Campo obligatorio" 
                    CssClass="error-text" Display="Dynamic" />
            </div>

            <div class="grupo-formulario">
                <label for="ddlProvincia">Provincia:</label>
                <asp:DropDownList ID="ddlProvincia" runat="server" />
                <asp:RequiredFieldValidator ID="rfvProvincia" runat="server"
                    ControlToValidate="ddlProvincia" InitialValue="0" 
                    ErrorMessage="* Seleccione una provincia" CssClass="error-text" Display="Dynamic" />
            </div>

            <div class="grupo-formulario">
                <label for="TxtDireccion">Dirección:</label>
                <asp:TextBox ID="TxtDireccion" runat="server" />
                <asp:RequiredFieldValidator ID="rfvDireccion" runat="server"
                    ControlToValidate="TxtDireccion" ErrorMessage="* Campo obligatorio" 
                    CssClass="error-text" Display="Dynamic" />
            </div>

            <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" Height="56px" OnClick="BtnAceptar_Click" />

            <div id="MensajeConfirmacion">
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
