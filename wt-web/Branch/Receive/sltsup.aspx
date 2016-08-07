<%@ page language="C#"  CodeFile="sltsup.aspx.cs"     autoeventwireup="true" inherits="Branch_Receive_SltSup" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <div class="ftool">
        <div class="ftoolleft">
        <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                    <asp:DropDownList ID="ddlKey" runat="server" onchange="document.getElementById('tbCon').focus();" CssClass="pindl">
                        <asp:ListItem Value="0">模糊查询</asp:ListItem>
                        <asp:ListItem Value="1">按厂商名称查询</asp:ListItem>
                        <asp:ListItem Value="2">按厂商编号查询</asp:ListItem>
                        <asp:ListItem Value="3">按联系人查询</asp:ListItem>
                        <asp:ListItem Value="4">按电话查询</asp:ListItem>
                        <asp:ListItem Value="5">按地址查询</asp:ListItem>
                        <asp:ListItem Value="6">按传真查询</asp:ListItem>
                        <asp:ListItem Value="7">按邮编查询</asp:ListItem>
                        <asp:ListItem Value="8">按Email查询</asp:ListItem>
                        <asp:ListItem Value="9">按备注查询</asp:ListItem>
                        <asp:ListItem Value="-1">查询全部</asp:ListItem>
                    </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
             </tr>
            </table>   
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td style="padding-right:50px;">
                <input id="btnAdd" type="button" value="确定" class="bt1" onclick="ChkSup();"/>
            </td>
            <td>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                </span>
            </td>
            </tr>
            </table>
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="lndiv" class="lndiv" style="height:460px">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:TreeView ID="tvsup" runat="server" ShowLines="True" OnSelectedNodeChanged="tvsup_SelectedNodeChanged">
            <SelectedNodeStyle BackColor="#7d8abe" BorderColor="White" />
        </asp:TreeView>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="tvsup" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="lncn" class="uw" style="height:460px"></div>
    <div id="cndiv" style="float:left;height:460px; width:635px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvsup" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvsup_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="厂商分类" DataField="ClassName" />
            <asp:BoundField HeaderText="厂商编号" DataField="SupNO" />
            <asp:BoundField HeaderText="厂商名称" DataField="_Name" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="电话" DataField="Tel" />
            <asp:BoundField HeaderText="手机号码" DataField="Tel2" />
            <asp:BoundField HeaderText="传真" DataField="Fax" />
            <asp:BoundField HeaderText="邮编" DataField="Zip" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="帐户" DataField="Account" />
            <asp:BoundField HeaderText="地址" DataField="Adr" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
        </Columns>
    </asp:GridView>
    <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="当页显示数"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="总记录数"></asp:Label></td>
        </tr>
    </table>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
        <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
        <asp:HiddenField ID="hfSql" runat="server" />
        <asp:HiddenField ID="hfClass" runat="server" />
        <asp:HiddenField ID="hfName" runat="server" />
        <asp:HiddenField ID="hfLinkMan" runat="server" />
        <asp:HiddenField ID="hfTel" runat="server" />
        <asp:HiddenField ID="hfAdr" runat="server" />
        <asp:HiddenField ID="hfZip" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tvsup" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div class="clearfloat"></div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript">
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
}
function ChkIDSup(strname,linkman,tel,adr,zip)
{
    $("hfName").value=strname;
    $("hfLinkMan").value=linkman;
    $("hfTel").value=tel;
    $("hfAdr").value=adr;
    $("hfZip").value=zip;
}
function ChkSup()
{
    if(ChkSlt()==false)
     return;
    
    try{
    parent.<%=Str_Fid %>.$("tbCusName").value=$("hfName").value;
    parent.<%=Str_Fid %>.$("tbLinkMan").value=$("hfLinkMan").value;
    parent.<%=Str_Fid %>.$("tbTel").value=$("hfTel").value;
    parent.<%=Str_Fid %>.$("tbAdr").value=$("hfAdr").value;
    parent.<%=Str_Fid %>.$("tbZip").value=$("hfZip").value;
    }catch(e){}
    parent.CloseDialog<%=Str_F %>();
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
