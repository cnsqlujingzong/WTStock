<%@ page language="C#"  CodeFile="incomeadm.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Financial_IncomeAdm" theme="Themes" enableEventValidation="false" %>
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
            <asp:Button ID="btnChk" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ConfChk('�����ѡ���[�ո��]')==false)return false;" OnClick="btnChk_Click" />
            <asp:Button ID="btnChkU" runat="server" Text="�����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ConfChk('�������ѡ���[�ո��]')==false)return false;" OnClick="btnChkU_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ConfChk('������ѡ���[�ո��]')==false)return false;" OnClick="btnCancel_Click" />
            <span style="display:none;">
                <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                <asp:Button ID="btnSchH" runat="server" Text="�߼���ѯ" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />
                <asp:Button ID="btnShow" runat="server" Text="��ʾ" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="false"/>
            </span>
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                    <input id="btnClass" runat="server" type="button" class="bclass" value="�����޸�" onclick="ChkEditClass();" />
                    <asp:CheckBox ID="chkbox" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" Text="����������ո��" />
                    <asp:CheckBox ID="cbzerostk" runat="server" AutoPostBack="True" Checked="true" OnCheckedChanged="cbzerostk_CheckedChanged" Text=" ���ضԳ��ո��" />
                </td>
                <td>
                    <input id="btnPrint" runat="server" type="button" value="��ӡ" class="iprint" onclick="ChkPrints();" />
                </td>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="BillID">�����ݱ�Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="Type">���������Ͳ�ѯ</asp:ListItem>
                    <asp:ListItem Value="_Date">�����ڲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="Operator">�������˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="CustomerName">��������λ��ѯ</asp:ListItem>
                    <asp:ListItem Value="ChargeStyle">�����㷽ʽ��ѯ</asp:ListItem>
                    <asp:ListItem Value="Account">�������ʻ���ѯ</asp:ListItem>
                    <asp:ListItem Value="InvoiceClass">����Ʊ����ѯ</asp:ListItem>
                    <asp:ListItem Value="InvoiceNO">����Ʊ�����ѯ</asp:ListItem>
                    <asp:ListItem Value="CheckNO">��֧Ʊ�����ѯ</asp:ListItem>
                    <asp:ListItem Value="VoucherNO">��ƾ֤�����ѯ</asp:ListItem>
                    <asp:ListItem Value="ChargeItem">����֧��Ŀ��ѯ</asp:ListItem>
                    <asp:ListItem Value="ChkDate">��������ڲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="ChkOperator">������˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="RecType">���ʿ����Ͳ�ѯ</asp:ListItem>
                    <asp:ListItem Value="Remark">����ע��ѯ</asp:ListItem>
                    <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td style="padding:0px;"><input id="btnSchsH" type="button" value="�߼���ѯ" class="bsch" onclick="parent.ShowDialog(470,290, 'Financial/IncomeCd.aspx', '�߼���ѯ');" /></td>
            </tr>
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
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderTemplate>
                    <input id="cball" type="checkbox" class="cb1" onclick="SltAllValue();" title="ȫѡ/ȡ��ȫѡ"/>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="�������" DataField="Type" />
            <asp:BoundField HeaderText="���ݱ��" DataField="BillID" />
            <asp:BoundField HeaderText="״̬" DataField="Status" />
            <asp:BoundField HeaderText="����" DataField="_Date"/>
            <asp:BoundField HeaderText="������" DataField="Operator" />
            <asp:BoundField HeaderText="����" DataField="Dept" />
            <asp:BoundField HeaderText="������λ" DataField="CustomerName" />
            <asp:BoundField HeaderText="ʵ�տ�" DataField="RealRecMoney" />
            <asp:BoundField HeaderText="ʵ����" DataField="RealDueMoney" />
            <asp:BoundField HeaderText="�Żݽ��" DataField="PreMoney" />
            <asp:BoundField HeaderText="���㷽ʽ" DataField="ChargeStyle" />
            <asp:BoundField HeaderText="�����ʻ�" DataField="Account" />
            <asp:BoundField HeaderText="��Ʊ����" DataField="InvoiceDate" />
            <asp:BoundField HeaderText="��Ʊ���" DataField="InvoiceAmount" />
            <asp:BoundField HeaderText="��Ʊ����" DataField="InvoiceNO" />
            <asp:BoundField HeaderText="��Ʊ���" DataField="InvoiceClass" />
            <asp:BoundField HeaderText="֧Ʊ����" DataField="CheckNO" />
            <asp:BoundField HeaderText="ƾ֤����" DataField="VoucherNO" />
            <asp:BoundField HeaderText="��֧��Ŀ" DataField="ChargeItem" />
            <asp:BoundField HeaderText="�ʿ�����" DataField="RecType" />
            <asp:BoundField HeaderText="�������" DataField="ChkDate" />
            <asp:BoundField HeaderText="�����" DataField="ChkOperator" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
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
    <asp:HiddenField ID="hfType" runat="server" />
    <asp:HiddenField ID="hfcbID" runat="server" />
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkU" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="cbzerostk" EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="chkbox" EventName="CheckedChanged" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut" style="overflow:hidden;">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1"></span>
                <span id="tabs1" onclick="ChkTab('1');">��ϸ</span>
                <span id="tabs_r1"></span>
            </div>
        </div>
        <div id="info1" style="height:163px;background:#ECE9D8;">
        <div class="cndiv2" id="cndiv2" style="height:143px;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView1_RowDataBound"  EnableViewState="false" ShowFooter="true" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="�������" DataField="Type" />
                    <asp:BoundField HeaderText="�������" DataField="RecType" />
                    <asp:BoundField HeaderText="���ݱ��" DataField="OperationID" />
                    <asp:BoundField HeaderText="����" DataField="_Date" />
                    <asp:BoundField HeaderText="������" DataField="_Name" />
                    <asp:BoundField HeaderText="�ܽ��" DataField="Amount" />
                    <asp:BoundField HeaderText="�ѽ�����" DataField="HaveAmount" />
                    <asp:BoundField HeaderText="δ������" DataField="NotChargeAmount" />
                    <asp:BoundField HeaderText="��������" DataField="RemindDate" />
                    <asp:BoundField HeaderText="��ע"  DataField="Remark"/>
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
    </div>
    
    <div class="fbom">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td><div id="fbon" class="fbon"></div></td>
                <td>
                    <span class="sred">�����</span>
                    <span class="sgreen">�����</span>
                    <span class="sgay">������</span>
                </td>
                <td>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
                    <span class="bs1" style="color:#0000ff;">��ʵ�տ�:<asp:Label ID="Label1" runat="server" Text=""></asp:Label></span>
                    <span class="bs1" style="color:#ff0000;">��ʵ����:<asp:Label ID="Label2" runat="server" Text=""></asp:Label></span>
                    <span class="bs1" style="color:Black;">�ܿ�Ʊ��:<asp:Label ID="Label3" runat="server" Text=""></asp:Label></span>
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkU" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="cbzerostk" EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="chkbox" EventName="CheckedChanged" />
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
var tabnum=2;
function ChkID(id,type)
{
    ClrID(id);
    $("btnShow").click();
    $("hfType").value=type;
}

