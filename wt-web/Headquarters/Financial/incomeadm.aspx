<%@ page language="C#"  CodeFile="incomeadm.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Financial_IncomeAdm" theme="Themes" enableEventValidation="false" %>
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
            <asp:Button ID="btnChk" runat="server" Text="审核" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ConfChk('审核已选择的[收付款单]')==false)return false;" OnClick="btnChk_Click" />
            <asp:Button ID="btnChkU" runat="server" Text="反审核" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ConfChk('反审核已选择的[收付款单]')==false)return false;" OnClick="btnChkU_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="作废" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ConfChk('作废已选择的[收付款单]')==false)return false;" OnClick="btnCancel_Click" />
            <span style="display:none;">
                <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                <asp:Button ID="btnSchH" runat="server" Text="高级查询" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />
                <asp:Button ID="btnShow" runat="server" Text="显示" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="false"/>
            </span>
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                    <input id="btnClass" runat="server" type="button" class="bclass" value="批量修改" onclick="ChkEditClass();" />
                    <asp:CheckBox ID="chkbox" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" Text="隐藏已审核收付款单" />
                    <asp:CheckBox ID="cbzerostk" runat="server" AutoPostBack="True" Checked="true" OnCheckedChanged="cbzerostk_CheckedChanged" Text=" 隐藏对冲收付款单" />
                </td>
                <td>
                    <input id="btnPrint" runat="server" type="button" value="打印" class="iprint" onclick="ChkPrints();" />
                </td>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="BillID">按单据编号查询</asp:ListItem>
                    <asp:ListItem Value="Type">按单据类型查询</asp:ListItem>
                    <asp:ListItem Value="_Date">按日期查询</asp:ListItem>
                    <asp:ListItem Value="Operator">按经办人查询</asp:ListItem>
                    <asp:ListItem Value="CustomerName">按往来单位查询</asp:ListItem>
                    <asp:ListItem Value="ChargeStyle">按结算方式查询</asp:ListItem>
                    <asp:ListItem Value="Account">按结算帐户查询</asp:ListItem>
                    <asp:ListItem Value="InvoiceClass">按发票类别查询</asp:ListItem>
                    <asp:ListItem Value="InvoiceNO">按发票号码查询</asp:ListItem>
                    <asp:ListItem Value="CheckNO">按支票号码查询</asp:ListItem>
                    <asp:ListItem Value="VoucherNO">按凭证号码查询</asp:ListItem>
                    <asp:ListItem Value="ChargeItem">按收支项目查询</asp:ListItem>
                    <asp:ListItem Value="ChkDate">按审核日期查询</asp:ListItem>
                    <asp:ListItem Value="ChkOperator">按审核人查询</asp:ListItem>
                    <asp:ListItem Value="RecType">按帐款类型查询</asp:ListItem>
                    <asp:ListItem Value="Remark">按备注查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td style="padding:0px;"><input id="btnSchsH" type="button" value="高级查询" class="bsch" onclick="parent.ShowDialog(470,290, 'Financial/IncomeCd.aspx', '高级查询');" /></td>
            </tr>
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
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderTemplate>
                    <input id="cball" type="checkbox" class="cb1" onclick="SltAllValue();" title="全选/取消全选"/>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="单据类别" DataField="Type" />
            <asp:BoundField HeaderText="单据编号" DataField="BillID" />
            <asp:BoundField HeaderText="状态" DataField="Status" />
            <asp:BoundField HeaderText="日期" DataField="_Date"/>
            <asp:BoundField HeaderText="经办人" DataField="Operator" />
            <asp:BoundField HeaderText="所属" DataField="Dept" />
            <asp:BoundField HeaderText="往来单位" DataField="CustomerName" />
            <asp:BoundField HeaderText="实收款" DataField="RealRecMoney" />
            <asp:BoundField HeaderText="实付款" DataField="RealDueMoney" />
            <asp:BoundField HeaderText="优惠金额" DataField="PreMoney" />
            <asp:BoundField HeaderText="结算方式" DataField="ChargeStyle" />
            <asp:BoundField HeaderText="结算帐户" DataField="Account" />
            <asp:BoundField HeaderText="开票日期" DataField="InvoiceDate" />
            <asp:BoundField HeaderText="开票金额" DataField="InvoiceAmount" />
            <asp:BoundField HeaderText="发票号码" DataField="InvoiceNO" />
            <asp:BoundField HeaderText="发票类别" DataField="InvoiceClass" />
            <asp:BoundField HeaderText="支票号码" DataField="CheckNO" />
            <asp:BoundField HeaderText="凭证号码" DataField="VoucherNO" />
            <asp:BoundField HeaderText="收支项目" DataField="ChargeItem" />
            <asp:BoundField HeaderText="帐款类型" DataField="RecType" />
            <asp:BoundField HeaderText="审核日期" DataField="ChkDate" />
            <asp:BoundField HeaderText="审核人" DataField="ChkOperator" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
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
    <asp:HiddenField ID="hfType" runat="server" />
    <asp:HiddenField ID="hfcbID" runat="server" />
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkU" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="cbzerostk" EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="chkbox" EventName="CheckedChanged" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut" style="overflow:hidden;">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1"></span>
                <span id="tabs1" onclick="ChkTab('1');">明细</span>
                <span id="tabs_r1"></span>
            </div>
        </div>
        <div id="info1" style="height:163px;background:#ECE9D8;">
        <div class="cndiv2" id="cndiv2" style="height:143px;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView1_RowDataBound"  EnableViewState="false" ShowFooter="true" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="款项类别" DataField="Type" />
                    <asp:BoundField HeaderText="单据类别" DataField="RecType" />
                    <asp:BoundField HeaderText="单据编号" DataField="OperationID" />
                    <asp:BoundField HeaderText="日期" DataField="_Date" />
                    <asp:BoundField HeaderText="经办人" DataField="_Name" />
                    <asp:BoundField HeaderText="总金额" DataField="Amount" />
                    <asp:BoundField HeaderText="已结算金额" DataField="HaveAmount" />
                    <asp:BoundField HeaderText="未结算金额" DataField="NotChargeAmount" />
                    <asp:BoundField HeaderText="提醒日期" DataField="RemindDate" />
                    <asp:BoundField HeaderText="备注"  DataField="Remark"/>
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
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
                    <span class="sred">待审核</span>
                    <span class="sgreen">已审核</span>
                    <span class="sgay">已作废</span>
                </td>
                <td>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
                    <span class="bs1" style="color:#0000ff;">总实收款:<asp:Label ID="Label1" runat="server" Text=""></asp:Label></span>
                    <span class="bs1" style="color:#ff0000;">总实付款:<asp:Label ID="Label2" runat="server" Text=""></asp:Label></span>
                    <span class="bs1" style="color:Black;">总开票额:<asp:Label ID="Label3" runat="server" Text=""></asp:Label></span>
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkU" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="cbzerostk" EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="chkbox" EventName="CheckedChanged" />
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
var tabnum=2;
function ChkID(id,type)
{
    ClrID(id);
    $("btnShow").click();
    $("hfType").value=type;
}

