<%@ page language="C#"  CodeFile="backupplan.aspx.cs"     autoeventwireup="true" inherits="Headquarters_System_BackupPlan" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:636px;">
    <div style=" margin:0px auto 5px auto; text-align:center;">
    <span style="color:#ff0000;">自动备份需要sa权限，建议在SQLServer里手工进行。</span>
    </div>
    <div class="fdiv">
    <div class="sdiv">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td>
                每
                <asp:TextBox ID="tbDay" runat="server" CssClass="pinb" Text="1" Width="20" ReadOnly="true"></asp:TextBox>
                天。时间
                <asp:TextBox ID="tbTime" runat="server" CssClass="pinb" Text="12:00:00" Width="70" ReadOnly="true"></asp:TextBox>
                ，数据库自动备份到
                <asp:TextBox ID="tbPath" runat="server" CssClass="pin" Width="250"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="color:#999; text-align:right;">(文件夹若不存在，将自动创建。路径格式如:D:\data\backup\wt)</td>
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
        <td><asp:Label ID="lbInfo" runat="server" style=" background:#dd0000; color:#ffffff; padding:2px 15px;" Text="自动备份需要开启SQLServer的Agent服务。"></asp:Label>
        </td>
        <td align="right">
            <asp:Button ID="btnSave" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnSave_Click" />
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

<script language="javascript" type="text/javascript" src="../../Public/Script/menu.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkSave()
{
   if(confirm("确定要进行该项操作吗？"))
   {
        return true;
   }else{return false;}
}
</script>
