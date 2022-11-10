<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioGestorWeb.aspx.cs" Inherits="www1.UsuarioGestorWeb" %>

<!DOCTYPE html>
<link href="estilos.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="https://unpkg.com/tailwindcss@%5E2/dist/tailwind.min.css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
       <h1 align="center" style="font-size: 40px"> Usuario </h1>
    <h2> Bienvenido a la página del usuario</h2>
    <form id="form1" runat="server">
        

        <iframe align="center" width="125" height="40" src="https://reloj-alarma.com/embed/#theme=0&m=0&showdate=1" frameborder="0" allowfullscreen></iframe>


        <h2> Crea tu entrada </h2>
        <label >
            Nombre Entrada
            <br />
            <asp:TextBox autofocus="autofocus" runat="server" ID="EntradaNombre_Input"  Text="" placeholder="Escribe su entrada aqui" ></asp:TextBox>
        </label>

       

        <div>
            <span class="w-full flex justify-between items-center">
                <label>Password Mayor de 8 caracteres </label>
            </span>
            <asp:TextBox runat="server" ID="Password_Input" TextMode="Password" Text="" placeholder="Escribe su contraseña" ></asp:TextBox>
        </div>
        <br />
        <button class="cybr-btn w-full flex justify-between items-center" type="submit">
                
                <asp:Button ID="EntradaButton" runat="server" OnClick="EntradaButton_Click" Text="Enviar Entrada" CssClass="cybr-btn" />

        </button>
        <button class="cybr-btn w-full flex justify-between items-center" type="submit">
                
                <asp:Button ID="CambiarContraseña" runat="server" OnClick="CambiarContraseña_Click" Text="Cambiar Contraseña" CssClass="cybr-btn" />
                <span aria-hidden class="cybr-btn__glitch">Enviar</span>
                <span aria-hidden class="cybr-btn__tag">22/23</span>
        </button>

                <button class="cybr-btn" type="submit">
              
                <asp:Button ID="IrGestor" runat="server" OnClick="GestorBackOnClick" Text="VolverAGestor" CssClass="cybr-btn" />
                <span aria-hidden class="cybr-btn__glitch">VolverAGestor</span>
                <span aria-hidden class="cybr-btn__tag">22/23</span>
                
        </button>
        
                <button class="cybr-btn" type="submit">
              
                <asp:Button ID="Button1" runat="server" OnClick="CerrarSesion_Click" Text="Cerrar Sesión" CssClass="cybr-btn" />
                <span aria-hidden class="cybr-btn__glitch">Cerrar Sesión</span>
                <span aria-hidden class="cybr-btn__tag">22/23</span>
                
        </button>

    </form>
</body>
</html>
