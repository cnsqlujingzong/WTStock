<%@ page language="C#"  CodeFile="transfer.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Financial_Transfer" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body onload="Chkset();" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="cndiv" style="height:1px;">
    <div class="tldiv">
        �ʻ�ת��
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right">�Ƶ����ڣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                <td align="right">�����ˣ�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td align="right" class="sysred">�����ʻ���</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlFAccount" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlFAccount_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>�ʻ���</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbFBalance" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="sysred">�տ��ʻ���</td>
                <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlSAccount" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlSAccount_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>�ʻ���</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbSBalance" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
                </td>
                 <td class="sysred">ת�˽�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbAmount" runat="server" CssClass="pin" ></asp:TextBox>
                </td>
                <td align="right">֧Ʊ���룺</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbCheckNO" runat="server" CssClass="pin" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                 <td>ƾ֤���룺</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbVoucherNO" runat="server" CssClass="pin" ></asp:TextBox>
                </td>
                <td align="right">��ע��</td>
                <td colspan="5" style="padding-left:0px;">
                    <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                </td>
            </tr>
         </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div class="divh"></div>
    <div class="ftool">
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td></td>
            <td align="right" style="padding-right:20px;">
                <asp:Button ID="btnChk" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnChk_Click"  />
                <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click" />
                <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseWin();" />
            </td>
        </tr>
    </table>
    </div>
    
    </div>
    </div>
    <div class="fbom">
        <div id="fbon" class="fbon"></div> 
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;

function ChkSave()
{
    if(isNull($("tbDate").value))
    {
        window.alert("����ʧ�ܣ����ڲ���Ϊ��");
        $("tbDate").focus();
        return false
    }
    
    if($("ddlOperator").value=="-1")
    {
        window.alert("����ʧ�ܣ������˲���Ϊ��");
        $("ddlOperator").focus();
        return false
    }
    
    if($("ddlFAccount").value=="-1")
    {
        window.alert("����ʧ�ܣ������ʻ�����Ϊ��");
        $("ddlFAccount").focus();
        return false
    }
    if($("ddlSAccount").value=="-1")
    {
        window.alert("����ʧ�ܣ��տ��ʻ�����Ϊ��");
        $("ddlSAccount").focus();
        return false
    }
    if($("ddlFAccount").value==$("ddlSAccount").value)
    {
        window.alert("����ʧ�ܣ��ո����ʻ�������ͬ");
        $("ddlFAccount").focus();
        return false
    }
    if(!isMoney($("tbAmount").value))
    {
        window.alert("����ʧ�ܣ�����ʽ����ȷ");
        $("tbAmount").focus();
        return false
    }else
    {
        if(parseFloat($("tbAmount").value)>0)
        {}
        else
        {
            window.alert("����ʧ�ܣ������������");
            $("tbAmount").focus();
            return false
        }
    }

}

function Chkset()
{
    Chkwh6();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("�ʻ�ת��");
}
</script>
