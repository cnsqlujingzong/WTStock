<%@ page language="C#"  CodeFile="sltfault.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_SltFault" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <div class="ftool">
        <div class="ftoolleft">
        <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td class="red">
                   <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">模糊查询</asp:ListItem>
                    <asp:ListItem Value="1">按故障编号查询</asp:ListItem>
                    <asp:ListItem Value="2">按产品类别查询</asp:ListItem>
                    <asp:ListItem Value="3">按维修类别查询</asp:ListItem>
                    <asp:ListItem Value="4">按故障类别查询</asp:ListItem>
                    <asp:ListItem Value="5">按故障查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
                </td><td align="left">
                    <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" />
                    <input id="btnNew" type="button" value="新建" class="bt1" onclick="parent.ShowDialog2(540, 200, '../Headquarters/Basic/FaultAdd.aspx?p=t'+strtel, '新建故障');" />
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
                </span>
            </td>
            </tr>
            </table>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="height:320px; width:600px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="产品类别" DataField="GoodsClass" />
            <asp:BoundField HeaderText="维修类别" DataField="RepairClass" />
            <asp:BoundField HeaderText="故障类别" DataField="TroubleClass" />
            <asp:BoundField HeaderText="故障编号" DataField="TroubleNO" />
            <asp:BoundField HeaderText="故障名称" DataField="Summary" />
            <asp:BoundField HeaderText="工分" DataField="dScore" />
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
        <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
        <asp:HiddenField ID="hfSql" runat="server" />
        <asp:HiddenField ID="hfcbID" runat="server" />
        <asp:HiddenField ID="hfcbInfo" runat="server" />
        <asp:HiddenField ID="hfInfo" runat="server" />
        <asp:HiddenField ID="hfScore" runat="server" />
        <asp:HiddenField ID="hfScoreInfo" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="Div1" style="height:120px; width:600px;">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1" class="tabs_activeleft"></span>
                <span id="tabs1" class="tabs_active" >处理措施</span>
                <span id="tabs_r1" class="tabs_activeright"></span>
            </div>
        </div>
        <div class="cndiv2" id="cndiv2" style="height:90px;width:635px;">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView1_RowDataBound"  EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="处理措施" DataField="Summary" />
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
            <span style="display:none;">
            <asp:Button ID="btnShow" runat="server" Text="显示" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="false"/></span>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
    </div>
    <div style="background:#ECE9D8;" >
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td><span class="si2">点选复选框进行选择，可多选</span></td>
            <td align="right" style="padding-right:20px;">
                <input id="btnAdd" type="button" value="确定" class="bt1" onclick="ChkPass();"/>
                <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();" />
            </td>
        </tr>
    </table>
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
var strtel="";
var uri=location.href;
var sum=0;
if(uri.indexOf("itel=1")>0)
    strtel="&itel=1";
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}
function ChkID2(id)
{
    ClrID2(id);
}
function ChkPass()
{
    var mid=$("hfcbID").value;
    mid=mid.substring(0,mid.length-1);
    mid=mid.replace(/\^/g,",");
    if(mid=="")
        mid=$("hfRecID").value;
    if(parent.<%=Str_Fid %>.$("hfFault"))
        parent.<%=Str_Fid %>.$("hfFault").value=mid;
    var m=$("hfcbInfo").value;
    var s=$("hfScoreInfo").value;
    m=m.substring(0,m.length-1);
    m=m.replace(/\^/g,",");
    if(m=="")
    {
        m=$("hfInfo").value;
        s=$("hfScore").value;
    }
    parent.<%=Str_Fid %>.$("tbFault").value=m;
    parent.<%=Str_Fid %>.$("tbPoint").value=s;
    parent.CloseDialog<%=Str_F %>();
}
function CbView(i,m,s,cb)
{
   if($(cb).checked)
    {
        $("hfcbID").value=$("hfcbID").value+i+"^";
        $("hfcbInfo").value=$("hfcbInfo").value+m+"^";
        sum+=parseFloat(s);
        $("hfScoreInfo").value=sum;
    }else
    {
        $("hfcbID").value=$("hfcbID").value.replace(i+"^","");
        $("hfcbInfo").value=$("hfcbInfo").value.replace(m+"^","");
        $("hfScoreInfo").value=s;
    }
}

function ChkValue(name)
{
    $("hfInfo").value=name;
}
function chkScore(score)
{
    $("hfScore").value=score;
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
