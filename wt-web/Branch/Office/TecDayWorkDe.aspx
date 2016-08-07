<%@ page language="C#"  CodeFile="TecDayWorkDe.aspx.cs"     autoeventwireup="true" inherits="Branch_Office_TecDayWorkDe" theme="Themes" enableeventvalidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
    <div class="maincon">
    <div id="sa" style="width:886px;">
        <div class="ftool2">
        <div id="mytabs" style="padding-left:2px;">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">服务单</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">销售单</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">销售订单</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">出库单</span>
            <span id="tabs_r4"></span>
            <span id="tabs_l5"></span>
            <span id="tabs5" onclick="ChkTab('5');">入库单</span>
            <span id="tabs_r5"></span>
            <span id="tabs_l6"></span>
            <span id="tabs6" onclick="ChkTab('6');">领退单</span>
            <span id="tabs_r6"></span>
            <span id="tabs_l7"></span>
            <span id="tabs7" onclick="ChkTab('7');">调拨单</span>
            <span id="tabs_r7"></span>
            <span id="tabs_l8"></span>
            <span id="tabs8" onclick="ChkTab('8');">采购单</span>
            <span id="tabs_r8"></span>
            <span id="tabs_l9"></span>
            <span id="tabs9" onclick="ChkTab('9');">采购订单</span>
            <span id="tabs_r9"></span>
            <span id="tabs_l10"></span>
            <span id="tabs10" onclick="ChkTab('10');">新建客户</span>
            <span id="tabs_r10"></span>
            <span id="tabs_l11"></span>
            <span id="tabs11" onclick="ChkTab('11');">服务合同</span>
            <span id="tabs_r11"></span>
            <span id="tabs_l12"></span>
            <span id="tabs12" onclick="ChkTab('12');">客户跟踪</span>
            <span id="tabs_r12"></span>
            <span id="tabs_l13"></span>
            <span id="tabs13" onclick="ChkTab('13');">耗材跟踪</span>
            <span id="tabs_r13"></span>
        </div>
        </div>
        <div id="info1" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="cndiv2" style="height:448px;">
        <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
                <asp:BoundField HeaderText="序号" DataField="ID" />
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="操作步骤" DataField="btype" />
                <asp:BoundField HeaderText="服务单号" DataField="BillID" />
                <asp:BoundField HeaderText="服务状态" DataField="curStatus" />
                <asp:BoundField HeaderText="服务类别" DataField="ServicesType" />
                <asp:BoundField HeaderText="受理人" DataField="Operator" />
                <asp:BoundField HeaderText="受理时间" DataField="Time_TakeOver" />
                <asp:BoundField HeaderText="处理时间" DataField="Speding" />
                <asp:BoundField HeaderText="受理方式" DataField="TakeStyle" />
                <asp:BoundField HeaderText="受理单位" DataField="TakeDept" />
                <asp:BoundField HeaderText="处理单位" DataField="DisposalDept" />
                <asp:BoundField HeaderText="服务级别" DataField="_PRI" />
                <asp:BoundField HeaderText="技术员" DataField="DisposalOper" /> 
                <asp:BoundField HeaderText="完成关闭操作人" DataField="FinTec" /> 
                <asp:BoundField HeaderText="客户来源" DataField="CustomerFrom" />
                <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
                <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                <asp:BoundField HeaderText="联系电话" DataField="Tel" />
                <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
                <asp:BoundField HeaderText="机器型号" DataField="ProductModel" />
                <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
                <asp:BoundField HeaderText="类别" DataField="ProductClass" />
                <asp:BoundField HeaderText="序列号1" DataField="ProductSN1" />
                <asp:BoundField HeaderText="序列号2" DataField="ProductSN2" />
                <asp:BoundField HeaderText="故障" DataField="Fault" />
                <asp:BoundField HeaderText="处理措施/结果" DataField="TakeSteps" />
                <asp:BoundField HeaderText="计数器" DataField="QtyType" />
                <asp:BoundField HeaderText="提成明细" DataField="Deduct" />
                <asp:BoundField HeaderText="保修情况" DataField="Warranty" />
                <asp:BoundField HeaderText="预约时间" DataField="SubscribeTime" />
                <asp:BoundField HeaderText="预报价" DataField="SubscribePrice" />
                <asp:BoundField HeaderText="预收费" DataField="PreCharge" />
                <asp:BoundField HeaderText="再修" DataField="bAgain" />
                <asp:BoundField HeaderText="返修" DataField="bRepair" />
                <asp:BoundField HeaderText="回访" DataField="bCall" />
                <asp:BoundField HeaderText="取消原因" DataField="CancelReason" />
                <asp:BoundField HeaderText="备注" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lbTitle" runat="server" Text="总记录："></asp:Label><asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfBillID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfType" runat="server" />
        <asp:HiddenField ID="hfCount" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
    </div>
    </div>
    <div id="info2" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div1" style="height:448px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="序号" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="单据状态" DataField="Status" />
            <asp:BoundField HeaderText="单据类别" DataField="Type" />
            <asp:BoundField HeaderText="单据编号" DataField="BillID" />
            <asp:BoundField HeaderText="日期" DataField="_Date" />
            <asp:BoundField HeaderText="业务员" DataField="Operator" />
            <asp:BoundField HeaderText="所属" DataField="Dept" />
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
        <asp:Label ID="lbTitle2" runat="server" Text="总记录："></asp:Label><asp:Label ID="lbCount2" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField2" runat="server" />
    </div>
    </div>
    <div id="info3" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div3" style="height:448px;">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView2_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="序号" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="单据状态" DataField="Status" />
            <asp:BoundField HeaderText="单据编号" DataField="BillID" />
            <asp:BoundField HeaderText="日期" DataField="_Date" />
            <asp:BoundField HeaderText="业务员" DataField="Operator" />
            <asp:BoundField HeaderText="客户名称" DataField="_Name" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="地址" DataField="Adr" />
            <asp:BoundField HeaderText="送货人" DataField="SndOperator" />
            <asp:BoundField HeaderText="合同编号" DataField="ContractNO" />
            <asp:BoundField HeaderText="执行状态" DataField="EndStatus" />
            <asp:BoundField HeaderText="审核日期" DataField="ChkDate" />
            <asp:BoundField HeaderText="审核人" DataField="ChkOperator" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label1" runat="server" Text="总记录："></asp:Label><asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField3" runat="server" />
    </div>
    </div>
    <div id="info4" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div5" style="height:448px;">
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView3_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="序号" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="单据状态" DataField="Status" />
            <asp:BoundField HeaderText="单据编号" DataField="BillID" />
            <asp:BoundField HeaderText="日期" DataField="_Date" />
            <asp:BoundField HeaderText="制单人" DataField="Person" />
            <asp:BoundField HeaderText="经办人" DataField="Operator" />
            <asp:BoundField HeaderText="所属" DataField="Dept" />
            <asp:BoundField HeaderText="出库原因" DataField="Reason" />
            <asp:BoundField HeaderText="业务编号" DataField="OperationID" />
            <asp:BoundField HeaderText="审核日期" DataField="ChkDate" />
            <asp:BoundField HeaderText="审核人" DataField="ChkOperator" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label3" runat="server" Text="总记录："></asp:Label><asp:Label ID="Label4" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField4" runat="server" />
    </div>
    </div>
    <div id="info5" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div7" style="height:448px;">
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView4_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="序号" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="单据状态" DataField="Status" />
            <asp:BoundField HeaderText="单据编号" DataField="BillID" />
            <asp:BoundField HeaderText="日期" DataField="_Date" />
            <asp:BoundField HeaderText="制单人" DataField="Person" />
            <asp:BoundField HeaderText="经办人" DataField="Operator" />
            <asp:BoundField HeaderText="所属" DataField="Dept" />
            <asp:BoundField HeaderText="入库原因" DataField="Reason" />
            <asp:BoundField HeaderText="业务编号" DataField="OperationID" />
            <asp:BoundField HeaderText="审核日期" DataField="ChkDate" />
            <asp:BoundField HeaderText="审核人" DataField="ChkOperator" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label5" runat="server" Text="总记录："></asp:Label><asp:Label ID="Label6" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField5" runat="server" />
    </div>
    </div>
    <div id="info6" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div9" style="height:448px;">
        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView5_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="序号" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="单据状态" DataField="Status" />
            <asp:BoundField HeaderText="单据类型" DataField="Type" />
            <asp:BoundField HeaderText="单据编号" DataField="BillID" />
            <asp:BoundField HeaderText="日期" DataField="_Date" />
            <asp:BoundField HeaderText="制单人" DataField="Person" />
            <asp:BoundField HeaderText="领料人" DataField="AppOperator" />
            <asp:BoundField HeaderText="所属" DataField="Dept" />
            <asp:BoundField HeaderText="审核日期" DataField="ChkDate" />
            <asp:BoundField HeaderText="审核人" DataField="ChkOperator" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label7" runat="server" Text="总记录："></asp:Label><asp:Label ID="Label8" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField6" runat="server" />
    </div>
    </div>
    <div id="info7" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div11" style="height:448px;">
        <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView6_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="序号" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="单据状态" DataField="curStatus" />
            <asp:BoundField HeaderText="单据编号" DataField="BillID" />
            <asp:BoundField HeaderText="日期" DataField="_Date" />
            <asp:BoundField HeaderText="申请人" DataField="Person" />
            <asp:BoundField HeaderText="申请网点" DataField="FromDept" />
            <asp:BoundField HeaderText="受理网点" DataField="ToDept" />
            <asp:BoundField HeaderText="审核日期" DataField="ChkDate" />
            <asp:BoundField HeaderText="审核人" DataField="ChkOperator" />
            <asp:BoundField HeaderText="发货日期" DataField="SndDate" />
            <asp:BoundField HeaderText="发货人" DataField="SndOper" />
            <asp:BoundField HeaderText="签收日期" DataField="SignedDate" />
            <asp:BoundField HeaderText="签收人" DataField="SignedOper" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label9" runat="server" Text="总记录："></asp:Label><asp:Label ID="Label10" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField7" runat="server" />
    </div>
    </div>
    <div id="info8" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div13" style="height:448px;">
        <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView7_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="序号" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="单据状态" DataField="Status" />
            <asp:BoundField HeaderText="单据类别" DataField="Type" />
            <asp:BoundField HeaderText="单据编号" DataField="BillID" />
            <asp:BoundField HeaderText="日期" DataField="_Date" />
            <asp:BoundField HeaderText="业务员" DataField="Operator" />
            <asp:BoundField HeaderText="仓库" DataField="StockName" />
            <asp:BoundField HeaderText="供应商" DataField="Provider" />
            <asp:BoundField HeaderText="现结金额" DataField="InCash" />
            <asp:BoundField HeaderText="审核日期" DataField="ChkDate" />
            <asp:BoundField HeaderText="审核人" DataField="ChkOperator" />
            <asp:BoundField HeaderText="引用单号" DataField="OperationID" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label11" runat="server" Text="总记录："></asp:Label><asp:Label ID="Label12" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField8" runat="server" />
    </div>
    </div>
    <div id="info9" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div15" style="height:448px;">
        <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView8_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="序号" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="状态" DataField="Status" />
            <asp:BoundField HeaderText="单据编号" DataField="BillID" />
            <asp:BoundField HeaderText="日期" DataField="_Date" />
            <asp:BoundField HeaderText="业务员" DataField="Operator" />
            <asp:BoundField HeaderText="入库仓库" DataField="StockName" />
            <asp:BoundField HeaderText="供应商" DataField="Provider" />
            <asp:BoundField HeaderText="审核日期" DataField="ChkDate" />
            <asp:BoundField HeaderText="审核人" DataField="ChkOperator" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label13" runat="server" Text="总记录："></asp:Label><asp:Label ID="Label14" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField9" runat="server" />
    </div>
    </div>
    <div id="info10" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div17" style="height:448px;">
        <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView9_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="序号" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="停用" DataField="bStop" />
            <asp:BoundField HeaderText="客户分类" DataField="ClassName" />
            <asp:BoundField HeaderText="客户编号" DataField="CustomerNO" />
            <asp:BoundField HeaderText="客户名称" DataField="_Name" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="手机号码" DataField="Tel2" />
            <asp:BoundField HeaderText="地址" DataField="Adr" />
            <asp:BoundField HeaderText="邮编" DataField="Zip" />
            <asp:BoundField HeaderText="传真" DataField="Fax" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="QQ/MSN" DataField="QQ" />
            <asp:BoundField HeaderText="帐户" DataField="Account" />
            <asp:BoundField HeaderText="客户区域" DataField="Area" />
            <asp:BoundField HeaderText="客户来源" DataField="CusFrom" />
            <asp:BoundField HeaderText="业务员" DataField="Seller" />
            <asp:BoundField HeaderText="会员级别" DataField="Member" />
            <asp:BoundField HeaderText="客户状态" DataField="Status" />
            <asp:BoundField HeaderText="跟踪人" DataField="TrackOperator" />
            <asp:BoundField HeaderText="登记部门" DataField="DeptID" />
            <asp:BoundField HeaderText="登记时间" DataField="_Date" />
            <asp:BoundField HeaderText="自定义1" DataField="userdef1" />
            <asp:BoundField HeaderText="自定义2" DataField="userdef2" />
            <asp:BoundField HeaderText="自定义3" DataField="userdef3" />
            <asp:BoundField HeaderText="自定义4" DataField="userdef4" />
            <asp:BoundField HeaderText="自定义5" DataField="userdef5" />
            <asp:BoundField HeaderText="自定义6" DataField="userdef6" />
            <asp:BoundField HeaderText="回访标志" DataField="bCall" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label15" runat="server" Text="总记录："></asp:Label><asp:Label ID="Label16" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField10" runat="server" />
    </div>
    </div>
    <div id="info11" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div18" style="height:448px;">
        <asp:GridView ID="GridView10" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView10_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="序号" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="状态" DataField="Status" />
            <asp:BoundField HeaderText="合同类别" DataField="ContractType" />
            <asp:BoundField HeaderText="签约日期" DataField="_Date" />
            <asp:BoundField HeaderText="合同编号" DataField="ContractNO" />
            <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
             <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="地址" DataField="Adr" />
            <asp:BoundField HeaderText="起始日期" DataField="StartDate" />
            <asp:BoundField HeaderText="终止日期" DataField="EndDate" />
            <asp:BoundField HeaderText="金额" DataField="dAmount" />
            <asp:BoundField HeaderText="现结金额" DataField="dInCash" />
            <asp:BoundField HeaderText="附件" DataField="Accessory" />
            <asp:BoundField HeaderText="合同条款" DataField="Summary" />
            <asp:BoundField HeaderText="业务员" DataField="Seller" />
            <asp:BoundField HeaderText="经办人" DataField="Operator" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label17" runat="server" Text="总记录："></asp:Label><asp:Label ID="Label18" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField11" runat="server" />
    </div>
    </div>
    <div id="info12" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div19" style="height:448px;">
        <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView11_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="序号" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
            <asp:BoundField HeaderText="跟踪日期" DataField="_Date" />
            <asp:BoundField HeaderText="跟踪人" DataField="Operator" />
            <asp:BoundField HeaderText="跟踪内容" DataField="Content" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="跟踪方式" DataField="TrackStyle" />
            <asp:BoundField HeaderText="跟踪类别" DataField="TrackType" />
            <asp:BoundField HeaderText="跟踪结果" DataField="Result" />
            <asp:BoundField HeaderText="下次跟踪日期" DataField="NextTrack" />
            <asp:BoundField HeaderText="不再跟踪" DataField="bTrack" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label19" runat="server" Text="总记录："></asp:Label><asp:Label ID="Label20" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField12" runat="server" />
    </div>
    </div>
    <div id="info13" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div20" style="height:448px;">
        <asp:GridView ID="GridView12" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView12_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="序号" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="预警日期" DataField="WarringDate" />
            <asp:BoundField HeaderText="业务类别" DataField="Type" />
            <asp:BoundField HeaderText="业务单号" DataField="BillID" />
            <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="计数器类型" DataField="QtyTypeName" />
            <asp:BoundField HeaderText="创建日期" DataField="_Date" />
            <asp:BoundField HeaderText="操作人" DataField="Operator" />
            <asp:BoundField HeaderText="跟踪人" DataField="TrackOperator" />
            <asp:BoundField HeaderText="跟踪日期" DataField="TrackDate" />
            <asp:BoundField HeaderText="跟踪结果" DataField="Result" />
            <asp:BoundField HeaderText="再次跟踪" DataField="bAgain" />
            <asp:BoundField HeaderText="跟踪派工" DataField="bAllot" />
            <asp:BoundField HeaderText="派工单号" DataField="OperationID" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label21" runat="server" Text="总记录："></asp:Label><asp:Label ID="Label22" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField13" runat="server" />
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnExout" runat="server" Text="导出" class="bt1" OnClick="btnExout_Click" />
                <input id="btnDetail" type="button" value="明细" class="bt1" onclick="ShowDetail();" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var tabnum=14;
