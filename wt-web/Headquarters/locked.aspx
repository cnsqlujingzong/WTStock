<%@ page language="C#"  CodeFile="locked.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Locked" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>系统提示</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style="padding-top:70px;text-align:center;">
        <p style=" margin:0 auto; text-align:left; border:1px #a1b8d8 solid; padding-left:30px; background:#d8e3f3 url(../Public/Images/dmcal.gif) no-repeat 8px center; width:300px; line-height:28px; color:#4b4b4b; font-size:12px;">系统已经被锁定了，请联系开发商获得解锁码。</p></div>
    </div>
    <div style="text-align:center; padding-top:20px; font-size:12px;">
        输入解锁码:
        <asp:TextBox ID="tbLockCode" runat="server" Width="250"></asp:TextBox>
        <asp:Label ID="lb1" runat="server" Text="" style="color:#ff0000"></asp:Label>
        <asp:Button ID="btnUnLock" runat="server" Text="解锁:" style="font-size:12px; width:100px;" OnClick="btnUnLock_Click" />
    </div>
    </form>
</body>
</html>