function ChkView()
{
    ChkMod(670,245, 'Financial/InPayView.aspx', '收付款单');
}

function ConfChk(str)
{
    if(ChkSltValue()!=false)
    {
        return confirm("确认要"+str+"吗？");
    }else{return false;}
}

function Chkset()
{
    Chkwh2();
    Chkbom(); 
}
function ChkModR()
{
    var id=$("hfRecID2").value
    parent.ShowDialog(300, 123, 'Financial/ModRemindDate.aspx?id='+id, '修改提醒日期');
}
function ChkPrints()
{
    if($("hfType").value=="收款单")
    ChkPrint('SKD');
    else
    ChkPrint('FKD');
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("收付款查询");
}
function ChkCG(bid)
{
    parent.ShowDialog(800, 480,'Purchase/PurchaseMod.aspx?ids='+bid+'&n=1','采购单');
}

function ChkHT(bid)
{
    parent.ShowDialog(820, 510, 'Customer/DevContMod.aspx?conno='+bid+'&n=1', '修改服务合同');
}

function ChkGD(bid)
{
    parent.ShowDialog(860,444, 'Services/SerView.aspx?ids='+bid, '服务单');
}

function ChkDB(bid)
{
    parent.ShowDialog(800, 480,'Stock/AllocateMod.aspx?ids='+bid+'&n=1','调拨单');
}

function ChkXS(bid)
{
    parent.ShowDialog(800, 510,'Sell/SellMod.aspx?ids='+bid+'&n=1','销售单');
}

function ChkJS(bid)
{
    parent.ShowDialog(700, 480,'Lease/ShowCharge.aspx?ids='+bid+'&n=1', '结算明细');
}
function ChkSFK(bid)
{
    parent.ShowDialog(670,245, 'Financial/InPayView.aspx?ids='+bid+'&n=1', '收付款单');
}
function ChkEditClass()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(300, 128,'Financial/EditExpense.aspx?id='+id,'批量修改');
    }
}
</script>
