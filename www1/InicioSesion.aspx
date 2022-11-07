<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="www1.WebForm1" %>

<!DOCTYPE html>
<link href="estilos.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="https://unpkg.com/tailwindcss@%5E2/dist/tailwind.min.css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>INICIO DE SESIÓN</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1 align="center" >INICIO DE SESIÓN</h1>
        <label >
            Email
            <asp:TextBox autofocus="autofocus" runat="server" ID="Email_Input" AutoCompleteType="Email" TextMode="Email" Text="" placeholder="Escribe su email"></asp:TextBox>
        </label>

        <div>
            <span class="w-full flex justify-between items-center">
                <label>Password</label>
            </span>
            <asp:TextBox runat="server" ID="Password_Input" TextMode="Password" Text="" placeholder="Escribe su contraseña"  ></asp:TextBox>
        </div>
       
        <button class="cybr-btn type="submit">
              
                <asp:Button ID="Button1" runat="server" Text="Enviar" OnClick="Button1_Click" CssClass="cybr-btn" />
                
        </button>
           
            
        
    </form>
    
</body>
</html>
