<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="webSistemaInventarioBioEyza.Html.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Css/Login.css" rel="stylesheet" />
     <link rel="stylesheet" href="../Css/bootstrap.min.css" />
<!-- style css -->
<link rel="stylesheet" href="../Css/style.css" />
    <link rel="icon" href="../img/ICON BIOOOOO.png" type="image/x-icon"/>
    <title>Login</title>

</head>
<body>
    <form id="registerForm" runat="server">
        <div class="register-container">
            <h2 class="register-title">Login</h2>
            <div class="register-form">

                <asp:Label runat="server" Text="Nombre:"></asp:Label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="register-input" placeholder="Ingrese su nombre" required="required"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Contraseña:"></asp:Label>
                <asp:TextBox runat="server" ID="txtContraseña" CssClass="register-input" TextMode="Password" placeholder="Ingrese su contraseña" required="required"></asp:TextBox>
                <br />
                <asp:Button runat="server" ID="btnLogin" CssClass="submit-button" Text="Loguear" OnClick="btnLogin_Click" />
                <asp:Label CssClass="heading2"  ID="lblMensaje" runat="server" Visible="true"> </asp:Label>
                <br />
            </div>
        </div>
    </form>
</body>
</html>
