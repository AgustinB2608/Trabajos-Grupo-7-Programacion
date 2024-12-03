<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarUsuario.aspx.cs" Inherits="VISTAS.EliminarUsuario" %>

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
        --color-texto: black;
        --color-textbox: #ddd;
        --radio-borde: 8px;
    }

    body {
        margin: 0;
        font-family: Arial, sans-serif;
        background-color: var(--color-fondo);
        color: var(--color-texto);
    }

    .header {
        background-color: var(--color-header);
        color: var(--color-texto);
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

    h1 {
        font-size: 1.8rem;
        color: var(--color-header);
        margin-bottom: 20px;
        text-align: center;
    }

    .form-group {
        margin-bottom: 20px;
    }

    .form-group label {
        font-weight: bold;
        display: block;
        margin-bottom: 5px;
        color: black;
    }

    .btn {
        background-color: var(--color-boton);
        color: var(--color-texto);
        border: none;
        border-radius: var(--radio-borde);
        font-size: 1rem;
        padding: 10px 20px;
        cursor: pointer;
        margin-top: 15px;
        display: inline-block;
        text-align: center;
        text-decoration: none;
    }

    .btn:hover {
        background-color: var(--color-boton-hover);
    }

    .btn-container {
        text-align: center;
        margin-top: 20px;
    }

    #mensaje {
        margin-top: 20px;
        font-size: 1rem;
        color: var(--color-header);
        text-align: center;
    }
</style>


</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <span>Menu Administrador</span>
            <asp:Label ID="lblUsuario" runat="server" Text="" />
        </div>
        <div class="container">
            <h1>Eliminar Usuario Medico</h1>

             <div class="form-group">
                <asp:Label ID="lblEliminar" runat="server" Text="Se eliminara el usuario del Médico:" Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtCodigo" runat="server" Width="219px" />
            </div>

            <div class="btn-container">
                <asp:Button ID="btnEliminar" runat="server" CssClass="btn" Text="Eliminar" OnClick="btnEliminar_Click"  />
                <asp:HyperLink ID="hlkEliminar" runat="server" CssClass="btn" NavigateUrl="~/EliminarMedico.aspx">Volver Atras</asp:HyperLink>
            </div>

            <div id="mensaje">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblMensaje2" runat="server"></asp:Label>
                <br />
            </div>   
        </div>
    </form>
</body>
</html>
