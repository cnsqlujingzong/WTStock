<%@ page language="C#"  CodeFile="arrearageadm.aspx.cs"     autoeventwireup="true" inherits="Branch_Financial_ArrearageAdm" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body onload="Chkset();" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="ftool">
        <div class="ftoolleft">
        <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
            <asp:Button ID="btnFsh" runat="server" Text="ˢ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnFsh_Click"/>
            <input id="btnAuto" type="button" value="�Զ��Գ�" class="bt1" onclick="AtuoHedge();" />
            <input id="btnManual" type="button" value="�ֹ��Գ�" class="bt1" onclick="ManualHedge();" />
            <input id="btnCancel" type="button" value="ע������" class="bt1" onclick="CancelArr();" />
            <span style="display:none;">
                <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                <asp:Button ID="btnShow" runat="server" Text="��ʾ" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="false"/>
            </span>
            </td>
            <td>
                <asp:CheckBox ID="cbAll" runat="server" Text="��ʾȫ��Ӧ��Ӧ��" OnCheckedChanged="cbAll_CheckedChanged" AutoPostBack="true" />
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                    <input id="btnPrint" runat="server" type="button" value="��ӡ" class="iprint" onclick="ChkPrint('YSYF');" />
                </td>
                <td>
                    <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
                </td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="CustomerNO">���ͻ���Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="Type">���ͻ�����ѯ</asp:ListItem>
                    <asp:ListItem Value="_Name">�����Ʋ�ѯ</asp:ListItem>
                    <asp:ListItem Value="LinkMan">����ϵ�˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="Tel">����ϵ�绰��ѯ</asp:ListItem>
                    <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td></tr>
            </table>   
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvbranch" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvbranch_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="�ͻ����" DataField="Type" />
            <asp:BoundField HeaderText="�ͻ����" DataField="CustomerNO" />
            <asp:BoundField HeaderText="����" DataField="_Name" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan"/>
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="Ӧ�տ�" DataField="Rec" />
            <asp:BoundField HeaderText="Ӧ����" DataField="Due" />
            <asp:BoundField HeaderText="�������" DataField="Balance" />
        </Columns>
    </asp:GridView>
    
    <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCountText" runat="server" ToolTip="�ܼ�¼��" Text="�ܼ�¼:"></asp:Label><asp:Label ID="lbCount" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
        </tr>
    </table>
    
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="cbAll" EventName="CheckedChanged" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>

    <div id="cnbut" style="overflow:hidden;">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1"></span>
                <span id="tabs1" onclick="ChkTab('1');">Ӧ����ϸ</span>
                <span id="tabs_r1"></span>
                <span id="tabs_l2"></span>
                <span id="tabs2" onclick="ChkTab('2');">Ӧ����ϸ</span>
                <span id="tabs_r2"></span>
            </div>
        </div>
        <div id="info1" style="height:163px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
        <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
            <tr>
            <td style="width:60px" align="right">
            �������
            </td>
            <td>
            <asp:DropDownList ID="ddlRecType" runat="server" CssClass="pindl" AutoPostBack="true" OnSelectedIndexChanged="ddlRecType_SelectedIndexChanged">
            <asp:ListItem Value="0">ȫ��</asp:ListItem>
            <asp:ListItem Value="�ɹ��˻�">�ɹ��˻�</asp:ListItem>
            <asp:ListItem Value="�����ͬ">�����ͬ</asp:ListItem>
            <asp:ListItem Value="�ڳ�Ӧ��">�ڳ�Ӧ��</asp:ListItem>
            <asp:ListItem Value="�깤����">�깤����</asp:ListItem>
            <asp:ListItem Value="�������">�������</asp:ListItem>
            <asp:ListItem Value="���۳���">���۳���</asp:ListItem>
            <asp:ListItem Value="Ԥ����">Ԥ����</asp:ListItem>
            <asp:ListItem Value="������">������</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td align="right" style="padding-right:30px;">
                 <asp:Button ID="btnRecExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkRDToExcel()==false)return false;" OnClick="btnRecExcel_Click" />
            </td>
            </tr>
        </table>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <div class="cndiv2" id="cndiv2" style="height:116px;">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView1_RowDataBound"  EnableViewState="false" ShowFooter="true" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="�������" DataField="RecType" />
                    <asp:BoundField HeaderText="���ݱ��" DataField="OperationID" />
                    <asp:BoundField HeaderText="����" DataField="_Date" />
                    <asp:BoundField HeaderText="������" DataField="_Name" />
                    <asp:BoundField HeaderText="�ܽ��" DataField="Amount" />
                    <asp:BoundField HeaderText="�ѽ�����" DataField="HaveAmount" />
                    <asp:BoundField HeaderText="δ������" DataField="NotChargeAmount" />
                    <asp:BoundField HeaderText="��������" DataField="RemindDate" />
                    <asp:BoundField HeaderText="��Ʊ����" DataField="InvoiceNO" />
                    <asp:BoundField HeaderText="��Ʊ���" DataField="InvoiceMoney" DataFormatString="{0:f2}" />
                    <asp:BoundField HeaderText="��Ʊ����" DataField="InvoiceDate" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField HeaderText="�տ��˻�" DataField="AccountName" />
                    <asp:BoundField HeaderText="��ע"  DataField="Remark"/>
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
        </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlRecType" EventName="SelectedIndexChanged" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        <div id="info2" style="height:163px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
        <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
            <tr>
            <td style="width:60px" align="right">
            �������
            </td>
            <td>
            <asp:DropDownList ID="ddlDueType" runat="server" CssClass="pindl" AutoPostBack="true" OnSelectedIndexChanged="ddlDueType_SelectedIndexChanged">
            <asp:ListItem Value="0">ȫ��</asp:ListItem>
            <asp:ListItem Value="�ɹ����">�ɹ����</asp:ListItem>
            <asp:ListItem Value="�ڳ�Ӧ��">�ڳ�Ӧ��</asp:ListItem>
            <asp:ListItem Value="�ջ�����">�ջ�����</asp:ListItem>
            <asp:ListItem Value="�������">�������</asp:ListItem>
            <asp:ListItem Value="�����˻�">�����˻�</asp:ListItem>
            <asp:ListItem Value="Ԥ�տ�">Ԥ�տ�</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td align="right" style="padding-right:30px;">
                 <asp:Button ID="btnDueExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkRDToExcel()==false)return false;" OnClick="btnDueExcel_Click" />
            </td>
            </tr>
        </table>
        </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <div class="cndiv2" id="Div1" style="height:116px;">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView2_RowDataBound"  EnableViewState="false" ShowFooter="true" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="�������" DataField="RecType" />
                    <asp:BoundField HeaderText="���ݱ��" DataField="OperationID" />
                    <asp:BoundField HeaderText="����" DataField="_Date" />
                    <asp:BoundField HeaderText="������" DataField="_Name" />
                    <asp:BoundField HeaderText="�ܽ��" DataField="Amount" />
                    <asp:BoundField HeaderText="�ѽ�����" DataField="HaveAmount" />
                    <asp:BoundField HeaderText="δ������" DataField="NotChargeAmount" />
                    <asp:BoundField HeaderText="��������" DataField="RemindDate" />
                    <asp:BoundField HeaderText="��Ʊ����" DataField="InvoiceNO" />
                    <asp:BoundField HeaderText="��Ʊ���" DataField="InvoiceMoney" DataFormatString="{0:f2}" />
                    <asp:BoundField HeaderText="��Ʊ����" DataField="InvoiceDate" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField HeaderText="�տ��˻�" DataField="AccountName" />
                    <asp:BoundField HeaderText="��ע"  DataField="Remark"/>
                </Columns>
            </asp:GridView>
        </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlDueType" EventName="SelectedIndexChanged" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
    </div>
    
    <div class="fbom">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><div id="fbon" class="fbon"></div></td>
            <td align="right" style=" padding-right:15px;">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <span class="bs1" style="color:#0000ff;">��Ӧ�գ�<asp:Label ID="lbARec" runat="server" Text="" style="font-weight:bold;"></asp:Label></span>
                 <span class="bs1" style="color:#ff0000;">��Ӧ����<asp:Label ID="lbADue" runat="server" Text="" style="font-weight:bold;"></asp:Label></span>
                </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
