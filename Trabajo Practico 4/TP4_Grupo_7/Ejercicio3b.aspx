<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3b.aspx.cs" Inherits="TP4_Grupo_7.Ejercicio3b" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado de Libros</title>
    <style type="text/css">
        /* Estilos generales */
        body {
            display: flex;
            justify-content: center;
            margin: 0;
            padding: 0;
        }
        /* Estilos del contenedor */
        .container {
            text-align: center;
            margin-top: 20px;
        }
        /* Estilos para la tabla: centrarla*/
        .tabla {
            margin: 20px auto;
        }
        /*Mismo diseño que la tabla del ej2*/
        .tabla th,
        .tabla td {
            border: 1px solid black;
            padding: 4px;
            text-align: center;
        }

        /* Sin subrayado, con espaciado de 10px a, b y 20px d y y, botones en blanco, fondo azul, una transición para el cambio de color de azul a azul clarito */
        .bt-contenedor a {
            text-decoration: none;
            padding: 5px 10px;
            font-size: 10px;
            color: white;
            background-color: #007bff;
            border-radius: 4px;
            transition: background-color 0.3s ease;
        }
        /*Transición de color al pasar el mouse por encima*/
        .bt-contenedor a:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <%--//Sección de listado de libros--%>
            <h2>Listado de Libros</h2>
            <asp:GridView ID="GvLibros" runat="server" AutoGenerateColumns="False" CssClass="tabla">
                <Columns>
                    <asp:BoundField DataField="IdLibro" HeaderText="ID Libro" />
                    <asp:BoundField DataField="IdTema" HeaderText="ID Tema" />
                    <asp:BoundField DataField="Titulo" HeaderText="Título" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="Autor" HeaderText="Autor" />
                </Columns>
            </asp:GridView>
            <%--//Botón para seleccionar otro tema--%>
            <div class="bt-contenedor">
                <asp:LinkButton ID="lkbVolver" runat="server" OnClick="lkbVolver_Click">Consultar otro Tema</asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
