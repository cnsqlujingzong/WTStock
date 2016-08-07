<%@ page language="C#"  CodeFile="maintenancecontract.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_MaintenanceContract" theme="Themes" enableEventValidation="false" %>
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
<body onload="Chkset();" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="ftool">
        <div class="ftoolleft">
        <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
            <asp:Button ID="btnFsh" runat="server" Text="刷新" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnFsh_Click"/>
            <input id="btnNewCont" type="button" value="新建" class="bt1" onclick="NewCont();" />
           <input id="btnModCont" type="button" value="修改" class="bt1" onclick="ModCont();" />
           <asp:Button ID="btnDelCont" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel('服务合同')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelCont_Click" />
           <input id="btnCancel" runat="server" type="button" value="终止" class="bt1" onclick="ChkCancel();" />
            <span style="display:none;">
                <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                <asp:Button ID="btnSchH" runat="server" Text="高级查询" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />
                <asp:Button ID="btnShow" runat="server" Text="明细" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="False" />
            </span>
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                <input id="btnPrint" runat="server" type="button" value="打印" class="iprint" onclick="ChkPrint('HT');" />
                </td>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">模糊查询</asp:ListItem>
                    <asp:ListItem Value="1">按签约日期查询</asp:ListItem>
                    <asp:ListItem Value="2">按合同编号查询</asp:ListItem>
                    <asp:ListItem Value="3">按起始日期查询</asp:ListItem>
                    <asp:ListItem Value="4">按终止日期查询</asp:ListItem>
                    <asp:ListItem Value="5">按合同条款查询</asp:ListItem>
                    <asp:ListItem Value="6">按客户名称查询</asp:ListItem>
                    <asp:ListItem Value="7">按联系人查询</asp:ListItem>
                    <asp:ListItem Value="8">按联系电话查询</asp:ListItem>
                    <asp:ListItem Value="9">按地址查询</asp:ListItem>
                    <asp:ListItem Value="10">按金额查询</asp:ListItem>
                    <asp:ListItem Value="11">按业务员查询</asp:ListItem>
                    <asp:ListItem Value="12">按经办人查询</asp:ListItem>
                    <asp:ListItem Value="13">按备注查询</asp:ListItem>
                    <asp:ListItem Value="14">按客户区域查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server"  onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td>
            <td align="left">
            <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td style="padding:0px;"><input id="btnSchsH" type="button" value="高级查询" class="bsch" onclick="parent.ShowDialog(470,284, 'Customer/Mtnsconcd.aspx', '高级查询');" /></td>
            </tr>
            </table>   
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="CustomerID" DataField="CustomerID" />
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
            <asp:BoundField HeaderText="终止原因" DataField="termRemark" />
        </Columns>
    </asp:GridView>
    <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="当页显示数"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCountText" runat="server" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCount" runat="server" ToolTip="总记录数"></asp:Label></td>
        </tr>
    </table>
    
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfCustomerID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
    <asp:HiddenField ID="hfDeviceID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    <asp:HiddenField ID="hfcbID" runat="server" />
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    <asp:HiddenField ID="hfPurArea" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnDelCont" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut" style="overflow:hidden;">
        <div class="ftool2">
        <div id="mytabs" style="padding-left:2px;">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">机器信息</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">客户信息</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">服务单</span>
            <span id="tabs_r3"></span>
        </div>
        </div>
       
        <div id="info1" style="height:205px;background:#ECE9D8;">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
             <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView2_RowDataBound"  EnableViewState="false" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="机器品牌" DataField="ProductBrand" />
                    <asp:BoundField HeaderText="类别" DataField="ProductClass" />
                    <asp:BoundField HeaderText="型号" DataField="ProductModel" />
                    <asp:BoundField HeaderText="序列号" DataField="ProductSN1" />
                    <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
                    <asp:BoundField HeaderText="服务级别" DataField="ServiceLevel" />
                    <asp:BoundField HeaderText="免维修费" DataField="bRepair" />
                    <asp:BoundField HeaderText="免耗材费" DataField="bConsumables" />
                    <asp:BoundField HeaderText="免备件费" DataField="bMaterial" />
                    <asp:BoundField HeaderText="备注"  DataField="Remark"/>
                </Columns>
            </asp:GridView>
             </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            </Triggers>       
        </asp:UpdatePanel>
        </div>
        <div id="info2" style="height:205px;background:#ECE9D8;">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td>客户类别：</td>
                <td style="padding-left:0px;">
                    <input type="text" id="tbCusClass" runat="server" class="pinb" readonly="readonly" />
                 </td>
                 <td align="right">联系人：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbCusLinkMan" runat="server" CssClass="pinb"></asp:TextBox></td>
                    <td>联系电话：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbCusTel" runat="server" CssClass="pinb"></asp:TextBox></td>
            </tr>
                <tr>
                    <td align="right">手机号码：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbCusTel2" runat="server" CssClass="pinb"></asp:TextBox></td>
                    <td align="right">传真：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbCusFax" runat="server" CssClass="pinb"></asp:TextBox></td>
                    <td align="right">邮编：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbCusZip" runat="server" CssClass="pinb"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">Email：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbEmail" runat="server" CssClass="pinb"></asp:TextBox>
                    </td>
                    <td align="right">客户区域：</td>
                    <td style="padding-left:0px;">
                    <asp:TextBox ID="tbArea" runat="server" CssClass="pinb"></asp:TextBox>
                    </td>
                    <td align="right">地图坐标：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbCoordinates" runat="server" CssClass="pinb"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">客户来源：</td>
                    <td style="padding-left:0px;">
                    <asp:TextBox ID="tbFrom" runat="server" CssClass="pinb"></asp:TextBox>
                    </td>
                    <td align="right">业务员：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbSeller" runat="server" CssClass="pinb"></asp:TextBox>
                    </td>
                    <td align="right">会员级别：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbMember" runat="server" CssClass="pinb"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">帐户：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbAccount" runat="server" CssClass="pinb"></asp:TextBox></td>
                    <td align="right">地址：</td>
                    <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbCusAdr" runat="server" CssClass="pinb" Width="341"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">备注：</td>
                    <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pinb" Width="341"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left:0px;">
                         <asp:CheckBox ID="cbStop" runat="server" /> <span class="sysred">停用</span>
                         <asp:CheckBox ID="cbCall" runat="server" /> 回访
                    </td>
                </tr>
            </table>
            </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
        </div>
         <div id="info3" style="height:205px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
           <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
            <tr>
            <td>
               <input id="btnSerV" type="button" value="查看" class="bt1" onclick="SerV();" />
               </td>
            <td align="right" style="padding-right:30px;">
                <asp:Button ID="btnExcelSer" runat="server" Text="导出" CssClass="bexcel" OnClick="btnExcelSer_Click" />
            </td>
            </tr>
           </table>
        </div>
        <div class="cndiv2" id="ddd" style="height:175px;">
           <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
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
             <asp:HiddenField ID="hfSql2" runat="server" />
             <asp:HiddenField ID="hfTbTitle2" runat="server" />
            <asp:HiddenField ID="hfTbField2" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            </Triggers>       
            </asp:UpdatePanel>
        </div>
        </div>
    </div>
    
    <div class="fbom">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td><div id="fbon" class="fbon"></div></td>
                <td>
                    <span class="sred">将执行</span>
                    <span class="sgreen">正执行</span>
                    <span class="sblue">已过期</span>
                    <span class="sgay">已终止</span>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
var tabnum=4;
function ChkID(id,customerid)
{
    ClrID(id);
    $("hfCustomerID").value=customerid;
    $("btnShow").click();
}
function ChkIDd(id)
{
    ClrID(id);
    $("btnShow").click();
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
        parent.ShowDialog(860,444, 'Services/SerView.aspx?id='+id, '服务单');
    }
}

function ChkCancel()
{
    id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条合同后操作！");
        return;
    }
    parent.ShowDialog(460, 95, 'Customer/MaitenTerminate.aspx?id='+id, '终止合同');
}
function NewCont()
{
    parent.ShowDialog(820, 510, 'Customer/DevContAdd.aspx', '新建服务合同')
}

function ModCont()
{
    var id=document.getElementById("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条记录后操作！");
    }
    else
    {
        parent.ShowDialog(820, 510, 'Customer/DevContMod.aspx?id='+id, '修改服务合同');
    }
}
function Chkset()
{
    Chkwh12();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("服务合同");
}
</script>
