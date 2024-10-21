<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarSucursal.aspx.cs" Inherits="VISTA.EliminarSucursal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            text-align: center;
        }

        #contenedor {
            width: 80%;
            margin: 0 auto;
            padding: 60px 70px;
            border: 1px solid #ccc;
            border-radius: 10px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.3);
            max-height:250px;
        }

        #titulo-grupo {
            font-size: 1rem;
            color: #555;
            margin-bottom: 10px;
            letter-spacing: 2px;
        }

        h1 {
            font-size: 1.6rem;
            color: #333;
            margin-bottom: 20px;
        }

        .form-grupo {
            margin-bottom: 15px;
            text-align: left;
        }

        .form-grupo label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }

        .form-grupo input[type="text"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 1rem;
            box-sizing: border-box;
        }

        .form-grupo input[type="text"]:focus {
            border-color: #007bff;
            outline: none;
        }

        .btn {
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            font-size: 1rem;
            padding: 10px 20px;
            cursor: pointer;
        }

        .btn:hover {
            background-color: #0056b3;
        }

        #mensaje {
            margin-top: 20px;
            font-size: 0.8rem;
        }

        #links {
            display: flex;
            justify-content: space-between;
            margin-bottom: 15px;
        }

        #links a {
            color: #007bff;
            text-decoration: none;
            transition: color 0.3s ease;
            font-size: 0.8rem;
        }

        #links a:hover {
            color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
          <div id="contenedor">
     

      <div id="links">
      
      </div>
              <div id="EliminarSucu" style="font-size: xx-large">
          <asp:Label ID="lblEliminarSucursal" runat="server" Font-Bold="True">Eliminar Sucursal</asp:Label>

                  <br />

          <br />
      
      </div>

    <div id="IDSucu">
          <asp:Label ID="lblEliminar" runat="server" Font-Bold="True">Ingresar ID Sucursal</asp:Label>
      
          :

          <br />

          <br />
      
      </div>

      <div class="form-grupo">
         
          <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
      </div>

      <asp:Button ID="btnEliminar" runat="server" CssClass="btn" Text="Eliminar" OnClick="btnEliminar_Click" />

      <div id="mensaje">
          <asp:Label ID="lblMensaje" runat="server"></asp:Label>
      </div>
  </div>

    </form>
</body>
</html>
