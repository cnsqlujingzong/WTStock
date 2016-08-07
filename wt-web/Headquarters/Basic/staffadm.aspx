<%@ page language="C#"  CodeFile="staffadm.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_StaffAdm" theme="Themes" enableEventValidation="false" %>
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
                <input id="btnNew" type="button" value="新建" class="bt1" onclick="parent.ShowDialog(600, 430, 'Basic/StaffAdd.aspx', '新建员工');" />
                <input id="btnMod" type="button" value="修改" class="bt1" onclick="ChkMod(600, 430,'Basic/StaffMod.aspx','修改员工');" />
                <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('员工')==false) return false;" OnClick="btnDel_Click"/>
                <input id="btnSchLocation" type="button" value="查看位置" class="bt1" onclick="ChkMod(800, 600,'Basic/StSerMap.aspx','员工所在位置');" />
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
                    <input id="btnInput" runat="server" type="button" class="binput" value="导入" onclick="ChkInput();" />
                </td>
                <td>
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
                </td>
               <td>
                    <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                        <asp:ListItem Value="JobNO">按编号查询</asp:ListItem>
                        <asp:ListItem Value="_Name">按姓名查询</asp:ListItem>
                        <asp:ListItem Value="Sex">按性别查询</asp:ListItem>
                        <asp:ListItem Value="Tel">按电话查询</asp:ListItem>
                        <asp:ListItem Value="Adr">按地址查询</asp:ListItem>
                        <asp:ListItem Value="NativePlace">按籍贯查询</asp:ListItem>
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
    <asp:GridView ID="gvstaff" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvstaff_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="当前状态" DataField="Status" />
            <asp:BoundField HeaderText="编号" DataField="JobNO" />
            <asp:BoundField HeaderText="姓名" DataField="_Name" />
            <asp:BoundField HeaderText="岗位" DataField="Quarters" />
            <asp:BoundField HeaderText="籍贯" DataField="NativePlace" />
            <asp:BoundField HeaderText="性别" DataField="Sex" />
            <asp:BoundField HeaderText="电话" DataField="Tel" />
            <asp:BoundField HeaderText="区域" DataField="Area" />
            <asp:BoundField HeaderText="员工部门" DataField="StaffDept" />
            <asp:BoundField HeaderText="住址" DataField="Adr" />
            <asp:BoundField HeaderText="身份证号" DataField="CardID" />
            <asp:BoundField HeaderText="出生年月" DataField="BirthDate" />
            <asp:BoundField HeaderText="学历" DataField="Academic" />
            <asp:BoundField HeaderText="毕业院校" DataField="School" />
            <asp:BoundField HeaderText="专业" DataField="Specialty" />
            <asp:BoundField HeaderText="入职时间" DataField="JobDate" />
            <asp:BoundField HeaderText="底薪" DataField="Salary" />
            <asp:BoundField HeaderText="津贴" DataField="Allowance" />
            <asp:BoundField HeaderText="工资帐号" DataField="Account" />
            <asp:BoundField HeaderText="受理员" DataField="bDestClerk" />
            <asp:BoundField HeaderText="派工人员" DataField="bAllot" />
            <asp:BoundField HeaderText="技术员" DataField="bTechnician" />
            <asp:BoundField HeaderText="业务员" DataField="bSeller" />
            <asp:BoundField HeaderText="财务人员" DataField="bAccountant" />
            <asp:BoundField HeaderText="仓库管理员" DataField="bStockMan" />
            <asp:BoundField HeaderText="销售提成" DataField="SellDeduct" />
            <asp:BoundField HeaderText="维修提成" DataField="BillDeduct" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
            <asp:BoundField HeaderText="当前状态" DataField="Status" />
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
    </Triggers>       
    </asp:UpdatePanel>
    </div>
       
    <div class="fbom">  
    <div id="fbon" class="fbon">
    </div>
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
function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("员工目录");
}
function ChkInput()
{
    parent.ShowDialog(600, 499,'Basic/InputStaff.aspx?iflag=1', '导入员工');
}
</script>
