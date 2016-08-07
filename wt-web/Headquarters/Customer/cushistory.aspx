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
            <span id="tabs1" onclick="ChkTab('1');">机器档案</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">服务业务</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">销售业务</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');"> 租赁/全保</span>
            <span id="tabs_r4"></span>
        </div>
        </div>
        <div id="info1" style="height:473px;background:#ECE9D8;">
            <div class="cndiv2" id="cndiv2" style="height:471px;">
                <asp:GridView ID="gvtrouble" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvtrouble_RowDataBound" EnableViewState="false">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
                        <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                        <asp:BoundField HeaderText="所属部门" DataField="CusDept" />
                        <asp:BoundField HeaderText="联系电话" DataField="Tel" />
                        <asp:BoundField HeaderText="手机号码" DataField="Tel2" />
                        <asp:BoundField HeaderText="传真" DataField="Fax" />
                        <asp:BoundField HeaderText="邮编" DataField="Zip" />
                        <asp:BoundField HeaderText="地址" DataField="Adr" />
                        <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
                        <asp:BoundField HeaderText="类别" DataField="ProductClass" />
                        <asp:BoundField HeaderText="型号" DataField="ProductModel" />
                        <asp:BoundField HeaderText="序列号1" DataField="ProductSN1" />
                        <asp:BoundField HeaderText="序列号2" DataField="ProductSN2" />
                        <asp:BoundField HeaderText="外观" DataField="ProductAspect" />
                        <asp:BoundField HeaderText="产权" DataField="Property" />
                        <asp:BoundField HeaderText="购买时间" DataField="BuyDate" />
                        <asp:BoundField HeaderText="购买价格" DataField="BuyPrice" />
                        <asp:BoundField HeaderText="经销商" DataField="BuyFrom" />
                        <asp:BoundField HeaderText="购买发票" DataField="BuyInvoice" />
                        <asp:BoundField HeaderText="安装日期" DataField="InstallDate" />
                        <asp:BoundField HeaderText="保修期" DataField="MaintenancePeriod" />
                        <asp:BoundField HeaderText="保修情况" DataField="Warranty" />
                        <asp:BoundField HeaderText="厂家保修开始" DataField="WarrantyStart" />
                        <asp:BoundField HeaderText="厂家保修截至" DataField="WarrantyEnd" />
                        <asp:BoundField HeaderText="维修次数" DataField="RepairTimes" />
                        <asp:BoundField HeaderText="最近维修时间" DataField="Repairlately" />
                        <asp:BoundField HeaderText="维修保修截至" DataField="RepairWarrantyEnd" />
                        <asp:BoundField HeaderText="合同保修开始" DataField="ContractWarrantyStart" />
                        <asp:BoundField HeaderText="合同保修截至" DataField="ContractWarrantyEnd" />
                        <asp:BoundField HeaderText="维修合同编号" DataField="ContractNO" />
                        <asp:BoundField HeaderText="自定义1" DataField="userdef1" />
                        <asp:BoundField HeaderText="自定义2" DataField="userdef2" />
                        <asp:BoundField HeaderText="自定义3" DataField="userdef3" />
                        <asp:BoundField HeaderText="自定义4" DataField="userdef4" />
                        <asp:BoundField HeaderText="自定义5" DataField="userdef5" />
                        <asp:BoundField HeaderText="备注" DataField="Remark" />
                    </Columns>
                </asp:GridView>

                <table cellpadding="0" cellspacing="0" class="pages">
                    <tr>
                        <td><webdiyer:aspnetpager id="jsPagerd" runat="server" onpagechanged="jsPagerd_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
                        <td style="padding-left:8px;"><asp:Label ID="lbPaged" runat="server" ToolTip="当页显示数"></asp:Label></td>
                        <td style="padding-left:8px;"><asp:Label ID="lbCountTextd" runat="server" Visible="false" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCountd" runat="server" ToolTip="总记录数"></asp:Label></td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="info2" style="height:473px;background:#ECE9D8;">
            <div class="cndiv2" id="Div1" style="height:471px;">
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView3_RowDataBound" EnableViewState="false">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="服务单号" DataField="BillID" />
                        <asp:BoundField HeaderText="服务状态" DataField="curStatus" />
                        <asp:BoundField HeaderText="服务类别" DataField="ServicesType" />
                        <asp:BoundField HeaderText="受理人" DataField="Operator" />
                        <asp:BoundField HeaderText="受理时间" DataField="Time_TakeOver" />
                        <asp:BoundField HeaderText="处理时间" DataField="Speding" />
                        <asp:BoundField HeaderText="受理方式" DataField="TakeStyle" />
                        <asp:BoundField HeaderText="受理单位" DataField="TakeDept" />
                        <asp:BoundField HeaderText="服务级别" DataField="_PRI" />
                        <asp:BoundField HeaderText="技术员" DataField="DisposalOper" />  
                        <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
                        <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                        <asp:BoundField HeaderText="联系电话" DataField="Tel" />
                        <asp:BoundField HeaderText="机器型号" DataField="ProductModel" />
                        <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
                        <asp:BoundField HeaderText="类别" DataField="ProductClass" />
                        <asp:BoundField HeaderText="序列号1" DataField="ProductSN1" />
                        <asp:BoundField HeaderText="序列号2" DataField="ProductSN2" />
                        <asp:BoundField HeaderText="故障" DataField="Fault" />
                        <asp:BoundField HeaderText="处理措施/结果" DataField="TakeSteps" />
                        <asp:BoundField HeaderText="计数器" DataField="QtyType" />
                        <asp:BoundField HeaderText="保修情况" DataField="Warranty" />
                        <asp:BoundField HeaderText="预约时间" DataField="SubscribeTime" />
                        <asp:BoundField HeaderText="预报价" DataField="SubscribePrice" />
                        <asp:BoundField HeaderText="预收费" DataField="PreCharge" />
                        <asp:BoundField HeaderText="返修" DataField="bRepair" />
                        <asp:BoundField HeaderText="备注" DataField="Remark" />
                    </Columns>
                </asp:GridView>

                <table cellpadding="0" cellspacing="0" class="pages">
                    <tr>
                        <td><webdiyer:aspnetpager id="jsPagerb" runat="server" onpagechanged="jsPagerb_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
                        <td style="padding-left:8px;"><asp:Label ID="lbPageb" runat="server" ToolTip="当页显示数"></asp:Label></td>
                        <td style="padding-left:8px;"><asp:Label ID="lbCountTextb" runat="server" Visible="false" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCountb" runat="server" ToolTip="总记录数"></asp:Label></td>
                    </tr>
                </table>
            </div>
        </div>
        
        <div id="info3" style="height:473px;background:#ECE9D8;">
            <div class="cndiv2" id="Div2" style="height:471px;">
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView4_RowDataBound" EnableViewState="false">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="单据状态" DataField="Status" />
                        <asp:BoundField HeaderText="单据类别" DataField="Type" />
                        <asp:BoundField HeaderText="单据编号" DataField="BillID" />
                        <asp:BoundField HeaderText="日期" DataField="_Date" />
                        <asp:BoundField HeaderText="业务员" DataField="Operator" />
                        <asp:BoundField HeaderText="客户名称" DataField="_Name" />
                        <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                        <asp:BoundField HeaderText="联系电话" DataField="Tel" />
                        <asp:BoundField HeaderText="地址" DataField="Adr" />
                        <asp:BoundField HeaderText="送货人" DataField="SndOperator" />
                        <asp:BoundField HeaderText="现结金额" DataField="InCash" />
                        <asp:BoundField HeaderText="审核日期" DataField="ChkDate" />
                        <asp:BoundField HeaderText="审核人" DataField="ChkOperator" />
                        <asp:BoundField HeaderText="自编号" DataField="AutoNO" />
                        <asp:BoundField HeaderText="引用单号" DataField="OperationID" />
                        <asp:BoundField HeaderText="制单人" DataField="Person" />
                        <asp:BoundField HeaderText="备注" DataField="Remark" />
                    </Columns>
                </asp:GridView>

                <table cellpadding="0" cellspacing="0" class="pages">
                    <tr>
                        <td><webdiyer:aspnetpager id="jsPagers" runat="server" onpagechanged="jsPagers_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
                        <td style="padding-left:8px;"><asp:Label ID="lbPages" runat="server" ToolTip="当页显示数"></asp:Label></td>
                        <td style="padding-left:8px;"><asp:Label ID="lbCountTexts" runat="server" Visible="false" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCounts" runat="server" ToolTip="总记录数"></asp:Label></td>
                    </tr>
                </table>
            </div>
        </div>
        
        <div id="info4" style="height:473px;background:#ECE9D8;">
            <div class="cndiv2" id="Div4" style="height:471px;">
                <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView5_RowDataBound" EnableViewState="false">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="业务类别" DataField="Type" />
                            <asp:BoundField HeaderText="业务状态" DataField="curStatus" />
                            <asp:BoundField HeaderText="业务编号" DataField="BillID" />
                            <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
                            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                             <asp:BoundField HeaderText="联系电话" DataField="Tel" />
                            <asp:BoundField HeaderText="地址" DataField="Adr" />
                            <asp:BoundField HeaderText="基础月租" DataField="Rent" />
                            <asp:BoundField HeaderText="起始日期" DataField="StartDate" />
                            <asp:BoundField HeaderText="终止日期" DataField="EndDate" />
                            <asp:BoundField HeaderText="结算周期" DataField="ChargeCycle" />
                            <asp:BoundField HeaderText="合同编号" DataField="ContractNO" />
                            <asp:BoundField HeaderText="押金" DataField="Deposit" />
                            <asp:BoundField HeaderText="日期" DataField="_Date" />
                            <asp:BoundField HeaderText="制单人" DataField="Operator" />
                            <asp:BoundField HeaderText="业务员" DataField="Seller" />
                            <asp:BoundField HeaderText="备注" DataField="Remark" />
                        </Columns>
                    </asp:GridView>

                    <table cellpadding="0" cellspacing="0" class="pages">
                        <tr>
                            <td><webdiyer:aspnetpager id="jsPagerle" runat="server" onpagechanged="jsPagerle_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbPagele" runat="server" ToolTip="当页显示数"></asp:Label></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbCountTextle" runat="server" Visible="false" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCountle" runat="server" ToolTip="总记录数"></asp:Label></td>
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
        alert("请选择一条机器档案后操作！");
    }
    else
    {
        parent.ShowDialog2(750, 430,'Customer/DeviceMod.aspx?id='+id+'&f=2', '修改机器档案');
    }
}

function SerV()
{
    var id=document.getElementById("hfRecID2").value.replace("b","");
    if(id=="-1")
    {
        alert("请选择一条服务单后操作！");
    }
    else
    {
        parent.ShowDialog2(860,444, 'Services/SerView.aspx?id='+id+'&iflag=2', '服务单');
    }
}

function SellV()
{
    var id=document.getElementById("hfRecID2").value.replace("s","");
    if(id=="-1")
    {
        alert("请选择一条销售单后操作！");
    }
    else
    {
        parent.ShowDialog2(800, 480,'Sell/SellMod.aspx?id='+id+'&f=2', '销售单');
    }
}

function LeaseV()
{
    var id=document.getElementById("hfRecID2").value.replace("le","");
    if(id=="-1")
    {
        alert("请选择一条业务单后操作！");
    }
    else
    {
        parent.ShowDialog2(800, 480,'Lease/LeaseMod.aspx?id='+id+'&f=2','业务单');
    }
}
function ShowTA(id)
{
    parent.ShowDialog2(470, 360,'Services/ShowTA.aspx?id='+id, '处理措施/结果');
}
</script>
