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
            <asp:BoundField HeaderText="服务类别" DataField="ServicesType" />
            <asp:BoundField HeaderText="受理方式" DataField="TakeStyle" />
            <asp:BoundField HeaderText="单据编号" DataField="BillID" />
            <asp:BoundField HeaderText="受理网点" DataField="TakeDept" />
            <asp:BoundField HeaderText="处理网点" DataField="DisposalDept" />
            <asp:BoundField HeaderText="受理时间" DataField="Time_TakeOver" />
            <asp:BoundField HeaderText="受理人" DataField="Operator" />
            <asp:BoundField HeaderText="处理时间" DataField="Speding" />
            <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="地址" DataField="Adr" />
            <asp:BoundField HeaderText="客户区域" DataField="Area" />
            <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
            <asp:BoundField HeaderText="机器品牌" DataField="ProductBrand" />
            <asp:BoundField HeaderText="类别" DataField="ProductClass" />
            <asp:BoundField HeaderText="型号" DataField="ProductModel" />
            <asp:BoundField HeaderText="序列号1" DataField="ProductSN1" />
            <asp:BoundField HeaderText="序列号2" DataField="ProductSN2" />
            <asp:BoundField HeaderText="外观" DataField="Aspect" />
            <asp:BoundField HeaderText="随机附件" DataField="Accessory" />
            <asp:BoundField HeaderText="服务级别" DataField="_PRI" />
            <asp:BoundField HeaderText="保修情况" DataField="Warranty" />
            <asp:BoundField HeaderText="报称故障" DataField="Fault" />
            <asp:BoundField HeaderText="技术员" DataField="DisposalOper" />
            <asp:BoundField HeaderText="处理措施/结果" DataField="TakeSteps" />
            <asp:BoundField HeaderText="计数器" DataField="QtyType" />
            <asp:BoundField HeaderText="购买时间" DataField="BuyDate" />
            <asp:BoundField HeaderText="经销商" DataField="BuyFrom" />
            <asp:BoundField HeaderText="购买发票" DataField="BuyInvoice" />
            <asp:BoundField HeaderText="工分" DataField="dPoint" />
            <asp:BoundField HeaderText="是否返修" DataField="bRepair" />
            <asp:BoundField HeaderText="存档单号" DataField="SaveID" />
            <asp:BoundField HeaderText="预约时间" DataField="SubscribeTime" />
            <asp:BoundField HeaderText="预约取机" DataField="SubscribeConnectTime" />
            <asp:BoundField HeaderText="送修厂商" DataField="RepairCorp" />
            <asp:BoundField HeaderText="完工时间" DataField="Time_Over" />
            <asp:BoundField HeaderText="结算时间" DataField="Time_Payee" />
            <asp:BoundField HeaderText="结算人" DataField="PayeeOper" />
            <asp:BoundField HeaderText="审核时间" DataField="Time_Close" />
            <asp:BoundField HeaderText="审核人" DataField="ChkOperator" />
            <asp:BoundField HeaderText="材料费" DataField="Fee_Materail" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="材料成本" DataField="MaterailCost" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="人工费" DataField="Fee_Labor" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="附加费" DataField="Fee_Add" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="送修成本" DataField="RepairCost" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="额外成本" DataField="ExtraCost" HtmlEncode="false" DataFormatString="{0:F2}"/>
            <asp:BoundField HeaderText="合计应收" DataField="Fee_Total" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="优惠金额" DataField="PreMoney" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="实际收款" DataField="RealMoney" HtmlEncode="false" DataFormatString="{0:F2}"/>
            <asp:BoundField HeaderText="已收款" DataField="HaveAmount" HtmlEncode="false" DataFormatString="{0:F2}"  />
            <asp:BoundField HeaderText="未收款" DataField="NotChargeAmount" HtmlEncode="false" DataFormatString="{0:F2}"  />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
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
    var id=$("hfRecID").value;
    if(id=="-1"||id=="")
    {
        window.alert("请选择一条明细后操作或直接双击记录查看明细！");
        return false;
    }
    parent.ShowDialog1(860,444, 'Services/SerView.aspx?id='+id+'&iflag=1', '服务单');
}
function ToExcel()
{
    if($("hfCount").value=="0")
    {
        window.alert("当前没有要导出的数据！");
        return false;
    }
}
function ShowTA(id)
{
    parent.ShowDialog1(470, 360,'Services/ShowTA.aspx?id='+id, '处理措施/结果');
}
</script>
