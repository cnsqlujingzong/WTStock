<%@ page language="C#"  CodeFile="sltdevconfitem.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_SltDevConfItem" theme="Themes" enableEventValidation="false" %>
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
                        <asp:ListItem Value="_Name">按名称查询</asp:ListItem>
                        <asp:ListItem Value="Parameter">按参数查询</asp:ListItem>
                        <asp:ListItem Value="MaintenancePeriod">按保修期查询</asp:ListItem>
                        <asp:ListItem Value="Remark">按备注查询</asp:ListItem>
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
            <td>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                </span>
            </td>
            <td style="padding-right:80px;">
                <input id="btnAdd" type="button" value="确定" class="bt1" onclick="ChkSltList();"/>
            </td>
            </tr>
            </table>
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="lndiv" class="lndiv" style="height:480px">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:TreeView ID="tv" runat="server" ShowLines="True" OnSelectedNodeChanged="tv_SelectedNodeChanged">
            <SelectedNodeStyle BackColor="#7d8abe" BorderColor="White" />
        </asp:TreeView>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="tv" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="lncn" class="uw" style="height:480px"></div>
    <div id="cndiv" style="float:left;height:480px;width:635px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvcus" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvcus_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderTemplate>
                    <input id="cball" type="checkbox" class="cb1" onclick="allcb();" title="全选/取消全选"/>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="类别" DataField="ProductClass" />
            <asp:BoundField HeaderText="名称" DataField="_Name" />
            <asp:BoundField HeaderText="参数" DataField="Parameter" />
            <asp:BoundField HeaderText="保修期" DataField="MaintenancePeriod" />
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
        <asp:HiddenField ID="hfreclist" runat="server" />
        <asp:HiddenField ID="hfClass" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tv" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div class="clearfloat"></div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
}

function ChkSltList()
{
    var list=document.getElementById("hfreclist").value;
    
    if(list=="")
        list=document.getElementById("hfRecID").value;
        
    if(list==""||list=="-1")
    {
        alert("操作失败！请选择后操作.");return false;
    }else{
    try{
    parent.<%=Str_Fid %>.$("hfRecID").value=list;
    parent.<%=Str_Fid %>.document.getElementById("btnId").click();
    }catch(e){alert("系统错误！请刷新后重试");}
    parent.CloseDialog<%=Str_F %>();
    }
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
