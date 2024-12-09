<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ObservacionTurno.aspx.cs" Inherits="VISTAS.ObservacionTurno" UnobtrusiveValidationMode="None"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Observación de Turno</title>
    <style>
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
            background-color: #6CB2EB;
            display: flex;
            flex-direction: column;
        }

        header {
            background-color: #2C3E50;
            padding: 20px;
            color: white;
            display: flex;
            justify-content: space-between;
            align-items: center;
            width: 100%;
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
        }

        .auto-style1 {
            width: 800px;
            background: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            position: relative;
            text-align: left;
        }

        .titulo-seccion {
            font-size: 22px;
            font-weight: bold;
            color: black;
            margin-bottom: 20px;
            text-align: center;
        }

        .gridview-container {
            margin-bottom: 20px;
        }

        .gridview {
            width: 100%;
            border-collapse: collapse;
        }

        .gridview th, .gridview td {
            text-align: center;
            padding: 10px;
            border: 1px solid #ddd;
        }

        .observacion-container {
            margin-top: 20px;
        }

        .observacion-label {
            font-size: 18px;
            font-weight: bold;
            margin-bottom: 10px;
            display: block;
        }
        .observacionVacia-label {
            font-size: 18px;
            margin-bottom: 10px;
            display: block;
            color: red;
        }

        .observacion-textarea {
            width: 100%;
            height: 150px;
            padding: 10px;
            font-size: 14px;
            border: 1px solid #ddd;
            border-radius: 4px;
        }

        .buttons-container {
            margin-top: 20px;
            display: flex;
            justify-content: space-between;
        }

        .accept-button, .back-button {
            padding: 10px 20px;
            font-size: 14px;
            background-color: #2C3E50;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            text-align: center;
        }

        .accept-button:hover, .back-button:hover {
            background-color: #1A252F;
        }

        .back-button {
            text-decoration: none;
            display: inline-block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div class="titulo">NovaVital</div>
            <asp:Label ID="lblUsuario" runat="server" class="titulo" />
        </header>

        <div class="contenedor">
            <div class="auto-style1">
                <div class="titulo-seccion">Turno seleccionado</div>

                <div class="gridview-container">
                    <asp:GridView ID="gvTurnoSeleccionado" runat="server" CssClass="gridview" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Medico" HeaderText="Médico" />
                            <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="DataTable-container">
                    
                </div>
                <div class="observacion-container">
                    <label for="txtObservacion" class="observacion-label">Observación:</label>
                    <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" CssClass="observacion-textarea"></asp:TextBox>
                </div>

                
                <asp:Label ID="lblObservacionVacia" runat="server" class="observacionVacia-label" ></asp:Label>

                <div class="buttons-container">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="accept-button" OnClick="btnAceptar_Click" />
                    <asp:HyperLink ID="lnkRegresar" runat="server" NavigateUrl="~/ListadoTurnos.aspx" CssClass="back-button">Regresar al Listado</asp:HyperLink>
                </div>
            </div>
        </div>
    </form>
</body>
</html>