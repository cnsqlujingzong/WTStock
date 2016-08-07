<%@ page language="C#"  CodeFile="tecdaywork.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Office_TecDayWork" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
</head>
<body onload="Chkset();" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="ftool">
        <div class="ftoolleft">
          <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td class="red">网点：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" Width="100">
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>日期从：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
            <td>到：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDateE" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
            <td align="left">
                <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td>
                <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
            </td>
            </tr>
          </table>
        </div>
        <div class="ftoolright">
              <span style="display:none;">
                <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
            </span>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="statf" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="序" DataField="ID" />
            <asp:BoundField HeaderText="工号" DataField="JobNO" />
            <asp:BoundField HeaderText="姓名" DataField="_Name"/>
            <asp:BoundField HeaderText="所属" DataField="Dept"/>
            <asp:BoundField HeaderText="入库单" DataField="StockIN"/>
            <asp:BoundField HeaderText="出库单" DataField="StockOUT"/>
            <asp:BoundField HeaderText="领退单" DataField="BroughtBack"/>
            <asp:BoundField HeaderText="调拨申请" DataField="Allocate"/>
            <asp:BoundField HeaderText="调拨审核" DataField="AllocateChk"/>
            <asp:BoundField HeaderText="调拨发货" DataField="AllocateSnd"/>
            <asp:BoundField HeaderText="调拨签收" DataField="AllocateSigned"/>
            <asp:BoundField HeaderText="采购单" DataField="Purchase"/>
            <asp:BoundField HeaderText="采购订单" DataField="PurchasePlan"/>
            <asp:BoundField HeaderText="销售单" DataField="Sell"/>
            <asp:BoundField HeaderText="销售订单" DataField="SellPlan"/>
            <asp:BoundField HeaderText="服务受理" DataField="TakeOver"/>
            <asp:BoundField HeaderText="服务处理" DataField="OverSer"/>
            <asp:BoundField HeaderText="完工结算" DataField="PayeeSer"/>
            <asp:BoundField HeaderText="审核关闭" DataField="ChkSer"/>
            <asp:BoundField HeaderText="服务回访" DataField="SeeSer"/>
            <asp:BoundField HeaderText="新建客户" DataField="Customer"/>
            <asp:BoundField HeaderText="服务合同" DataField="Contract"/>
            <asp:BoundField HeaderText="客户跟踪" DataField="CustomerTrack"/>
            <asp:BoundField HeaderText="耗材跟踪" DataField="ConsumablesTrack"/>
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" Value="ID,工号,姓名,所属,入库单,出库单,领退单,调拨申请,调拨审核,调拨发货,调拨签收,采购单,采购订单,销售单,销售订单,服务受理,服务处理,完工结算,审核关闭,服务回访,新建客户,服务合同,客户跟踪,耗材跟踪" />
    <asp:HiddenField ID="hfTbField" runat="server" Value="" />
    <asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div class="fbom">  
    <div id="fbon" class="fbon">
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
function ChkID(id)
{
    ClrID(id);
}
function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("员工工作汇总");
}
function ChkView()
{
    var id=$("hfRecID").value;
    if(id=="-1"||id=="")
    {
        window.alert("请选择一条记录后操作或直接双击记录查看明细！");
        return false;
    }
    var deptid=$("ddlBranch").value;
    var startdate=$("tbDateB").value;
    var enddate=$("tbDateE").value;
    parent.ShowDialog(900, 520, 'Office/TecDayWorkDe.aspx?id='+id+'&iflag=1'+'&startdate='+startdate+'&enddate='+enddate, '明细');
}
</script>
