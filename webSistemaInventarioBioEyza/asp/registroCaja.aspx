<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registroCaja.aspx.cs" Inherits="webSistemaInventarioBioEyza.Html.index"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Registro de Cajas</title>
    <link href="../Css/RegistroCaja.css" rel="stylesheet" />
    <link rel="icon" href="../img/ICON BIOOOOO.png" type="image/x-icon"/>
    <link rel="stylesheet" href="../Css/bootstrap.min.css"/>
    <link rel="stylesheet" href="../Css/style.css"/>
   <!-- <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/> -->
</head>

<body>

    <form id="form1" runat="server">

        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="logo"><a href="index.aspx">
                <img src="../img/icon_BIO-removebg-preview.png" /></a></div>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">

                    <li class="nav-item active">
                        <a class="nav-link" href="index.aspx">Inicio</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="mostrarInventario.aspx">Mostrar Inventario</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="retirarCajas.aspx">Retirar Cajas</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="consultarRetiros.aspx">Consultar Cajas</a>
                    </li>
                    <li class="nav-item">
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar sesión" OnClick="btnCerrarSesión_Click" CssClass="button-cerrar-sesion" />
                    </li>
                </ul>
            </div>
        </nav>

        <div class="container">
            <div class="form-container">
                <h2>Registrar Caja</h2>
                <div>
                    <label for="nombreCaja">Nombre de la Caja:</label>
                    <asp:TextBox ID="txtNombreCaja" runat="server" CssClass="textbox" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div>
                    <label for="cantidadCajas">Cantidad de Cajas:</label>
                    <asp:TextBox ID="txtCantidadCajas" runat="server" CssClass="textbox" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div>
                    <label for="cantidadPorUnidad">Cantidad por Unidad:</label>
                    <asp:TextBox ID="txtCantidadUnidad" runat="server" CssClass="textbox" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div>
                    <label for="dlTipoInventario">Tipo de Inventario:</label>
                    <asp:DropDownList ID="tipoInventario" runat="server" CssClass="textbox" ClientIDMode="Static">
                        <asp:ListItem Text="Bioeyza" Value="Bioeyza"></asp:ListItem>
                        <asp:ListItem Text="Lote" Value="Lote"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" CssClass="submit-button" />
            </div>
        </div>
    </form>

<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

</body>
</html>

