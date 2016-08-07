<%@ page language="C#"  CodeFile="servicede2.aspx.cs"     autoeventwireup="true" inherits="Branch_Stat_ServiceDe2" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
    <div class="maincon">
    <div id="sa" style="width:856px;">
    <div class="fdivs">
    <div class="sdivs" style="width:852px; height:455px;">
        <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="�������" DataField="ServicesType" />
            <asp:BoundField HeaderText="����ʽ" DataField="TakeStyle" />
            <asp:BoundField HeaderText="���ݱ��" DataField="BillID" />
            <asp:BoundField HeaderText="��������" DataField="TakeDept" />
            <asp:BoundField HeaderText="��������" DataField="DisposalDept" />
            <asp:BoundField HeaderText="����ʱ��" DataField="Time_TakeOver" />
            <asp:BoundField HeaderText="������" DataField="Operator" />
            <asp:BoundField HeaderText="����ʱ��" DataField="Speding" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="��ַ" DataField="Adr" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="Area" />
            <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
            <asp:BoundField HeaderText="����Ʒ��" DataField="ProductBrand" />
            <asp:BoundField HeaderText="���" DataField="ProductClass" />
            <asp:BoundField HeaderText="�ͺ�" DataField="ProductModel" />
            <asp:BoundField HeaderText="���к�1" DataField="ProductSN1" />
            <asp:BoundField HeaderText="���к�2" DataField="ProductSN2" />
            <asp:BoundField HeaderText="���" DataField="Aspect" />
            <asp:BoundField HeaderText="�������" DataField="Accessory" />
            <asp:BoundField HeaderText="���񼶱�" DataField="_PRI" />
            <asp:BoundField HeaderText="�������" DataField="Warranty" />
            <asp:BoundField HeaderText="���ƹ���" DataField="Fault" />
            <asp:BoundField HeaderText="����Ա" DataField="DisposalOper" />
            <asp:BoundField HeaderText="�����ʩ/���" DataField="TakeSteps" />
            <asp:BoundField HeaderText="������" DataField="QtyType" />
            <asp:BoundField HeaderText="����ʱ��" DataField="BuyDate" />
            <asp:BoundField HeaderText="������" DataField="BuyFrom" />
            <asp:BoundField HeaderText="����Ʊ" DataField="BuyInvoice" />
            <asp:BoundField HeaderText="����" DataField="dPoint" />
            <asp:BoundField HeaderText="�Ƿ���" DataField="bRepair" />
            <asp:BoundField HeaderText="�浵����" DataField="SaveID" />
            <asp:BoundField HeaderText="ԤԼʱ��" DataField="SubscribeTime" />
            <asp:BoundField HeaderText="ԤԼȡ��" DataField="SubscribeConnectTime" />
            <asp:BoundField HeaderText="���޳���" DataField="RepairCorp" />
            <asp:BoundField HeaderText="�깤ʱ��" DataField="Time_Over" />
            <asp:BoundField HeaderText="����ʱ��" DataField="Time_Payee" />
            <asp:BoundField HeaderText="������" DataField="PayeeOper" />
            <asp:BoundField HeaderText="���ʱ��" DataField="Time_Close" />
            <asp:BoundField HeaderText="�����" DataField="ChkOperator" />
            <asp:BoundField HeaderText="���Ϸ�" DataField="Fee_Materail" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="���ϳɱ�" DataField="MaterailCost" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="�˹���" DataField="Fee_Labor" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="���ӷ�" DataField="Fee_Add" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="���޳ɱ�" DataField="RepairCost" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="����ɱ�" DataField="ExtraCost" HtmlEncode="false" DataFormatString="{0:F2}"/>
            <asp:BoundField HeaderText="�ϼ�Ӧ��" DataField="Fee_Total" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="�Żݽ��" DataField="PreMoney" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="ʵ���տ�" DataField="RealMoney" HtmlEncode="false" DataFormatString="{0:F2}"/>
            <asp:BoundField HeaderText="���տ�" DataField="HaveAmount" HtmlEncode="false" DataFormatString="{0:F2}"  />
            <asp:BoundField HeaderText="δ�տ�" DataField="NotChargeAmount" HtmlEncode="false" DataFormatString="{0:F2}"  />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lbTitle" runat="server" Text="�ܼ�¼��"></asp:Label><asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfType" runat="server" />
        <asp:HiddenField ID="hfCount" runat="server" />
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <input id="btnDetail" type="button" value="��ϸ" class="bt1" onclick="ShowDetail();" />
                <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bt1" OnClientClick="if(ToExcel()==false)return false;" OnClick="btnExcel_Click" />
                <input id="btnClose" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();" />
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
<script language="javascript" type="text/javascript">
function ChkID(id,type)
{
    ClrID(id);
    $("hfType").value=type;
}
function ShowDetail()
{
    var id=$("hfRecID").value;
    if(id=="-1"||id=="")
    {
        window.alert("��ѡ��һ����ϸ�������ֱ��˫����¼�鿴��ϸ��");
        return false;
    }
    parent.ShowDialog1(860,444, 'Services/SerView.aspx?id='+id+'&iflag=1', '����');
}
function ToExcel()
{
    if($("hfCount").value=="0")
    {
        window.alert("��ǰû��Ҫ���������ݣ�");
        return false;
    }
}
function ShowTA(id)
{
    parent.ShowDialog1(470, 360,'Services/ShowTA.aspx?id='+id, '�����ʩ/���');
}
</script>
