<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2_B.aspx.cs" Inherits="TP2_Grupo_7.Ejercicio2_B" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Resumen EJ2</title>

    <style>
        /*Estilo lo mas parecido a la foto del Titulo*/
        h2 {
            font-family: Arial, sans-serif;
            font-size: 36px;
            text-align: left;
            margin-top: 0;
            margin-left: 20px;
            font-weight: 1000;
        }
        /*Espacio entre el borde izq y el eresumen*/
        .container-resumen {
            margin-left: 40px;
        }
        /*Espacio b.izq y los temas con letra negrita*/
        .container-temas {
            margin-left: 80px;
            font-weight: bold;
        }
        /*quito el margin pred de los parrafos*/
        p {
            margin: 0;
        }
        /*margin para los resultados de los temas*/
        .margin {
            margin-top: 20px;
            margin-bottom: 0;
        }
        /*aca separe los labels con los resultados para hacer el diseño tal cual la foto, usando 3 divs */
        .contenedor {
            display: flex;
            justify-content: flex-start;
        }

        .container-t,
        .container-resultados {
            display: flex;
            flex-direction: column;
            margin-right: 10px; 
        }
        /*negrita para los resultados*/
        .container-resultados {
            font-weight: bold;
        }

    </style>

</head>
<body>
    <form id="form1" runat="server">
        <h2>Resumen</h2>
        <div class="container-resumen">

            <div class="contenedor">
                <div class="container-t"> 
                    <p>Nombre:</p>
                    <p>Apellido:</p>
                    <p>Zona:</p>
                </div>

                <div class="container-resultados">
                    <asp:Label ID="lblNombre" runat="server"></asp:Label>
                    <asp:Label ID="lblApellido" runat="server"></asp:Label>
                    <asp:Label ID="lblResumen" runat="server"></asp:Label>
                </div>
            </div>

            <p class="margin">Los Temas elegidos son:</p>
            <div runat="server" id="temasSeleccionadosDiv">
                <div class="container-temas">  
                     <asp:Label ID="lblTemas" runat="server"></asp:Label>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
