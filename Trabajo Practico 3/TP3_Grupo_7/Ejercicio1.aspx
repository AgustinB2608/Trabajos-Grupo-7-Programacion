<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP3_Grupo_7.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Trabajo 3</title>
    <style type="text/css">
        body {
            margin:0;
        }

        .container {
            margin:20px;
            width:64%;
            text-align: center;
        }

        .container-localidades {
            margin-left:65px;
        }

        #BtnGuardarLocalidad {
            margin-top:10px;
            margin-left:60px;
        }

        /* Tamaño para los textbox */
        .textbox-tam {
        }

        .container-usuarios {
            margin-left:77px;
        }

        /* Estilos para el formulario de usuarios */
        .container2 {
            margin:20px;
            width:61%;
            text-align: center;
        }

        .form-grupo {
            display: flex;
            flex-direction: column;
            gap: 5px; /*espacio entre los elementos del formulario*/
        }

        .form-fila {
            display: flex;
            align-items: center;
            gap: 10px; /*espacio entre los elementos de la fila*/
            text-align:left;
        }

        .form-fila label {
            flex: 0 0 140px; /*/las reglas 0 0 significan q el elemnto laebl no puede achicarse ni agrandarse, 140px es el tamaño inicial del label*/
        }

        .form-input {
            flex: 1; /*hace q el elemento ocupe todo el ancho disponible dentro del container,*/
        }

        .container2 h4 {
            margin-right:20px;
        }

        .form-boton {
            margin-top:5px;
            margin-right:28px;
        }

        .btnIr {
            text-align:left;
            margin:10px 0 0 75px;  /*margin personalizado*/      
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">           
            <h4>Localidades</h4> 
            <div class="container-localidades">
                <asp:Label ID="Label1" runat="server" Text="Nombre de Localidad:"></asp:Label>&nbsp;&nbsp;
                <asp:TextBox ID="TxtLocalidades" runat="server" CssClass="textbox-tam"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvlocalidades" runat="server" ControlToValidate="TxtLocalidades" ErrorMessage="Ingrese localidad" ValidationGroup="Localidades"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revLocalidad" runat="server" ControlToValidate="TxtLocalidades" ValidationExpression="^[a-zA-Z0-9\sáéíóúÁÉÍÓÚñÑ]+$" ValidationGroup="Localidades">Ingreso un valor no permitido</asp:RegularExpressionValidator>
                <asp:CustomValidator ID="cvLocalidad" runat="server" ControlToValidate="TxtLocalidades" OnServerValidate="cvLocalidad_ServerValidate" ValidationGroup="Localidades">La localidad ya existe</asp:CustomValidator>
            </div>
            <asp:Button ID="BtnGuardarLocalidad" runat="server" Text="Guardar Localidad" OnClick="BtnGuardarLocalidad_Click" Width="147px" ValidationGroup="Localidades" />
        </div>

        <div class="container2">        
            <h4>Usuarios</h4>
            
            <div class="container-usuarios">

                <div class="form-grupo">
                    <div class="form-fila">
                        <label for="txtNombreUsuario">Nombre de Usuario:</label>
                        <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="textbox-tam" />
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtNombreUsuario" ValidationGroup="Usuarios" >*</asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form-fila">
                        <label for="txtContraseña">Contraseña:</label>
                        <asp:TextBox ID="txtContraseña" runat="server" CssClass="textbox-tam" TextMode="Password"/>
                        <asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="txtContraseña" ValidationGroup="Usuarios" >Ingrese una contraseña</asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form-fila">
                        <label for="txtRepetirContraseña">Repetir Contraseña:</label>
                        <asp:TextBox ID="txtRepetirContraseña" runat="server" CssClass="textbox-tam" TextMode="Password" />
                        <asp:CompareValidator ID="cvContraseña" runat="server" ControlToCompare="txtContraseña" ControlToValidate="txtRepetirContraseña" ValidationGroup="Usuarios" >*</asp:CompareValidator>
                    </div>
                    
                    <div class="form-fila">
                        <label for="txtCorreo">Correo electrónico:</label>
                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="textbox-tam" />
                        <asp:RequiredFieldValidator ID="rfvCorreoElectronico" runat="server" ControlToValidate="txtCorreo" ValidationGroup="Usuarios" >Ingrese un correo</asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form-fila">
                        <label for="txtCP">CP:</label>
                        <asp:TextBox ID="txtCP" runat="server" CssClass="textbox-tam" />
                        <asp:RequiredFieldValidator ID="rfvCP" runat="server" ControlToValidate="txtCP" ErrorMessage="*" ValidationGroup="Usuarios"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCP" runat="server" ControlToValidate="txtCP" ValidationExpression="^\d{4}$" ValidationGroup="Usuarios" >El CP ingresado no es válido.</asp:RegularExpressionValidator>
                    </div>
                    
                    <div class="form-fila">
                        <label for="ddlLocalidades">Localidades:</label>
                        <asp:DropDownList ID="ddlLocalidades" runat="server" CssClass="textbox-tam" AppendDataBoundItems="True" AutoPostBack="True" Height="27px" Width="178px"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvItems" runat="server" ControlToValidate="ddlLocalidades" ErrorMessage="*" ValidationGroup="Usuarios"></asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form-boton">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Usuario" CssClass="form-boton" ValidationGroup="Usuarios" />
                    </div>

                </div> <!-- Cierre de .form-grupo -->

            </div> <!-- Cierre de .container-usuarios -->
            <div class="btnIr">
                <asp:Button ID="btnInicio" runat="server" Text="Ir a inicio aspx" />
            </div>
        </div> <!-- Cierre de .container2 -->

    </form>
</body>
</html>
