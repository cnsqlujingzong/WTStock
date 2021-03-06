<%@ page language="C#"  CodeFile="schsellplan.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Sell_SchSellPlan" theme="Themes" enableEventValidation="false" %>
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
                <asp:Button ID="btnChk" runat="server" Text="审核" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkConf('审核该[销售订单]')==false) return false;" OnClick="btnChk_Click"/>
                <asp:Button ID="btnChkU" runat="server" Text="反审核" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkConf('反审核该[销售订单]')==false) return false;" OnClick="btnChkU_Click"/>
                <asp:Button ID="btnEnd" runat="server" Text="终止" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkConf('终止该[销售订单]')==false) return false;" OnClick="btnEnd_Click"/>
                <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('销售订单')==false) return false;" OnClick="btnDel_Click"/>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
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
                          <a href="#" onclick="printSXD()" class="iprint">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;打印合同</a>
                    <a href="#" onclick="printSXDD()" class="iprint">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;打印销售订单</a>
                <%--    <asp:Button ID="btnPrint" runat="server" Text="打印" class="iprint" OnClientClick="printSXDD()"/>--%>
           <input id="btnPrint" runat="server"  type="button" value="打印" class="iprint" onclick="ChkPrint('XSDD');" />
                </td>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="1">按单据编号查询</asp:ListItem>
                    <asp:ListItem Value="2">按日期查询</asp:ListItem>
                    <asp:ListItem Value="3">按业务员查询</asp:ListItem>
                    <asp:ListItem Value="4" Selected="True">按客户名称查询</asp:ListItem>
                    <asp:ListItem Value="5">按审核日期查询</asp:ListItem>
                    <asp:ListItem Value="6">按审核人查询</asp:ListItem>
                    <asp:ListItem Value="7">按合同编号查询</asp:ListItem>
                    <asp:ListItem Value="8">按备注查询</asp:ListItem>
                    <asp:ListItem Value="11">按产品编号</asp:ListItem>
                    <asp:ListItem Value="12">按产品名称</asp:ListItem>
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
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
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
              <asp:BoundField HeaderText="网点" DataField="BrandName" />
                <asp:BoundField HeaderText="税种" DataField="BrandTaxRateType" />
                <asp:BoundField HeaderText="税率" DataField="BrandTaxRate" />
            <asp:BoundField HeaderText="执行状态" DataField="EndStatus" />
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
    <asp:HiddenField ID="hfPurDept" runat="server" Value="0" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkU" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnEnd" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1" class="tabs_activeleft"></span>
                <span id="tabs1" class="tabs_active" >订单明细</span>
                <span id="tabs_r1" class="tabs_activeright"></span>
            </div>
        </div>
        <div style="border-bottom:#808080 1px solid;">
               <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
                <tr>
                <td align="right" style="padding-right:30px;">
                    <asp:Button ID="btnExcelDe" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcelDe_Click" />
                </td>
                </tr>
               </table>
        </div>
        <div class="cndiv2" id="cndiv2">
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
                    <asp:BoundField HeaderText="已售量" DataField = "Quotety" />
                    <asp:BoundField HeaderText="单价" DataField="Price" />
                    <asp:BoundField HeaderText="折扣" DataField="Dis" />
                    <asp:BoundField HeaderText="金额" DataField="Total" />
                    <asp:BoundField HeaderText="货期" DataField="Huoqi" />
                       <asp:BoundField HeaderText="成色" DataField="chengse" />
                       <asp:BoundField HeaderText="包装" DataField="baozhuang" />
                  <%--  <asp:BoundField HeaderText="税额" DataField="TaxAmount" />--%>
                    <asp:BoundField HeaderText="价税合计" DataField="GoodsAmount" />
                    <asp:BoundField HeaderText="保修期" DataField="MainTenancePeriod" />
                    <asp:BoundField HeaderText="备注"  DataField="Remark"/>
                </Columns>
            </asp:GridView>
            
            <asp:HiddenField ID="hfTbTitleDe" runat="server" />
            <asp:HiddenField ID="hfTbFieldDe" runat="server" />
            <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
    </div>
    
    <div class="fbom">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td><div id="fbon" class="fbon"></div></td>
                <td>
                    <span class="sred">待审核</span>
                    <span class="sgreen">已审核</span>
                    <span class="sblack">已执行</span>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}

function ModBill()
{
    ChkMod(820, 550,'Sell/SellPlanMod.aspx','销售订单');
}

function Chkset()
{
    Chkwhs();
    Chkbom(); 
}
function printSXDD()
{
    var oid = $("hfRecID").value;
    if (isNull(oid))
    {
        window.alert("操作失败！没有选择订单");  
        return false
    }
    parent.ShowDialog1(400, 300, 'Print/PrintItex.aspx?ptype=xsdd&&oid=' + oid, '打印销售订单');
  
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("销售订单查询");
}
function printSXD() {
    var oid = $("hfRecID").value;
    if (isNull(oid)) {
        window.alert("操作失败！没有选择订单");
        return false
    }
    parent.ShowDialog1(400, 300, 'Print/PrintItex.aspx?ptype=xsdd2&&oid=' + oid, '打印合同');

}
</script>
