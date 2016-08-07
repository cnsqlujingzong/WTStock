<%@ page language="C#"  CodeFile="stservicede.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stat_StServiceDe" theme="Themes" enableeventvalidation="false" %>
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
            <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">模糊查询</asp:ListItem>
                    <asp:ListItem Value="1">按服务单号查询</asp:ListItem>
                    <asp:ListItem Value="2">按服务类别查询</asp:ListItem>
                    <asp:ListItem Value="3">按受理部门查询</asp:ListItem>
                    <asp:ListItem Value="4">按处理部门查询</asp:ListItem>
                    <asp:ListItem Value="5">按受理方式查询</asp:ListItem>
                    <asp:ListItem Value="6">按服务级别查询</asp:ListItem>
                    <asp:ListItem Value="7">按受理人查询</asp:ListItem>
                    <asp:ListItem Value="8">按客户名称查询</asp:ListItem>
                    <asp:ListItem Value="9">按联系人查询</asp:ListItem>
                    <asp:ListItem Value="10">按客户电话查询</asp:ListItem>
                    <asp:ListItem Value="11">按客户地址查询</asp:ListItem>
                    <asp:ListItem Value="12">按机器型号查询</asp:ListItem>
                    <asp:ListItem Value="13">按机器品牌查询</asp:ListItem>
                    <asp:ListItem Value="14">按机器类别查询</asp:ListItem>
                    <asp:ListItem Value="15">按机器序列号查询</asp:ListItem>
                    <asp:ListItem Value="16">按维修技术员查询</asp:ListItem>
                    <asp:ListItem Value="17">按故障查询</asp:ListItem>
                    <asp:ListItem Value="23">按销售合同号查询</asp:ListItem>
                    <asp:ListItem Value="18">按保修情况查询</asp:ListItem>
                    <asp:ListItem Value="20">按送修厂商查询</asp:ListItem>
                    <asp:ListItem Value="21">按服务状态查询</asp:ListItem>
                    <asp:ListItem Value="19">按备注查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td>
            <td align="left">
                <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td style="padding:0px;"><input id="btnSchsH" type="button" value="高级查询" class="bsch" onclick="parent.ShowDialog(470,620, 'Services/SerSchCd.aspx', '高级查询');" /></td>
            <td>
                <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
            </td>
            </tr>
          </table>
        </div>
        <div class="ftoolright">
              <span style="display:none;">
                <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                <asp:Button ID="btnSchH" runat="server" Text="高级查询" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />
            </span>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="statf" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false" ShowFooter="true">
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
            <asp:BoundField HeaderText="所属部门" DataField="UsePersonDept" />
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
            <asp:BoundField HeaderText="毛利" DataField="Profit" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="实际收款" DataField="RealMoney" HtmlEncode="false" DataFormatString="{0:F2}"/>
            <asp:BoundField HeaderText="已收款" DataField="HaveAmount" HtmlEncode="false" DataFormatString="{0:F2}"  />
            <asp:BoundField HeaderText="未收款" DataField="NotChargeAmount" HtmlEncode="false" DataFormatString="{0:F2}"  />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    总记录：<asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
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
function ChkView()
{
    ChkMod(860,444, 'Services/SerView.aspx', '服务单');
}
function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("服务明细表");
}
</script>
