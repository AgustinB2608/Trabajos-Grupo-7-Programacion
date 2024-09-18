<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3.aspx.cs" Inherits="TP4_Grupo_7.Ejercicio3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Seleccionar Tema</title>
    <style type="text/css">

        /* Estilos generales */
        body {
            display: flex;
            justify-content: center;
            margin: 0;
        }
        /* Estilos del contenedor: Todo centrado con un espaciado arriba */
        .contenedor {
            text-align: center;
            margin-top: 20px;
        }
        /* Margen para que se separen los elementos */
        .grupo-formulario {
            margin-bottom: 15px;
        }
        /* El label principal tiene la prop de block para que haga un "salto de línea" y se muestre arriba del select */
        .grupo-formulario label {
            display: block;
            font-size: 16px;
            margin-bottom: 5px;
        }
        /* El select tiene un espaciado de 8px a los costados, con un ancho de 250px y un borde de 1px negro con bordes redondeados */
        .grupo-formulario select {
            padding: 8px;
            font-size: 14px;
            width: 250px;
            border-radius: 4px;
            border: 1px solid black;
        }
        /* Sin subrayado, con espaciado de 10px a, b y 20px d y y, Ver Libros en blanco, fondo azul, una transición para el cambio de color de azul a azul clarito */
        .bt-contenedor a {
            text-decoration: none;
            padding: 10px 20px;
            font-size: 14px;
            color: #ffffff;
            background-color: #007bff;
            border-radius: 4px;
            transition: background-color 0.3s ease;
        }
        .bt-contenedor a:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <div class="grupo-formulario">
                <label for="ddlTemas">Seleccionar Tema</label>
                <asp:DropDownList ID="ddlTemas" runat="server">
                </asp:DropDownList>
            </div>
            <div class="bt-contenedor">
                <asp:LinkButton ID="lnkVerLibros" runat="server" OnClick="lnkVerLibros_Click">Ver Libros</asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
