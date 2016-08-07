<%@ page language="C#"  CodeFile="sltmodel.aspx.cs"     autoeventwireup="true" inherits="Branch_Services_SltModel" theme="Themes" enableeventvalidation="false" %>
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
                <td class="red">
                   模糊查询：
                </td>
                <td>
                    <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
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
                    <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                </span>
            </td>
            </tr>
            </table>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="height:440px; width:400px;">
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
            <asp:BoundField HeaderText="机器型号" DataField="_Name" />
            <asp:BoundField HeaderText="机器类别" DataField="ProductClass" />
            <asp:BoundField HeaderText="机器品牌" DataField="ProductBrand" />

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
        <asp:HiddenField ID="hfInfo2" runat="server" />
        <asp:HiddenField ID="hfInfo3" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div style="background:#ECE9D8;" >
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td><span class="si2"></span></td>
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
function ChkID(id)
{
    ClrID(id);
}
function ChkPass()
{
    var m=$("hfcbInfo").value;
    var n="";
    var p="";
    m=m.substring(0,m.length-1);
    m=m.replace(/\^/g,",");
    if(m=="")
        m=$("hfInfo").value;
        n=$("hfInfo2").value;
        p=$("hfInfo3").value;

   var ddlgradelevel=parent.<%=Str_Fid %>.$("ddlClass");
    for(var i=0;i<ddlgradelevel.options.length;i++)
    {
        if(ddlgradelevel.options[i].text==n)
        {
            ddlgradelevel.options[i].selected=true;
             parent.<%=Str_Fid %>.$("tbClass").value=n;
            
            break;
        }
    }

    var ddlgradelevelp=parent.<%=Str_Fid %>.$("ddlBrand");
    for(var i=0;i<ddlgradelevelp.options.length;i++)
    {
        if(ddlgradelevelp.options[i].text==p)
        {
            ddlgradelevelp.options[i].selected=true;
            parent.<%=Str_Fid %>.$("tbBrand").value=p;
            break;
        }
    }
    
    var ddlgradelevelm=parent.<%=Str_Fid %>.$("ddlModel");
    for(var i=0;i<ddlgradelevelm.options.length;i++)
    {
        if(ddlgradelevelm.options[i].text==m)
        {
            ddlgradelevelm.options[i].selected=true;
            parent.<%=Str_Fid %>.$("tbModel").value=m;
            break;
        }
    }
    parent.CloseDialog<%=Str_F %>();
}
function CbView(i,m,cb)
{
   if($(cb).checked)
    {
        $("hfcbID").value=$("hfcbID").value+i+"^";
        $("hfcbInfo").value=$("hfcbInfo").value+m+"^";
    }else
    {
        $("hfcbID").value=$("hfcbID").value.replace(i+"^","");
        $("hfcbInfo").value=$("hfcbInfo").value.replace(m+"^","");
    }
}

function ChkValue(name,name2,name3)
{
    $("hfInfo").value=name;
    $("hfInfo2").value=name2;
    $("hfInfo3").value=name3;
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