function ChkID(id,billid,type)
{
    ClrID(id);
    $("hfBillID").value=billid
    $("hfType").value=type;
}
function ShowDetail(index)
{
    var type=$("hfType").value;
    var id=$("hfBillID").value;
    if(id=="-1"||id=="")
    {
        window.alert("请选择一条明细后操作或直接双击记录查看明细！");
        return false;
    }
    switch(index)
    {
        case 1:parent.ShowDialog1(860,444,'Services/SerView.aspx?id='+id+'&iflag=1', '服务单');break;
        case 2:parent.ShowDialog1(800, 480,'Sell/SellMod.aspx?id='+id+'&f=1', '销售单');break;
        case 3:parent.ShowDialog1(800, 480,'Sell/SellPlanMod.aspx?id='+id+'&f=1', '销售订单');break;
        case 4:parent.ShowDialog1(800, 520,'Stock/StockOutMod.aspx?id='+id+'&f=1', '出库单');break;
        case 5:parent.ShowDialog1(800, 520, 'Stock/StockINMod.aspx?id='+id+'&f=1', '入库单');break;
        case 6:parent.ShowDialog1(800, 480,'Stock/BroughtBackMod.aspx?id='+id+'&f=1', '领退单');break;
        case 7:parent.ShowDialog1(800, 480,'Stock/AllocateMod.aspx?id='+id+'&f=1', '调拨单');break;
        case 8:parent.ShowDialog1(800, 480,'Purchase/PurchaseMod.aspx?id='+id+'&f=1', '采购单');break;
        case 9:parent.ShowDialog1(800, 480,'Purchase/PurPlanMod.aspx?id='+id+'&f=1', '采购订单');break;
        case 10:parent.ShowDialog1(600, 450,'Customer/CusMod.aspx?id='+id+'&f=1', '修改客户');break;
        case 11:parent.ShowDialog1(820, 510,'Customer/DevContMod.aspx?id='+id+'&f=1', '修改服务合同');break;
        case 12:parent.ShowDialog1(470, 290,'Customer/TrackMod.aspx?id='+id+'&f=1', '修改跟踪');break;
        default:break;
    }
}
</script>
