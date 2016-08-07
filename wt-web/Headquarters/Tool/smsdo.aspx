<%@ page language="C#"  CodeFile="smsdo.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Tool_SmsDo" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa22" style="width:586px;">
    <div class="fdiv" style="height:292px;">
        <div class="sdiv2" style="height:290px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView2_RowDataBound" EnableViewState="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="RecID" />
                <asp:BoundField HeaderText="序" />
                <asp:BoundField HeaderText="接收号码" DataField="SndTo" />
                <asp:BoundField HeaderText="时间" DataField="SDate" />
                <asp:BoundField HeaderText="内容" DataField="Content" />
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <table cellpadding="0" cellspacing="0" class="pages">
            <tr>
                <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
                <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="当页显示数"></asp:Label></td>
                <td style="padding-left:8px;"><asp:Label ID="lbCountText" runat="server" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCount" runat="server" ToolTip="总记录数"></asp:Label></td>
            </tr>
        </table>
        </ContentTemplate>
           <Triggers>
               <asp:AsyncPostBackTrigger ControlID="btnSnd" EventName="Click"/>
               <asp:AsyncPostBackTrigger ControlID="btnSndDel" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
           </Triggers>
        </asp:UpdatePanel>
     </div>
     </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <asp:Button ID="btnSndDel" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('短信')==false) return false;" OnClick="btnSndDel_Click"/>
            <asp:Button ID="btnClean" runat="server" Text="清空" CssClass="bt1" OnClientClick="if(confirm('清空所有待发短信？')==false) return false;"  UseSubmitBehavior="false" OnClick="btnClean_Click"/>
        </td>
        <td align="right">
            <asp:Button ID="btnSnd" runat="server" Text="确认发送" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnSnd_Click" />
            <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();"/>
        </td>
    </tr>
    </table>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkID(id)
{
    ClrBaseID(id);
}

</script>
