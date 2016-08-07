<%@ page language="C#"  CodeFile="sndsch.aspx.cs"     autoeventwireup="true" inherits="Branch_Receive_SndSch" theme="Themes" enableEventValidation="false" %>
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
            <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkConf('删除该[发货单]')==false)return false;" OnClick="btnDel_Click" />
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
                <input id="btnPrint" type="button" value="打印" class="iprint" onclick="ChkPrint('FHD');" />
                </td>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="BillID">按单据号查询</asp:ListItem>
                    <asp:ListItem Value="Operator">按经办人查询</asp:ListItem>
                    <asp:ListItem Value="OperationType">按业务类别查询</asp:ListItem>
                    <asp:ListItem Value="CorpName">按收件公司查询</asp:ListItem>
                    <asp:ListItem Value="LinkMan">按收件人查询</asp:ListItem>
                    <asp:ListItem Value="Tel">按联系电话查询</asp:ListItem>
                    <asp:ListItem Value="Summary">按货品摘要查询</asp:ListItem>
                    <asp:ListItem Value="SndStyle">按发货方式查询</asp:ListItem>
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
    <asp:GridView ID="gvbranch" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvbranch_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="标" />
            <asp:BoundField HeaderText="单据编号" DataField="BillID" />
            <asp:BoundField HeaderText="日期" DataField="_Date"/>
            <asp:BoundField HeaderText="制单人" DataField="Person" />
            <asp:BoundField HeaderText="经办人" DataField="Operator" />
            <asp:BoundField HeaderText="类别" DataField="OperationType" />
            <asp:BoundField HeaderText="收货类型" DataField="RcvType" />
            <asp:BoundField HeaderText="收货网点" DataField="RcvDept" />
            <asp:BoundField HeaderText="公司名称" DataField="CorpName" />
            <asp:BoundField HeaderText="收件人" DataField="LinkMan" />
            <asp:BoundField HeaderText="电话" DataField="Tel" />
            <asp:BoundField HeaderText="收货地址" DataField="Adr" />
            <asp:BoundField HeaderText="货品摘要" DataField="Summary" />
            <asp:BoundField HeaderText="发货方式" DataField="SndStyle" />
            <asp:BoundField HeaderText="物流单号" DataField="PostNO" />
            <asp:BoundField HeaderText="邮资" DataField="Postage" />
            <asp:BoundField HeaderText="签收时间" DataField="RcvDate" />
            <asp:BoundField HeaderText="签收人" DataField="SignMan" />
            <asp:BoundField HeaderText="状态" DataField="Status" />
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
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
       
    <div class="fbom">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td><div id="fbon" class="fbon"></div></td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <span style="color:Red;">邮资合计：<asp:Label ID="lbMoney" runat="server" Text="0"></asp:Label></span>
                    </ContentTemplate>  
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
                    </Triggers>     
                    </asp:UpdatePanel>
                </td>
                <td>
                    <span class="sblue">待发货确认</span>
                    <span class="sred">待收货确认</span>
                    <span class="sgreen">已签收</span>
                    <span class="sgay">被取消</span>
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

function ChkView()
{
    ChkMod(724,285, 'Receive/SndView.aspx', '发货单');
}

function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("发货单查询");
}
</script>
