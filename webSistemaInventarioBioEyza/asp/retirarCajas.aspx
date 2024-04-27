<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="retirarCajas.aspx.cs" Inherits="webSistemaInventarioBioEyza.Html.retirarCajas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Css/RetirarCajas.css" rel="stylesheet" />
    <link rel="icon" href="../img/ICON BIOOOOO.png" type="image/x-icon"/>
    <link rel="stylesheet" href="../Css/bootstrap.min.css"/>
<link rel="stylesheet" href="../Css/style.css"/>
    <title></title>
    <!-- Agregar referencias a jQuery y jQuery UI -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
    <!-- Script para inicializar el DatePicker -->
    <script>
        $(document).ready(function () {
            $.datepicker.regional['es'] = {
                closeText: 'Cerrar',
                prevText: '< Ant',
                nextText: 'Sig >',
                currentText: 'Hoy',
                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
                dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
                weekHeader: 'Sm',
                dateFormat: 'dd/mm/yy',
                firstDay: 1,
                isRTL: false,
                showMonthAfterYear: false,
                yearSuffix: ''
            };
            $.datepicker.setDefaults($.datepicker.regional['es']);
            $(function () {
                $("#fecha").datepicker();
            });
            $("#<%=txtFecha.ClientID%>").datepicker({
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
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
                <a class="nav-link" href="registroCaja.aspx">Agregar Cajas</a>
            </li>
             <li class="nav-item">
                 <a class="nav-link" href="mostrarInventario.aspx">Mostrar Inventario</a>
             </li>
             
             <li class="nav-item">
                 <a class="nav-link" href="consultarRetiros.aspx">Consultar Cajas</a>
             </li>
             <li class="nav-item">
               <a class="nav-link" href="editarCaja.aspx">Editar caja</a>
            </li>
             <li class="nav-item">
                 <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar sesión" OnClick="btnCerrarSesión_Click" CssClass="submit-button" />
             </li>
         </ul>
     </div>
 </nav>
        <div class="container">
            <h2>Retirar Cajas</h2>
            <div>
                <asp:Label ID="lblNombreCaja" runat="server" Text="Nombre de la Caja:" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtNombreCaja" runat="server" CssClass="textbox"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblCantidadRetirar" runat="server" Text="Cantidad para retirar (unidades):" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtCantidadRetirar" runat="server" CssClass="textbox"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblDestinatario" runat="server" Text="Destinatario:" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtDestinatario" runat="server" CssClass="textbox"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblCodigoFactura" runat="server" Text="Código de Factura:" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtCodigoFactura" runat="server" CssClass="textbox"></asp:TextBox>
            </div>
            <div>
            <asp:Label ID="lblEtiquetaCaja" runat="server" Text="Etiqueta de la caja:" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtEtiquetaCaja" runat="server" CssClass="textbox"></asp:TextBox>
        </div>
            <div>
                <asp:Label ID="lblComentario" runat="server" Text="Comentario: (Opcional)" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine" Rows="4" CssClass="textbox"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblFecha" runat="server" Text="Fecha de Retiro:" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtFecha" runat="server" CssClass="textbox"></asp:TextBox>
            </div>

            <div>
                <asp:Label ID="lblTipoInventario" runat="server" Text="Tipo de inventario" CssClass="label"></asp:Label>
                <asp:DropDownList ID="tipoInventario" runat="server" CssClass="textbox" ClientIDMode="Static">
                    <asp:ListItem Text="Bioeyza" Value="Bioeyza"></asp:ListItem>
                    <asp:ListItem Text="Lote" Value="Lote"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div>
                <br />
                <asp:Button ID="btnRetirarCaja" runat="server" Text="Retirar Caja" CssClass="button" OnClick="btnRetirarCajas" />
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
