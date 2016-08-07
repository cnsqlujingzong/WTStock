<%@ page language="C#"  CodeFile="mailview.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Office_MailView" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body onload="ChkSetFocus('tbTitle');">
    <form id="form1" runat="server">
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:684px;">
            <div class="fdiv">
            <div class="sdiv">
               <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">发件人：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbSnd" CssClass="pinb" Width="400" runat="server"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <td align="right">收件人：</td>
                    <td style="padding-left:0px;">
                      <asp:TextBox ID="tbRcv" CssClass="pinb" Width="400" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">邮件主题：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbTitle" CssClass="pinb" Width="400" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height:275px;">
                        <asp:TextBox ID="tbContent" CssClass="pinb" TextMode="MultiLine" style="width:633px; height:260px;" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" class="tb1">
                <tr>
                    <td>
                        <div runat="server" id="dUpload"></div>
                    </td>
                </tr>    
            </table>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right">
                    <input id="btnReply" type="button" value="回复" class="bt1" onclick="ChkUrl('MailAdd.aspx','0');"/>
                    <input id="btnSend" type="button" value="转发" class="bt1" onclick="ChkUrl('MailAdd.aspx','1');"/>
                    <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();"/>
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
<script language="javascript" type="text/javascript">
function ChkUrl(url,flag)
{
    var num=Math.round(Math.random()*10000);
    location.href=url+"?id=<%=StrID %>&f="+flag+"&a="+num;
}
</script>
