<%@ page language="C#"  CodeFile="materialde.aspx.cs"     autoeventwireup="true" inherits="Branch_Stat_MaterialDe" theme="Themes" enableEventValidation="false" %>
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
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                <asp:ListItem Value="billid">按单据编号查询</asp:ListItem>
                <asp:ListItem Value="CustomerName">按客户名称查询</asp:ListItem>
                <asp:ListItem Value="LinkMan">按联系人查询</asp:ListItem>
                <asp:ListItem Value="UsePerson">按使用人查询</asp:ListItem>
                <asp:ListItem Value="UsePersonTel">按使用人电话查询</asp:ListItem>
                <asp:ListItem Value="Adr">按地址查询</asp:ListItem>
                <asp:ListItem Value="D_Name">按机器名称查询</asp:ListItem>
                <asp:ListItem Value="D_Parameters">按机器参数查询</asp:ListItem>
                <asp:ListItem Value="D_SN">按机器序列号查询</asp:ListItem>
                <asp:ListItem Value="D_Maint">按机器保修期查询</asp:ListItem>
                <asp:ListItem Value="D_BuyDate">按购买日期查询</asp:ListItem>
                
                <asp:ListItem Value="M_GoodsNO">按备件编号查询</asp:ListItem>
                <asp:ListItem Value="M_Name">按备件名称查询</asp:ListItem>
                <asp:ListItem Value="M_SN">按备件序列号查询</asp:ListItem>
                <asp:ListItem Value="M_MaintenancePeriod">按备件保修期查询</asp:ListItem>
                <asp:ListItem Value="-1">查询全部</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td>
                <input id="btnSchsH" type="button" value="高级查询" class="bsch" onclick="parent.ShowDialog(500,345, 'Stat/SchHMaterialDe.aspx', '高级查询');" />
            </td>
            <td>
            <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                    <td>
                        <span style="display:none;">
                            <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                            <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                            <asp:Button ID="btnSchH" runat="server" Text="高级查询" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />                   
                        </span>
                    </td>
                </tr>
            </table>   
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="statf" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="业务编号" DataField="billid" />
            <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="电话" DataField="Tel" />
            <asp:BoundField HeaderText="使用人" DataField="UsePerson" />
            <asp:BoundField HeaderText="使用人部门" DataField="UsePersonDept" />
            <asp:BoundField HeaderText="使用人电话" DataField="UsePersonTel" />
            <asp:BoundField HeaderText="地址" DataField="Adr" />
            <asp:BoundField HeaderText="机器名称" DataField="D_Name" />
            <asp:BoundField HeaderText="机器参数" DataField="D_Parameters" />
            <asp:BoundField HeaderText="机器序列号" DataField="D_SN" />
            <asp:BoundField HeaderText="机器保修期" DataField="D_Maint" />
            <asp:BoundField HeaderText="机器保修截止" DataField="D_MaintE" />
            <asp:BoundField HeaderText="购买日期" DataField="D_BuyDate" />
            <asp:BoundField HeaderText="机器备注" DataField="D_Remark" />
            <asp:BoundField HeaderText="备件编号" DataField="M_GoodsNO" />
            <asp:BoundField HeaderText="备件名称" DataField="M_Name" />
            <asp:BoundField HeaderText="备件单位" DataField="M_Unit" />
            <asp:BoundField HeaderText="备件数量"  DataField="M_Qty"/>
            <asp:BoundField HeaderText="备件价格" DataField="M_Price" />
            <asp:BoundField HeaderText="备件总额" DataField="M_Total" />
            <asp:BoundField HeaderText="已领数量"  DataField="M_LQty"/>
            <asp:BoundField HeaderText="备件序列号"  DataField="M_SN"/>
            <asp:BoundField HeaderText="备件保修期"  DataField="M_MaintenancePeriod"/>
            <asp:BoundField HeaderText="保修截止"  DataField="M_PeriodEndDate"/>
            <asp:BoundField HeaderText="备件成本"  DataField="M_CostPrice"/>
            <asp:BoundField HeaderText="备件备注"  DataField="M_Remark"/>

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
        <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
        <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
        <asp:HiddenField ID="hfSql" runat="server" />
        <asp:HiddenField ID="hfTbTitle" runat="server" />
        <asp:HiddenField ID="hfTbField" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
       
    <div class="fbom">  
    <div id="fbon" class="fbon"></div>
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
function ViewSN(strsn)
{
    parent.ShowDialog1(400, 300, 'Stock/ViewSN.aspx?sn='+escape(strsn), '查看序列号');
}
function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("备件明细汇总表");
}
</script>
