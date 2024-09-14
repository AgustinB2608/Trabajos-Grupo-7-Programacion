<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP4_Grupo_7.Ejercicio1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ejercicio 1</title>

    <style>
        body {
            margin: 0;
            padding: 0;
        }

        .contenedor {
            width: 80%;
            margin: 0 auto;
            padding: 20px;
            margin-top: 20px;
        }

        .seccion {
            margin-bottom: 20px;
        }

        .titulo-seccion {
            font-size: 18px;
            display: block;
            margin-bottom: 10px;
        }

        .form-grupo {
            margin-bottom: 10px;
        }

        .form-etiqueta {
            display: inline-block;
            width: 100px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <div class="seccion">
                <span class="titulo-seccion">DESTINO INICIO:</span>
                <div class="form-grupo">
                    <label class="form-etiqueta">PROVINCIA:</label>
                    <asp:DropDownList ID="ddlProvincias" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincias_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-grupo">
                    <label class="form-etiqueta">LOCALIDAD:</label>
                    <asp:DropDownList ID="ddlLocalidadesInicio" runat="server"></asp:DropDownList>
                </div>
            </div>

            <div class="seccion">
                <span class="titulo-seccion">DESTINO FINAL:</span>
                <div class="form-grupo">
                    <label class="form-etiqueta">PROVINCIA:</label>
                    <asp:DropDownList ID="ddlProvinciaFinal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvinciaFinal_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-grupo">
                    <label class="form-etiqueta">LOCALIDAD:</label>
                    <asp:DropDownList ID="ddlLocalidadesFinal" runat="server"></asp:DropDownList>
                </div>
            </div>

            <div class="form-grupo">
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar Viaje" OnClick="btnConfirmar_Click" />
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
