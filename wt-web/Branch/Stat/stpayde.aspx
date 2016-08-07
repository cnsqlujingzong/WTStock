<%@ page language="C#"  CodeFile="stpayde.aspx.cs"     autoeventwireup="true" inherits="Branch_Stat_StPayDe" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
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
            <td>日期从：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
            <td>到：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDateE" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
            <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="BillID">按单据编号查询</asp:ListItem>
                    <asp:ListItem Value="Type">按单据类型查询</asp:ListItem>
                    <asp:ListItem Value="_Date">按日期查询</asp:ListItem>
                    <asp:ListItem Value="Operator">按经办人查询</asp:ListItem>
                    <asp:ListItem Value="CustomerName">按往来单位查询</asp:ListItem>
                    <asp:ListItem Value="ChargeStyle">按结算方式查询</asp:ListItem>
                    <asp:ListItem Value="Account">按结算帐户查询</asp:ListItem>
                    <asp:ListItem Value="InvoiceClass">按发票类别查询</asp:ListItem>
                    <asp:ListItem Value="InvoiceNO">按发票号码查询</asp:ListItem>
                    <asp:ListItem Value="CheckNO">按支票号码查询</asp:ListItem>
                    <asp:ListItem Value="VoucherNO">按凭证号码查询</asp:ListItem>
                    <asp:ListItem Value="ChargeItem">按收支项目查询</asp:ListItem>
                    <asp:ListItem Value="ChkDate">按审核日期查询</asp:ListItem>
                    <asp:ListItem Value="ChkOperator">按审核人查询</asp:ListItem>
                    <asp:ListItem Value="Remark">按备注查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td>
            <td align="left">
                <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td>
                <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
            </td>
            </tr>
          </table>
        </div>
        <div class="ftoolright">
              <span style="display:none;">
                <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                <asp:Button ID="btnSchH" runat="server" Text="高级查询" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />
            </span>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="statf" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false" ShowFooter="true">
        <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="单据类别" DataField="type" />
                <asp:BoundField HeaderText="单据编号" DataField="billid" />
                <asp:BoundField HeaderText="所属" DataField="dept" />
                <asp:BoundField HeaderText="日期" DataField="_Date" />
                <asp:BoundField HeaderText="经办人" DataField="operator" />
                <asp:BoundField HeaderText="往来单位" DataField="customername" />
                <asp:BoundField HeaderText="应收款" DataField="DueMoney" />
                <asp:BoundField HeaderText="优惠金额" DataField="PreMoney" />
                <asp:BoundField HeaderText="实收款" DataField="RealDueMoney" />
                <asp:BoundField HeaderText="结算方式" DataField="ChargeStyle" />
                <asp:BoundField HeaderText="结算帐户" DataField="Account" />
                <asp:BoundField HeaderText="发票类别" DataField="InvoiceClass" />
                <asp:BoundField HeaderText="发票号码" DataField="InvoiceNO" />
                <asp:BoundField HeaderText="凭证号码" DataField="VoucherNO" />
                <asp:BoundField HeaderText="结算项目" DataField="ChargeItem" />
                <asp:BoundField HeaderText="审核日期" DataField="chkdate" />
                <asp:BoundField HeaderText="审核人" DataField="chkoperator" />
                <asp:BoundField HeaderText="备注" DataField="Remark" />
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    总记录：<asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
function ChkID(id)
{
    ClrID(id);
}
function ChkView()
{
    ChkMod(670,245, 'Financial/InPayView.aspx', '付款单');
}
function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("付款单明细表");
}
</script>
