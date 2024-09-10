<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP4_Grupo_7.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Destino inicial:<br />
            <br />
            Provincia:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlProvincias" runat="server">
            </asp:DropDownList>
            <br />
            Localidad&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlLocalidadesInicio" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <span class="auto-style1">Destino Final:<br />
            <br />
            </span><strong>Provincia&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlProvinciaFinal" runat="server">
            </asp:DropDownList>
            </strong>
        </div>
    </form>
</body>
</html>
