<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarMedico.aspx.cs" Inherits="VISTAS.EliminarMedico" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Eliminar Médico</title>
    <style>
        :root {
            --color-fondo: #6CB2EB;
            --color-header: #2C3E50;
            --color-boton: #3490dc;
            --color-boton-hover: #2779bd;
            --color-texto: white;
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
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }

        .titulo {
            font-size: 24px;
            font-weight: bold;
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

        .form-group input[type="text"] {
            width: 100%;
            padding: 10px;
            background-color: var(--color-textbox);
            border: 1px solid #ccc;
            border-radius: var(--radio-borde);
            font-size: 1rem;
            box-sizing: border-box;
        }

        .form-group input[type="text"]:focus {
            border-color: var(--color-boton);
            outline: none;
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

        #gvMedicoInfo {
            width: 100%;
            margin-top: 20px;
            border-collapse: collapse;
        }

        #gvMedicoInfo th, #gvMedicoInfo td {
            padding: 10px;
            text-align: left;
            border-bottom: 1px solid #ccc;
        }

        #gvMedicoInfo th {
            background-color: var(--color-header);
            color: var(--color-texto);
        }

        #links a {
            color: var(--color-boton);
            text-decoration: none;
            font-size: 1rem;
            transition: color 0.3s ease;
        }

        #links a:hover {
            color: var(--color-boton-hover);
        }

        #label {
            font-size: 10rem;
            color: red;
            background-color: white;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="titulo">NovaVital</div>
            <asp:Label ID="lblUsuario" runat="server" />
        </div>
        <div class="container">
            <h1>Eliminar Médico</h1>

            <div class="form-group">
                <asp:Label ID="lblEliminar" runat="server" Text="Ingresar Codigo del Médico:" Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtCodigo" runat="server" Width="219px" />
            </div>

            <div class="btn-container">
                <asp:Button ID="btnEliminar" runat="server" CssClass="btn" Text="Eliminar" OnClick="btnEliminar_Click" />
                <asp:HyperLink ID="hlkEliminar" runat="server" CssClass="btn" NavigateUrl="~/ABMLMedicos.aspx">Volver Atras</asp:HyperLink>
            </div>

            <div id="mensaje">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                <br />
                <asp:GridView ID="gvMedicoInfo" runat="server">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                        <asp:BoundField DataField="DNI" HeaderText="DNI" SortExpression="DNI" />
                    </Columns>
                </asp:GridView>

                <br />
                <br />
                <asp:Label ID="lblMensaje2" runat="server"></asp:Label>
                <br />
                <asp:Button ID="btnConfirmarEliminar" runat="server" OnClick="btnConfirmarEliminar_Click" Text="Confirmar" CssClass="btn" />
            </div>   
        </div>
    </form>
</body>
</html>
