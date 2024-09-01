<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2_A.aspx.cs" Inherits="TP2_Grupo_7.Ejercicio2_A" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Formulario de Datos</title>

    <style type="text/css">
        /*El margen entre los bordes del nav y el form */
        .form-container {
            display: flex;
            flex-direction: column;
            margin-left: 20px;
            margin-top: 20px;
        }
        /*El espacio entre los labels y los TextBox*/
        .form-group {
            display: flex;
            align-items: center;
            margin-bottom: 20px;
        }
        /*El ancho de los labels*/
        .form-group label {
            width: 80px; 
        }
        /*Espacio entre las opciones y el boton*/
        .button-container {
            margin-top: 20px;
        }
        /*El espacio entre el borde izq con los temas */
        .options-container {
            margin-left:70px;
        }
        /*El ancho de los TextBox*/
        #TextBox1, #TextBox2{
            width: 100px;
        }

    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <div class="form-group">
                <label for="TextBox1">Nombre:</label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="TextBox2">Apellido:</label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="ddlCiudades">Ciudad:</label>
                <asp:DropDownList ID="ddlCiudades" runat="server">
                    <asp:ListItem Value="Norte">Gral. Pacheco</asp:ListItem>
                    <asp:ListItem Value="Oeste">San Miguel</asp:ListItem>
                    <asp:ListItem Value="Sur">Boedo</asp:ListItem>
                </asp:DropDownList>
            </div>
            <label>Temas:</label>
            <div class="options-container">     
                <asp:CheckBoxList ID="cblTemas" runat="server">
                    <asp:ListItem>Ciencias</asp:ListItem>
                    <asp:ListItem>Literatura</asp:ListItem>
                    <asp:ListItem>Historia</asp:ListItem>
                </asp:CheckBoxList>
            <div class="button-container">
                <asp:Button ID="btnResumen" runat="server" Text="Ver resumen" OnClick="btnResumen_Click" />
            </div>

            </div>

        </div>
    </form>
</body>
</html>
