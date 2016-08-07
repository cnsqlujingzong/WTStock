<%@ page language="C#"  CodeFile="servicesde.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stat_ServicesDe" theme="Themes" enableEventValidation="false" %>
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
                <asp:BoundField HeaderText="单据编号" DataField="billid" />
                <asp:BoundField HeaderText="所属" DataField="dept" />
                <asp:BoundField HeaderText="日期" DataField="billdate" />
                <asp:BoundField HeaderText="制单人" DataField="person" />
                <asp:BoundField HeaderText="受理人" DataField="operator" />
                <asp:BoundField HeaderText="客户名称" DataField="customername" />
                <asp:BoundField HeaderText="审核日期" DataField="chkdate" />
                <asp:BoundField HeaderText="审核人" DataField="chkoperator" />
                <asp:BoundField HeaderText="材料费" DataField="Fee_Materail" />
                <asp:BoundField HeaderText="人工费" DataField="Fee_Labor" />
                <asp:BoundField HeaderText="附加费" DataField="Fee_Add" />
                <asp:BoundField HeaderText="优惠金额" DataField="PreMoney" />
                <asp:BoundField HeaderText="合计" DataField="RealMoney" />
                <asp:BoundField HeaderText="材料成本" DataField="MaterailCost" />
                <asp:BoundField HeaderText="额外成本" DataField="ExtraCost" />
                <asp:BoundField HeaderText="送修成本" DataField="RepairCost" />
                <asp:BoundField HeaderText="营业额" DataField="Fee_Total" />
                <asp:BoundField HeaderText="毛利" DataField="Profit" />
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
                <input id="btnDetail" type="button" value="明细" class="bt1" onclick="ShowDetail();" />
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
    parent.ShowDialog1(860,444, 'Services/SerView.aspx?ids='+id+'&iflag=1', '服务单');
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
