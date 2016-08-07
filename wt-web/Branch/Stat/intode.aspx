<%@ page language="C#"  CodeFile="intode.aspx.cs"     autoeventwireup="true" inherits="Branch_Stat_InToDe" theme="Themes" enableEventValidation="false" %>
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
                <asp:BoundField HeaderText="�������" DataField="type" />
                <asp:BoundField HeaderText="���ݱ��" DataField="billid" />
                <asp:BoundField HeaderText="����" DataField="dept" />
                <asp:BoundField HeaderText="����" DataField="_Date" />
                <asp:BoundField HeaderText="������" DataField="operator" />
                <asp:BoundField HeaderText="������λ" DataField="customername" />
                <asp:BoundField HeaderText="Ӧ�տ�" DataField="RecMoney" />
                <asp:BoundField HeaderText="Ӧ����" DataField="DueMoney" />
                <asp:BoundField HeaderText="�Żݽ��" DataField="PreMoney" />
                <asp:BoundField HeaderText="ʵ�տ�" DataField="RealRecMoney" />
                <asp:BoundField HeaderText="ʵ����" DataField="RealDueMoney" />
                <asp:BoundField HeaderText="���㷽ʽ" DataField="ChargeStyle" />
                <asp:BoundField HeaderText="�����ʻ�" DataField="Account" />
                <asp:BoundField HeaderText="��Ʊ���" DataField="InvoiceClass" />
                <asp:BoundField HeaderText="��Ʊ����" DataField="InvoiceNO" />
                <asp:BoundField HeaderText="ƾ֤����" DataField="VoucherNO" />
                <asp:BoundField HeaderText="������Ŀ" DataField="ChargeItem" />
                <asp:BoundField HeaderText="�������" DataField="chkdate" />
                <asp:BoundField HeaderText="�����" DataField="chkoperator" />
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
    var type=$("hfType").value;
    var id=$("hfRecID").value;
    if(id=="-1"||id=="")
    {
        window.alert("��ѡ��һ����ϸ�������ֱ��˫����¼�鿴��ϸ��");
        return false;
    }
    parent.ShowDialog1(670,245, 'Financial/InPayView.aspx?id='+id+'&iflag=1', type);
}
function ToExcel()
{
    if($("hfCount").value=="0")
    {
        window.alert("��ǰû��Ҫ���������ݣ�");
        return false;
    }
}
</script>
