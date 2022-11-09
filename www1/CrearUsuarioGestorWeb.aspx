<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearUsuarioGestorWeb.aspx.cs" Inherits="www1.CrearUsuarioGestorWeb" %>

<!DOCTYPE html>
<link href="estilos.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="https://unpkg.com/tailwindcss@%5E2/dist/tailwind.min.css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            border-style: none;
            border-color: inherit;
            border-width: 0;
            width: 100%;
            height: 100%;
            --primary: hsl(var(--primary-hue), 85%, calc(var(--primary-lightness, 50) * 1%));
            --shadow-primary: hsl(var(--shadow-primary-hue), 90%, 50%);
            --primary-hue: 0;
            --primary-lightness: 50;
            --color: hsl(0, 100%, 50%) --font-size: 30px;
            --shadow-primary-hue: 180;
            --label-size: 5px;
            --shadow-secondary-hue: 60;
            --shadow-secondary: hsl(var(--shadow-secondary-hue), 90%, 60%);
            --clip: polygon(0 0, 100% 0, 100% 100%, 95% 100%, 95% 90%, 85% 90%, 85% 100%, 8% 100%, 0 70%);
            --border: 4px;
            --shimmy-distance: 5;
            --clip-one: polygon(0 2%, 100% 2%, 100% 95%, 95% 95%, 95% 90%, 85% 90%, 85% 95%, 8% 95%, 0 70%);
            --clip-two: polygon(0 78%, 100% 78%, 100% 100%, 95% 100%, 95% 90%, 85% 90%, 85% 100%, 8% 100%, 0 78%);
            --clip-three: polygon(0 44%, 100% 44%, 100% 54%, 95% 54%, 95% 54%, 85% 54%, 85% 54%, 8% 54%, 0 54%);
            --clip-four: polygon(0 0, 100% 0, 100% 0, 95% 0, 95% 0, 85% 0, 85% 0, 8% 0, 0 0);
            --clip-five: polygon(0 0, 100% 0, 100% 0, 95% 0, 95% 0, 85% 0, 85% 0, 8% 0, 0 0);
            --clip-six: polygon(0 40%, 100% 40%, 100% 85%, 95% 85%, 95% 85%, 85% 85%, 85% 85%, 8% 85%, 0 70%);
            --clip-seven: polygon(0 63%, 100% 63%, 100% 80%, 95% 80%, 95% 80%, 85% 80%, 85% 80%, 8% 80%, 0 70%);
            font-family: 'Cyber', sans-serif;
            color: var(--color);
            cursor: pointer;
            background: transparent;
            text-transform: uppercase;
            font-size: var(--font-size);
            outline: transparent;
            letter-spacing: 2px;
            position: relative;
            font-weight: 500;
            min-width: 200px;
            height: 50px;
            line-height: 75px;
            transition: background 0.2s;
            left: 0px;
            top: 0px;
        }
    </style>
</head>
<body>
    <h1 align="center" style="font-size: 40px"> Crear Usuario Siendo Gestor </h1>
    <h2> Bienvenido a la página para crear Usuarios siendo Gestor</h2>
    <form id="form1" runat="server">
        <label >
            Nombre Usuario
            <asp:TextBox autofocus="autofocus" runat="server" ID="Nombre_Usuario_Input"  Text="" placeholder="Escribe el nombre" ></asp:TextBox>
        <br />
            Apellido Usuario
            <asp:TextBox autofocus="autofocus" runat="server" ID="Apellido_Usuario_Input"  Text="" placeholder="Escribe el apellido " ></asp:TextBox>
        <br />
            Email (tiene que ser @ubu.es)
            <asp:TextBox autofocus="autofocus" runat="server" ID="Email_Usuario_Input"  Text="" placeholder="Escribe el email" ></asp:TextBox>
        <br />
            ¿El nuevo usuario será Gestor?
            <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" />
        </label>
        <div>
            <span class="w-full flex justify-between items-center">
                <label>Password tiene que tener más de 8 caracteres</label>
            </span>
            <asp:TextBox runat="server" ID="Password_Input" TextMode="Password" Text="" placeholder="Escribe su contraseña" ></asp:TextBox>
        </div>

        <button class="cybr-btn w-full flex justify-between items-center" type="submit">
                
                <asp:Button ID="CrearUsuario" runat="server" OnClick="CrearUsuarioOnClick" Text="Crear al usuario" CssClass="cybr-btn" />
                <span aria-hidden class="cybr-btn__glitch">Crear al usuario</span>
                <span aria-hidden class="cybr-btn__tag">22/23</span>
        </button>

                <button class="cybr-btn" type="submit">
              
                <asp:Button ID="VolverAGestor" runat="server" OnClick="VolverAUsuarioGestorOnClick" Text="Volver a Gestor" CssClass="auto-style1" />
                <span aria-hidden class="cybr-btn__glitch">Volver a Gestor</span>
                <span aria-hidden class="cybr-btn__tag">22/23</span>
                
        </button>
    </form>
</body>
</html>
