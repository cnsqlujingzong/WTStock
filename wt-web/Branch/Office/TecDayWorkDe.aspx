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
            <span id="tabs1" onclick="ChkTab('1');">����</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">���۵�</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">���۶���</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">���ⵥ</span>
            <span id="tabs_r4"></span>
            <span id="tabs_l5"></span>
            <span id="tabs5" onclick="ChkTab('5');">��ⵥ</span>
            <span id="tabs_r5"></span>
            <span id="tabs_l6"></span>
            <span id="tabs6" onclick="ChkTab('6');">���˵�</span>
            <span id="tabs_r6"></span>
            <span id="tabs_l7"></span>
            <span id="tabs7" onclick="ChkTab('7');">������</span>
            <span id="tabs_r7"></span>
            <span id="tabs_l8"></span>
            <span id="tabs8" onclick="ChkTab('8');">�ɹ���</span>
            <span id="tabs_r8"></span>
            <span id="tabs_l9"></span>
            <span id="tabs9" onclick="ChkTab('9');">�ɹ�����</span>
            <span id="tabs_r9"></span>
            <span id="tabs_l10"></span>
            <span id="tabs10" onclick="ChkTab('10');">�½��ͻ�</span>
            <span id="tabs_r10"></span>
            <span id="tabs_l11"></span>
            <span id="tabs11" onclick="ChkTab('11');">�����ͬ</span>
            <span id="tabs_r11"></span>
            <span id="tabs_l12"></span>
            <span id="tabs12" onclick="ChkTab('12');">�ͻ�����</span>
            <span id="tabs_r12"></span>
            <span id="tabs_l13"></span>
            <span id="tabs13" onclick="ChkTab('13');">�Ĳĸ���</span>
            <span id="tabs_r13"></span>
        </div>
        </div>
        <div id="info1" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="cndiv2" style="height:448px;">
        <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
                <asp:BoundField HeaderText="���" DataField="ID" />
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="��������" DataField="btype" />
                <asp:BoundField HeaderText="���񵥺�" DataField="BillID" />
                <asp:BoundField HeaderText="����״̬" DataField="curStatus" />
                <asp:BoundField HeaderText="�������" DataField="ServicesType" />
                <asp:BoundField HeaderText="������" DataField="Operator" />
                <asp:BoundField HeaderText="����ʱ��" DataField="Time_TakeOver" />
                <asp:BoundField HeaderText="����ʱ��" DataField="Speding" />
                <asp:BoundField HeaderText="����ʽ" DataField="TakeStyle" />
                <asp:BoundField HeaderText="����λ" DataField="TakeDept" />
                <asp:BoundField HeaderText="����λ" DataField="DisposalDept" />
                <asp:BoundField HeaderText="���񼶱�" DataField="_PRI" />
                <asp:BoundField HeaderText="����Ա" DataField="DisposalOper" /> 
                <asp:BoundField HeaderText="��ɹرղ�����" DataField="FinTec" /> 
                <asp:BoundField HeaderText="�ͻ���Դ" DataField="CustomerFrom" />
                <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
                <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
                <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
                <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
                <asp:BoundField HeaderText="�����ͺ�" DataField="ProductModel" />
                <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
                <asp:BoundField HeaderText="���" DataField="ProductClass" />
                <asp:BoundField HeaderText="���к�1" DataField="ProductSN1" />
                <asp:BoundField HeaderText="���к�2" DataField="ProductSN2" />
                <asp:BoundField HeaderText="����" DataField="Fault" />
                <asp:BoundField HeaderText="�����ʩ/���" DataField="TakeSteps" />
                <asp:BoundField HeaderText="������" DataField="QtyType" />
                <asp:BoundField HeaderText="�����ϸ" DataField="Deduct" />
                <asp:BoundField HeaderText="�������" DataField="Warranty" />
                <asp:BoundField HeaderText="ԤԼʱ��" DataField="SubscribeTime" />
                <asp:BoundField HeaderText="Ԥ����" DataField="SubscribePrice" />
                <asp:BoundField HeaderText="Ԥ�շ�" DataField="PreCharge" />
                <asp:BoundField HeaderText="����" DataField="bAgain" />
                <asp:BoundField HeaderText="����" DataField="bRepair" />
                <asp:BoundField HeaderText="�ط�" DataField="bCall" />
                <asp:BoundField HeaderText="ȡ��ԭ��" DataField="CancelReason" />
                <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lbTitle" runat="server" Text="�ܼ�¼��"></asp:Label><asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
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
            <asp:BoundField HeaderText="���" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="����״̬" DataField="Status" />
            <asp:BoundField HeaderText="�������" DataField="Type" />
            <asp:BoundField HeaderText="���ݱ��" DataField="BillID" />
            <asp:BoundField HeaderText="����" DataField="_Date" />
            <asp:BoundField HeaderText="ҵ��Ա" DataField="Operator" />
            <asp:BoundField HeaderText="����" DataField="Dept" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="_Name" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="��ַ" DataField="Adr" />
            <asp:BoundField HeaderText="�ͻ���" DataField="SndOperator" />
            <asp:BoundField HeaderText="�ֽ���" DataField="InCash" />
            <asp:BoundField HeaderText="�������" DataField="ChkDate" />
            <asp:BoundField HeaderText="�����" DataField="ChkOperator" />
            <asp:BoundField HeaderText="�Ա��" DataField="AutoNO" />
            <asp:BoundField HeaderText="���õ���" DataField="OperationID" />
            <asp:BoundField HeaderText="�Ƶ���" DataField="Person" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lbTitle2" runat="server" Text="�ܼ�¼��"></asp:Label><asp:Label ID="lbCount2" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField2" runat="server" />
    </div>
    </div>
    <div id="info3" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div3" style="height:448px;">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView2_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="���" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="����״̬" DataField="Status" />
            <asp:BoundField HeaderText="���ݱ��" DataField="BillID" />
            <asp:BoundField HeaderText="����" DataField="_Date" />
            <asp:BoundField HeaderText="ҵ��Ա" DataField="Operator" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="_Name" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="��ַ" DataField="Adr" />
            <asp:BoundField HeaderText="�ͻ���" DataField="SndOperator" />
            <asp:BoundField HeaderText="��ͬ���" DataField="ContractNO" />
            <asp:BoundField HeaderText="ִ��״̬" DataField="EndStatus" />
            <asp:BoundField HeaderText="�������" DataField="ChkDate" />
            <asp:BoundField HeaderText="�����" DataField="ChkOperator" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label1" runat="server" Text="�ܼ�¼��"></asp:Label><asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField3" runat="server" />
    </div>
    </div>
    <div id="info4" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div5" style="height:448px;">
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView3_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="���" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="����״̬" DataField="Status" />
            <asp:BoundField HeaderText="���ݱ��" DataField="BillID" />
            <asp:BoundField HeaderText="����" DataField="_Date" />
            <asp:BoundField HeaderText="�Ƶ���" DataField="Person" />
            <asp:BoundField HeaderText="������" DataField="Operator" />
            <asp:BoundField HeaderText="����" DataField="Dept" />
            <asp:BoundField HeaderText="����ԭ��" DataField="Reason" />
            <asp:BoundField HeaderText="ҵ����" DataField="OperationID" />
            <asp:BoundField HeaderText="�������" DataField="ChkDate" />
            <asp:BoundField HeaderText="�����" DataField="ChkOperator" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label3" runat="server" Text="�ܼ�¼��"></asp:Label><asp:Label ID="Label4" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField4" runat="server" />
    </div>
    </div>
    <div id="info5" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div7" style="height:448px;">
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView4_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="���" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="����״̬" DataField="Status" />
            <asp:BoundField HeaderText="���ݱ��" DataField="BillID" />
            <asp:BoundField HeaderText="����" DataField="_Date" />
            <asp:BoundField HeaderText="�Ƶ���" DataField="Person" />
            <asp:BoundField HeaderText="������" DataField="Operator" />
            <asp:BoundField HeaderText="����" DataField="Dept" />
            <asp:BoundField HeaderText="���ԭ��" DataField="Reason" />
            <asp:BoundField HeaderText="ҵ����" DataField="OperationID" />
            <asp:BoundField HeaderText="�������" DataField="ChkDate" />
            <asp:BoundField HeaderText="�����" DataField="ChkOperator" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label5" runat="server" Text="�ܼ�¼��"></asp:Label><asp:Label ID="Label6" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField5" runat="server" />
    </div>
    </div>
    <div id="info6" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div9" style="height:448px;">
        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView5_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="���" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="����״̬" DataField="Status" />
            <asp:BoundField HeaderText="��������" DataField="Type" />
            <asp:BoundField HeaderText="���ݱ��" DataField="BillID" />
            <asp:BoundField HeaderText="����" DataField="_Date" />
            <asp:BoundField HeaderText="�Ƶ���" DataField="Person" />
            <asp:BoundField HeaderText="������" DataField="AppOperator" />
            <asp:BoundField HeaderText="����" DataField="Dept" />
            <asp:BoundField HeaderText="�������" DataField="ChkDate" />
            <asp:BoundField HeaderText="�����" DataField="ChkOperator" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label7" runat="server" Text="�ܼ�¼��"></asp:Label><asp:Label ID="Label8" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField6" runat="server" />
    </div>
    </div>
    <div id="info7" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div11" style="height:448px;">
        <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView6_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="���" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="����״̬" DataField="curStatus" />
            <asp:BoundField HeaderText="���ݱ��" DataField="BillID" />
            <asp:BoundField HeaderText="����" DataField="_Date" />
            <asp:BoundField HeaderText="������" DataField="Person" />
            <asp:BoundField HeaderText="��������" DataField="FromDept" />
            <asp:BoundField HeaderText="��������" DataField="ToDept" />
            <asp:BoundField HeaderText="�������" DataField="ChkDate" />
            <asp:BoundField HeaderText="�����" DataField="ChkOperator" />
            <asp:BoundField HeaderText="��������" DataField="SndDate" />
            <asp:BoundField HeaderText="������" DataField="SndOper" />
            <asp:BoundField HeaderText="ǩ������" DataField="SignedDate" />
            <asp:BoundField HeaderText="ǩ����" DataField="SignedOper" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label9" runat="server" Text="�ܼ�¼��"></asp:Label><asp:Label ID="Label10" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField7" runat="server" />
    </div>
    </div>
    <div id="info8" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div13" style="height:448px;">
        <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView7_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="���" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="����״̬" DataField="Status" />
            <asp:BoundField HeaderText="�������" DataField="Type" />
            <asp:BoundField HeaderText="���ݱ��" DataField="BillID" />
            <asp:BoundField HeaderText="����" DataField="_Date" />
            <asp:BoundField HeaderText="ҵ��Ա" DataField="Operator" />
            <asp:BoundField HeaderText="�ֿ�" DataField="StockName" />
            <asp:BoundField HeaderText="��Ӧ��" DataField="Provider" />
            <asp:BoundField HeaderText="�ֽ���" DataField="InCash" />
            <asp:BoundField HeaderText="�������" DataField="ChkDate" />
            <asp:BoundField HeaderText="�����" DataField="ChkOperator" />
            <asp:BoundField HeaderText="���õ���" DataField="OperationID" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label11" runat="server" Text="�ܼ�¼��"></asp:Label><asp:Label ID="Label12" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField8" runat="server" />
    </div>
    </div>
    <div id="info9" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div15" style="height:448px;">
        <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView8_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="���" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="״̬" DataField="Status" />
            <asp:BoundField HeaderText="���ݱ��" DataField="BillID" />
            <asp:BoundField HeaderText="����" DataField="_Date" />
            <asp:BoundField HeaderText="ҵ��Ա" DataField="Operator" />
            <asp:BoundField HeaderText="���ֿ�" DataField="StockName" />
            <asp:BoundField HeaderText="��Ӧ��" DataField="Provider" />
            <asp:BoundField HeaderText="�������" DataField="ChkDate" />
            <asp:BoundField HeaderText="�����" DataField="ChkOperator" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label13" runat="server" Text="�ܼ�¼��"></asp:Label><asp:Label ID="Label14" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField9" runat="server" />
    </div>
    </div>
    <div id="info10" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div17" style="height:448px;">
        <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView9_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="���" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="ͣ��" DataField="bStop" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="ClassName" />
            <asp:BoundField HeaderText="�ͻ����" DataField="CustomerNO" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="_Name" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="�ֻ�����" DataField="Tel2" />
            <asp:BoundField HeaderText="��ַ" DataField="Adr" />
            <asp:BoundField HeaderText="�ʱ�" DataField="Zip" />
            <asp:BoundField HeaderText="����" DataField="Fax" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="QQ/MSN" DataField="QQ" />
            <asp:BoundField HeaderText="�ʻ�" DataField="Account" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="Area" />
            <asp:BoundField HeaderText="�ͻ���Դ" DataField="CusFrom" />
            <asp:BoundField HeaderText="ҵ��Ա" DataField="Seller" />
            <asp:BoundField HeaderText="��Ա����" DataField="Member" />
            <asp:BoundField HeaderText="�ͻ�״̬" DataField="Status" />
            <asp:BoundField HeaderText="������" DataField="TrackOperator" />
            <asp:BoundField HeaderText="�Ǽǲ���" DataField="DeptID" />
            <asp:BoundField HeaderText="�Ǽ�ʱ��" DataField="_Date" />
            <asp:BoundField HeaderText="�Զ���1" DataField="userdef1" />
            <asp:BoundField HeaderText="�Զ���2" DataField="userdef2" />
            <asp:BoundField HeaderText="�Զ���3" DataField="userdef3" />
            <asp:BoundField HeaderText="�Զ���4" DataField="userdef4" />
            <asp:BoundField HeaderText="�Զ���5" DataField="userdef5" />
            <asp:BoundField HeaderText="�Զ���6" DataField="userdef6" />
            <asp:BoundField HeaderText="�طñ�־" DataField="bCall" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label15" runat="server" Text="�ܼ�¼��"></asp:Label><asp:Label ID="Label16" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField10" runat="server" />
    </div>
    </div>
    <div id="info11" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div18" style="height:448px;">
        <asp:GridView ID="GridView10" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView10_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="���" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="״̬" DataField="Status" />
            <asp:BoundField HeaderText="��ͬ���" DataField="ContractType" />
            <asp:BoundField HeaderText="ǩԼ����" DataField="_Date" />
            <asp:BoundField HeaderText="��ͬ���" DataField="ContractNO" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
             <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="��ַ" DataField="Adr" />
            <asp:BoundField HeaderText="��ʼ����" DataField="StartDate" />
            <asp:BoundField HeaderText="��ֹ����" DataField="EndDate" />
            <asp:BoundField HeaderText="���" DataField="dAmount" />
            <asp:BoundField HeaderText="�ֽ���" DataField="dInCash" />
            <asp:BoundField HeaderText="����" DataField="Accessory" />
            <asp:BoundField HeaderText="��ͬ����" DataField="Summary" />
            <asp:BoundField HeaderText="ҵ��Ա" DataField="Seller" />
            <asp:BoundField HeaderText="������" DataField="Operator" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label17" runat="server" Text="�ܼ�¼��"></asp:Label><asp:Label ID="Label18" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField11" runat="server" />
    </div>
    </div>
    <div id="info12" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div19" style="height:448px;">
        <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView11_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="���" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
            <asp:BoundField HeaderText="��������" DataField="_Date" />
            <asp:BoundField HeaderText="������" DataField="Operator" />
            <asp:BoundField HeaderText="��������" DataField="Content" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="���ٷ�ʽ" DataField="TrackStyle" />
            <asp:BoundField HeaderText="�������" DataField="TrackType" />
            <asp:BoundField HeaderText="���ٽ��" DataField="Result" />
            <asp:BoundField HeaderText="�´θ�������" DataField="NextTrack" />
            <asp:BoundField HeaderText="���ٸ���" DataField="bTrack" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label19" runat="server" Text="�ܼ�¼��"></asp:Label><asp:Label ID="Label20" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField12" runat="server" />
    </div>
    </div>
    <div id="info13" style="height:450px;background:#ECE9D8;">
            <div class="cndiv2" id="Div20" style="height:448px;">
        <asp:GridView ID="GridView12" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView12_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="���" DataField="ID" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="Ԥ������" DataField="WarringDate" />
            <asp:BoundField HeaderText="ҵ�����" DataField="Type" />
            <asp:BoundField HeaderText="ҵ�񵥺�" DataField="BillID" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="����������" DataField="QtyTypeName" />
            <asp:BoundField HeaderText="��������" DataField="_Date" />
            <asp:BoundField HeaderText="������" DataField="Operator" />
            <asp:BoundField HeaderText="������" DataField="TrackOperator" />
            <asp:BoundField HeaderText="��������" DataField="TrackDate" />
            <asp:BoundField HeaderText="���ٽ��" DataField="Result" />
            <asp:BoundField HeaderText="�ٴθ���" DataField="bAgain" />
            <asp:BoundField HeaderText="�����ɹ�" DataField="bAllot" />
            <asp:BoundField HeaderText="�ɹ�����" DataField="OperationID" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label21" runat="server" Text="�ܼ�¼��"></asp:Label><asp:Label ID="Label22" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="HiddenField13" runat="server" />
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnExout" runat="server" Text="����" class="bt1" OnClick="btnExout_Click" />
                <input id="btnDetail" type="button" value="��ϸ" class="bt1" onclick="ShowDetail();" />
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
        window.alert("��ѡ��һ����ϸ�������ֱ��˫����¼�鿴��ϸ��");
        return false;
    }
    switch(index)
    {
        case 1:parent.ShowDialog1(860,444,'Services/SerView.aspx?id='+id+'&iflag=1', '����');break;
        case 2:parent.ShowDialog1(800, 480,'Sell/SellMod.aspx?id='+id+'&f=1', '���۵�');break;
        case 3:parent.ShowDialog1(800, 480,'Sell/SellPlanMod.aspx?id='+id+'&f=1', '���۶���');break;
        case 4:parent.ShowDialog1(800, 520,'Stock/StockOutMod.aspx?id='+id+'&f=1', '���ⵥ');break;
        case 5:parent.ShowDialog1(800, 520, 'Stock/StockINMod.aspx?id='+id+'&f=1', '��ⵥ');break;
        case 6:parent.ShowDialog1(800, 480,'Stock/BroughtBackMod.aspx?id='+id+'&f=1', '���˵�');break;
        case 7:parent.ShowDialog1(800, 480,'Stock/AllocateMod.aspx?id='+id+'&f=1', '������');break;
        case 8:parent.ShowDialog1(800, 480,'Purchase/PurchaseMod.aspx?id='+id+'&f=1', '�ɹ���');break;
        case 9:parent.ShowDialog1(800, 480,'Purchase/PurPlanMod.aspx?id='+id+'&f=1', '�ɹ�����');break;
        case 10:parent.ShowDialog1(600, 450,'Customer/CusMod.aspx?id='+id+'&f=1', '�޸Ŀͻ�');break;
        case 11:parent.ShowDialog1(820, 510,'Customer/DevContMod.aspx?id='+id+'&f=1', '�޸ķ����ͬ');break;
        case 12:parent.ShowDialog1(470, 290,'Customer/TrackMod.aspx?id='+id+'&f=1', '�޸ĸ���');break;
        default:break;
    }
}
</script>
