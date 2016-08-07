<%@ page language="C#"  CodeFile="cushistory.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_CusHistory" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
    <div class="maincon">
    <div id="sa" style="width:786px;">
        <div class="ftool2">
        <div id="mytabs" style="padding-left:2px;">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">��������</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">����ҵ��</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">����ҵ��</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');"> ����/ȫ��</span>
            <span id="tabs_r4"></span>
        </div>
        </div>
        <div id="info1" style="height:473px;background:#ECE9D8;">
            <div class="cndiv2" id="cndiv2" style="height:471px;">
                <asp:GridView ID="gvtrouble" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvtrouble_RowDataBound" EnableViewState="false">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
                        <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
                        <asp:BoundField HeaderText="��������" DataField="CusDept" />
                        <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
                        <asp:BoundField HeaderText="�ֻ�����" DataField="Tel2" />
                        <asp:BoundField HeaderText="����" DataField="Fax" />
                        <asp:BoundField HeaderText="�ʱ�" DataField="Zip" />
                        <asp:BoundField HeaderText="��ַ" DataField="Adr" />
                        <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
                        <asp:BoundField HeaderText="���" DataField="ProductClass" />
                        <asp:BoundField HeaderText="�ͺ�" DataField="ProductModel" />
                        <asp:BoundField HeaderText="���к�1" DataField="ProductSN1" />
                        <asp:BoundField HeaderText="���к�2" DataField="ProductSN2" />
                        <asp:BoundField HeaderText="���" DataField="ProductAspect" />
                        <asp:BoundField HeaderText="��Ȩ" DataField="Property" />
                        <asp:BoundField HeaderText="����ʱ��" DataField="BuyDate" />
                        <asp:BoundField HeaderText="����۸�" DataField="BuyPrice" />
                        <asp:BoundField HeaderText="������" DataField="BuyFrom" />
                        <asp:BoundField HeaderText="����Ʊ" DataField="BuyInvoice" />
                        <asp:BoundField HeaderText="��װ����" DataField="InstallDate" />
                        <asp:BoundField HeaderText="������" DataField="MaintenancePeriod" />
                        <asp:BoundField HeaderText="�������" DataField="Warranty" />
                        <asp:BoundField HeaderText="���ұ��޿�ʼ" DataField="WarrantyStart" />
                        <asp:BoundField HeaderText="���ұ��޽���" DataField="WarrantyEnd" />
                        <asp:BoundField HeaderText="ά�޴���" DataField="RepairTimes" />
                        <asp:BoundField HeaderText="���ά��ʱ��" DataField="Repairlately" />
                        <asp:BoundField HeaderText="ά�ޱ��޽���" DataField="RepairWarrantyEnd" />
                        <asp:BoundField HeaderText="��ͬ���޿�ʼ" DataField="ContractWarrantyStart" />
                        <asp:BoundField HeaderText="��ͬ���޽���" DataField="ContractWarrantyEnd" />
                        <asp:BoundField HeaderText="ά�޺�ͬ���" DataField="ContractNO" />
                        <asp:BoundField HeaderText="�Զ���1" DataField="userdef1" />
                        <asp:BoundField HeaderText="�Զ���2" DataField="userdef2" />
                        <asp:BoundField HeaderText="�Զ���3" DataField="userdef3" />
                        <asp:BoundField HeaderText="�Զ���4" DataField="userdef4" />
                        <asp:BoundField HeaderText="�Զ���5" DataField="userdef5" />
                        <asp:BoundField HeaderText="��ע" DataField="Remark" />
                    </Columns>
                </asp:GridView>

                <table cellpadding="0" cellspacing="0" class="pages">
                    <tr>
                        <td><webdiyer:aspnetpager id="jsPagerd" runat="server" onpagechanged="jsPagerd_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
                        <td style="padding-left:8px;"><asp:Label ID="lbPaged" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
                        <td style="padding-left:8px;"><asp:Label ID="lbCountTextd" runat="server" Visible="false" ToolTip="�ܼ�¼��" Text="�ܼ�¼:"></asp:Label><asp:Label ID="lbCountd" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="info2" style="height:473px;background:#ECE9D8;">
            <div class="cndiv2" id="Div1" style="height:471px;">
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView3_RowDataBound" EnableViewState="false">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="���񵥺�" DataField="BillID" />
                        <asp:BoundField HeaderText="����״̬" DataField="curStatus" />
                        <asp:BoundField HeaderText="�������" DataField="ServicesType" />
                        <asp:BoundField HeaderText="������" DataField="Operator" />
                        <asp:BoundField HeaderText="����ʱ��" DataField="Time_TakeOver" />
                        <asp:BoundField HeaderText="����ʱ��" DataField="Speding" />
                        <asp:BoundField HeaderText="����ʽ" DataField="TakeStyle" />
                        <asp:BoundField HeaderText="����λ" DataField="TakeDept" />
                        <asp:BoundField HeaderText="���񼶱�" DataField="_PRI" />
                        <asp:BoundField HeaderText="����Ա" DataField="DisposalOper" />  
                        <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
                        <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
                        <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
                        <asp:BoundField HeaderText="�����ͺ�" DataField="ProductModel" />
                        <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
                        <asp:BoundField HeaderText="���" DataField="ProductClass" />
                        <asp:BoundField HeaderText="���к�1" DataField="ProductSN1" />
                        <asp:BoundField HeaderText="���к�2" DataField="ProductSN2" />
                        <asp:BoundField HeaderText="����" DataField="Fault" />
                        <asp:BoundField HeaderText="�����ʩ/���" DataField="TakeSteps" />
                        <asp:BoundField HeaderText="������" DataField="QtyType" />
                        <asp:BoundField HeaderText="�������" DataField="Warranty" />
                        <asp:BoundField HeaderText="ԤԼʱ��" DataField="SubscribeTime" />
                        <asp:BoundField HeaderText="Ԥ����" DataField="SubscribePrice" />
                        <asp:BoundField HeaderText="Ԥ�շ�" DataField="PreCharge" />
                        <asp:BoundField HeaderText="����" DataField="bRepair" />
                        <asp:BoundField HeaderText="��ע" DataField="Remark" />
                    </Columns>
                </asp:GridView>

                <table cellpadding="0" cellspacing="0" class="pages">
                    <tr>
                        <td><webdiyer:aspnetpager id="jsPagerb" runat="server" onpagechanged="jsPagerb_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
                        <td style="padding-left:8px;"><asp:Label ID="lbPageb" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
                        <td style="padding-left:8px;"><asp:Label ID="lbCountTextb" runat="server" Visible="false" ToolTip="�ܼ�¼��" Text="�ܼ�¼:"></asp:Label><asp:Label ID="lbCountb" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
                    </tr>
                </table>
            </div>
        </div>
        
        <div id="info3" style="height:473px;background:#ECE9D8;">
            <div class="cndiv2" id="Div2" style="height:471px;">
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView4_RowDataBound" EnableViewState="false">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="����״̬" DataField="Status" />
                        <asp:BoundField HeaderText="�������" DataField="Type" />
                        <asp:BoundField HeaderText="���ݱ��" DataField="BillID" />
                        <asp:BoundField HeaderText="����" DataField="_Date" />
                        <asp:BoundField HeaderText="ҵ��Ա" DataField="Operator" />
                        <asp:BoundField HeaderText="�ͻ�����" DataField="_Name" />
                        <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
                        <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
                        <asp:BoundField HeaderText="��ַ" DataField="Adr" />
                        <asp:BoundField HeaderText="�ͻ���" DataField="SndOperator" />
                        <asp:BoundField HeaderText="�ֽ���" DataField="InCash" />
                        <asp:BoundField HeaderText="�������" DataField="ChkDate" />
                        <asp:BoundField HeaderText="�����" DataField="ChkOperator" />
                        <asp:BoundField HeaderText="�Ա��" DataField="AutoNO" />
                        <asp:BoundField HeaderText="���õ���" DataField="OperationID" />
                        <asp:BoundField HeaderText="�Ƶ���" DataField="Person" />
                        <asp:BoundField HeaderText="��ע" DataField="Remark" />
                    </Columns>
                </asp:GridView>

                <table cellpadding="0" cellspacing="0" class="pages">
                    <tr>
                        <td><webdiyer:aspnetpager id="jsPagers" runat="server" onpagechanged="jsPagers_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
                        <td style="padding-left:8px;"><asp:Label ID="lbPages" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
                        <td style="padding-left:8px;"><asp:Label ID="lbCountTexts" runat="server" Visible="false" ToolTip="�ܼ�¼��" Text="�ܼ�¼:"></asp:Label><asp:Label ID="lbCounts" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
                    </tr>
                </table>
            </div>
        </div>
        
        <div id="info4" style="height:473px;background:#ECE9D8;">
            <div class="cndiv2" id="Div4" style="height:471px;">
                <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView5_RowDataBound" EnableViewState="false">
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
                        </Columns>
                    </asp:GridView>

                    <table cellpadding="0" cellspacing="0" class="pages">
                        <tr>
                            <td><webdiyer:aspnetpager id="jsPagerle" runat="server" onpagechanged="jsPagerle_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbPagele" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbCountTextle" runat="server" Visible="false" ToolTip="�ܼ�¼��" Text="�ܼ�¼:"></asp:Label><asp:Label ID="lbCountle" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
                        </tr>
                    </table>
            </div>
        </div>
        <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var tabnum=5;
