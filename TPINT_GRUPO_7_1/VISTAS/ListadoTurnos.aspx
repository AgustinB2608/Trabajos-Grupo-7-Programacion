<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoTurnos.aspx.cs" Inherits="VISTAS.ListadoTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado de turnos</title>
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

        .usuario {
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

        .search-filter-row {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 20px;
        }

        .search-container {
            display: flex;
            align-items: center;
            gap: 10px;
        }

        .form-control {
            padding: 10px;
            font-size: 14px;
            border: 1px solid #ddd;
            border-radius: 4px;
        }

        .search-button {
            padding: 10px 20px;
            font-size: 14px;
            background-color: #2C3E50;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .search-button:hover {
            background-color: #1A252F;
        }

        .filter-container {
            display: flex;
            gap: 10px;
        }

        .gridview-container {
            display: flex;
            justify-content: center;
            margin-bottom: 20px;
        }

        .volver-menu {
            padding: 10px 20px;
            background-color: #2C3E50;
            color: white;
            text-decoration: none;
            font-size: 14px;
            border-radius: 4px;
            position: absolute;
            bottom: 20px;
            right: 20px;
            cursor: pointer;
            text-align: center;
        }

        .volver-menu:hover {
            background-color: #1A252F;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div class="titulo">Nombre del sistema</div>
            <div class="usuario">Nombre del usuario</div>
        </header>
        
        <div class="contenedor">
            <div class="auto-style1">
                <div class="titulo-seccion">Listado de Turnos</div>

               
                <div class="search-filter-row">
                    <div class="search-container">
                        <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" Placeholder="Buscar..."></asp:TextBox>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="search-button" />
                    </div>
                    <div class="filter-container">
                        <asp:DropDownList ID="ddlFiltro1" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Filtro 1" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlFiltro2" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Filtro 2" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlFiltro3" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Filtro 3" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

               
                <div class="gridview-container">
                    <asp:GridView ID="gvTurnos" runat="server" CssClass="gridview" />
                </div>

                
                <asp:HyperLink ID="lnkVolverMenu" runat="server" NavigateUrl="~/Menu.aspx" CssClass="volver-menu">Volver al menú</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>