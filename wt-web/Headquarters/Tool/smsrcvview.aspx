<%@ page language="C#"  CodeFile="smsrcvview.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Tool_SmsRcvView" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:486px;">
    <div class="fdiv" style="height:206px;">
    <div class="sdiv" style="background:#ECE9D8;height:201px; padding-top:3px;">
        <table cellpadding="0" cellspacing="0" class="tb4">
            <tr>
                <td>发送号码：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTitle" runat="server" CssClass="pin" Width="180"></asp:TextBox></td>
            </tr>
            <tr>
                <td>短信内容：</td>
                <td style="padding-left:0px; height:130px;"><asp:TextBox ID="tbContent" runat="server" TextMode="MultiLine" CssClass="pin" Height="120" Width="350"></asp:TextBox></td>
            </tr>
        </table>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right">
            <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog1();"/>
        </td>
    </tr>
    </table>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
