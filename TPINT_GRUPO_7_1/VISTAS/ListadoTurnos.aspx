﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoTurnos.aspx.cs" Inherits="VISTAS.ListadoTurnos" UnobtrusiveValidationMode="None" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado de turnos</title>
    <style>
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
            background-color: #6CB2EB;
            display: flex;
            flex-direction: column;
        }

        header {
            background-color: #2C3E50;
            padding: 20px;
            color: white;
            display: flex;
            justify-content: space-between;
            align-items: center;
            width: 100%;
        }

        .titulo {
            font-size: 24px;
            font-weight: bold;
        }

        .usuario {
            font-size: 24px;
            font-weight: bold;
        }

        .contenedor {
            flex: 1;
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 20px;
            overflow-x: auto;
        }

        .auto-style1 {
            width: 140%; /* Ocupa todo el ancho disponible */
            max-width: 1000px; /* Mantiene el ancho máximo de 1000px */
            background: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            position: relative;
            text-align: left;
        }

        .titulo-seccion {
            font-size: 22px;
            font-weight: bold;
            color: black;
            margin-bottom: 20px;
            text-align: center;
        }

        .search-filter-row {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 20px;
        }

        .search-container {
            display: flex;
            align-items: center;
            gap: 10px;
        }

        .form-control {
            padding: 10px;
            font-size: 14px;
            border: 1px solid #ddd;
            border-radius: 4px;
        }

        .search-button {
            padding: 10px 20px;
            font-size: 14px;
            background-color: #2C3E50;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .search-button:hover {
            background-color: #1A252F;
        }

        .filter-container {
            display: flex;
            gap: 10px;
        }

        .gridview-container {
            display: flex;
            justify-content: flex-start;
            
            margin-bottom: 20px;
            margin: 0; /* Elimina márgenes adicionales */
            padding: 0; /* Elimina cualquier relleno adicional */
            width: 100%;
            max-width: 100%;
        }
        .gridview {
            width: 130%; /* Ajusta este porcentaje para hacerlo más largo horizontalmente */
            table-layout: auto; /* Permite a las columnas ajustarse automáticamente */
            margin: 0 auto;
        }

        .volver-menu {
            padding: 10px 20px;
            background-color: #2C3E50;
            color: white;
            text-decoration: none;
            font-size: 14px;
            border-radius: 4px;
            bottom: 20px;
            right: 20px;
            cursor: pointer;
            text-align: center;
            display: inline-block; 
            margin-top: 5px;
            float: right;
        }

        .volver-menu:hover {
            background-color: #1A252F;
        }

        .presente-button,
        .ausente-button {
           padding: 5px 10px; 
           font-size: 12px; 
           background-color: #2C3E50;
           color: white;
           border: none;
           border-radius: 4px;
           cursor: pointer;
           margin-right: 5px;
        }

        .presente-button:hover,
        .ausente-button:hover {
            background-color: #1A252F;

        }

        .gridview .pager {
            background-color: #2C3E50; /* Azul oscuro */
            padding: 10px;
            text-align: center;
            border-radius: 4px;
        }

        .gridview .pager a {
            color: white; /* Números en blanco */
            padding: 8px 12px;
            margin: 0 4px;
            text-decoration: none;
            border-radius: 4px;
        }

        .gridview .pager a:hover {
            background-color: #1A252F; /* Azul aún más oscuro para el hover */
        }
        
        .gridview .pager span {
            color: white; /* Color blanco para el número de la página activa */
            padding: 8px 12px;
            margin: 0 4px;
            font-weight: bold;
            border-radius: 4px;
        }

        .gridview th {
             text-align: center;
        }

        /* Centrar el contenido de las columnas */
        .gridview td {
             text-align: center;
        }
        #mensaje {
            display: flex;
            flex-direction: column; /* Los elementos estarán en columna */
            align-items: center; /* Centra el texto horizontalmente */
            justify-content: flex-start; /* Alinea los elementos al inicio del contenedor */
            margin-top: 10px; /* Espaciado superior*/
        }
        .botones-container {
            display: flex; /* Alinea los botones horizontalmente */
            justify-content: center; /* Centra los botones en el contenedor */
            gap: 7px; /* Menor espacio entre los botones */
            margin-top: 5px; /* Menos espacio entre el texto y los botones */
        }

        .aceptar-cancelar-button {
            margin: 10px 20px; /* Espacio entre los botones */
            padding: 10px 20px; /* Tamaño de los botones */
            font-size: 14px; /* Tamaño de la fuente */
            background-color: #2C3E50; /* Color de fondo */
            color: white; /* Color del texto */
            border: none; /* Sin bordes */
            border-radius: 4px; /* Bordes redondeados */
            cursor: pointer; /* Apunta como cursor de acción */
        }
        
        .aceptar-cancelar-button:hover {
            background-color: #1A252F; /* Cambio de color al pasar el ratón */
        }

        #txtBuscar {
            width: 250px;
        }



    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div class="titulo">NovaVital</div>
            <asp:Label ID="lblUsuario" runat="server" class="titulo" />
            
        </header>
        
        <div class="contenedor">
            <div class="auto-style1">
                <div class="titulo-seccion">Listado de Turnos</div>

               
                <div class="search-filter-row">
                    <div class="search-container">

                        

                        <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" Placeholder="Buscar nombre/apellido medico"></asp:TextBox>

                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="search-button" OnClick="btnBuscar_Click" />
                    </div>
                    <div class="filter-container">
                       
                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
                               <asp:ListItem Text="Seleccione un estado" Value="0"></asp:ListItem>
                          
                                <asp:ListItem Text="Pendiente" Value="P" />
                                <asp:ListItem Text="Confirmado" Value="C" />
                                <asp:ListItem Text="Cancelado" Value="S" />
                          
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" >
                            <asp:ListItem Text="Especialidad" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

               
                <div class="gridview-container">
                    <asp:GridView ID="gvTurnos" runat="server" CssClass="gridview" AutoGenerateColumns="False" AllowPaging="True" PageSize="8"  OnPageIndexChanging="gvTurnos_PageIndexChanging" >
                        <Columns>
                              <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                              <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                              <asp:BoundField DataField="Medico" HeaderText="Médico" />
                              <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                              <asp:BoundField DataField="Estado" HeaderText="Estado" />
                              <asp:TemplateField HeaderText="Presentismo">
                                 <ItemTemplate>
                                    <asp:LinkButton ID="lkbPresente" runat="server" 
                                     NavigateUrl="~/ObservacionTurno.aspx" Text="Presente" CommandName="MarcarPresente" CommandArgument='<%# Eval("CodTurno_TU") %>' OnCommand="lkbPresente_Command" CssClass="presente-button"  />
                                    <asp:Button ID="btnAusente" runat="server" Text="Ausente" CommandName="MarcarAusente" CommandArgument='<%# Eval("CodTurno_TU") %>' CssClass="ausente-button"  OnCommand="btnAusente_Command"  />
                                 </ItemTemplate>
                             </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

                    <div id="mensaje">
                        
                            <asp:Label ID="lblMensaje2" runat="server"></asp:Label>
                        
                   <div class="botones-container">
                     <asp:Button ID="btnConfirmarEliminar" runat="server" OnClick="btnConfirmarEliminar_Click" Text="Confirmar" CssClass="aceptar-cancelar-button" />
                     <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" CssClass="aceptar-cancelar-button" />
                 </div>
               </div> 

               

                

               

                <asp:HyperLink ID="lnkVolverMenu" runat="server" NavigateUrl="~/InicioLogin.aspx" CssClass="volver-menu">Cerrar Sesion</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>