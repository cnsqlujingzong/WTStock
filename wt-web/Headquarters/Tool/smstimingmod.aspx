<%@ page language="C#"  CodeFile="smstimingmod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Tool_SmsTimingMod" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:486px;">
    <div class="fdiv" >
    <div class="sdiv" style="background:#ECE9D8;padding-top:3px; padding-bottom:3px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td>发送时机：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlTiming" runat="server" CssClass="pindl">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="报修审核">报修审核</asp:ListItem>
                        <asp:ListItem Value="服务受理">服务受理</asp:ListItem>
                        <asp:ListItem Value="自修派工">自修派工</asp:ListItem>
                        <asp:ListItem Value="派工通知客户">派工通知客户</asp:ListItem>
                        <asp:ListItem Value="派给网点通知客户">派给网点通知客户</asp:ListItem>
                        <asp:ListItem Value="派给网点通知网点">派给网点通知网点</asp:ListItem>
                        <asp:ListItem Value="工单完工">工单完工</asp:ListItem>
                        <asp:ListItem Value="完工结算">完工结算</asp:ListItem>
                        <asp:ListItem Value="确认发货">确认发货</asp:ListItem>
                        <asp:ListItem Value="派给网点通知技术员">派给网点通知技术员</asp:ListItem>
                        <asp:ListItem Value="取消工单通知客户">取消工单通知客户</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>短信模版：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlSmsTmp" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right">
            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnSave_Click" />
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
<script language="javascript" type="text/javascript">
function ChkSave()
{
    if(isNull($("ddlTiming").value))
    {
        window.alert("操作失败！请选择发送时机");
        $("ddlTiming").focus();
        return false
    }
    if(isNull($("ddlSmsTmp").value))
    {
        window.alert("操作失败！请选择短信模版");
        $("ddlSmsTmp").focus();
        return false
    }
}
</script>
