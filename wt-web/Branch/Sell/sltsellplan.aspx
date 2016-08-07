<%@ page language="C#"  CodeFile="sltsellplan.aspx.cs"     autoeventwireup="true" inherits="Branch_Sell_SltSellPlan" theme="Themes" enableEventValidation="false" %>
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
                    <asp:ListItem Value="1">按单据编号查询</asp:ListItem>
                    <asp:ListItem Value="2">按日期查询</asp:ListItem>
                    <asp:ListItem Value="3">按业务员查询</asp:ListItem>
                    <asp:ListItem Value="4">按客户名称查询</asp:ListItem>
                    <asp:ListItem Value="5">按审核日期查询</asp:ListItem>
                    <asp:ListItem Value="6">按审核人查询</asp:ListItem>
                    <asp:ListItem Value="7">按合同编号查询</asp:ListItem>
                    <asp:ListItem Value="8">按备注查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnSch_Click" /></td>
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
                    <asp:Button ID="btnShow" runat="server" Text="显示" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnShow_Click"/>
                </span>
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
            <asp:BoundField HeaderText="单据编号" DataField="BillID" />
            <asp:BoundField HeaderText="日期" DataField="_Date" />
            <asp:BoundField HeaderText="业务员" DataField="Operator" />
            <asp:BoundField HeaderText="客户名称" DataField="_Name" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="地址" DataField="Adr" />
            <asp:BoundField HeaderText="送货人" DataField="SndOperator" />
            <asp:BoundField HeaderText="合同编号" DataField="ContractNO" />
            <asp:BoundField HeaderText="审核日期" DataField="ChkDate" />
            <asp:BoundField HeaderText="审核人" DataField="ChkOperator" />
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
        <asp:HiddenField ID="hfPurDept" runat="server" Value="0" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="cnbut" style="width:800px; height:180px;">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1" class="tabs_activeleft"></span>
                <span id="tabs1" class="tabs_active" >订单明细</span>
                <span id="tabs_r1" class="tabs_activeright"></span>
            </div>
        </div>
        <div class="cndiv2" id="cndiv2" style="height:155px;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView2_RowDataBound"  EnableViewState="false" ShowFooter="true" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="仓库" DataField="StockName" />
                    <asp:BoundField HeaderText="产品编号" DataField="GoodsNO" />
                    <asp:BoundField HeaderText="名称" DataField="_Name" />
                    <asp:BoundField HeaderText="规格" DataField="Spec" />
                    <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
                    <asp:BoundField HeaderText="单位" DataField="Unit" />
                    <asp:BoundField HeaderText="订货量" DataField="Qty" />
                    <asp:BoundField HeaderText="已售量" DataField="SellQty" />
                    <asp:BoundField HeaderText="单价" DataField="Price" />
                    <asp:BoundField HeaderText="折扣" DataField="Dis" />
                    <asp:BoundField HeaderText="金额" DataField="Total" />
                    <asp:BoundField HeaderText="税率" DataField="TaxRate" />
                    <asp:BoundField HeaderText="税额" DataField="TaxAmount" />
                    <asp:BoundField HeaderText="价税合计" DataField="GoodsAmount" />
                    <asp:BoundField HeaderText="保修期" DataField="MainTenancePeriod" />
                    <asp:BoundField HeaderText="备注"  DataField="Remark"/>
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
    </div>
    <div class="clearfloat"></div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}

function SltPurPlan()
{
    var list=document.getElementById("hfRecID").value;
    if(list==""||list=="-1")
    {
        alert("操作失败！请选择后操作.");return false;
    }else{
    try{
        parent.<%=Str_Fid %>.$("hfSltID").value=list;
        parent.<%=Str_Fid %>.document.getElementById("btnSltBill").click();
    }catch(e){alert("系统错误！请刷新后重试");}
    parent.CloseDialog<%=Str_F %>();
    }
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
