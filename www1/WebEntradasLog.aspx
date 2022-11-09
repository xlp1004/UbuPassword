<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebEntradasLog.aspx.cs" Inherits="www1.WebEntradasLog" %>

<!DOCTYPE html>
<link href="estilos.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1 style="font-size=40px">EntradasLog</h1>
    <form id="form1" runat="server">
        <div>
        </div>
      <asp:GridView ID="gvwProyectos" runat="server" AutoGenerateColumns="false" onrowcommand="gvwProyectos_RowCommand" Width="90%" HorizontalAlign="Center">
             <RowStyle HorizontalAlign="Center" />
                 <Columns>
                     <asp:BoundField DataField="Id." HeaderText="Id." />
                     <asp:BoundField DataField="Email" HeaderText="Email" />
                     <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                     <asp:BoundField DataField="HoraAcceso" HeaderText="HoraAcceso" />
                     <asp:BoundField DataField="TipoAcceso" HeaderText="TipoAcceso" />
                     <asp:BoundField DataField="Entrada" HeaderText="Entrada" />
                 </Columns>
</asp:GridView>
        <br /> 
         <button class="cybr-btn" type="submit">
              
                <asp:Button ID="CambiarAGestor" runat="server" OnClick="VolverAGestor" Text="Volver a Gestor" CssClass="cybr-btn" />
                <span aria-hidden class="cybr-btn__glitch">Volver a Gestor</span>
                <span aria-hidden class="cybr-btn__tag">22/23</span>
                
        </button>
    </form>
</body>
</html>
