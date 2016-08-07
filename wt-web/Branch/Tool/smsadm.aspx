<%@ page language="C#"  CodeFile="smsadm.aspx.cs"     autoeventwireup="true" inherits="Branch_Tool_SmsAdm" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa22" style="width:586px;">
    <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">发送</span>
            <span id="tabs_r1"></span>
     </div>
    <div id="info1" style="height:271px;padding:3px 0px 0px 3px; overflow:hidden;">
        <div id="divinfo1" class="divinfo" style="height:265px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td>发送到：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin" Width="200"></asp:TextBox></td>
                    <td style="padding-left:120px;">模版：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlTmp" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlTmp_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height:165px">
                        <asp:TextBox ID="tbSmsContent" runat="server" TextMode="MultiLine" Height="150" Width="540"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSnd" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="560px">
            <tr>
                <td align="right">
                    <asp:Button ID="btnSnd" runat="server" Text="发送" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSnd()==false)return false;" OnClick="btnSnd_Click"/>
                </td>
            </tr>
            </table>
        </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right">
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
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var tabnum=2;

function ChkSnd()
{
    if(isNull($("tbTel").value))
    {
        window.alert("请输入要发送的手机号码！");
        $("tbTel").select();
        return false
    }
    
    if(isNull($("tbSmsContent").value))
    {
        window.alert("请输入要发送的短信内容！");
        $("tbSmsContent").select();
        return false
    }
    
    var smsno=$("tbTel").value;
    var sn=smsno.split(',');
    var flag=0;
    for(var i=0;i<sn.length;i++)
    {
        if(!sn[i].isMobile())
        {
            flag=1;
            break;
        }
    }
    if(flag==1)
    {
        return confirm("存在不正确的手机号码，是否继续");
    }
}

String.prototype.isMobile = function(){   
return (/^0?(13[0-9]|15[012356789]|18[0236789]|14[57])[0-9]{8}$/.test(this.Trim()));   
} 
String.prototype.Trim = function() {   
var m = this.match(/^\s*(\S+(\s+\S+)*)\s*/);   
return (m == null) ? "" : m[1];   
} 

</script>
