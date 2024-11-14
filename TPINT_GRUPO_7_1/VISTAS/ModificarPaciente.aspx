<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarPaciente.aspx.cs" Inherits="VISTAS.ModificarPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    <style>
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

        .container {
            max-width: 900px;
            margin: 30px auto;
            padding: 30px;
            background-color: #E1EFFF;
            border-radius: 15px;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
        }

        /* Formulario */
        .form-container {
            background-color: #4296E0;
            padding: 20px;
            border-radius: 10px;
            color: white;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        /* Contenedor de formulario con dos columnas */
        .form-content {
            display: flex;
            gap: 20px;
        }

        .form-column {
            width: 50%;
            display: flex;
            flex-direction: column;
            gap: 15px;
        }

        .form-group label {
            display: block;
            font-weight: bold;
            font-size: 14px;
            margin-bottom: 5px;
        }

        .form-control {
            width: 100%;
            padding: 8px;
            border-radius: 4px;
            border: 1px solid #ccc;
            font-size: 14px;
        }

        /* Seccion inferior */
        .lower-section {
            display: flex;
            justify-content: space-between;
            align-items: flex-start;
            margin-top: 20px;
        }

        .lower-section .left-form {
            width: 65%; 
            display: flex;
            flex-direction: column;
            gap: 15px;
        }

        .lower-section .right-buttons { 
            display: flex;
            flex-direction: column;
            gap: 10px;
            align-items: stretch; 
        
            margin-top: 50px; 
        }

        .config-button {
            background-color: #2C3E50;
            color: white;
            border: none;
            padding: 10px;
            border-radius: 8px;
            cursor: pointer;
            font-size: 14px;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            gap: 8px;
        }

        .config-button:hover {
            background-color: #1A252F;
        }
        .auto-style1 {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #2C3E50;
            color: white;
            padding: 10px;
            border-radius: 8px;
            cursor: pointer;
            font-size: 14px;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            gap: 8px;
            text-decoration: none;
        }
        .auto-style2 {
            width: 779px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <span>Menu Administrador</span>
            <span>Nombre Administrador</span>
        </div>

        <div class="container">
            <div class="form-container">
                <h1 class="auto-style2">Modificar Paciente&nbsp;&nbsp; |
                    <asp:Label ID="lblBuscar" runat="server" Font-Size="Medium" Text="Ingrese CodPaciente o Dni"></asp:Label>
&nbsp;
                    <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnBuscar" runat="server" Height="21px" OnClick="btnBuscar_Click" Text="Ok" Width="30px" />
                </h1>
                <div class="form-content"> 
                    <!-- Columna izquierda -->
                    <div class="form-column">
                        <div class="form-group">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>

                            <br />

                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblDNI" runat="server" Text="DNI:"></asp:Label>
                            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblEmail" runat="server" Text="E-mail:"></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>                            
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblCelular" runat="server" Text="Tel/Celular:"></asp:Label>
                            <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                       
                    </div>

                    <!-- Columna derecha -->
                    <div class="form-column">
                        <div class="form-group">
                            <asp:Label ID="lblSexo" runat="server" Text="Sexo:"></asp:Label>
                            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control">
                                  <asp:ListItem>--Seleccione un sexo--</asp:ListItem>
                                  <asp:ListItem>Mujer</asp:ListItem>
                                  <asp:ListItem>Hombre</asp:ListItem>
                                  <asp:ListItem>Otro</asp:ListItem>

                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblProvincia" runat="server" Text="Provincia:"></asp:Label>
                            <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:"></asp:Label>
                            <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblDireccion" runat="server" Text="Direccion:"></asp:Label>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="fechaNacimiento">&nbsp;&nbsp; Fecha Nacimiento:<br />
                            <br />
                            Día:&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlDia" runat="server" Height="17px" Width="63px">
                                <asp:ListItem Value="-">-</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem>13</asp:ListItem>
                                <asp:ListItem>14</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>16</asp:ListItem>
                                <asp:ListItem>17</asp:ListItem>
                                <asp:ListItem>18</asp:ListItem>
                                <asp:ListItem>19</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>21</asp:ListItem>
                                <asp:ListItem>22</asp:ListItem>
                                <asp:ListItem>23</asp:ListItem>
                                <asp:ListItem>24</asp:ListItem>
                                <asp:ListItem>25</asp:ListItem>
                                <asp:ListItem>26</asp:ListItem>
                                <asp:ListItem>27</asp:ListItem>
                                <asp:ListItem>28</asp:ListItem>
                                <asp:ListItem>29</asp:ListItem>
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>31</asp:ListItem>
                            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp; Mes:&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlMes" runat="server" Height="16px" Width="63px">
                                <asp:ListItem Value="-">-</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp; Año:&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlAño" runat="server" Height="16px" Width="63px">
                                <asp:ListItem>-</asp:ListItem>
                            </asp:DropDownList>
                            </label>
&nbsp;<asp:Label ID="lblMensajeFecha" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>

                <!-- Seccion inferior con dos columnas -->
                <div class="lower-section">
                        <!-- Parte izquierda: Especialidad, Dias de Atencion, Horario -->
                        <div class="left-form">
                            

                        <!-- Parte derecha: Botones -->
                        <div class="right-buttons">
                            <div class="config-button">
                                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="config-button" OnClick="btnModificar_Click" />

                                <asp:HyperLink ID="hlkVolverAtras" runat="server" CssClass="auto-style1" NavigateUrl="~/ABMLMedicos.aspx">Volver Atras</asp:HyperLink>

                            </div>
                            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>