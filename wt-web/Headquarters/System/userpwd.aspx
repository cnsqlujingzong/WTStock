<%@ page language="C#"  CodeFile="userpwd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_System_UserPwd" enableEventValidation="false" %>
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
    <div id="sa" style="width:586px;">     
    <div class="fdiv">
    <div class="sdiv" style="height:125px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb3">
        <tr>
            <td style="text-align:right;">��������룺</td>
            <td style="padding-left:0px;">
            <asp:TextBox ID="tbPswOld" runat="server" CssClass="pin pin2" Width="200" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right;">���������룺</td>
            <td style="padding-left:0px;">
            <asp:TextBox ID="tbPsw" runat="server" CssClass="pin pin2" Width="200" TextMode="Password"></asp:TextBox>
            <span style="color:#999999; padding-left:20px; background:url(../../Public/Images/li2.gif) no-repeat 12px center">(���볤����7��20λ֮��)</span>
            </td>
        </tr>
        <tr>
            <td style="text-align:right;">������һ�Σ�</td>
            <td style="padding-left:0px;">
            <asp:TextBox ID="tbPsw2" runat="server" CssClass="pin pin2" Width="200" TextMode="Password"></asp:TextBox>
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
            <asp:Button ID="btnSave" runat="server" Text="ȷ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnSave_Click" />
            <input id="btnCls" type="button" value="ȡ��" class="bt1" onclick="parent.CloseDialog();"/>
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
   if(isNull($("tbPsw").value))
   {
        alert("������������.");
        $("tbPsw").select();
        return false;
   }
   
    if($("tbPsw").value.length==0||$("tbPsw").value.length>20)
    {
        window.alert("����ʧ�ܣ����볤�ȱ�����1-20λ֮��");
        $("tbPsw").focus();
        return false
    }
    
   if(isNull($("tbPsw2").value))
   {
        alert("��������һ��������");
        $("tbPsw2").select();
        return false;
   }
   
   if($("tbPsw2").value!=$("tbPsw").value)
   {
        alert("�����������벻һ��");
        $("tbPsw").select();
        return false;
   }
}
</script>
