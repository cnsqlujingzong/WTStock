<%@ page language="C#"  CodeFile="timesetmod.aspx.cs"     autoeventwireup="true" inherits="Branch_Office_TimeSetMod" enableEventValidation="false" %>
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
                    <td align="right">���ڣ�</td>
                    <td style="padding-left:0px;" colspan="2">
                        <asp:DropDownList ID="ddlWeek" runat="server" CssClass="pindl">
                            <asp:ListItem Value="����һ">����һ</asp:ListItem>
                            <asp:ListItem Value="���ڶ�">���ڶ�</asp:ListItem>
                            <asp:ListItem Value="������">������</asp:ListItem>
                            <asp:ListItem Value="������">������</asp:ListItem>
                            <asp:ListItem Value="������">������</asp:ListItem>
                            <asp:ListItem Value="������">������</asp:ListItem>
                            <asp:ListItem Value="������">������</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:HiddenField ID="hfTemp" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td align="right">�ϰ�ʱ�䣺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbStartDate" runat="server" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'HH:mm:ss'})"></asp:TextBox></td>
                    <td align="right">�°�ʱ�䣺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbEndDate" runat="server" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'HH:mm:ss'})"></asp:TextBox></td>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var processtip=1;
function ChkSave()
{
    if(isNull($("tbStartDate").value))
    {
        window.alert("����ʧ�ܣ��ϰ�ʱ�䲻��Ϊ��");
        $("tbStartDate").focus();
        return false
    }
    if(isNull($("tbEndDate").value))
    {
        window.alert("����ʧ�ܣ��°�ʱ�䲻��Ϊ��");
        $("tbEndDate").focus();
        return false
    }
}

</script>
