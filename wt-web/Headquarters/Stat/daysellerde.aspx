<%@ page language="C#"  CodeFile="daysellerde.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stat_DaySellerDe" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
                <asp:BoundField HeaderText="�������" DataField="billtype" />
                <asp:BoundField HeaderText="���ݱ��" DataField="billid" />
                <asp:BoundField HeaderText="����" DataField="dept" />
                <asp:BoundField HeaderText="����" DataField="billdate" />
                <asp:BoundField HeaderText="�Ƶ���" DataField="person" />
                <asp:BoundField HeaderText="ҵ��Ա" DataField="operator" />
                <asp:BoundField HeaderText="����Ա" DataField="disposaloper" />
                <asp:BoundField HeaderText="�ͻ�����" DataField="customername" />
                <asp:BoundField HeaderText="���" DataField="total" />
                <asp:BoundField HeaderText="ë��" DataField="profit" />
                <asp:BoundField HeaderText="�������" DataField="chkdate" />
                <asp:BoundField HeaderText="�����" DataField="chkoperator" />
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
    if(type=="����")
    parent.ShowDialog2(860,444, 'Services/SerView.aspx?ids='+id+'&iflag=2', type);
    else
    parent.ShowDialog2(800, 480,'Sell/SellMod.aspx?ids='+id+'&f=2', type+'��');
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
