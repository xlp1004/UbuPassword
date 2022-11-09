<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BorrarUsuarioGestorWeb.aspx.cs" Inherits="www1.BorrarUsuarioGestorWeb" %>

<!DOCTYPE html>
<link href="estilos.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="https://unpkg.com/tailwindcss@%5E2/dist/tailwind.min.css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1 align="center" style="font-size: 40px"> Borrar Usuario Siendo Gestor </h1>
    <h2> Bienvenido a la página para borrar Usuarios siendo Gestor</h2>
    <form id="form1" runat="server">
         <label >
            Email del usuario que quieres eliminar de la red (tiene que ser @ubu.es)
            <asp:TextBox autofocus="autofocus" runat="server" ID="Email_Usuario_Input"  Text="" placeholder="Escribe el email" ></asp:TextBox>
        <br />
            ¿Estás Seguro que quieres borrarlo?
            <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" />
        </label>
        <button class="cybr-btn w-full flex justify-between items-center" type="submit">
                
                <asp:Button ID="BorrarUsuario" runat="server" OnClick="BorrarUsuarioOnClick" Text="Borrar al usuario" CssClass="cybr-btn" />
                <span aria-hidden class="cybr-btn__glitch">Borrar al usuario</span>
                <span aria-hidden class="cybr-btn__tag">22/23</span>
        </button>

                <button class="cybr-btn" type="submit">
              
                <asp:Button ID="VolverAGestor" runat="server" OnClick="VolverAUsuarioGestorOnClick" Text="Volver a Gestor" CssClass="cybr-btn" />
                <span aria-hidden class="cybr-btn__glitch">Volver a Gestor</span>
                <span aria-hidden class="cybr-btn__tag">22/23</span>
                
        </button>
    </form>
</body>
</html>
