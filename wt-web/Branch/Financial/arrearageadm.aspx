<%@ page language="C#"  CodeFile="arrearageadm.aspx.cs"     autoeventwireup="true" inherits="Branch_Financial_ArrearageAdm" theme="Themes" enableEventValidation="false" %>
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
            <input id="btnAuto" type="button" value="自动对冲" class="bt1" onclick="AtuoHedge();" />
            <input id="btnManual" type="button" value="手工对冲" class="bt1" onclick="ManualHedge();" />
            <input id="btnCancel" type="button" value="注销坏账" class="bt1" onclick="CancelArr();" />
            <span style="display:none;">
                <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                <asp:Button ID="btnShow" runat="server" Text="显示" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="false"/>
            </span>
            </td>
            <td>
                <asp:CheckBox ID="cbAll" runat="server" Text="显示全部应收应付" OnCheckedChanged="cbAll_CheckedChanged" AutoPostBack="true" />
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                    <input id="btnPrint" runat="server" type="button" value="打印" class="iprint" onclick="ChkPrint('YSYF');" />
                </td>
                <td>
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
                </td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="CustomerNO">按客户编号查询</asp:ListItem>
                    <asp:ListItem Value="Type">按客户类别查询</asp:ListItem>
                    <asp:ListItem Value="_Name">按名称查询</asp:ListItem>
                    <asp:ListItem Value="LinkMan">按联系人查询</asp:ListItem>
                    <asp:ListItem Value="Tel">按联系电话查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td></tr>
            </table>   
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvbranch" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvbranch_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="客户类别" DataField="Type" />
            <asp:BoundField HeaderText="客户编号" DataField="CustomerNO" />
            <asp:BoundField HeaderText="名称" DataField="_Name" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan"/>
            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="应收款" DataField="Rec" />
            <asp:BoundField HeaderText="应付款" DataField="Due" />
            <asp:BoundField HeaderText="往来余额" DataField="Balance" />
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
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="cbAll" EventName="CheckedChanged" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>

    <div id="cnbut" style="overflow:hidden;">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1"></span>
                <span id="tabs1" onclick="ChkTab('1');">应收明细</span>
                <span id="tabs_r1"></span>
                <span id="tabs_l2"></span>
                <span id="tabs2" onclick="ChkTab('2');">应付明细</span>
                <span id="tabs_r2"></span>
            </div>
        </div>
        <div id="info1" style="height:163px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
        <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
            <tr>
            <td style="width:60px" align="right">
            单据类别
            </td>
            <td>
            <asp:DropDownList ID="ddlRecType" runat="server" CssClass="pindl" AutoPostBack="true" OnSelectedIndexChanged="ddlRecType_SelectedIndexChanged">
            <asp:ListItem Value="0">全部</asp:ListItem>
            <asp:ListItem Value="采购退货">采购退货</asp:ListItem>
            <asp:ListItem Value="服务合同">服务合同</asp:ListItem>
            <asp:ListItem Value="期初应收">期初应收</asp:ListItem>
            <asp:ListItem Value="完工结算">完工结算</asp:ListItem>
            <asp:ListItem Value="网点调拨">网点调拨</asp:ListItem>
            <asp:ListItem Value="销售出库">销售出库</asp:ListItem>
            <asp:ListItem Value="预付款">预付款</asp:ListItem>
            <asp:ListItem Value="租金结算">租金结算</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td align="right" style="padding-right:30px;">
                 <asp:Button ID="btnRecExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkRDToExcel()==false)return false;" OnClick="btnRecExcel_Click" />
            </td>
            </tr>
        </table>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <div class="cndiv2" id="cndiv2" style="height:116px;">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView1_RowDataBound"  EnableViewState="false" ShowFooter="true" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="单据类别" DataField="RecType" />
                    <asp:BoundField HeaderText="单据编号" DataField="OperationID" />
                    <asp:BoundField HeaderText="日期" DataField="_Date" />
                    <asp:BoundField HeaderText="经办人" DataField="_Name" />
                    <asp:BoundField HeaderText="总金额" DataField="Amount" />
                    <asp:BoundField HeaderText="已结算金额" DataField="HaveAmount" />
                    <asp:BoundField HeaderText="未结算金额" DataField="NotChargeAmount" />
                    <asp:BoundField HeaderText="提醒日期" DataField="RemindDate" />
                    <asp:BoundField HeaderText="发票号码" DataField="InvoiceNO" />
                    <asp:BoundField HeaderText="发票金额" DataField="InvoiceMoney" DataFormatString="{0:f2}" />
                    <asp:BoundField HeaderText="开票日期" DataField="InvoiceDate" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField HeaderText="收款账户" DataField="AccountName" />
                    <asp:BoundField HeaderText="备注"  DataField="Remark"/>
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
        </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlRecType" EventName="SelectedIndexChanged" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        <div id="info2" style="height:163px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
        <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
            <tr>
            <td style="width:60px" align="right">
            单据类别
            </td>
            <td>
            <asp:DropDownList ID="ddlDueType" runat="server" CssClass="pindl" AutoPostBack="true" OnSelectedIndexChanged="ddlDueType_SelectedIndexChanged">
            <asp:ListItem Value="0">全部</asp:ListItem>
            <asp:ListItem Value="采购入库">采购入库</asp:ListItem>
            <asp:ListItem Value="期初应付">期初应付</asp:ListItem>
            <asp:ListItem Value="收货结算">收货结算</asp:ListItem>
            <asp:ListItem Value="网点调拨">网点调拨</asp:ListItem>
            <asp:ListItem Value="销售退货">销售退货</asp:ListItem>
            <asp:ListItem Value="预收款">预收款</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td align="right" style="padding-right:30px;">
                 <asp:Button ID="btnDueExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkRDToExcel()==false)return false;" OnClick="btnDueExcel_Click" />
            </td>
            </tr>
        </table>
        </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <div class="cndiv2" id="Div1" style="height:116px;">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView2_RowDataBound"  EnableViewState="false" ShowFooter="true" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="单据类别" DataField="RecType" />
                    <asp:BoundField HeaderText="单据编号" DataField="OperationID" />
                    <asp:BoundField HeaderText="日期" DataField="_Date" />
                    <asp:BoundField HeaderText="经办人" DataField="_Name" />
                    <asp:BoundField HeaderText="总金额" DataField="Amount" />
                    <asp:BoundField HeaderText="已结算金额" DataField="HaveAmount" />
                    <asp:BoundField HeaderText="未结算金额" DataField="NotChargeAmount" />
                    <asp:BoundField HeaderText="提醒日期" DataField="RemindDate" />
                    <asp:BoundField HeaderText="发票号码" DataField="InvoiceNO" />
                    <asp:BoundField HeaderText="发票金额" DataField="InvoiceMoney" DataFormatString="{0:f2}" />
                    <asp:BoundField HeaderText="开票日期" DataField="InvoiceDate" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField HeaderText="收款账户" DataField="AccountName" />
                    <asp:BoundField HeaderText="备注"  DataField="Remark"/>
                </Columns>
            </asp:GridView>
        </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlDueType" EventName="SelectedIndexChanged" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
    </div>
    
    <div class="fbom">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><div id="fbon" class="fbon"></div></td>
            <td align="right" style=" padding-right:15px;">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <span class="bs1" style="color:#0000ff;">总应收：<asp:Label ID="lbARec" runat="server" Text="" style="font-weight:bold;"></asp:Label></span>
                 <span class="bs1" style="color:#ff0000;">总应付：<asp:Label ID="lbADue" runat="server" Text="" style="font-weight:bold;"></asp:Label></span>
                </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
