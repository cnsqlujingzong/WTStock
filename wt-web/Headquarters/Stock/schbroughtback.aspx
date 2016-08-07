<%@ page language="C#"  CodeFile="schbroughtback.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stock_SchBroughtBack" theme="Themes" enableEventValidation="false" %>
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
                <asp:Button ID="btnChk" runat="server" Text="审核" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkConf('审核该[领退单]')==false) return false;" OnClick="btnChk_Click"/>
                <asp:Button ID="btnChkU" runat="server" Text="反审核" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkConf('反审核该[领退单]')==false) return false;" OnClick="btnChkU_Click"/>
                <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('领退单')==false) return false;" OnClick="btnDel_Click"/>
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
                <input id="btnPrint" runat="server" type="button" value="打印" class="iprint" onclick="ChkPrint('LTD');" />
                </td>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="1">按单据编号查询</asp:ListItem>
                    <asp:ListItem Value="9">按服务单号查询</asp:ListItem>
                    <asp:ListItem Value="2">按制单日期查询</asp:ListItem>
                    <asp:ListItem Value="3">按制单人查询</asp:ListItem>
                    <asp:ListItem Value="4">按经办人查询</asp:ListItem>
                    <asp:ListItem Value="10">按领料人查询</asp:ListItem>
                    <asp:ListItem Value="5">按单据类别查询</asp:ListItem>
                    <asp:ListItem Value="6">按审核日期查询</asp:ListItem>
                    <asp:ListItem Value="7">按审核人查询</asp:ListItem>
                    <asp:ListItem Value="8">按备注查询</asp:ListItem>
                    <asp:ListItem Value="21">按网点查询</asp:ListItem>
                    <asp:ListItem Value="25">按产品编号查询</asp:ListItem>
                    <asp:ListItem Value="26">按产品名称查询</asp:ListItem>
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
            <asp:BoundField HeaderText="标" />
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
        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkU" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1" class="tabs_activeleft"></span>
                <span id="tabs1" class="tabs_active" >领退明细</span>
                <span id="tabs_r1" class="tabs_activeright"></span>
                <asp:Button ID="btnEx" runat="server" style="float:right;" Text="导出" CssClass="bexcel" OnClick="btnEx_Click" />
            </div>
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
                    <asp:BoundField HeaderText="属性" DataField="Attr" />
                    <asp:BoundField HeaderText="规格" DataField="Spec" />
                    <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
                    <asp:BoundField HeaderText="单位" DataField="Unit" />
                    <asp:BoundField HeaderText="数量" DataField="Qty" />
                    <asp:BoundField HeaderText="单价" DataField="Price" />
                    <asp:BoundField HeaderText="金额" DataField="Total" />
                    <asp:BoundField HeaderText="序列号" DataField="SN" />
                    <asp:BoundField HeaderText="保修期" DataField="MainTenancePeriod" />
                    <asp:BoundField HeaderText="截止日期" DataField="PeriodEndDate" />
                    <asp:BoundField HeaderText="服务单号" DataField="OperationID" />
                    <asp:BoundField HeaderText="备注"  DataField="Remark"/>
                </Columns>
            </asp:GridView>
           
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
    ChkMod(800, 480,'Stock/BroughtBackMod.aspx','领退单');
}

function ViewSN(strsn)
{
    parent.ShowDialog1(400, 300, 'Stock/ViewSN.aspx?sn='+escape(strsn), '查看序列号');
}

function Chkset()
{
    Chkwh2();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("领退单查询");
}

</script>
