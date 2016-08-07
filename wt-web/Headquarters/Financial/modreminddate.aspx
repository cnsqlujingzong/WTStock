<%@ page language="C#"  CodeFile="modreminddate.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Financial_ModRemindDate" enableEventValidation="false" %>
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
        <div id="sa" style="width:286px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td>�ܽ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbSumAmount" runat="server" CssClass="pin" onblur="caclAmount();"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>�ѽ����</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbHaveAmount" runat="server" CssClass="pin" onblur="caclAmount();"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>δ�����</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbNotChargeAmount" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>�������ڣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>��Ʊ���룺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbInvoice" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>   
                <tr>
                    <td>��Ʊ��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbAmount" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr> 
                <tr>
                    <td>��Ʊ���ڣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbInvDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">��ע��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="180"></asp:TextBox></td>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
function ChkAdd()
{
    if(isNull($("tbSumAmount").value))
    {
        window.alert("����ʧ�ܣ��ܶ��Ϊ��");
        $("tbSumAmount").focus();
        return false
    }
}
function caclAmount()
{
    var sumAmount = $("tbSumAmount").value;
    if(!isMoney(sumAmount))
    {
        window.alert("����ʧ�ܣ��ܶ���д����ȷ");
        $("tbSumAmount").focus();
        return false
    }
    var haveAmount = $("tbHaveAmount").value;
    if(haveAmount == "")
    {
        document.getElementById("tbNotChargeAmount").value = sumAmount;
    }
    else
    {
        var notChargeAmount = parseInt(sumAmount) - parseInt(haveAmount);
        document.getElementById("tbNotChargeAmount").value = notChargeAmount;
    }
}
</script>
