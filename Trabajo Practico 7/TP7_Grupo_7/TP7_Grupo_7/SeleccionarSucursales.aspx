<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarSucursales.aspx.cs" Inherits="TP7_Grupo_7.SeleccionarSucursales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body {
            margin: 0;
            padding: 20px;
        }
        .links {
            text-align: center; 
            margin-bottom: 20px; 
        }
        .links a {
            margin: 0 15px;
            text-decoration: none; 
            color: #007bff; 
            font-weight: bold; 
        }
        .links a:hover {
            text-decoration: underline;
        }
        h2 {
            font-size: 24px;
            font-weight: bold;
            text-align: left;
        }
        .search-container {
            display: flex;
            align-items: center;
        }
        #txtBuscar {
            margin-left: 10px;
            padding: 5px;
            border: 1px solid #ccc;
            font-size: 14px;
            width: 200px;
        }
        #btnBuscar {
            margin-left: 10px;
            padding: 5px 10px;
            font-size: 14px;
            background-color: #007bff;
            color: white;
            border: none;
            cursor: pointer;
        }
        #btnBuscar:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="links">
            <asp:HyperLink ID="hkListadoSucursales" runat="server" NavigateUrl="~/SeleccionarSucursales.aspx">Listado de sucursales</asp:HyperLink>
            <asp:HyperLink ID="hkMostrarSucursales" runat="server" NavigateUrl="~/ListadoSucursalesSeleccionadas.aspx">Mostrar sucursales seleccionadas</asp:HyperLink>
        </div>
        
        <div>
            <h2>Listado de sucursales</h2>
            <div class="search-container">
                <label for="txtBuscar">Búsqueda por nombre de sucursal:</label>
                <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="auto-style1" />
            </div>
        </div>
    </form>
</body>
</html>
