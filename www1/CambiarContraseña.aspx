<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="www1.CambiarContraseña" %>

<!DOCTYPE html>
<link href="estilos.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="https://unpkg.com/tailwindcss@%5E2/dist/tailwind.min.css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1 align="center" style="font-size: 40px" > Cambiar Contraseña </h1>
    
    <form id="form1" runat="server">
        <div>
            <span class="w-full flex justify-between items-center">
                <label>Contraseña antigua</label>
            </span>
            <asp:TextBox runat="server" ID="Password_Input" TextMode="Password" Text="" placeholder="Escribe su vieja contraseña"  ></asp:TextBox>
        </div>

        <div>
            <span class="w-full flex justify-between items-center">
                <label>Contraseña nueva</label>
            </span>
            <asp:TextBox runat="server" ID="NuevaContra" TextMode="Password" Text="" placeholder="Escribe su nueva contraseña"  ></asp:TextBox>
        </div>
        <div>
            <span class="w-full flex justify-between items-center">
                <label>Confirmar Contraseña nueva</label>
            </span>
            <asp:TextBox runat="server" ID="NuevaContraConf" TextMode="Password" Text="" placeholder="Escribe su nueva contraseña"  ></asp:TextBox>
        </div>
        <br />
       
        <button class="cybr-btn type="submit">
              
                <asp:Button ID="CambiarContra" runat="server" Text="Enviar" OnClick="CambiarContraseñaOnClick" CssClass="cybr-btn" />

        </button>

    </form>
</body>
</html>
