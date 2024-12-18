﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AñadirPaciente.aspx.cs" Inherits="VISTAS.ABMLPacientes" UnobtrusiveValidationMode="None" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestión de Personal Médico</title>
    <style>
        :root {
            --color-fondo: #6CB2EB;
            --color-header: #2C3E50;
            --color-boton: #3490dc;
            --color-boton-hover: #2779bd;
            --color-textbox: #ddd;
            --color-error: #ff6347;
            --color-fondo-error: #f8d7da;
            --radio-borde: 8px;
        }

        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: Arial, sans-serif;
        }

        html, body {
            height: 100%;
        }

        body {
            background-color: var(--color-fondo);
            display: flex;
            flex-direction: column;
            min-height: 100vh;
        }

        header {
            background-color: #2C3E50;
            color: white;
            display: flex;
            justify-content: space-between;
            padding: 15px 20px;
            font-weight: bold;
            align-items: center;              
        }

        #lblUsuario {
            font-weight: bold;
        }

        .titulo {
            font-size: 24px;
            font-weight: bold;
        }

        .contenedor {
            flex: 1;
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 20px;
            min-height: calc(100vh - 80px);
        }

        .formulario-contenedor {
            display: flex;
            flex-direction: column;
            gap: 20px;
            max-width: 800px;
            width: 100%;
            margin: auto;
            padding: 40px;
            background-color: white;
            border-radius: var(--radio-borde);
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .title {
            text-align: center;
            font-size: 20px;
            font-weight: bold;
            color: var(--color-header);
            margin-bottom: 40px;
        }

        .form-columns {
            display: flex;
            gap: 40px;
        }

        .form-columna {
            flex: 1;
            display: flex;
            flex-direction: column;
            gap: 15px;
        }

        .form-group {
            display: flex;
            flex-direction: column;
        }

        .form-label {
            font-weight: bold;
            margin-bottom: 5px;
            font-size: 14px;
        }

        .form-control {
            width: 100%;
            padding: 12px;
            border: 1px solid var(--color-textbox);
            border-radius: 4px;
            font-size: 14px;
        }
        .form-control::placeholder {
            color: #757575; 
        }

        .btn-container {
            display: flex;
            justify-content: center;
            gap: 10px;
        }

        .btn {
            width: 100%;
            padding: 12px;
            background-color: var(--color-boton);
            color: white;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
        }

        .btn:hover {
            background-color: var(--color-boton-hover);
        }

        .error-message{
            color: var(--color-error);
        }

       .msgConfirmacion {
            padding: 20px;
            border-radius: var(--radio-borde);
            margin-top: 20px;
            text-align: center;
        }

        .msgConfirmacion input {
            width: 100%;
            padding: 12px;
            margin-top: 10px;
            border-radius: 4px;
            border: 1px solid black;
        }

        .msgConfirmacion .btn {
            width: 100%;
            padding: 12px;
            background-color: var(--color-boton);
            color: white;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
        }

        .msgConfirmacion .btn:last-child {
            width: 100%;
            padding: 12px;
            background-color: #e74c3c; 
            color: white;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
        }

        .msgConfirmacionCompleta {
            color: white;
            padding: 15px;
            margin-top: 15px;
            border-radius: 5px;
            text-align: center;
        }

        .mensajeConfirmacion {
            font-size: 1.5rem;
            font-weight: bold;
            text-transform: uppercase;
            color: #28a745;
        }

       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div class="titulo">NovaVital</div>
            <asp:Label ID="lblUsuario" runat="server" class="titulo" />
        </header>

	<%--Contenedor Principal--%>
        <div class="contenedor">
            <%--Contenedor 2--%>
            <div class="formulario-contenedor">
               <h1 id="h1" runat="server">Añadir Paciente</h1>
               
                  
        
         <%--Columnas--%>
                <div id="colums" class="form-columns" runat="server">
                    <!-- Columna Izquierda -->
                    <div class="form-columna">
                        <%--Nombre--%>
                        <div class="form-group">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingresar Nombre" ></asp:TextBox>
                        </div>
                        <%--DNI--%>
                        <div class="form-group">
                            <asp:Label ID="lblDni" runat="server" Text="DNI:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" placeholder="Ingresar DNI"></asp:TextBox>
                        </div>
                        <%--Correo Electronico--%>
                        <div class="form-group">
                            <asp:Label ID="lblEmail" runat="server" Text="E-mail:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Ingresar Correo" ></asp:TextBox>                            
                        </div>
                        <%--Celular--%>
                        <div class="form-group">
                            <asp:Label ID="lblCelular" runat="server" Text="Tel/Celular:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" placeholder="Ingresar Celular" ></asp:TextBox>
                        </div>
                        <%--Nacionalidad--%>
                        <div class="form-group">
                            <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="form-control" placeholder="Ingresar Nacionalidad" ></asp:TextBox>
                        </div>
                        <%--Direccion--%>
                        <div class="form-group">
                            <asp:Label ID="lblDireccion" runat="server" Text="Dirección:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Ingresar Direccion" ></asp:TextBox>
                        </div>
                        <%--Fecha de Nacimiento--%>
                        <div class="form-group">
                            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento:" CssClass="form-label"></asp:Label>
                            <div class="form-columns">
                                <!-- Día -->
                                <asp:DropDownList ID="ddlDia" runat="server" CssClass="form-control">
                                    <%-- Aquí cargarás los días del 1 al 31 --%>
                                    <asp:ListItem Value="0">Seleccionar Día</asp:ListItem>
                                    <asp:ListItem>01</asp:ListItem>
                                    <asp:ListItem>02</asp:ListItem>
                                    <asp:ListItem>03</asp:ListItem>
                                    <asp:ListItem>04</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>06</asp:ListItem>
                                    <asp:ListItem>07</asp:ListItem>
                                    <asp:ListItem>08</asp:ListItem>
                                    <asp:ListItem>09</asp:ListItem>
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

                                <!-- Mes -->
                                <asp:DropDownList ID="ddlMes" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Seleccionar Mes" Value="0" />
                                    <%-- Aquí cargarás los meses, por ejemplo Enero a Diciembre --%>
                                </asp:DropDownList>

                                <!-- Año -->
                                <asp:DropDownList ID="ddlAño" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Seleccionar Año" Value="0" />
                                    <%-- Aquí cargarás los años, por ejemplo del 1900 al año actual --%>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%--Label para los mensajes d error--%>
                        <div class="error-message">
                            <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red" />
                        </div>
                       
                    </div>

                    <!-- Columna Derecha -->
                    <div class="form-columna">
                        <%--Apellido--%>
                        <div class="form-group">
                            <asp:Label ID="lblApellido" runat="server" Text="Apellido:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingresar Apellido "></asp:TextBox>
                        </div>
                        <%--Sexo--%>
                        <div class="form-group">
                            <asp:Label ID="lblSexo" runat="server" Text="Sexo:" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <%--Provincia--%>
                        <div class="form-group">
                            <asp:Label ID="lblProvincia" runat="server" Text="Provincia:" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <%--Localidad--%>
                        <div class="form-group">
                            <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    <%--Botones--%>
                        <div class="btn-container">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click1" CssClass="btn" />
                    	<asp:HyperLink ID="hlAtras" runat="server" NavigateUrl="~/ABMLPacientes.aspx" CssClass="btn">Atrás</asp:HyperLink>
                        </div>
                     </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>