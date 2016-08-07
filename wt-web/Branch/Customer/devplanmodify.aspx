<%@ page language="C#"  CodeFile="devplanmodify.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_DevPlanModify" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
                        <td align="right">���ƣ�</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbName" runat="server" CssClass="pin"></asp:TextBox>
                        </td>
                        <td align="right">��ǰ���ѣ�</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbRemindDay" runat="server" CssClass="pin" Width="110"></asp:TextBox>
                            <span class="red">��</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">��ʼ���ڣ�</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbStartDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                        </td>
                        <td align="right">��ֹ���ڣ�</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbEndDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">��ʱ��ʽ��</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlTimingStyle" runat="server" CssClass="pindl" onchange="ChkCycle();">
                                <asp:ListItem Value="�̶�����">�̶�����</asp:ListItem>
                                <asp:ListItem Value="�̶�����">�̶�����</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right"><asp:Label ID="lbType" runat="server" Text="��������"></asp:Label>��</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbMaintenanceCycle" runat="server" CssClass="pin" Width="110"></asp:TextBox>
                            <asp:Label ID="lbDay" runat="server" CssClass="red" Text="��"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">��ע��</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
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
                    <asp:Button ID="btnAdd" runat="server" Text="ȷ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var isfocus=1;
var processtip=1;
function ChkAdd()
{
    if(isNull($("tbName").value))
    {
        window.alert("����ʧ�ܣ����Ʋ���Ϊ��");
        $("tbName").focus();
        return false
    }
    if(isNull($("tbRemindDay").value))
    {
        window.alert("����ʧ�ܣ���ǰ���Ѳ���Ϊ��");
        $("tbRemindDay").focus();
        return false
    }
    if(parseFloat($("tbRemindDay").value)<=0)
    {
        window.alert("����ʧ�ܣ���ǰ���ѱ������0");
        $("tbRemindDay").focus();
        return false
    }
    if(!isDigit($("tbRemindDay").value))
    {
        window.alert("����ʧ�ܣ���ǰ���Ѹ�ʽ����ȷ");
        $("tbRemindDay").focus();
        return false
    }
    
    if(isNull($("tbStartDate").value))
    {
        window.alert("����ʧ�ܣ���ʼ���ڲ���Ϊ��");
        $("tbStartDate").focus();
        return false
    }
    
    if(isNull($("tbEndDate").value))
    {
        window.alert("����ʧ�ܣ���ֹ���ڲ���Ϊ��");
        $("tbEndDate").focus();
        return false
    }
    if(isNull($("tbMaintenanceCycle").value))
    {
        window.alert("����ʧ�ܣ�"+$("lbType").innerHTML+"����Ϊ��");
        $("tbMaintenanceCycle").focus();
        return false
    }
    if(parseFloat($("tbMaintenanceCycle").value)<=0)
    {
        window.alert("����ʧ�ܣ�"+$("lbType").innerHTML+"�������0");
        $("tbMaintenanceCycle").focus();
        return false
    }
    if(!isDigit($("tbMaintenanceCycle").value))
    {
        window.alert("����ʧ�ܣ�"+$("lbType").innerHTML+"��ʽ����ȷ");
        $("tbMaintenanceCycle").focus();
        return false
    }
}
function ChkCycle()
{
    if($("ddlTimingStyle").value=="�̶�����")
    {
        $("lbType").innerHTML="��������";
        $("lbDay").innerHTML="��";
    }
    else
    {
        $("lbType").innerHTML="��������";
        $("lbDay").innerHTML="��";
    }
}
</script>
