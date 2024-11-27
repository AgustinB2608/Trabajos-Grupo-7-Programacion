<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarMedico.aspx.cs" Inherits="VISTAS.ModificarMedico" UnobtrusiveValidationMode ="none"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        /* General */
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
            max-width: 90%;
            margin: 0 auto;
            margin-top: 10px;
            padding: 20px;
            background-color: white;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            overflow-x: auto;
        }

        .form-container {
            background-color: #4296E0;
            padding: 20px;
            border-radius: 10px;
            color: white;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        /* Buscador */
        .search-section {
            margin-bottom: 20px;
            display: flex;
            flex-wrap: wrap;
            align-items: center;
            gap: 15px;
        }

        .form-group label {
            font-weight: bold;
            font-size: 14px;
            margin-bottom: 5px;
            display: inline-block;
        }

        .form-control {
            padding: 8px;
            border-radius: 5px;
            border: 1px solid #ccc;
            font-size: 14px;
        }

        .btn {
            padding: 10px 15px;
            border: none;
            border-radius: 5px;
            font-size: 14px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .btn-primary {
            background-color: #2C3E50;
            color: white;
        }

        .btn-primary:hover {
            background-color: #1A252F;
        }

        .text {
            color: #ff4d4d;
            font-size: 12px;
            margin-top: 5px;
            display: block;
        }

        /* Estilo general para el GridView */
        .gridview {
            width: 100%;
            border-collapse: collapse;
        }

        .gridview th, .gridview td {
            border: 1px solid #ddd;
            text-align: left;
            padding: 8px;
        }

        .gridview th{
            background-color: #2C3E50;
        }

        .gridview td {
            color: white;
            text-align: center;
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
                <h1>Modificar Medico</h1>
                 <!-- Seccion buscar por codigo -->
                <div class="search-section">
                    <div class="form-group">
                        <asp:Label ID="lblCodigoMedico" runat="server" Text="Código de Médico:"></asp:Label>
                        <asp:TextBox ID="txtCodigoMedico" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                        <asp:Button ID="btnMostrarTodos" runat="server" Text="Mostrar Todos" CssClass="btn btn-primary  " OnClick="btnMostrarTodos_Click" />
                        <asp:Label ID="lblMensajeBusqueda" runat="server" CssClass="text"></asp:Label>
                    </div>
                </div>
                <div class="form-content">
                    <asp:GridView ID="grvMedicos"
                        runat="server"
                        AutoGenerateColumns="true"
                        AutoGenerateEditButton="true"
                        CssClass="gridview"
                        OnRowEditing="grvMedicos_RowEditing" 
                        AllowPaging ="true"
                        PageSize = "10" OnPageIndexChanging="grvMedicos_PageIndexChanging"
                        DataKeyNames="CodigoMedico">

                    </asp:GridView>
                </div>
           </div>
        </div>
    </form>
</body>
</html>