var tabnum=3;
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}

function AtuoHedge()
{
    ChkMod(460,205, 'Financial/AtuoHedge.aspx', '自动对冲');
}

function ManualHedge()
{
    ChkMod(860,562, 'Financial/ManualHedge.aspx', '手工对冲');
}

function CancelArr()
{
    ChkMod(400,135, 'Financial/CancelArr.aspx', '注销坏账');
}

function ChkCG(bid)
{
    parent.ShowDialog(800, 480,'Purchase/PurchaseMod.aspx?ids='+bid,'采购单');
}

function ChkHT(bid)
{
    parent.ShowDialog(820, 510, 'Customer/DevContMod.aspx?conno='+bid, '修改服务合同');
}

function ChkGD(bid)
{
    parent.ShowDialog(860,444, 'Services/SerView.aspx?ids='+bid, '服务单');
}

function ChkDB(bid)
{
    parent.ShowDialog(800, 480,'Stock/AllocateMod.aspx?ids='+bid,'调拨单');
}

function ChkXS(bid)
{
    parent.ShowDialog(800, 510,'Sell/SellMod.aspx?ids='+bid,'销售单');
}

function ChkJS(bid)
{
    parent.ShowDialog(700, 480,'Lease/ShowCharge.aspx?ids='+bid, '结算明细');
}

function ChkSFK(bid)
{
    parent.ShowDialog(670,245, 'Financial/InPayView.aspx?ids='+bid, '收付款单');
}

function ChkModR()
{
    var id=$("hfRecID2").value
    parent.ShowDialog(300, 290, 'Financial/ModRemindDate.aspx?id='+id, '修改提醒日期');
}

function Chkset()
{
    Chkwh2();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("应收应付");
}
</script>
