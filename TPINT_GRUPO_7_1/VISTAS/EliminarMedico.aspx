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
            background-color: #2C3E50;
            color: white;
            display: flex;
            justify-content: space-between;
            padding: 15px 20px;
            font-weight: bold;
            align-items: center;
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

        .label{
            color: black;
        }

        .form-group {
    display: flex;
    align-items: center; /* Asegura la alineación vertical */
    gap: 10px; /* Espacio entre el label y el textbox */
    position: relative; /* Para habilitar z-index */
    z-index: 1; /* Coloca la capa sobre otros elementos */
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
            z-index: 1;
        }

        .form-label {
            font-weight: bold;
            margin-bottom: 5px;
            font-size: 14px;
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
        .form-group {
            display: flex;
            flex-direction: column;
        }

        .form-label {
            font-weight: bold;
            margin-bottom: 5px;
            font-size: 14px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="titulo">NovaVital</div>
            <asp:Label ID="lblUsuario" runat="server" class="titulo"  />
        </div>
        
            <h1 style="color: #FFFFFF">Eliminar Médico</h1>
            
            <div class="formulario-contenedor">
            <div class="form-group">
                <strong>
                <asp:Label ID="lblEliminar" runat="server" Text="Ingrese el Codigo del médico:" CssClass="label"></asp:Label>
                </strong>
                <asp:TextBox ID="txtCodigo" runat="server" Width="219px"></asp:TextBox>
            </div>
            <div class="btn-container">
                <asp:Button ID="btnBuscar" runat="server" CssClass="btn" Text="Buscar" OnClick="btnBuscar_Click" />
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
