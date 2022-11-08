<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebEntradasLog.aspx.cs" Inherits="www1.WebEntradasLog" %>

<!DOCTYPE html>

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
                     <asp:BoundField DataField="Entrada" HeaderText="Entrada" />
                     <asp:BoundField DataField="TipoAcceso" HeaderText="TipoAcceso" />
                     <asp:BoundField DataField="HoraAcceso" HeaderText="HoraAcceso" />
                    
                    
                 </Columns>
</asp:GridView>
    </form>
</body>
</html>
