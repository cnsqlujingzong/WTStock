<%@ page language="C#"  CodeFile="stockadm.aspx.cs"     autoeventwireup="true" inherits="Branch_Stock_StockAdm" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
</head>
<body onload="Chkset();" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="ftool">
        <div class="ftoolleft">
         <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td style="padding-left:15px;color:#ff0000;">网点：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                </span>
            </td>
            </tr>
            </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                    <asp:CheckBox ID="cbzerostk" runat="server" AutoPostBack="True" OnCheckedChanged="cbzerostk_CheckedChanged" Text=" 隐藏零库存" />
                </td>
                <td>
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                        <asp:ListItem Value="0">模糊查询</asp:ListItem>
                        <asp:ListItem Value="1">按编号查询</asp:ListItem>
                        <asp:ListItem Value="2">按名称查询</asp:ListItem>
                        <asp:ListItem Value="3">按规格查询</asp:ListItem>
                        <asp:ListItem Value="4">按属性查询</asp:ListItem>
                        <asp:ListItem Value="6">按品牌查询</asp:ListItem>
                        <asp:ListItem Value="7">按保修期查询</asp:ListItem>
                        <asp:ListItem Value="9">按备注查询</asp:ListItem>
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
    
    <div id="lndiv" class="lndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:TreeView ID="tvgds" runat="server" ShowLines="True" OnSelectedNodeChanged="tvgds_SelectedNodeChanged" OnTreeNodeExpanded="tvgds_TreeNodeExpanded">
            <SelectedNodeStyle BackColor="#7d8abe" BorderColor="White" />
        </asp:TreeView>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="tvgds" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="lncn" class="uw"></div>
    <div id="cndiv" style="float:left;height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvgds" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvgds_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="产品分类" DataField="ClassName" />
            <asp:BoundField HeaderText="产品编号" DataField="GoodsNO" />
            <asp:BoundField HeaderText="产品名称" DataField="_Name" />
            <asp:BoundField HeaderText="属性" DataField="Attr" />
            <asp:BoundField HeaderText="总库存" DataField="Stock" />
            <asp:BoundField HeaderText="规格" DataField="Spec" />
            <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
            <asp:BoundField HeaderText="单位" DataField="Unit" />
            <asp:BoundField HeaderText="零售价" DataField="PriceDetail" />
            <asp:BoundField HeaderText="进货价" DataField="PriceCost" />
            <asp:BoundField HeaderText="内部价" DataField="PriceInner" />
            <asp:BoundField HeaderText="旧货价" DataField="PriceWholesale1" />
            <asp:BoundField HeaderText="替代价" DataField="PriceWholesale2" />
            <asp:BoundField HeaderText="列表价" DataField="PriceWholesale3" />
            <asp:BoundField HeaderText="保修期" DataField="MaintenancePeriod" />
            <asp:BoundField HeaderText="适用产品" DataField="ForProducts" />
            <asp:BoundField HeaderText="成本模式" DataField="CostMode" />
            <asp:BoundField HeaderText="供应商" DataField="Provider" />
            <asp:BoundField HeaderText="允许负库存" DataField="bStock" />
            <asp:BoundField HeaderText="有效期(天)" DataField="Valid" />
            <asp:BoundField HeaderText="增值产品" DataField="bIncrement" />
            <asp:BoundField HeaderText="条码" DataField="BarCode" />
            <asp:BoundField HeaderText="停用" DataField="bStop" />
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
        <asp:HiddenField ID="hfClass" runat="server" />
        <asp:HiddenField ID="hfClassID" runat="server" />
        <asp:HiddenField ID="hfTbTitle" runat="server" />
        <asp:HiddenField ID="hfTbField" runat="server" />
        <asp:HiddenField ID="hfPurCost" runat="server" Value="0" />
        <asp:HiddenField ID="hfPurProv" runat="server" Value="0" />
        <asp:HiddenField ID="hfPurCostPrice" runat="server" Value="0" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tvgds" EventName="SelectedNodeChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlBranch" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="cbzerostk" EventName="CheckedChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="lncn2" class="uw"></div>
    <div id="cndivs" class="cndivs">
    
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv2" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="仓库" DataField="StockName" />
            <asp:BoundField HeaderText="库存" DataField="Stock" />
            <asp:BoundField HeaderText="成本均价" DataField="CostPrice" />
            <asp:BoundField HeaderText="仓位" DataField="StockLocName" />
            <asp:BoundField HeaderText="警戒下限" DataField="downWarning" />
            <asp:BoundField HeaderText="警戒上限" DataField="upWarning" />
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
    <span style="display:none;">
            <asp:Button ID="btnStockDept" runat="server" Text="StockDept" UseSubmitBehavior="false" OnClick="btnStockDept_Click" /></span>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnStockDept" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div class="clearfloat"></div>
    <div class="fbom">  
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td><div id="fbon" class="fbon"></div></td>
                <td style="padding-right:20px; width:230px;" align="right">
                    <span class="sblue">高于警戒库存</span>
                    <span class="sred">低于警戒库存</span>
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
    $("btnStockDept").click();
}

function ChkID2(id)
{
    ClrID2(id);
}

function ChkWarming()
{
    parent.ShowDialog(480, 205, 'Stock/WarningMod.aspx?id='+document.getElementById("hfRecID2").value, '分仓库存');
}

function ShowGds()
{
    ChkMod(620, 425,'Stock/GoodsMod.aspx','产品明细');
}

function Chkset()
{
    Chkwh4();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("当前库存");
}
</script>
