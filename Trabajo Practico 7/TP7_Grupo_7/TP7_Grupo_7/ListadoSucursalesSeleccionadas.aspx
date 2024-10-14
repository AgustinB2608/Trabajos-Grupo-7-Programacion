<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursalesSeleccionadas.aspx.cs" Inherits="TP7_Grupo_7.ListadoSucursalesSeleccionadas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sucursales 2</title>

    <style>

        :root {
            --color-header: #F2F2F2; 
            --color-enlace-nav: #6B5B93; 
            --color-enlace-nav-hover: #5A4E7E; 
            --color-h2: #333333; 
        }

        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }
        header {
            background-color: var(--color-header); 
            padding: 10px 0; 
            box-shadow: 0 1px 30px rgba(0, 0, 0, 0.3); /*una sombra leve que aparece abajo del encabezado*/
        }

        .nav-links { /*Para manejar los links a los otros ejercicios, centrado horizontal y le sacamos todos los margenes */
            list-style-type: none;
            padding: 0;
            margin: 0;
            display: flex;
            justify-content: center; 
        }

        .nav-links li {
            margin: 0 40px; 
        }

        .nav-links a { /*Para manejar los links a los otros ejercicios, color, tamaño, negrita y transicion de color*/
            color: var(--color-enlace-nav); 
            text-decoration: none; 
            font-size: 14px; 
            font-weight: bold; 
            transition: color 0.3s; 
        }

        .nav-links a:hover {
            color: var(--color-enlace-nav-hover); 
        }

        .title {
            text-align: center;
            margin: 15px 0; 
            color: var(--color-h2); 
        }

        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
        <ul class="nav-links"> 
            <li>
                <asp:HyperLink ID="hkListadoSucursales" runat="server" NavigateUrl="~/SeleccionarSucursales.aspx">Listado de Sucursales</asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="hkMostrarSucursales" runat="server" NavigateUrl="~/ListadoSucursalesSeleccionadas.aspx">Sucursales Seleccionadas</asp:HyperLink>
            </li>
        </ul>
        </header>

        <h2 class="title" >Sucursales Seleccionadas: </h2>

        <%--falta--%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="gvSucursalesSeleccionadas" runat="server" BackColor="#B9B9FF" BorderColor="Black" Height="16px" Width="531px">
            <EditRowStyle Font-Bold="True" Font-Size="X-Large" />
        </asp:GridView>

    </form>
</body>
</html>