var tabnum=3;
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}

function AtuoHedge()
{
    ChkMod(460,205, 'Financial/AtuoHedge.aspx', '�Զ��Գ�');
}

function ManualHedge()
{
    ChkMod(860,562, 'Financial/ManualHedge.aspx', '�ֹ��Գ�');
}

function CancelArr()
{
    ChkMod(400,135, 'Financial/CancelArr.aspx', 'ע������');
}

function ChkCG(bid)
{
    parent.ShowDialog(800, 480,'Purchase/PurchaseMod.aspx?ids='+bid,'�ɹ���');
}

function ChkHT(bid)
{
    parent.ShowDialog(820, 510, 'Customer/DevContMod.aspx?conno='+bid, '�޸ķ����ͬ');
}

function ChkGD(bid)
{
    parent.ShowDialog(860,444, 'Services/SerView.aspx?ids='+bid, '����');
}

function ChkDB(bid)
{
    parent.ShowDialog(800, 480,'Stock/AllocateMod.aspx?ids='+bid,'������');
}

function ChkXS(bid)
{
    parent.ShowDialog(800, 510,'Sell/SellMod.aspx?ids='+bid,'���۵�');
}

function ChkJS(bid)
{
    parent.ShowDialog(700, 480,'Lease/ShowCharge.aspx?ids='+bid, '������ϸ');
}

function ChkSFK(bid)
{
    parent.ShowDialog(670,245, 'Financial/InPayView.aspx?ids='+bid, '�ո��');
}

function ChkModR()
{
    var id=$("hfRecID2").value
    parent.ShowDialog(300, 290, 'Financial/ModRemindDate.aspx?id='+id, '�޸���������');
}

function Chkset()
{
    Chkwh2();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("Ӧ��Ӧ��");
}
</script>
