<%@ page language="C#"  CodeFile="snadm.aspx.cs"     autoeventwireup="true" inherits="Branch_Stock_SNAdm" theme="Themes" enableEventValidation="false" %>
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
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" Width="100">
                </asp:DropDownList>
            </td>
            <td style="padding-left:15px;color:#ff0000;">仓库：</td>
            <td style="padding-left:0px;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DropDownList ID="ddlStock" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlStock_SelectedIndexChanged" Width="120">
                </asp:DropDownList>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="tvgds" EventName="SelectedNodeChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlBranch" EventName="SelectedIndexChanged" />
            </Triggers>
            </asp:UpdatePanel>
            </td>
            <td>
                <input id="btnNew" type="button" value="入库" class="bt1" onclick="parent.ShowDialog(800, 500, 'Stock/SNStockIN.aspx', '序列号入库');" />
                <input id="btnMod" type="button" value="出库" class="bt1" onclick="parent.ShowDialog(800, 500,'Stock/SNStockOUT.aspx','序列号出库');" />
                <span style="display:none;">
                    <asp:Button ID="btnFsh" runat="server" Text="刷新" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnFsh_Click"/>
                    
                    <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('序列号')==false) return false;" OnClick="btnDel_Click"/>
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
            <td style="padding-left:0px;">
                <input id="btnInput" runat="server" type="button" class="binput" value="导入" onclick="ChkInput();" />
            </td>
            <td style="padding-left:0px;">
                <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
             <td>
             <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl" onchange="document.getElementById('ddlKey').focus();" Width="80">
                <asp:ListItem Value="-1">查询全部</asp:ListItem>
                <asp:ListItem Value="在库">在库</asp:ListItem>
                <asp:ListItem Value="离库">离库</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td>
            <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                <asp:ListItem Value="SN">按序列号查询</asp:ListItem>
                <asp:ListItem Value="GoodsNO">按产品编号查询</asp:ListItem>
                <asp:ListItem Value="_Name">按产品名称查询</asp:ListItem>
                <asp:ListItem Value="Spec">按产品规格查询</asp:ListItem>
                <asp:ListItem Value="Brand">按产品品牌查询</asp:ListItem>
                <asp:ListItem Value="BillID">按入库单号查询</asp:ListItem>
                <asp:ListItem Value="_Date">按入库日期查询</asp:ListItem>
                <asp:ListItem Value="Type">按入库业务类别查询</asp:ListItem>
                <asp:ListItem Value="OperationID">按入库业务单号查询</asp:ListItem>
                <asp:ListItem Value="StockOUTNO">按出库单号查询</asp:ListItem>
                <asp:ListItem Value="_OUTDate">按出库日期查询</asp:ListItem>
                <asp:ListItem Value="OUTType">按出库业务类别查询</asp:ListItem>
                <asp:ListItem Value="OUTOperationID">按出库业务单号查询</asp:ListItem>
                <asp:ListItem Value="-1">查询全部</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td>
            <td align="left">
            <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
          </tr>
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
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="状态" DataField="Status" />
            <asp:BoundField HeaderText="序列号" DataField="SN" />
            <asp:BoundField HeaderText="状态" DataField="Status" />
            <asp:BoundField HeaderText="产品编号" DataField="GoodsNO" />
            <asp:BoundField HeaderText="名称" DataField="_Name" />
            <asp:BoundField HeaderText="所属网点" DataField="Dept" />
            <asp:BoundField HeaderText="所属仓库" DataField="StockName" />
            <asp:BoundField HeaderText="仓库属性" DataField="Reject" />
            <asp:BoundField HeaderText="仓位" DataField="StockLocName" />
            <asp:BoundField HeaderText="入库价" DataField="Price" />
            <asp:BoundField HeaderText="仓库均价" DataField="CostPrice" />
            <asp:BoundField HeaderText="规格" DataField="Spec" />
            <asp:BoundField HeaderText="品牌" DataField="Brand" />
            <asp:BoundField HeaderText="入库单号" DataField="BillID" />
            <asp:BoundField HeaderText="入库日期" DataField="_Date" />
            <asp:BoundField HeaderText="入库业务类别" DataField="Type" />
            <asp:BoundField HeaderText="入库业务单号" DataField="OperationID" />
            <asp:BoundField HeaderText="出库单号" DataField="StockOUTNO" />
            <asp:BoundField HeaderText="出库日期" DataField="_OUTDate" />
            <asp:BoundField HeaderText="出库业务类别" DataField="OUTType" />
            <asp:BoundField HeaderText="出库业务单号" DataField="OUTOperationID" />
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
    <asp:HiddenField ID="hfPurCostPrice" runat="server" Value="0" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tvgds" EventName="SelectedNodeChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlBranch" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlStock" EventName="SelectedIndexChanged" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    <div class="fbom">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td><div id="fbon" class="fbon"></div></td>
                <td>
                    <span class="sred">离库</span>
                    <span class="sgreen">在库</span>
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
}
function Goods(id)
{
    parent.ShowDialog(620, 425,'Stock/GoodsMod.aspx?ids='+id,'产品明细');
}
function StockIN(id)
{
    parent.ShowDialog(800, 520, 'Stock/StockINMod.aspx?ids=' + id, '入库单');
}
function StockOut(id)
{
    parent.ShowDialog(800, 520,'Stock/StockOutMod.aspx?ids='+id,'出库单');
}
function BroughtBack(id,title)
{
    parent.ShowDialog(800, 480,'Stock/BroughtBackMod.aspx?ids='+id,title);
}
function Sell(id,title)
{
    parent.ShowDialog(800, 480,'Sell/SellMod.aspx?ids='+id,title);
}
function Lease(id)
{
    parent.ShowDialog(800, 480,'Lease/LeaseMod.aspx?ids='+id,'业务单');
}
function Chkset()
{
    Chkwh3();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("序列号库");
}
function ChkInput()
{
    parent.ShowDialog(520, 193,'Stock/InputSN.aspx', '导入序列号库');
}
</script>
