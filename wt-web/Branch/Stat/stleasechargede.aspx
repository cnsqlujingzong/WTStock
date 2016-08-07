<%@ page language="C#"  CodeFile="stleasechargede.aspx.cs"     autoeventwireup="true" inherits="Branch_Stat_StLeaseChargeDe" theme="Themes" enableEventValidation="false" %>
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
            <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
            <asp:ListItem Value="OperationID">按单据编号查询</asp:ListItem>
                <asp:ListItem Value="_Date">按日期查询</asp:ListItem>
                <asp:ListItem Value="Person">按制单人查询</asp:ListItem>
                <asp:ListItem Value="Operator">按经办人查询</asp:ListItem>
                <asp:ListItem Value="CustomerName">按客户名称查询</asp:ListItem>
                <asp:ListItem Value="StockName">按仓库查询</asp:ListItem>
                <asp:ListItem Value="GoodsNO">按租赁机器查询</asp:ListItem>
                <asp:ListItem Value="Brand">按机器品牌查询</asp:ListItem>
                <asp:ListItem Value="Class">按类别查询</asp:ListItem>
                <asp:ListItem Value="Model">按型号查询</asp:ListItem>
                <asp:ListItem Value="ProductSN1">按序列号查询</asp:ListItem>
                <asp:ListItem Value="Remark">按备注查询</asp:ListItem>
                <asp:ListItem Value="strStatus">按状态查询</asp:ListItem>
                <asp:ListItem Value="-1">查询全部</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td>
                <input id="btnSchsH" type="button" value="高级查询" class="bsch" onclick="parent.ShowDialog(460,230, 'Stat/StLeaseCd.aspx', '高级查询');" />
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
            <asp:BoundField HeaderText="状态" DataField="strStatus" />
            <asp:BoundField HeaderText="结算单号" DataField="OperationID" />
            <asp:BoundField HeaderText="日期" DataField="_Date" />
            <asp:BoundField HeaderText="经办人" DataField="Operator" />
            <asp:BoundField HeaderText="所属" DataField="Dept" />
            <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
             <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="地址" DataField="Adr" />
            <asp:BoundField HeaderText="起始日期" DataField="StartDate" />
            <asp:BoundField HeaderText="终止日期" DataField="EndDate" />
            <asp:BoundField HeaderText="周期" DataField="Cycle" />
            <asp:BoundField HeaderText="上期计数" DataField="ShangQty" />
            <asp:BoundField HeaderText="本期计数" DataField="BenQty" />
            <asp:BoundField HeaderText="月租金" DataField="Rent" />
            <asp:BoundField HeaderText="超张费" DataField="SuperZhangFee" />
            <asp:BoundField HeaderText="合计应收" DataField="dRec" />
            <asp:BoundField HeaderText="现收金额" DataField="InCash" />
            <asp:BoundField HeaderText="已结算金额" DataField="HaveAmount" />
            <asp:BoundField HeaderText="未结算金额" DataField="NotChargeAmount" />
            <asp:BoundField HeaderText="业务类别" DataField="Type" />
            <asp:BoundField HeaderText="结算备注" DataField="Remark" />
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
    <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
    <div id="fbon" class="fbon"></div></td>
    <td>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <span class="bs1" style="color:#0000ff;">现收合计:<asp:Label ID="Label1" runat="server" Text=""></asp:Label></span>
            <span class="bs1" style="color:#ff0000;">已结算金额合计:<asp:Label ID="Label2" runat="server" Text=""></asp:Label></span>
            <span class="bs1" style="color:Black;">未结算金额合计:<asp:Label ID="Label3" runat="server" Text=""></asp:Label></span>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
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
}

function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("结算单明细表");
}
</script>
