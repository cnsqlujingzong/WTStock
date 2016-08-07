<%@ page language="C#"  CodeFile="starrage.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stat_StArrAge" theme="themes" enableEventValidation="false" %>
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
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>截止日期：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
            <td>客户名称：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCusName" runat="server" CssClass="pink"></asp:TextBox></td>
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
            </span>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="statf" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="序" />
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="网点" DataField="DeptName" />
            <asp:BoundField HeaderText="客户类型" DataField="CusType" />
            <asp:BoundField HeaderText="客户编号" DataField="CustomerNO" />
            <asp:BoundField HeaderText="客户名称" DataField="CustomerName"/>
            <asp:BoundField HeaderText="合计应收款" DataField="RecA" DataFormatString="{0:f2}"/>
            <asp:BoundField HeaderText="合计应付款" DataField="DueA" DataFormatString="{0:f2}" />
            <asp:BoundField HeaderText="1至30天应收款" DataField="Rec1" DataFormatString="{0:f2}" />
            <asp:BoundField HeaderText="1至30天应付款" DataField="Due1" DataFormatString="{0:f2}" />
            <asp:BoundField HeaderText="31至60天应收款" DataField="Rec2" DataFormatString="{0:f2}" />
            <asp:BoundField HeaderText="31至60天应付款" DataField="Due2" DataFormatString="{0:f2}" />
            <asp:BoundField HeaderText="61至90天应收款" DataField="Rec3" DataFormatString="{0:f2}" />
            <asp:BoundField HeaderText="61至90天应付款" DataField="Due3" DataFormatString="{0:f2}" />
            <asp:BoundField HeaderText="91至180天应收款" DataField="Rec4" DataFormatString="{0:f2}" />
            <asp:BoundField HeaderText="91至180天应付款" DataField="Due4" DataFormatString="{0:f2}" />
            <asp:BoundField HeaderText="181至360天应收款" DataField="Rec5" DataFormatString="{0:f2}" />
            <asp:BoundField HeaderText="181至360天应付款" DataField="Due5" DataFormatString="{0:f2}" />
            <asp:BoundField HeaderText="361至720天应收款" DataField="Rec6" DataFormatString="{0:f2}" />
            <asp:BoundField HeaderText="361至720天应付款" DataField="Due6" DataFormatString="{0:f2}" />
            <asp:BoundField HeaderText="721至1095天应收款" DataField="Rec7" DataFormatString="{0:f2}" />
            <asp:BoundField HeaderText="721至1095天应付款" DataField="Due7" DataFormatString="{0:f2}" />
            <asp:BoundField HeaderText="1096天以上应收款" DataField="Rec8" DataFormatString="{0:f2}" />
            <asp:BoundField HeaderText="1096天以上应付款" DataField="Due8" DataFormatString="{0:f2}" />
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="a.ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" Value="网点,客户类型,客户编号,客户名称,合计应收款,合计应付款,1至30天应收款,1至30天应付款,31至60天应收款,31至60天应付款,61至90天应收款,61至90天应付款,91至180天应收款,91至180天应付款,181至360天应收款,181至360天应付款,361至720天应收款,361至720天应付款,721至1095天应收款,721至1095天应付款,1096天以上应收款,1096天以上应付款" />
    <asp:HiddenField ID="hfTbField" runat="server" Value="DeptName,CusType,CustomerNO,CustomerName,RecA,DueA,Rec1,Due1,Rec2,Due2,Rec3,Due3,Rec4,Due4,Rec5,Due5,Rec6,Due6,Rec7,Due7,Rec8,Due8" />
    <asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
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
            <span class="bs1" style="color:#0000ff;">合计应收:<asp:Label ID="Label1" runat="server" Text=""></asp:Label></span>
            <span class="bs1" style="color:#ff0000;">合计应付:<asp:Label ID="Label2" runat="server" Text=""></asp:Label></span>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
function ChkID(id)
{
    ClrID(id);
}
function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function ChkView(id)
{
    parent.ShowDialog(870, 508,'Stat/StArrAgeDe.aspx?id='+id,'账龄明细');
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("应收应付帐龄表");
}
</script>
