<%@ page language="C#"  CodeFile="sltlease.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Lease_SltLease" theme="Themes" enableEventValidation="false" %>
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
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <div class="ftool">
        <div class="ftoolleft">
        <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">ģ����ѯ</asp:ListItem>
                    <asp:ListItem Value="1">��ҵ���Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="2">���ͻ����Ʋ�ѯ</asp:ListItem>
                    <asp:ListItem Value="3">����ϵ�˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="4">����ϵ�绰��ѯ</asp:ListItem>
                    <asp:ListItem Value="5">����ַ��ѯ</asp:ListItem>
                    <asp:ListItem Value="6">�������ͺŲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="7">�����кŲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="8">������Ʒ�Ʋ�ѯ</asp:ListItem>
                    <asp:ListItem Value="9">����������ѯ</asp:ListItem>
                    <asp:ListItem Value="10">����ʼ���ڲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="11">����ֹ���ڲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="12">��ҵ��Ա��ѯ</asp:ListItem>
                    <asp:ListItem Value="13">����ע��ѯ</asp:ListItem>
                    <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnSch_Click" /></td>
             </tr>
            </table>   
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td style="padding-right:50px;">
                <input id="btnAdd" type="button" value="ȷ��" class="bt1" onclick="SltLease();"/>
            </td>
            <td>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                    <asp:Button ID="btnShow" runat="server" Text="��ʾ" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnShow_Click"/>
                </span>
            </td>
            </tr>
            </table>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="height:300px; width:800px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="ҵ�����" DataField="Type" />
            <asp:BoundField HeaderText="ҵ��״̬" DataField="curStatus" />
            <asp:BoundField HeaderText="ҵ����" DataField="BillID" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
             <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="��ַ" DataField="Adr" />
            <asp:BoundField HeaderText="��������" DataField="Rent" />
            <asp:BoundField HeaderText="��ʼ����" DataField="StartDate" />
            <asp:BoundField HeaderText="��ֹ����" DataField="EndDate" />
            <asp:BoundField HeaderText="��������" DataField="ChargeCycle" />
            <asp:BoundField HeaderText="��ͬ���" DataField="ContractNO" />
            <asp:BoundField HeaderText="Ѻ��" DataField="Deposit" />
            <asp:BoundField HeaderText="����" DataField="_Date" />
            <asp:BoundField HeaderText="�Ƶ���" DataField="Operator" />
            <asp:BoundField HeaderText="ҵ��Ա" DataField="Seller" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            <asp:BoundField HeaderText="ȡ��ԭ��" DataField="CancelReason" />
        </Columns>
    </asp:GridView>
    <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
        </tr>
    </table>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
        <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
        <asp:HiddenField ID="hfSql" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="cnbut" style="width:800px; height:180px;">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1" class="tabs_activeleft"></span>
                <span id="tabs1" class="tabs_active" >���޻���</span>
                <span id="tabs_r1" class="tabs_activeright"></span>
            </div>
        </div>
        <div class="cndiv2" id="cndiv2" style="height:155px;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView2_RowDataBound"  EnableViewState="false" ShowFooter="true" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="�ֿ�" DataField="StockName" />
                    <asp:BoundField HeaderText="���޻���" DataField="GoodsNO" />
                    <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
                    <asp:BoundField HeaderText="����Ʒ��" DataField="Brand" />
                    <asp:BoundField HeaderText="���" DataField="Class" />
                    <asp:BoundField HeaderText="�ͺ�" DataField="Model" />
                    <asp:BoundField HeaderText="���к�" DataField="ProductSN1" />
                    <asp:BoundField HeaderText="���к�2" DataField="ProductSN2" />
                    <asp:BoundField HeaderText="������"/>
                    <asp:BoundField HeaderText="��ע" DataField="Remark" />
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
    </div>
    <div class="clearfloat"></div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}
function ViewQty(id)
{
    parent.ShowDialog3(400, 300,'Lease/ViewQty.aspx?id='+id, '�鿴������');
}

function SltLease()
{
    var list=document.getElementById("hfRecID").value;
    if(list==""||list=="-1")
    {
        alert("����ʧ�ܣ���ѡ������.");return false;
    }else{
    try{
        parent.<%=Str_Fid %>.$("hfSltID").value=list;
        parent.<%=Str_Fid %>.document.getElementById("btnSltBill").click();
    }catch(e){alert("ϵͳ������ˢ�º�����");}
    parent.CloseDialog<%=Str_F %>();
    }
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
