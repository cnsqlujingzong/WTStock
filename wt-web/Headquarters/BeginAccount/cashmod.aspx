<%@ page language="C#"  CodeFile="cashmod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_BeginAccount_CashMod" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body onload="ChkSetFocus('tbMoney');">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:366px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td align="right" class="red">�ʻ���</td>
                        <td style="padding-left:0px; height:35px;"><asp:TextBox ID="tbName" runat="server" CssClass="pinb" Width="150"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="sysred">�ڳ���</td>
                        <td style="padding-left:0px;height:35px;"><asp:TextBox ID="tbMoney" runat="server" CssClass="pin" Width="150"></asp:TextBox></td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td><asp:Label ID="lbMod" runat="server"></asp:Label></td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();"/>
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
function ChkAdd()
{
    if(!isNull($("tbMoney").value))
    {
        if(!isMoney($("tbMoney").value))
        {
            window.alert("����ʧ�ܣ��ڳ�����ʽ����ȷ");
            $("tbMoney").focus();
            return false
        }
        else
        {
            var money = parseFloat($("tbMoney").value);
            if(money < 0)
            {
                window.alert("�ڳ�����Ϊ����");
                $("tbMoney").focus();
                return false
            }
        }
    }
    
}
</script>
