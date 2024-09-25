<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarSucursal.aspx.cs" Inherits="TP5_Grupo_7.AgregarSucursal" UnobtrusiveValidationMode="None"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Agregar Sucursal</title>

    <style>
        body { /* Quitar márgenes y padding predeterminados */
            margin: 0;
            padding: 0;
            font-family: Arial, sans-serif; /* Fuente de letra más agradable */
        }

        #contenedor {
            width: 80%;
            margin: 0 auto;
            border-radius: 10px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.3);
            padding: 20px;
        }

        #header {
            text-align: center;
            font-size: 1rem;
            color: #555;
            margin-bottom: 10px;
            letter-spacing: 2px;
        }

        #titulo-formulario {
            font-size: 1.4rem;
            color: #000;
            margin-bottom: 10px;
            text-align: center;
        }

        .grupo-formulario {
            margin-bottom: 10px;
        }

        .grupo-formulario label {
            display: block;
            font-weight: bold;
            font-size: 0.8rem;
            color: #333;
            margin-bottom: 8px;
        }

        .grupo-formulario input[type="text"],
        .grupo-formulario select {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 1rem;
            box-sizing: border-box;
        }

        .grupo-formulario input[type="text"]:focus,
        .grupo-formulario select:focus {
            border-color: #007bff;
            outline: none;
        }

        #formulario {
            text-align: center;
            margin-top: 10px;
        }

        #BtnAceptar {
            background-color: #007bff;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            font-size: 1rem;
            cursor: pointer;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.3);
        }

        #links {
            text-align: center;
            margin-bottom: 10px;
        }

        #links a {
            margin: 0 10px;
            color: #007bff;
            font-size: 0.8rem;
            text-decoration: none;
            transition: color 0.3s ease;
        }

        #links a:hover {
            color: #0056b3;
        }

        #MensajeConfirmacion {
            text-align: center;
            margin-top: 5px;
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
            <div id="header">GRUPO N°7</div>

            <div id="links">
                <asp:HyperLink ID="hplAgregarSucursal" runat="server" NavigateUrl="AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
                <asp:HyperLink ID="hplListarSucursales" runat="server" NavigateUrl="ListadoSucursales.aspx">Listado de sucursales</asp:HyperLink>
                <asp:HyperLink ID="hplEliminarSucursal" runat="server" NavigateUrl="EliminarSucursal.aspx">Eliminar Sucursal</asp:HyperLink>
            </div>

            <div id="titulo-formulario">Agregar Sucursal</div>

            <div class="grupo-formulario">
                <label for="TxtSucursal">Nombre Sucursal:</label>
                <asp:TextBox ID="TxtSucursal" runat="server" CssClass="error-input" />
                <asp:RequiredFieldValidator ID="rfvNombreSucursal" runat="server" ControlToValidate="TxtSucursal" ErrorMessage="* Campo obligatorio" ForeColor="Red" />
            </div>

            <div class="grupo-formulario">
                <label for="TxtDescripcion">Descripción:</label>
                <asp:TextBox ID="TxtDescripcion" runat="server" CssClass="error-input" />
                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="TxtDescripcion" ErrorMessage="* Campo obligatorio" ForeColor="Red" />
            </div>

            <div class="grupo-formulario">
                <label for="ddlProvincia">Provincia:</label>
                <asp:DropDownList ID="ddlProvincia" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" InitialValue="" ErrorMessage="* Seleccione una provincia" ForeColor="Red" />
            </div>

            <div class="grupo-formulario">
                <label for="TxtDireccion">Dirección:</label>
                <asp:TextBox ID="TxtDireccion" runat="server" />
                <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="TxtDireccion" ErrorMessage="* Campo obligatorio" ForeColor="Red" />
            </div>

            <div id="formulario">
                <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" OnClick="BtnAceptar_Click" />
            </div>

            <div id="MensajeConfirmacion">
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
