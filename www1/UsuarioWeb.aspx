<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioWeb.aspx.cs" Inherits="www1.UsuarioWeb" %>

<!DOCTYPE html>
<link href="estilos.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="https://unpkg.com/tailwindcss@%5E2/dist/tailwind.min.css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
       <h1 align="center"> Usuario </h1>
    <h2> Bienvenido a la página del usuario</h2>
    <form id="form1" runat="server">
        

        <button class="cybr-btn" type="submit">
              
                <asp:Button ID="CerrarSesión" runat="server" OnClick="CerrarSesion_Click" Text="Cerrar Sesión" CssClass="cybr-btn" />
              
                
        </button>

        <h2> Crea tu entrada </h2>
        <label >
            Nombre Entrada
            <asp:TextBox autofocus="autofocus" runat="server" ID="EntradaNombre_Input"  Text="" placeholder="Escribe su entrada aqui" CssClass="textobox"></asp:TextBox>
        </label>

       

        <div>
            <span class="w-full flex justify-between items-center">
                <label>Password</label>
            </span>
            <asp:TextBox runat="server" ID="Password_Input" TextMode="Password" Text="" placeholder="Escribe su contraseña" ></asp:TextBox>
        </div>

        <button class="cybr-btn w-full flex justify-between items-center" type="submit">
                
                <asp:Button ID="EntradaButton" runat="server" OnClick="EntradaButton_Click" Text="Enviar Entrada" CssClass="cybr-btn" />
                
        </button>

    </form>
</body>
</html>
