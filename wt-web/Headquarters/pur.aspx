<%@ page language="C#"  CodeFile="pur.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Pur" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>系统提示</title>
</head>
<body onclick="ChkPrt();" style="height:100%; width:100%;" scroll="no";>
    <form id="form1" runat="server">
    <div>
    <div style="padding-top:100px;text-align:center;">
        <p style=" margin:0 auto; text-align:left; border:1px #a1b8d8 solid; padding-left:30px; background:#d8e3f3 url(../Public/Images/dmcal.gif) no-repeat 8px center; width:300px; line-height:28px; color:#4b4b4b; font-size:12px;">您没有该项操作的权限，请联系管理员取得权限!</p></div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
function ChkPrt()
{
    try{parent.Sethidden1();}catch(e){}
}
</script>
