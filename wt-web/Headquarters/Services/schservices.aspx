<%@ page language="C#"  CodeFile="schservices.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_SchServices" theme="Themes" enableeventvalidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
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
            <asp:Button ID="btnDel" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('����')==false)return false;" OnClick="btnDel_Click"/>
            <input id="btnBack" type="button" value="����" class="bt1" onclick="ChkBack();" />
            <span style="display:none;">
                <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                <asp:Button ID="btnSchH" runat="server" Text="�߼���ѯ" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />
            </span>
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                    <input id="btnPrint" runat="server" type="button" value="��ӡ" class="iprint" onclick="ChkPrintChoise('PrintBill.aspx');" />
                </td>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">ģ����ѯ</asp:ListItem>
                    <asp:ListItem Value="1">�����񵥺Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="2">����������ѯ</asp:ListItem>
                    <asp:ListItem Value="3">���������Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="4">���������Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="5">��������ʽ��ѯ</asp:ListItem>
                    <asp:ListItem Value="6">�����񼶱��ѯ</asp:ListItem>
                    <asp:ListItem Value="7">�������˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="8">���ͻ����Ʋ�ѯ</asp:ListItem>
                    <asp:ListItem Value="9">����ϵ�˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="24">������ʱ����ѯ(��)</asp:ListItem>
                    <asp:ListItem Value="10">���ͻ��绰��ѯ</asp:ListItem>
                    <asp:ListItem Value="11">���ͻ���ַ��ѯ</asp:ListItem>
                    <asp:ListItem Value="12">�������ͺŲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="13">������Ʒ�Ʋ�ѯ</asp:ListItem>
                    <asp:ListItem Value="14">����������ѯ</asp:ListItem>
                    <asp:ListItem Value="15">���������кŲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="16">��ά�޼���Ա��ѯ</asp:ListItem>
                    <asp:ListItem Value="17">�����ϲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="18">�����������ѯ</asp:ListItem>
                    <asp:ListItem Value="20">�����޳��̲�ѯ</asp:ListItem>
                    <asp:ListItem Value="21">������״̬��ѯ</asp:ListItem>
                    <asp:ListItem Value="19">����ע��ѯ</asp:ListItem>
                    <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td style="padding:0px;"><input id="btnSchsH" type="button" value="�߼���ѯ" class="bsch" onclick="parent.ShowDialog(470,620, 'Services/SerSchCd.aspx', '�߼���ѯ');" /></td>
            </tr>
            </table>   
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="����״̬" DataField="curStatus" />
            <asp:BoundField HeaderText="���񵥺�" DataField="BillID" />
            <asp:BoundField HeaderText="����״̬" DataField="curStatus" />
            <asp:BoundField HeaderText="�������" DataField="ServicesType" />
            <asp:BoundField HeaderText="������" DataField="Operator" />
            <asp:BoundField HeaderText="����ʱ��" DataField="Time_TakeOver" />
            <asp:BoundField HeaderText="����ʱ��" DataField="Speding" />
            <asp:BoundField HeaderText="������ʽ" DataField="TakeStyle" />
            <asp:BoundField HeaderText="������λ" DataField="TakeDept" />
            <asp:BoundField HeaderText="������λ" DataField="DisposalDept" />
            <asp:BoundField HeaderText="���񼶱�" DataField="_PRI" />
            <asp:BoundField HeaderText="����Ա" DataField="DisposalOper" /> 
            <asp:BoundField HeaderText="��ɹرղ�����" DataField="FinTec" /> 
            <asp:BoundField HeaderText="�ͻ���Դ" DataField="CustomerFrom" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
            <asp:BoundField HeaderText="�����ͺ�" DataField="ProductModel" />
            <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
            <asp:BoundField HeaderText="���" DataField="ProductClass" />
            <asp:BoundField HeaderText="���к�1" DataField="ProductSN1" />
            <asp:BoundField HeaderText="���к�2" DataField="ProductSN2" />
            <asp:BoundField HeaderText="����" DataField="Fault" />
            <asp:BoundField HeaderText="������ʩ/���" DataField="TakeSteps" />
            <asp:BoundField HeaderText="������" DataField="QtyType" />
            <asp:BoundField HeaderText="�����ϸ" DataField="Deduct" />
            <asp:BoundField HeaderText="�������" DataField="Warranty" />
            <asp:BoundField HeaderText="ԤԼʱ��" DataField="SubscribeTime" />
            <asp:BoundField HeaderText="Ԥ����" DataField="SubscribePrice" />
            <asp:BoundField HeaderText="Ԥ�շ�" DataField="PreCharge" />
            <asp:BoundField HeaderText="����" DataField="bAgain" />
            <asp:BoundField HeaderText="����" DataField="bRepair" />
            <asp:BoundField HeaderText="�ط�" DataField="bCall" />
            <asp:BoundField HeaderText="ȡ��ԭ��" DataField="CancelReason" />
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
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    <asp:HiddenField ID="hfTecPur" runat="server" Value="1" />
    <asp:HiddenField ID="hfPurArea" runat="server" Value="" />
    <asp:HiddenField ID="hfPurDept" runat="server" Value="0" />
    <asp:HiddenField ID="hfPurOPDept" runat="server" Value="0" />
    <asp:HiddenField ID="hfTecDept" runat="server" Value="0" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
       
    <div class="fbom">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td><div id="fbon" class="fbon"></div></td>
                <td>
                    <span class="sred">������</span>
                    <span class="sgreen">������</span>
                    <span class="sblue">������</span>
                    <span class="sblack">�����</span>
                    <span class="syellow">����</span>
                    <span class="stin">�ѽ���</span>
                    <span class="sgay">��ȡ��</span>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
}

function ChkBack()
{
    ChkMod(460,124, 'Services/SchBack.aspx', '����');
}
function ChkView()
{
    ChkMod(860,444, 'Services/SerView.aspx', '����');
}

function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("���񵥲�ѯ");
}
</script>