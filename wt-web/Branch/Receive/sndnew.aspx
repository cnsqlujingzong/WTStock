<%@ page language="C#"  CodeFile="sndnew.aspx.cs"     autoeventwireup="true" inherits="Branch_Receive_SndNew" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
        �½�����
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>�������ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
            <td>���ڣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" Width="120" onfocus="WdatePicker()"></asp:TextBox></td>
            <td class="red">�����ˣ�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl" Width="100">
                </asp:DropDownList>
            </td>
            <td>���</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlSndType" runat="server" CssClass="pindl" Width="89">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="sysred">�ջ����ͣ�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlRcvObj" runat="server" CssClass="pindl" Width="80" AutoPostBack="true" OnSelectedIndexChanged="ddlRcvObj_SelectedIndexChanged">
                    <asp:ListItem Value="�ͻ�">�ͻ�</asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem> 
                    <asp:ListItem Value="����">����</asp:ListItem>
                </asp:DropDownList>
                
            </td>
        </tr>
     </table>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td class="red">��˾���ƣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCusName" runat="server" CssClass="pin" Width="250"></asp:TextBox>
            </td>
            <td style="padding:0px;"><input id="btnSlt" type="button" value="" onclick="ChkCompay();" class="bview"/></td>
            <td>�ջ��ˣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin" Width="80"></asp:TextBox></td>
            <td>��ϵ�绰��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
        </tr>
        <tr>
            <td>�ջ���ַ��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="250"></asp:TextBox></td>
            <td align="right" colspan="2">�ʱࣺ</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbZip" runat="server" CssClass="pin" Width="80"></asp:TextBox>
            </td>
            <td class="red">�������ƣ�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>��ƷժҪ��</td>
            <td style="padding-left:0px; height:50px;"><asp:TextBox ID="tbSummary" runat="server" CssClass="pin" Width="626" TextMode="MultiLine" Height="42"></asp:TextBox></td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>���˷�ʽ��</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlShipStyle" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td>�������ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSndNo" runat="server" CssClass="pin"></asp:TextBox></td>
            <td>���ʣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbPostage" runat="server" CssClass="pin"></asp:TextBox></td>
        </tr>
     </table>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>��ע��Ϣ��</td>
            <td style="padding-left:0px;height:50px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="626" TextMode="MultiLine" Height="42"></asp:TextBox></td>
        </tr>
    </table>
    <asp:HiddenField ID="hfPrintID" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnConfSnd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ddlRcvObj" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlBranch" EventName="SelectedIndexChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div class="divh"></div>
    <div class="ftool">
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td></td>
            <td align="right" style="padding-right:20px;">
                <asp:Button ID="btnConfSnd" runat="server" Text="ȷ�Ϸ���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnConfSnd_Click"/>
                <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnAdd_Click"/>
                <input id="btnPrint" runat="server" type="button" value="��ӡ" class="bt1" onclick="ChkPrint('FHD');" />
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
    
    if(isNull($("ddlSndType").value))
    {
        window.alert("����ʧ�ܣ������Ϊ��");
        $("ddlSndType").focus();
        return false
    }
    
    if($("ddlRcvObj").value=="����")
    {
        if($("ddlBranch").value=="-1")
        {
            window.alert("����ʧ�ܣ��ջ����㲻��Ϊ��");
            $("ddlBranch").focus();
            return false
        }
    }
    else
    {
        if(isNull($("tbLinkMan").value))
        {
            window.alert("����ʧ�ܣ���ϵ�˲���Ϊ��");
            $("tbLinkMan").focus();
            return false
        }
        if(isNull($("tbAdr").value))
        {
            window.alert("����ʧ�ܣ���ַ����Ϊ��");
            $("tbAdr").focus();
            return false
        }
    }
    
    if(isNull($("tbSummary").value))
    {
        window.alert("����ʧ�ܣ���ƷժҪ����Ϊ��");
        $("tbSummary").focus();
        return false
    }  
    
    if(!isNull($("tbPostage").value))
    {
        if(!isMoney($("tbPostage").value))
        {
            window.alert("����ʧ�ܣ����ʸ�ʽ����ȷ");
            $("tbPostage").focus();
            return false
        }
    }
}
function ChkCompay()
{
    if($("ddlRcvObj").value=="����")
    {
        parent.ShowDialog(800, 500, 'Receive/SltSup.aspx', 'ѡ����');
    }else
    if($("ddlRcvObj").value=="�ͻ�")
    {
        parent.ShowDialog(800, 500, 'Receive/SltCus.aspx', 'ѡ��ͻ�');
    }
}
function Chkset()
{
    Chkwh6();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("�½�����");
}
</script>
