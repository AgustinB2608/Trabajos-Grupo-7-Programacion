<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3.aspx.cs" Inherits="TP4_Grupo_7.Ejercicio3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp; Seleccionar Tema:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:DropDownList ID="ddlTemas" runat="server">
            </asp:DropDownList>
        </p>
        <p>
            &nbsp;&nbsp;&nbsp; &nbsp;<asp:LinkButton ID="lnkVerLibros" runat="server" OnClick="lnkVerLibros_Click">Ver Libros</asp:LinkButton>
        </p>
    </form>
</body>
</html>
