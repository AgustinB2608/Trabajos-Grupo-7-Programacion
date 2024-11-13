<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AsignarTurnos.aspx.cs" Inherits="AsignarTurnos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Asignar Turnos</title>
    <style>
        .container {
            background-color: #87CEFA;
            padding: 20px;
            max-width: 700px;
            margin: auto;
            border-radius: 10px;
        }

        .form-section {
            background-color: #FFC0CB;
            padding: 20px;
            border-radius: 10px;
            margin-bottom: 20px;
        }

        .title {
            text-align: center;
            font-weight: bold;
            font-size: 24px;
            margin-bottom: 20px;
        }

        .label {
            font-weight: bold;
            margin-top: 10px;
            display: block;
        }

        .btn-assign {
            background-color: #333;
            color: white;
            padding: 10px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .btn-assign:hover {
            background-color: #555;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="title">ASIGNAR TURNOS</div>

            <div class="form-section">
                <asp:Label ID="lblMedico" runat="server" Text="Médico" CssClass="label"></asp:Label>
                <asp:DropDownList ID="ddlMedico" runat="server" Width="100%" />

                <asp:Label ID="lblHorario" runat="server" Text="Horario Disponible" CssClass="label"></asp:Label>
                <asp:DropDownList ID="ddlHorario" runat="server" Width="100%" />

                <asp:Label ID="lblFecha" runat="server" Text="Fecha" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtFecha" runat="server" Width="100%" Placeholder="dd/mm/aa"></asp:TextBox>
                
                <asp:Button ID="btnAsignarTurno" runat="server" Text="Asignar turno" CssClass="btn-assign" OnClick="btnAsignarTurno_Click" />
            </div>

            <div class="title">Turnos Asignados</div>
            <asp:GridView ID="gvTurnosAsignados" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Hora" HeaderText="Hora" />
                    <asp:BoundField DataField="Medico" HeaderText="Medico" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
