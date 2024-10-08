<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TP6_GRUPO_7.Inicio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Página de Inicio</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .container {
            padding: 20px;
            border: 2px solid #007BFF;
            border-radius: 10px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.3);
            text-align: center;
            width: 400px;
        }

        h1 {
            font-size: 2em;
            color: black;
            margin:0;
        }

        nav ul {
            list-style-type: none;
            padding: 0;
        }

        nav ul li {
            margin: 10px 0;
        }
        /*esitlo para los enlaces (transicion de 0.3s para el hover*/
        nav a {
            text-decoration: none;
            font-size: 1.2em;
            color: #007BFF;
            display: block;
            padding: 10px;
            border: 1px solid #007BFF;
            border-radius: 5px;
            transition: background-color 0.3s, color 0.3s;
        }

        nav a:hover {
            background-color: #007BFF;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <header>
                <h1>Grupo N°7</h1>
            </header>

            <nav>
                <ul>
                    <li><asp:HyperLink ID="hlkEjercicio1" runat="server" NavigateUrl="~/Ejercicio1.aspx">Ejercicio 1</asp:HyperLink></li>
                    <li><asp:HyperLink ID="hlkEjercicio2" runat="server" NavigateUrl="~/Ejercicio2.aspx">Ejercicio 2</asp:HyperLink></li>
                </ul>
            </nav>
        </div>
    </form>
</body>
</html>
