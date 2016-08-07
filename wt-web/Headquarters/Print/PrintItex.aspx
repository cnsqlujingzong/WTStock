<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintItex.aspx.cs" Inherits="Headquarters_Print_PrintItex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding:20px;">
        <table style="width:320px">
            <tr>
                <td></td><!--选择印章：-->
                <td>  <asp:DropDownList ID="dl_tuzhang" runat="server" Width="150" Visible="false">
                    <asp:ListItem Value="sthx">盛唐和讯公章</asp:ListItem>
                    <asp:ListItem Value="fc">凡驰传动公章</asp:ListItem>
                    <asp:ListItem Value="fcht">凡驰传动合同章</asp:ListItem>
                    <asp:ListItem Value="mfy">美褔洋公章</asp:ListItem>
                    <asp:ListItem Value="mfyht">美褔洋合同章</asp:ListItem>
                    </asp:DropDownList>

                </td>
                <td><asp:Button ID="Button1" runat="server" Text="立刻打印" OnClick="Button1_Click" /></td>
                <td></td>
            </tr>
        </table>
      
    
    </div>
    </form>
</body>
</html>
