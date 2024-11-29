<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarPaciente.aspx.cs" Inherits="VISTAS.ListarPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listar Paciente</title>
    <style>
        /* Definición de variables de CSS */
        :root {
            --color-fondo: #6CB2EB;
            --color-header: #2C3E50;
            --color-boton: #3490dc;
            --color-boton-hover: #2779bd;
            --color-texto: white;
            --color-textbox: #ddd;
            --radio-borde: 8px;
        }

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
       
        .titulo {
            font-size: 24px;
            font-weight: bold;
        }

        .container {
            max-width: 900px;
            margin: 30px auto;
            padding: 30px;
            background-color: #E1EFFF;
            border-radius: 15px;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
        }

        h1 {
            font-size: 1.6rem;
            color: var(--color-texto);
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 15px;
            text-align: left;
        }

        .form-group label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
            color: var(--color-texto);
        }

        .form-group input[type="text"] {
            width: 100%;
            padding: 10px;
            background-color: var(--color-textbox);
            border: 1px solid #ccc;
            border-radius: var(--radio-borde);
            font-size: 1rem;
            box-sizing: border-box;
        }

        .form-group input[type="text"]:focus {
            border-color: var(--color-boton);
            outline: none;
        }

        .btn {
            background-color: var(--color-boton);
            color: var(--color-texto);
            border: none;
            border-radius: var(--radio-borde);
            font-size: 1rem;
            padding: 10px 20px;
            cursor: pointer;
            margin-top: 15px;
        }

        .btn:hover {
            background-color: var(--color-boton-hover);
        }

        #mensaje {
            margin-top: 20px;
            font-size: 0.9rem;
            color: var(--color-texto);
        }

        #links a {
            color: var(--color-boton);
            text-decoration: none;
            font-size: 0.9rem;
            transition: color 0.3s ease;
        }

        #links a:hover {
            color: var(--color-boton-hover);
        }

        #label {
            font-size: 10rem;
            color:red;
            background-color: white;
        }
        .contenedor {
            flex: 1;
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <span>Menu Administrador</span>
            <span>Nombre Administrador</span>
        </div>
        <div class="contenedor">
            <div id=".container">
                <h1>Listar Paciente</h1>
                </div>
            </div>
            
        <div class="contenedor">
         <h1>
        <asp:Label ID="lblListar" runat="server" Text="Ingrese el Dni del paciente:"></asp:Label>
       &nbsp;
       <asp:TextBox ID="txtListar" runat="server" Width="203px" Height="26px"></asp:TextBox>
      
       &nbsp;&nbsp;&nbsp;
             <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
&nbsp;<asp:Button ID="btnMostrarTodos" runat="server" Text="Mostrar Todos" OnClick="btnMostrarTodos_Click" />
      
       </h1>
            
        <div>
        </div>
            <asp:GridView ID="gvPaciente" runat="server">
            </asp:GridView>

            <br />

        </div>
            <div class="contenedor">
                <div>

                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

                </div>
                </div>
                <div class="contenedor">
                <div>

                    <asp:Button ID="btnAtras" runat="server" PostBackUrl="~/ABMLPacientes.aspx" Text="Atrás" />

                </div>
                    </div>
    </form>
</body>
</html>
