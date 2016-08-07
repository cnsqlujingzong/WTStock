<%@ page language="C#"  CodeFile="stbillformdetail.aspx.cs"     autoeventwireup="true" inherits="Branch_Services_StBillFormDetail" theme="Themes" enableeventvalidation="false" %>
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
    <div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <div class="ftool">
    <table cellpadding="0" cellspacing="0" class="tb2"><tr><td>
        <asp:DropDownList ID="ddlSch" runat="server">
        <asp:ListItem Value = "1">按客户名称查询</asp:ListItem>
        <asp:ListItem Value = "2">按服务单状态查询</asp:ListItem>
        <asp:ListItem Value = "3">按受理人查询</asp:ListItem>
        <asp:ListItem Value ="4">按报修人查询</asp:ListItem>
        <asp:ListItem Value ="5">按报修人电话查询</asp:ListItem>
        <asp:ListItem Value ="6">按报故障查询</asp:ListItem>
        </asp:DropDownList></td>
        <td>
            <asp:TextBox ID="tbWhere" runat="server"></asp:TextBox></td>
        <td>
            <asp:Button ID="btnSch" runat="server" Text="查询" OnClick ="btnSch_Click" /></td>    
        </tr></table>
    </div>    
    <div style ="overflow-x:auto;overflow-y:auto;height:400px;width:825px;">
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1"  EnableViewState="false">
        <Columns>
         <asp:BoundField DataField ="BillID" HeaderText ="服务单号" /> 
         <asp:BoundField DataField ="curStatus" HeaderText ="服务状态" />
         <asp:BoundField DataField ="DisposalOper" HeaderText ="受理人" />
         <asp:BoundField DataField ="Time_Make" HeaderText ="受理时间" />
         <asp:BoundField DataField ="CustomerName" HeaderText ="客户名称" />
         <asp:BoundField DataField ="LinkMan" HeaderText ="报修人" />
         <asp:BoundField DataField ="Tel" HeaderText ="报修人电话" />
         <asp:BoundField DataField ="Fault" HeaderText ="故障" />
        </Columns>
    </asp:GridView>
    
    </div>
    </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID ="btnSch" EventName = "Click" />    
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
