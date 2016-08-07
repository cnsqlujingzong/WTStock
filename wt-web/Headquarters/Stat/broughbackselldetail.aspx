<%@ page language="C#"  CodeFile="broughbackselldetail.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stat_BroughBackSellDetail" theme="Themes" enableEventValidation="false" %>
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
                <asp:BoundField HeaderText="单据编号" DataField="BillID" />
                <asp:BoundField HeaderText="领料人" DataField="AppOperator" />
                <asp:BoundField HeaderText="仓库" DataField="StockName" />
                <asp:BoundField HeaderText="商品编号" DataField="GoodsNO" />
                <asp:BoundField HeaderText="商品名称" DataField="_Name" />
                <asp:BoundField HeaderText="规格" DataField="Spec" />
                <asp:BoundField HeaderText="单位" DataField="unit" />
                <asp:BoundField HeaderText="审核日期" DataField="chkdate" />
                <asp:BoundField HeaderText="数量" DataField="qty" />
                <asp:BoundField HeaderText="成本" DataField="CostPrice" />
                <asp:BoundField HeaderText="服务单号" DataField="OperationID" />
                <asp:BoundField HeaderText="单据类型" DataField="Type" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lbTitle" runat="server" Text="总记录："></asp:Label><asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfType" runat="server" />
        <asp:HiddenField ID="hfCount" runat="server" />
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bt1" OnClientClick="if(ToExcel()==false)return false;" OnClick="btnExcel_Click" />
                <input id="btnClose" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();" />
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
        window.alert("请选择一条明细后操作或直接双击记录查看明细！");
        return false;
    }
    if(type=="销售单")
    parent.ShowDialog1(800, 480, 'Sell/SellMod.aspx?ids='+id+'&f=1', type);
    else if(type=="退货单")
    parent.ShowDialog1(800, 480,'Sell/SellMod.aspx?ids='+id+'&f=1', type);
    else if(type=="服务单")
    parent.ShowDialog1(860,444, 'Services/SerView.aspx?ids='+id+'&iflag=1', '服务单');
}
function ViewSN(strsn)
{
    parent.ShowDialog1(400, 300, 'Stock/ViewSN.aspx?sn='+escape(strsn), '查看序列号');
}
function ToExcel()
{
    if($("hfCount").value=="0")
    {
        window.alert("当前没有要导出的数据！");
        return false;
    }
}
</script>
