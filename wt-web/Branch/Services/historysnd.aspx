<%@ page language="C#"  CodeFile="historysnd.aspx.cs"     autoeventwireup="true" inherits="Branch_Services_HistorySnd" theme="Themes" enableEventValidation="false" %>
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
            <td>
            <asp:Button ID="btnFsh" runat="server" Text="刷新" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnFsh_Click"/>
            <input id="btnMod" type="button" value="明细" class="bt1" onclick="ChkView();" />
            <span style="display:none;">
                <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                <asp:Button ID="btnSchH" runat="server" Text="高级查询" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />
            </span>
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">模糊查询</asp:ListItem>
                    <asp:ListItem Value="1">按服务单号查询</asp:ListItem>
                    <asp:ListItem Value="20">按送修厂商查询</asp:ListItem>
                    <asp:ListItem Value="2">按服务类别查询</asp:ListItem>
                    <asp:ListItem Value="3">按受理部门查询</asp:ListItem>
                    <asp:ListItem Value="4">按处理部门查询</asp:ListItem>
                    <asp:ListItem Value="5">按受理方式查询</asp:ListItem>
                    <asp:ListItem Value="6">按服务级别查询</asp:ListItem>
                    <asp:ListItem Value="7">按受理人查询</asp:ListItem>
                    <asp:ListItem Value="8">按客户名称查询</asp:ListItem>
                    <asp:ListItem Value="9">按联系人查询</asp:ListItem>
                    <asp:ListItem Value="10">按客户电话查询</asp:ListItem>
                    <asp:ListItem Value="11">按客户地址查询</asp:ListItem>
                    <asp:ListItem Value="12">按机器型号查询</asp:ListItem>
                    <asp:ListItem Value="13">按机器品牌查询</asp:ListItem>
                    <asp:ListItem Value="14">按机器类别查询</asp:ListItem>
                    <asp:ListItem Value="15">按机器序列号查询</asp:ListItem>
                    <asp:ListItem Value="16">按维修技术员查询</asp:ListItem>
                    <asp:ListItem Value="17">按故障查询</asp:ListItem>
                    <asp:ListItem Value="18">按保修情况查询</asp:ListItem>
                    <asp:ListItem Value="19">按备注查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server"  onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td>
            <td align="left">
            <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td style="padding:0px;"><input id="btnSchsH" type="button" value="高级查询" class="bsch" onclick="parent.ShowDialog(470,428, 'Services/SerCd.aspx', '高级查询');" /></td>
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
            <asp:BoundField HeaderText="当前状态" DataField="curStatus" />
            <asp:BoundField HeaderText="服务单号" DataField="BillID" />
            <asp:BoundField HeaderText="服务类别" DataField="ServicesType" />
            <asp:BoundField HeaderText="送修类别" DataField="RepairType" />
            <asp:BoundField HeaderText="送修厂商" DataField="RepairCorp" />
            <asp:BoundField HeaderText="受理人" DataField="Operator" />
            <asp:BoundField HeaderText="受理时间" DataField="Time_TakeOver" />
            <asp:BoundField HeaderText="受理方式" DataField="TakeStyle" />
            <asp:BoundField HeaderText="受理部门" DataField="TakeDept" />
            <asp:BoundField HeaderText="服务级别" DataField="_PRI" />
            <asp:BoundField HeaderText="技术员" DataField="DisposalOper" />  
            <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
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
    <asp:HiddenField ID="hfcbID" runat="server" />
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
       
    <div class="fbom">  
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><div id="fbon" class="fbon"></div></td>
            <td>
                <span class="sblue">待结算</span>
                <span class="sgreen">待回访</span>
                <span class="sblack">待审核</span>
                <span class="stin">已结束</span>
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
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
}

function SltValue(i,cb)
{
   if($(cb).checked)
    {
        $("hfcbID").value=$("hfcbID").value+i+",";
    }else
    {
        $("hfcbID").value=$("hfcbID").value.replace(i+",","");
    }
}

function ChkSltValue()
{
    if(isNull($("hfcbID").value)&&$("hfcbID").value=="-1")
    {
        alert("请打勾选择记录后操作！");
        return false
    }
}

function ChkCancel()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;

    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(460,100, 'Services/Cancel.aspx?id='+id, '取消工单');
    }else{return false;}
}
function ChkRepair()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;

    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(460,128, 'Services/Repair.aspx?id='+id, '送修');
    }else{return false;}
}
function ChkSelf()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;

    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(460,100, 'Services/Self.aspx?id='+id, '自修');
    }else{return false;}
}
function ChkDispatching()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;

    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(460,100, 'Services/Dispatching.aspx?id='+id, '派工');
    }else{return false;}
}

function ChkView()
{
    ChkMod(860,444, 'Services/SerView.aspx', '服务单');
}
function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("历史送修");
}
</script>
