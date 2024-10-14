<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarSucursales.aspx.cs" Inherits="TP7_Grupo_7.SeleccionarSucursales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Listado de Sucursales</title>
    <style>
        /*Selector Root para hacer variables globales, */
        :root {
            --color-principal: #FF6F61; 
            --color-secundario: #6B5B93; 
            --color-acento: #88B04B; 
            --color-fondo: #F7F7F7; 
            --color-texto: #333333; 
            --color-header: #F2F2F2; 
            --color-boton: #FF6F61; 
            --color-boton-hover: #E65C50; 
            --color-fondo-tarjeta: #FFFFFF;
            --color-borde-tarjeta: #E0E0E0;
            --color-enlace: #6B5B93;
            --color-enlace-hover: #5A4E7E; 
            --color-enlace-nav: #6B5B93; 
            --color-enlace-nav-hover: #5A4E7E; 
            --color-h2: #333333; 
            --color-boton-busqueda: #FF6F61; 
            --color-boton-busqueda-hover: #E65C50; 
            --color-boton-provincia: #6B5B93;
            --color-boton-provincia-hover: #5A4E7E; 
            --color-tarjeta-sucursal: #FFFFFF; 
            --color-texto-tarjeta-sucursal: #333333;
            --color-boton-seleccionar: #FF6F61; 
            --color-boton-seleccionar-hover: #E65C50; 
            /*Para usar las variables es "var(nombre de la variable)*/
        }

        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }

        header {
            background-color: var(--color-header); 
            padding: 10px 0; 
            box-shadow: 0 1px 30px rgba(0, 0, 0, 0.3); /*una sombra leve que aparece abajo del encabezado*/
        }

        .nav-links { /*Para manejar los links a los otros ejercicios, centrado horizontal y le sacamos todos los margenes */
            list-style-type: none;
            padding: 0;
            margin: 0;
            display: flex;
            justify-content: center; 
        }

        .nav-links li {
            margin: 0 40px; 
        }

        .nav-links a { /*Para manejar los links a los otros ejercicios, color, tamaño, negrita y transicion de color*/
            color: var(--color-enlace-nav); 
            text-decoration: none; 
            font-size: 14px; 
            font-weight: bold; 
            transition: color 0.3s; 
        }

        .nav-links a:hover {
            color: var(--color-enlace-nav-hover); 
        }

        h2 {
            text-align: center;
            margin: 15px 0; 
            color: var(--color-h2); 
        }

        .search-container {     /*Para el contenedor de busqueda, centrado horizontal y margen*/
            margin: 20px 0;
            text-align: center;
        }

        .search-container input[type="text"] { /*Para el input de busqueda, tamaño, padding, borde y radio de esquinas*/
            padding: 10px;
            width: 300px;
            border-radius: 5px; 
            border: 1px solid #ccc; 
        }

        .search-container .btn-search { /*Para el boton de busqueda, tamaño, padding, color, borde, radio de esquinas y cursor*/
            padding: 10px 20px;
            background-color: var(--color-boton-busqueda); 
            color: white;
            border: none;
            border-radius: 5px; 
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .search-container .btn-search:hover {
            background-color: var(--color-boton-busqueda-hover); 
        }

        .provinces { /*Para el contenedor de provincias, centrado horizontal y margen*/
            display: flex;
            flex-wrap: wrap;
            margin-bottom: 10px;
            justify-content: space-around;
        }

        .provinces .btn-province {  /*Para los botones de provincias, tamaño, padding, color, borde, radio de esquinas y cursor*/
            padding: 10px 20px;
            background-color: var(--color-boton-provincia); 
            color: white;
            border: none;
            border-radius: 5px; 
            cursor: pointer; /*Pointer hace que aparezca la manito al estar arriba de un boton*/
            transition: background-color 0.3s;
        }

        .provinces .btn-province:hover {
            background-color: var(--color-boton-provincia-hover); /*Cambia de color al pasar por arriba al boton d provincias*/
        }

        .sucursales-grid {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(200px, 1fr)); /* Crea columnas que se ajustan al tamaño del contenedor. autofit determina automáticamente cuántas columnas caben según el espacio disponible. minmax(200px, 1fr) hace que cada columna tenga un ancho mínimo de 200 píxeles  y un ancho máximo que puede crecer hasta ocupar una fracción del espacio q qda dispobible. */
            gap: 20px;
            padding: 20px;
            background-color: #e1e1e1;
            border-radius: 10px; 
            border: 1px solid var(--color-borde-tarjeta);
        }

        .sucursal-card { /*Para las tarjetas de sucursales, tamaño, padding, color, borde, radio de esquinas, sombra y transicion de movimiento*/
            background-color: var(--color-tarjeta-sucursal); 
            color: var(--color-texto-tarjeta-sucursal); 
            padding: 20px;
            text-align: center;
            border-radius: 10px; 
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2); 
            border: 1px solid var(--color-borde-tarjeta); 
            transition: transform 0.2s; 
        }

        .sucursal-card:hover {
            transform: translateY(-5px); /*hace que el contenedor se mueva -5px para arriba, si se pone numero positivo va para abajo*/
            /*hace un efecto de movimiento*/
        }

        .sucursal-card img { /*Para ajustar bien las imagenes.*/
            max-width: 80%; 
            height: auto;
            margin-bottom: 10px;
            border-radius: 5px; 
        }

        .sucursal-card h3 {
            margin: 10px 0; 
        }

        .sucursal-card p {
            font-size: 14px; 
            margin-bottom: 15px; 
        }

        .sucursal-card .btn-select { /*Para los botones de seleccionar, tamaño, padding, color, borde, radio de esquinas y cursor*/
            padding: 10px 20px;
            background-color: var(--color-boton-seleccionar); 
            color: white;
            border: none;
            border-radius: 5px; 
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .sucursal-card .btn-select:hover {
            background-color: var(--color-boton-seleccionar-hover); 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <%-- Header con los links a los otros ejercicios--%>
        <header>
        <ul class="nav-links"> 
            <li>
                <asp:HyperLink ID="hkListadoSucursales" runat="server" NavigateUrl="~/SeleccionarSucursales.aspx">Listado de Sucursales</asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="hkMostrarSucursales" runat="server" NavigateUrl="~/ListadoSucursalesSeleccionadas.aspx">Sucursales Seleccionadas</asp:HyperLink>
            </li>
        </ul>
        </header>
        
        <main class="container">
            <h2>Listado de sucursales</h2>

            <section class="search-container">
                <asp:TextBox ID="txtBuscar" runat="server" placeholder="Búsqueda por nombre de sucursal"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn-search" OnClick="btnBuscar_Click" />
            </section>

                <section class="provinces">
                    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <ItemTemplate>
                            <asp:Button ID="BtnNombreProv" runat="server" Text='<%# Eval("DescripcionProvincia") %>' CssClass="btn-province" CommandArgument='<%# Eval("ID_Provincia") %>' OnCommand="BtnNombreProv_Command" />
                        </ItemTemplate>
                    </asp:DataList>

                        <!-- Botón para mostrar todas las sucursales -->
                        <asp:Button ID="btnMostrarTodasSucursales" runat="server" Text="Todo" CssClass="btn-province" OnClick="btnMostrarTodasSucursales_Click" />

                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:BDSucursalesConnectionString2 %>" 
                        SelectCommand="SELECT [ID_Provincia], [DescripcionProvincia] FROM [Provincia]">
                        </asp:SqlDataSource>
                </section>


            <asp:ListView ID="lvSucursales" runat="server" GroupItemCount="3" DataKeyNames="Id_Sucursal">
                <LayoutTemplate>
                    <div class="sucursales-grid">
                        <asp:PlaceHolder ID="groupPlaceholder" runat="server"></asp:PlaceHolder>
                    </div>
                    <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </LayoutTemplate>
                <GroupTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </GroupTemplate>
                <ItemTemplate>
                    <div class="sucursal-card">
                        <asp:Image ID="ImagenSucursal" runat="server" ImageUrl='<%# Eval("URL_Imagen_Sucursal") %>' AlternateText='<%# Eval("NombreSucursal") %>' />
                        <h3><asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' /></h3>
                        <p><asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' /></p>
                        <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" OnClick="btnSeleccionar_Click" CssClass="btn-select" />
                    </div>
                </ItemTemplate>
            </asp:ListView>

            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </main>
    </form>
</body>
</html>