function ModD()
{
    var id=document.getElementById("hfRecID2").value.replace("d","");
    if(id=="-1")
    {
        alert("��ѡ��һ�����������������");
    }
    else
    {
        parent.ShowDialog2(750, 430,'Customer/DeviceMod.aspx?id='+id+'&f=2', '�޸Ļ�������');
    }
}

function SerV()
{
    var id=document.getElementById("hfRecID2").value.replace("b","");
    if(id=="-1")
    {
        alert("��ѡ��һ�����񵥺������");
    }
    else
    {
        parent.ShowDialog2(860,444, 'Services/SerView.aspx?id='+id+'&iflag=2', '����');
    }
}

function SellV()
{
    var id=document.getElementById("hfRecID2").value.replace("s","");
    if(id=="-1")
    {
        alert("��ѡ��һ�����۵��������");
    }
    else
    {
        parent.ShowDialog2(800, 480,'Sell/SellMod.aspx?id='+id+'&f=2', '���۵�');
    }
}

function LeaseV()
{
    var id=document.getElementById("hfRecID2").value.replace("le","");
    if(id=="-1")
    {
        alert("��ѡ��һ��ҵ�񵥺������");
    }
    else
    {
        parent.ShowDialog2(800, 480,'Lease/LeaseMod.aspx?id='+id+'&f=2','ҵ��');
    }
}
function ShowTA(id)
{
    parent.ShowDialog2(470, 360,'Services/ShowTA.aspx?id='+id, '�����ʩ/���');
}
</script>
