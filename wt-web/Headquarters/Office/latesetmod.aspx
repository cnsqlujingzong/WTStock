<%@ page language="C#"  CodeFile="latesetmod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Office_LateSetMod" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:456px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">���</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl">
                            <asp:ListItem Value="�ٵ�">�ٵ�</asp:ListItem>
                            <asp:ListItem Value="����">����</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">�ۿ��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbMoney" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>

                <tr>
                    <td align="right">��ʼ���ӣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbStart" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">��ֹ���ӣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbEnd" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">��ע��</td>
                    <td style="padding-left:0px;" colspan="3"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
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
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog1();"/>
                </td>
            </tr>
            </table>
         </div>
        </div>
        </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var processtip=1;
function ChkSave()
{
    if(isNull($("tbMoney").value))
    {
        window.alert("����ʧ�ܣ��ۿ����Ϊ��");
        $("tbMoney").focus();
        return false
    }
    if(isNull($("tbStart").value))
    {
        window.alert("����ʧ�ܣ���ʼ���Ӳ���Ϊ��");
        $("tbStart").focus();
        return false
    }
    if(isNull($("tbEnd").value))
    {
        window.alert("����ʧ�ܣ���ֹ���Ӳ���Ϊ��");
        $("tbEnd").focus();
        return false
    }
}

</script>
