<%@ page language="C#"  CodeFile="expensede.aspx.cs"     autoeventwireup="true" inherits="ExpenseDe" theme="Themes" enableeventvalidation="false" %>
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
            <span style="display:none;">
                <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('[报销申请]')==false)return false;" OnClick="btnDel_Click" />
                <asp:Button ID="btnChkU" runat="server" Text="反审核" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkU()==false)return false;" OnClick="btnChkU_Click" />
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
                <td>
                    <input id="btnPrint" runat="server" type="button" value="打印" class="iprint" onclick="ChkPrint('BXD');" />
                </td>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                    <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="keychange();">
                    <asp:ListItem Value="RelatedBusiness">按关联业务</asp:ListItem>
                    <asp:ListItem Value="Operator">按报销人查询</asp:ListItem>
                    <asp:ListItem Value="_Date">按申请日期查询</asp:ListItem>
                    <asp:ListItem Value="dMoney">按金额查询</asp:ListItem>
                    <asp:ListItem Value="Summary">按摘要查询</asp:ListItem>
                    <asp:ListItem Value="ChkDate">按审核日期查询</asp:ListItem>
                    <asp:ListItem Value="ChkOperator">按审核人查询</asp:ListItem>
                    <asp:ListItem Value="PaymentDate">按发放日期查询</asp:ListItem>
                    <asp:ListItem Value="PaymentOper">按发放人查询</asp:ListItem>
                    <asp:ListItem Value="Account">按付款帐户查询</asp:ListItem>
                    <asp:ListItem Value="Item">按收支项目查询</asp:ListItem>
                    <asp:ListItem Value="Remark">按备注查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td>
            <td id="tdend" style="display:none;">
                <asp:TextBox ID="tbDateE" runat="server" CssClass="pink"></asp:TextBox>
            </td>
            <td align="left">
            <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td style="padding:0px;"><input id="btnSchsH" type="button" value="高级查询" class="bsch" onclick="parent.ShowDialog(470,286, 'Financial/SchExpenseCd.aspx', '高级查询');" />
            </td>
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
            <asp:BoundField HeaderText="部门" DataField="Dept" />
            <asp:BoundField HeaderText="申请日期" DataField="_Date" />
            <asp:BoundField HeaderText="报销人" DataField="Operator" />
            <asp:BoundField HeaderText="金额" DataField="dMoney" />
            <asp:BoundField HeaderText="关联业务" DataField="RelatedBusiness" />
            <asp:BoundField HeaderText="摘要" DataField="Summary" />
            <asp:BoundField HeaderText="审核日期" DataField="ChkDate" />
            <asp:BoundField HeaderText="审核人" DataField="ChkOperator" />
            <asp:BoundField HeaderText="发放日期" DataField="PaymentDate" />
            <asp:BoundField HeaderText="发放人" DataField="PaymentOper" />
            <asp:BoundField HeaderText="付款帐户" DataField="Account" />
            <asp:BoundField HeaderText="收支项目" DataField="Item" />
            <asp:BoundField HeaderText="出发地点" DataField="FromAdr" />
            <asp:BoundField HeaderText="目的地点" DataField="ToAdr" />
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
    <asp:HiddenField ID="hfTbFieldDetail" runat="server" />
    <asp:HiddenField ID="hfTbTitleDetail" runat="server" />
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkU" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    
    <div class="fbom">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
    <div id="fbon" class="fbon"></div></td>
    <td>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <span class="bs1" style="color:#ff0000; display:none;">未审核金额:<asp:Label ID="Label1" runat="server" Text=""></asp:Label></span>
            <span class="bs1" style="color:#0000ff;display:none;">未发放金额:<asp:Label ID="Label2" runat="server" Text=""></asp:Label></span>
            <span class="bs1" style="color:green;">已完成金额:<asp:Label ID="Label3" runat="server" Text=""></asp:Label></span>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
         <asp:AsyncPostBackTrigger ControlID="btnChkU" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
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
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
    document.getElementById("btnShow").click();
}

function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function ModBill()
{
    ChkMod(840, 480,'Financial/ExpenseMod.aspx','报销明细');
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("报销查询");
}
function ChkU()
{
    if(ChkSlt()!=false)
    {
        if(confirm("确定要反审核该申请单吗？"))
        {
         return true;
        }  
        else
         return false;
    }else
    return false
}
function keychange()
{
    if($("ddlKey").value=="_Date"||$("ddlKey").value=="ChkDate"||$("ddlKey").value=="PaymentDate")
    {
        $("tdend").style.display="";
    }else
    {
        $("tdend").style.display="none";
    }
    document.getElementById('tbCon').focus();
}
</script>
