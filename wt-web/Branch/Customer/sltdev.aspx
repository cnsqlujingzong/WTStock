<%@ page language="C#"  CodeFile="sltdev.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_SltDev" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <div class="ftool">
        <div class="ftoolleft">
        <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">模糊查询</asp:ListItem>
                    <asp:ListItem Value="1">按机器编号查询</asp:ListItem>
                    <asp:ListItem Value="2">按客户名称查询</asp:ListItem>
                    <asp:ListItem Value="3">按联系人查询</asp:ListItem>
                    <asp:ListItem Value="4">按联系电话查询</asp:ListItem>
                    <asp:ListItem Value="5">按品牌查询</asp:ListItem>
                    <asp:ListItem Value="6">按类别查询</asp:ListItem>
                    <asp:ListItem Value="7">按型号查询</asp:ListItem>
                    <asp:ListItem Value="8">按序列号查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" />
                <input id="btnNew" runat="server" type="button" value="新建" class="bt1" onclick="parent.ShowDialog2(750, 430, '../Branch/Customer/DeviceAdd.aspx?f=2'+strtel, '新建机器档案');" />
                </td>
             </tr>
            </table>   
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                    <asp:Button ID="btnShow" runat="server" Text="显示" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="false"/>
                </span>
            </td>
            <td style="padding-right:80px;">
                <input id="btnAdd" type="button" value="确定" class="bt1" onclick="ChkSltList();"/>
            </td>
            </tr>
            </table>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="height:300px; width:800px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderTemplate>
                    <input id="cball" type="checkbox" class="cb1" onclick="allcb();" title="全选/取消全选"/>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
            <asp:BoundField HeaderText="客户名称" DataField="_Name" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
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
            <asp:BoundField HeaderText="维修次" DataField="RepairTimes" />
            <asp:BoundField HeaderText="最近维修时间" DataField="Repairlately" />
            <asp:BoundField HeaderText="维修保修截至" DataField="RepairWarrantyEnd" />
            <asp:BoundField HeaderText="合同保修开始" DataField="ContractWarrantyStart" />
            <asp:BoundField HeaderText="合同保修截至" DataField="ContractWarrantyEnd" />
            <asp:BoundField HeaderText="维修合同编号" DataField="ContractNO" />
            <asp:BoundField HeaderText="所属部门" DataField="CusDept" />
            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="手机号码" DataField="Tel2" />
            <asp:BoundField HeaderText="传真" DataField="Fax" />
            <asp:BoundField HeaderText="邮编" DataField="Zip" />
            <asp:BoundField HeaderText="地址" DataField="Adr" />
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
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="当页显示数"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="总记录数"></asp:Label></td>
        </tr>
    </table>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
        <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
        <asp:HiddenField ID="hfSql" runat="server" />
        <asp:HiddenField ID="hfClass" runat="server" />
        <asp:HiddenField ID="hfPurArea" runat="server" />
        <asp:HiddenField ID="hfreclist" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="cnbut" style=" height:160px;overflow:hidden;">
        <div class="ftool2">
        <div id="mytabs" style="padding-left:2px;">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">机器配置</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">附件列表</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">计数器</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">抄表记录</span>
            <span id="tabs_r4"></span>
            <span id="tabs_l5"></span>
            <span id="tabs5" onclick="ChkTab('5');">服务单</span>
            <span id="tabs_r5"></span>
            <span id="tabs_l6"></span>
            <span id="tabs6" onclick="ChkTab('6');">租赁/全保</span>
            <span id="tabs_r6"></span>
        </div>
        </div>
        <div id="info1" style="height:130px;background:#ECE9D8;">
        <div class="cndiv2" id="cndiv2" style="height:130px;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView2_RowDataBound" EnableViewState="false" Width="70%">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="名称" DataField="_Name" />
                    <asp:BoundField HeaderText="参数" DataField="Parameter" />
                    <asp:BoundField HeaderText="序列号" DataField="SN" />
                    <asp:BoundField HeaderText="保修期" DataField="MaintenancePeriod" />
                    <asp:BoundField HeaderText="购买日期" DataField="BuyDate" />
                    <asp:BoundField HeaderText="截止日期" DataField="MaintenanceEnd" />
                    <asp:BoundField HeaderText="备注" DataField="Remark" />
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info2" style="height:130px;background:#ECE9D8;">
        <div class="cndiv2" id="Div1" style="height:130px;">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView4_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="名称" DataField="_Name" />
                    <asp:BoundField HeaderText="摘要" DataField="Remark" />
                    <asp:BoundField HeaderText="附件" DataField="Path" />
                    <asp:BoundField HeaderText="创建日期" DataField="_Date" />
                    <asp:BoundField HeaderText="创建人" DataField="Operator" />
                </Columns>
            </asp:GridView>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info3" style="height:130px;background:#ECE9D8;">
        <div class="cndiv2" id="Div2" style="height:130px;">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView3_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="计数日期" DataField="_Date" />
                    <asp:BoundField HeaderText="计数人" DataField="Operator" />
                    <asp:BoundField HeaderText="类型" DataField="QtyType" />
                    <asp:BoundField HeaderText="计数" DataField="Qty" />
                    <asp:BoundField HeaderText="备注"  DataField="Remark"/>
                </Columns>
            </asp:GridView>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info4" style="height:130px;background:#ECE9D8;">
        <div class="cndiv2" id="Div3" style="height:130px;">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView5_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="读数日期" DataField="_Date" />
                    <asp:BoundField HeaderText="读数人" DataField="Operator" />
                    <asp:BoundField HeaderText="计数器类型" DataField="_Name" />
                    <asp:BoundField HeaderText="计数" DataField="Qty" />
                    <asp:BoundField HeaderText="损耗张数" DataField="Loss" />
                    <asp:BoundField HeaderText="备注"  DataField="WRemark"/>
                </Columns>
            </asp:GridView>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info5" style="height:130px;background:#ECE9D8;">
        <div class="cndiv2" id="Div4" style="height:130px;">
        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView6_RowDataBound" EnableViewState="false">
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
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info6" style="height:130px;background:#ECE9D8;">
        <div class="cndiv2" id="Div5" style="height:130px;">
        <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false">
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
         </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
    </div>
    <div class="clearfloat"></div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var isfocus=2;
var tabnum=7;
var strtel="";
var uri=location.href;
if(uri.indexOf("itel=1")>0)
    strtel="&itel=1";
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}

function ChkSltList()
{
    if(ChkSlt()==false)
     return;
    
    try{
    if("<%=Str_X %>"=="")
    {
        parent.<%=Str_Fid %>.$("hfDevID").value=$("hfRecID").value;
    }else
    {
        var list=document.getElementById("hfreclist").value;
        
        if(list=="")
            list=document.getElementById("hfRecID").value;
            
        if(list==""||list=="-1")
        {
            alert("操作失败！请选择后操作.");return false;
        }
        else
        {
            parent.<%=Str_Fid %>.$("hfDevID").value=list;
        }
    }
        parent.<%=Str_Fid %>.$("btnChkDev").click();
    }catch(e){}
    parent.CloseDialog1();
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
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
