<%@ page language="C#"  CodeFile="meterreading.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Lease_MeterReading" theme="Themes" enableEventValidation="false" %>
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
                <asp:Button ID="btnChkU" runat="server" Text="反审核" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkConf('反审核该[业务单]')==false) return false;" OnClick="btnChkU_Click"/>
                <input id="btnReading" type="button" value="抄表登记" class="bt1" onclick="ChkMeter();" />
                <input id="btnCharge" type="button" value="结算开单" class="bt1" onclick="ChkCharge();" />
                <input id="btnDevAdd" type="button" value="增机" class="bt1" onclick="ChkDeviceAdd();" />
                <input id="btnTranspond" type="button" value="派单" class="bt1" onclick="Transpond();" />
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
                <td>网点：</td>
                <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" Width="100">
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnSchDept" runat="server" CssClass="bt1" Text="查询" OnClick="btnSchDept_Click" />
                </td>
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
                    <asp:ListItem Value="22">7天内将要到期的</asp:ListItem>
                    <asp:ListItem Value="23">已过期</asp:ListItem>
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
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderTemplate>
                    <input id="cball" type="checkbox" class="cb1" onclick="SltAllValue();" title="全选/取消全选"/>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="业务类别" DataField="Type" />
            <asp:BoundField HeaderText="业务编号" DataField="BillID" />
            <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="地址" DataField="Adr" />
            <asp:BoundField HeaderText="起始日期" DataField="StartDate" />
            <asp:BoundField HeaderText="终止日期" DataField="EndDate" />
            <asp:BoundField HeaderText="基础月租" DataField="Rent" />
            <asp:BoundField HeaderText="上期抄表日期" DataField="ReadingDate" />
            <asp:BoundField HeaderText="上期结算日期" DataField="ChargeDate" />
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
        <asp:AsyncPostBackTrigger ControlID="btnChkU" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut" style="overflow:hidden;">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1"></span>
                <span id="tabs1" onclick="ChkTab('1');">租赁机器</span>
                <span id="tabs_r1"></span>
                <span id="tabs_l2"></span>
                <span id="tabs2" onclick="ChkTab('2');">抄表记录</span>
                <span id="tabs_r2"></span>
                <span id="tabs_l3"></span>
                <span id="tabs3" onclick="ChkTab('3');">结算单</span>
                <span id="tabs_r3"></span>
            </div>
        </div>
        <div id="info1" style="height:175px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
           <table style="margin-left:35px;" cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
                <asp:Button ID="bteEx" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="bteEx_Click" />
            </td>
            </tr>
           </table>
        </div>
        <div class="cndiv2" id="cndiv2" style="height:175px;">
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
        <div id="info2" style="height:175px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
           <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
               <input id="btnModD" type="button" value="修改" class="bt1" onclick="ModD();" />
               <asp:Button ID="btnDelD" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel2('抄表记录')==false) return false;" UseSubmitBehavior="false" OnClick="btnDelD_Click" />
            </td>
            <td align="right">
                <asp:Button ID="btnExcelDetail" runat="server" Text="导出" CssClass="bexcel" OnClick="btnExcelDetail_Click" OnClientClick="return excelDetail();" /></td>
            </tr>
           </table>
        </div>
        <div class="cndiv2" style="height:145px;">
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
            <asp:AsyncPostBackTrigger ControlID="btnDelD" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info3" style="height:175px;background:#ECE9D8;">
          <div style="border-bottom:#808080 1px solid;">
           <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnChkCU" runat="server" Text="反结算" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkConf2('反结算该[结算单]')==false) return false;" OnClick="btnChkCU_Click"/>
                    <asp:Button ID="btnCancelC" runat="server" Text="取消" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkConf2('取消该[结算单]')==false) return false;" OnClick="btnCancelC_Click"/>
                    <asp:Button ID="btnDelC" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkConf2('删除该[结算单]')==false) return false;" OnClick="btnDelC_Click"/>
                    <input id="btnShowCharge" type="button" value="查看明细" class="bt1" onclick="ChkShowCharge();" />
                </td>
                
                <td>
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
                        <asp:BoundField HeaderText="本期计数" DataField="BenQty" />
                        <asp:BoundField HeaderText="上期计数" DataField="ShangQty" />
                        <asp:BoundField HeaderText="损耗张数" DataField="Loss" />
                        <asp:BoundField HeaderText="基础月租" DataField="Rent" />
                        <asp:BoundField HeaderText="超张费" DataField="SuperZhangFee" />
                        <asp:BoundField HeaderText="合计应收" DataField="dRec" />
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
                <asp:AsyncPostBackTrigger ControlID="btnChkCU" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelC" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnDelC" EventName="Click" />
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

function ModBill()
{
    ChkMod(800, 480,'Lease/LeaseView.aspx','业务单');
}

function ChkMeter()
{
    ChkMod(600, 380,'Lease/Reading.aspx','抄表登记');
}

function ChkCharge()
{
    ChkMod(700, 480,'Lease/Charge.aspx','结算开单');
}
function ChkDeviceAdd()
{
    ChkMod(700, 450,'Lease/DeviceAdd.aspx','增机');
}
function Transpond()
{
    if($("hfcbID").value=="")
    {
        ChkMod(275, 90,'Lease/Transpond.aspx','派单');
    }else
    {
        parent.ShowDialog(275,90,'Lease/Transpond.aspx?idlist='+$("hfcbID").value,'派单');
    }
}
function ViewQty(id)
{
    parent.ShowDialog(400, 300,'Lease/ViewQty.aspx?id='+id, '查看计数器');
}

function ModD()
{
    var id=document.getElementById("hfRecID2").value.replace("q","");
    if(id=="-1")
    {
        alert("请选择一条抄表记录后操作！");
    }
    else
    {
        parent.ShowDialog(460, 150,'Lease/ReadingMod.aspx?id='+id, '修改抄表');
    }
}
function ChkShowCharge()
{
    var id=document.getElementById("hfRecID2").value;
    if(id=="-1")
    {
        alert("请选择一条结算单明细后操作！");
    }
    else
    {
        parent.ShowDialog(700, 480,'Lease/ShowCharge.aspx?id='+id, '结算明细');
    }
}
function Chkset()
{
    Chkwhs();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("抄表登记");
}
function excelDetail()
{
    var id = document.getElementById("hfRecID").value;
    if(id == "" || id== "-1")
    {
        alert("请选择一条租赁单后操作");
        return false;
    }
    else
    {
        return true;
    }
}
</script>
