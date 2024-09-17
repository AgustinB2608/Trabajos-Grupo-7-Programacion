<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3b.aspx.cs" Inherits="TP4_Grupo_7.Ejercicio3b" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblListado" runat="server" Font-Bold="True" Font-Size="Large" Text="Listado de libros:"></asp:Label>
            <br />
            <br />
        </div>
        <asp:GridView ID="GvLibros" runat="server">
        </asp:GridView>
        <br />
        <br />
        <asp:LinkButton ID="lkbVolver" runat="server" OnClick="lkbVolver_Click">Consultar otro Tema</asp:LinkButton>
        <br />
    </form>
</body>
</html>
