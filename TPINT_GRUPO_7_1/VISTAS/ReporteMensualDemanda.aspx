﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteMensualDemanda.aspx.cs" Inherits="VISTAS.AnalisisMensualDemanda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Analisis Mensual de Demanda</title>
    <style>
                :root {
             --color-fondo: #6CB2EB;
             --color-header: #2C3E50;
             --color-boton: #3490dc;
             --color-boton-hover: #2779bd;
             --color-error: #ff6347;
             --color-fondo-error: #f8d7da;
             --radio-borde: 8px;
         }
    .selector-mes{
        border: 2px solid #000;
        font-size: 14px;
        padding: 10px 20px;
        margin: 10px;
        background-color: white;
        color: black;
        border-radius: 5px;
        cursor: pointer;
        font-size: 1rem;
      }
   body {
   margin: 0;
   font-family: Arial, sans-serif;
   background-color:#6CB2EB;
        }

    .header {
        background-color: #2C3E50;
        color: white;
        padding: 15px 20px;
        font-size: 1.2rem;
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

    .contenedor {
       max-width: 100%;         /* Ajusta el ancho máximo al 100% del contenedor padre */
    padding: 20px;           /* Espaciado interno para mayor separación */
    background-color: #fff;  /* Color de fondo blanco */
    border-radius: 10px;     /* Bordes redondeados */
    overflow-x: auto;        /* Agrega scroll horizontal si el contenido es muy ancho */
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); /* Sombra para darle profundidad */
    }

    .titulo {
    font-size: 24px;
    font-weight: bold;
    }

    h1 {
        text-align: center;
        color: #333;
    }

    .form-grupo {
        margin: 20px 0;
        text-align: center;
    }

    .label {
        font-size: 1rem;
        color: #333;
    }

    .textbox {
        width: 200px;
        padding: 10px;
        margin: 10px;
        border: 1px solid #ccc;
        border-radius: 5px;
        font-size: 1rem;
    }

    .textbox:focus {
        border-color: #3490dc;
        outline: none;
    }

    .btn {
        padding: 10px 20px;
        margin: 10px;
        background-color: #3490dc;
        color: white;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        font-size: 1rem;
    }

    .btn:hover {
        background-color: #2779bd;
    }

    .grid-container {
        margin: 20px 0;
    }

    .grid-view {
        width: 100%;
        border-collapse: collapse;
    }

    .grid-view th,
    .grid-view td {
        border: 1px solid #ddd;
        padding: 10px;
        text-align: left;
    }

    .grid-view th {
        background-color: #3490dc;
        color: white;
    }

    .mensaje {
        text-align: center;
        margin: 20px 0;
    }

    .mensaje-texto {
        font-size: 1rem;
    }

    .boton-volver {
        text-align: center;
        margin-top: 20px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Encabezado -->
        <div class="header">
            <div class="titulo">NovaVital</div>
            <asp:Label ID="lblUsuario" runat="server" class="titulo" />
        </div>

        <!-- Contenedor principal -->
        <div class="contenedor">
            <h1 style="font-size: x-large">Análisis Mensual de Demanda por Especialidad </h1>

            <!-- Filtro -->
            <div class="form-grupo">
                <asp:DropDownList ID="ddlMes" runat="server" CssClass="selector-mes" AutoPostBack="True" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged"></asp:DropDownList>
                <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="selector-mes" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <!-- Mensaje -->
            <div class="mensaje">
                <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje-texto" ForeColor="#FF3300" />
            </div>

            <!-- Estadistica -->
            <div class="grid-container">
                <asp:GridView ID="grvEstadistica" runat="server" CssClass="grid-view" />
            </div>

            <!-- Mensaje adicional -->
            <div class="mensaje-adicional">
                <asp:Label ID="lblMensaje1" runat="server" CssClass="mensaje-texto" ForeColor="Red" />
            </div>

            <!-- Botón volver -->
            <div class="boton-volver">
                <asp:Button ID="btnVolver" runat="server" CssClass="btn" Text="Volver atrás" OnClick="btnVolver_Click" />
            </div>
        </div>
    </form>
</body>
</html>