function ChkView()
{
    ChkMod(670,245, 'Financial/InPayView.aspx', '�ո��');
}

function ConfChk(str)
{
    if(ChkSltValue()!=false)
    {
        return confirm("ȷ��Ҫ"+str+"��");
    }else{return false;}
}

function Chkset()
{
    Chkwh2();
    Chkbom(); 
}
function ChkModR()
{
    var id=$("hfRecID2").value
    parent.ShowDialog(300, 123, 'Financial/ModRemindDate.aspx?id='+id, '�޸���������');
}
function ChkPrints()
{
    if($("hfType").value=="�տ")
    ChkPrint('SKD');
    else
    ChkPrint('FKD');
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("�ո����ѯ");
}
function ChkCG(bid)
{
    parent.ShowDialog(800, 480,'Purchase/PurchaseMod.aspx?ids='+bid+'&n=1','�ɹ���');
}

function ChkHT(bid)
{
    parent.ShowDialog(820, 510, 'Customer/DevContMod.aspx?conno='+bid+'&n=1', '�޸ķ����ͬ');
}

function ChkGD(bid)
{
    parent.ShowDialog(860,444, 'Services/SerView.aspx?ids='+bid, '����');
}

function ChkDB(bid)
{
    parent.ShowDialog(800, 480,'Stock/AllocateMod.aspx?ids='+bid+'&n=1','������');
}

function ChkXS(bid)
{
    parent.ShowDialog(800, 510,'Sell/SellMod.aspx?ids='+bid+'&n=1','���۵�');
}

function ChkJS(bid)
{
    parent.ShowDialog(700, 480,'Lease/ShowCharge.aspx?ids='+bid+'&n=1', '������ϸ');
}
function ChkSFK(bid)
{
    parent.ShowDialog(670,245, 'Financial/InPayView.aspx?ids='+bid+'&n=1', '�ո��');
}
function ChkEditClass()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(300, 128,'Financial/EditExpense.aspx?id='+id,'�����޸�');
    }
}
</script>
