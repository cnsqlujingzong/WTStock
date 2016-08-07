<%@ page language="C#"  CodeFile="settlement.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Lease_Settlement" theme="Themes" enableEventValidation="false" %>
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
                <input id="btnMod" type="button" value="结算审核" class="bt1" onclick="ChkCharge();" />
                <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkConf('取消该[结算审核]')==false) return false;" OnClick="btnCancel_Click"/>
                <span style="display:none;">
                    <asp:Button ID="btnSchH" runat="server" Text="高级查询" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" /> 
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
                <input id="btnPrint" runat="server" type="button" value="打印" class="iprint" onclick="ChkPrint('ZLD');" />
                </td>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">模糊查询</asp:ListItem>
                    <asp:ListItem Value="1">按业务编号查询</asp:ListItem>
                    <asp:ListItem Value="2">按客户名称查询</asp:ListItem>
                    <asp:ListItem Value="3">按联系人查询</asp:ListItem>
                    <asp:ListItem Value="4">按联系电话查询</asp:ListItem>
                    <asp:ListItem Value="5">按地址查询</asp:ListItem>
                    <asp:ListItem Value="6">按机器型号查询</asp:ListItem>
                    <asp:ListItem Value="7">按序列号查询</asp:ListItem>
                    <asp:ListItem Value="8">按机器品牌查询</asp:ListItem>
                    <asp:ListItem Value="9">按机器类别查询</asp:ListItem>
                    <asp:ListItem Value="10">按起始日期查询</asp:ListItem>
                    <asp:ListItem Value="11">按终止日期查询</asp:ListItem>
                    <asp:ListItem Value="12">按业务员查询</asp:ListItem>
                    <asp:ListItem Value="13">按备注查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td>
                <input id="btnSchsH" type="button" value="高级查询" class="bsch" onclick="parent.ShowDialog(460,260, 'Lease/LeaseCd.aspx', '高级查询');" />
            </td>
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
            <asp:BoundField HeaderText="业务类别" DataField="Type" />
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
    
    <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="当页显示数"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCountText" runat="server" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCount" runat="server" ToolTip="总记录数"></asp:Label></td>
        </tr>
    </table>
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    <asp:HiddenField ID="hfcbID" runat="server" />
    <asp:HiddenField ID="hfCusID" runat="server" />
    <asp:HiddenField ID="hfPurDept" runat="server" Value="0" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut" style="overflow:hidden;">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1"></span>
                <span id="tabs1" onclick="ChkTab('1');">结算单</span>
                <span id="tabs_r1"></span>
                <span id="tabs_l2"></span>
                <span id="tabs2" onclick="ChkTab('2');">租赁机器</span>
                <span id="tabs_r2"></span>
                <span id="tabs_l3"></span>
                <span id="tabs3" onclick="ChkTab('3');">抄表记录</span>
                <span id="tabs_r3"></span>
            </div>
        </div>
        <div id="info1" style="height:175px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
           <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel2" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel2_Click" />
                </td>
                <td>
                <input id="btnPrint2" runat="server" type="button" value="打印" class="iprint" onclick="ChkPrint2('ZLJSD');" />
                </td>
            </tr>
           </table>
        </div>
        <div class="cndiv2" style="height:145px;">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView3_RowDataBound"  EnableViewState="false" >
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="序"/>
                        <asp:BoundField HeaderText="结算单号" DataField="OperationID" />
                        <asp:BoundField HeaderText="状态" DataField="strStatus" />
                        <asp:BoundField HeaderText="日期" DataField="_Date" />
                        <asp:BoundField HeaderText="经办人" DataField="Operator" />
                        <asp:BoundField HeaderText="起始日期" DataField="StartDate" />
                        <asp:BoundField HeaderText="终止日期" DataField="EndDate" />
                        <asp:BoundField HeaderText="周期" DataField="Cycle" />
                        <asp:BoundField HeaderText="上期计数" DataField="ShangQty" />
                        <asp:BoundField HeaderText="本期计数" DataField="BenQty" />
                        <asp:BoundField HeaderText="损耗张数" DataField="Loss" />
                        <asp:BoundField HeaderText="基础月租" DataField="Rent" />
                        <asp:BoundField HeaderText="超张费" DataField="SuperZhangFee" />
                        <asp:BoundField HeaderText="合计应收" DataField="dRec" />
                        <asp:BoundField HeaderText="优惠金额" DataField="Discount" />
                        <asp:BoundField HeaderText="现收金额" DataField="InCash" />
                        <asp:BoundField HeaderText="结算备注" DataField="Remark" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>        
        </div>
        </div>
        <div id="info2" style="height:175px;background:#ECE9D8;">
        <div class="cndiv2" style="height:175px;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView1_RowDataBound"  EnableViewState="false" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="机器状态" DataField="DevStatus" />
                    <asp:BoundField HeaderText="仓库" DataField="StockName" />
                    <asp:BoundField HeaderText="租赁机器" DataField="GoodsNO" />
                    <asp:BoundField HeaderText="租赁数量" DataField="iCount" />
                    <asp:BoundField HeaderText="租机单价" DataField="LeasePrice" />
                    <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
                    <asp:BoundField HeaderText="机器品牌" DataField="Brand" />
                    <asp:BoundField HeaderText="类别" DataField="Class" />
                    <asp:BoundField HeaderText="型号" DataField="Model" />
                    <asp:BoundField HeaderText="序列号" DataField="ProductSN1" />
                    <asp:BoundField HeaderText="序列号2" DataField="ProductSN2" />
                    <asp:BoundField HeaderText="计数器"/>
                    <asp:BoundField HeaderText="备注" DataField="Remark" />
                </Columns>
            </asp:GridView>
            
            <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        
        </div>
        <div id="info3" style="height:175px;background:#ECE9D8;">
        <div class="cndiv2" style="height:175px;">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView2_RowDataBound"  EnableViewState="false" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="读数日期" DataField="_Date" />
                    <asp:BoundField HeaderText="读数人" DataField="Operator" />
                    <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
                    <asp:BoundField HeaderText="机器序列号" DataField="ProductSN1" />
                    <asp:BoundField HeaderText="计数器类型" DataField="_Name" />
                    <asp:BoundField HeaderText="计数" DataField="Qty" />
                    <asp:BoundField HeaderText="损耗张数" DataField="Loss" />
                    <asp:BoundField HeaderText="备注"  DataField="WRemark"/>
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfRecID3" runat="server" Value="-1" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
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
                    <span class="sblue">抄表类租赁</span>
                    <span class="stin">非抄表类租赁</span>
                    <span class="sgreen">全保</span>
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
var tabnum=4;
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}

function ChkCharge()
{
    ChkMod(640, 455,'Lease/SettleCharge.aspx','结算审核');
}

function ViewQty(id)
{
    parent.ShowDialog(400, 300,'Lease/ViewQty.aspx?id='+id, '查看计数器');
}
function ModBill()
{
    ChkMod(800, 480,'Lease/LeaseView.aspx','业务单');
}

function Chkset()
{
    Chkwhs();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("结算审核");
}

</script>
