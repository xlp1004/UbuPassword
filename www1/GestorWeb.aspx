<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestorWeb.aspx.cs" Inherits="www1.WebForm2" %>

<!DOCTYPE html>
<link href="estilos.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="https://unpkg.com/tailwindcss@%5E2/dist/tailwind.min.css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1 align="center" style="font-size: 40px" > Gestor </h1>
    <h2> Bienvenido a la página del gestor</h2>
    <form id="form1" runat="server">
               
        <button class="cybr-btn" type="submit">
              
                <asp:Button ID="CambiarAUsuarioButton" runat="server" OnClick="CambiarAUsuario" Text="Cambiar a Usuario" CssClass="cybr-btn" />
                <span aria-hidden class="cybr-btn__glitch">Cambiar Usuario</span>
                <span aria-hidden class="cybr-btn__tag">22/23</span>

        </button>
        <button class="cybr-btn" type="submit">
              
                <asp:Button ID="VerEntradaLogs" runat="server" OnClick="EntradaLog_Click" Text="VerEntradaLogs" CssClass="cybr-btn" />              
                <span aria-hidden class="cybr-btn__glitch">Enviar</span>
                <span aria-hidden class="cybr-btn__tag">22/23</span>
        </button>

       <button class="cybr-btn" type="submit">
              
                <asp:Button ID="BotonCrearUsuario" runat="server" OnClick="CrearUsuarioOnClick" Text="Crear Usuario" CssClass="cybr-btn" />              
                <span aria-hidden class="cybr-btn__glitch">Crear Usuario</span>
                <span aria-hidden class="cybr-btn__tag">22/23</span>
        </button>
        
       <button class="cybr-btn" type="submit">
              
                <asp:Button ID="BorrarUsuarioButton" runat="server" OnClick="BorrarUsuarioOnClick" Text="Borrar Usuario" CssClass="cybr-btn" />              
                <span aria-hidden class="cybr-btn__glitch">Borrar Usuario</span>
                <span aria-hidden class="cybr-btn__tag">22/23</span>
        </button>
       <button class="cybr-btn" type="submit">
              
                <asp:Button ID="CerrarSesiónButton" runat="server" OnClick="CerrarSesion_Click" Text="Cerrar Sesión" CssClass="cybr-btn" />
                <span aria-hidden class="cybr-btn__glitch">Enviar</span>
                <span aria-hidden class="cybr-btn__tag">22/23</span>
                
        </button>



           
    </form>
</body>
</html>
