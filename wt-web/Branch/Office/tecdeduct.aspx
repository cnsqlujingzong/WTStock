<%@ page language="C#"  CodeFile="tecdeduct.aspx.cs"     autoeventwireup="true" inherits="Branch_Office_TecDeduct" theme="Themes" enableEventValidation="false" %>
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
            <td class="red">网点：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" Width="100">
                </asp:DropDownList>
            </td>
            <td>是否收款：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlTypes" runat="server" CssClass="pindl" Width="100">
                    <asp:ListItem Value="">全部</asp:ListItem>
                    <asp:ListItem Value="已收款">已收款</asp:ListItem>
                    <asp:ListItem Value="未收款">未收款</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>业务日期：</td>   
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbStartDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox>
            </td>
            <td>至</td>
            <td>
                <asp:TextBox ID="tbEndDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" />
                <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('提成明细单')==false)return false;" OnClick="btnDel_Click" />
                <input id="btnMod" runat="server" type="button" value="发放" class="bt1" onclick="if(ChkView()==false)return false; " />
                </td>
                <td>
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
                </td>
            <td>
                <span style="display:none;">
                    <asp:Button ID="btnFsh" runat="server" Text="刷新" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnFsh_Click"/>
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
            </tr>
            </table> 
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="lndiv" class="lndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:TreeView ID="tvgds" runat="server" ShowLines="True" OnSelectedNodeChanged="tvgds_SelectedNodeChanged">
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
    <asp:GridView ID="gvgds" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvgds_RowDataBound" EnableViewState="false" ShowFooter="true">
        <Columns>
            <asp:BoundField HeaderText="ID"/>
            <asp:BoundField HeaderText="日期" DataField="Time_Finish" />
            <asp:BoundField HeaderText="编号" DataField="JobNO" />
            <asp:BoundField HeaderText="姓名" DataField="Operator" />
            <asp:BoundField HeaderText="所属" DataField="Dept"/>
            <asp:BoundField HeaderText="业务编号" DataField="BillID" />
            <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
            <asp:BoundField HeaderText="业务类别" DataField="Type" />
            <asp:BoundField HeaderText="是否收款" DataField="Types" />
            <asp:BoundField HeaderText="提成" DataField="Deduct" />
            <asp:BoundField HeaderText="RID" DataField="ID"/>
            <asp:BoundField HeaderText="客户编号" DataField="CustomerNO" />
            <asp:BoundField HeaderText="发放状态" DataField="IsComIssued"/>
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
        <asp:HiddenField ID="hfTbTitle" runat="server" />
        <asp:HiddenField ID="hfTbField" runat="server" />
        <asp:HiddenField ID="hfType" runat="server"/>
        <asp:HiddenField ID="hfRID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
        <asp:HiddenField ID="hfvalue" runat="server" Value="0" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
         <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tvgds" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div class="clearfloat"></div>
    <div class="fbom">  
    <div id="fbon" class="fbon">
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
function ChkID(id,strType,rid)
{
    ClrID(id);
    document.getElementById("hfType").value=strType;
    document.getElementById("hfRID").value=rid;
}
function Sell(id)
{
    parent.ShowDialog(800, 520,'Sell/SellMod.aspx?ids='+id,'销售单');
}
function Lease(id)
{
    parent.ShowDialog(698, 480,'Lease/ShowCharge.aspx?id=0&ids='+id, '结算明细');
}
function Services(id)
{
    parent.ShowDialog(860,444, 'Services/SerView.aspx?ids='+id, '服务单');
}
function Chkset()
{
    Chkwh3();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("员工提成明细");
}
function ChkView()
{
    if(document.getElementById("hfRID").value=="-1" || document.getElementById("hfRID").value=="" )
    {
        window.alert("请选中一条记录！");
        return false;
    }
    else
    {
        var id=document.getElementById("hfRID").value;
        var strType=document.getElementById("hfType").value;
    
        parent.ShowDialog(500,180, 'Office/IsComTc.aspx?id='+id +'&type='+escape(strType), '提成发放');

    }
}
</script>
