<%@ page language="C#"  CodeFile="sltoublestepslist.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_SltoubleStepsList" theme="Themes" enableeventvalidation="false" %>
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
   <div class="ftool" style="height:58px;background:url(../../public/images/bg_tool2.jpg) repeat-x;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb2">
        <tr>
        <td>
            <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="true" Width="115" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
            <asp:ListItem Value="-1">��ѡ���Ʒ���</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            <asp:DropDownList ID="ddlRepClass" runat="server" AutoPostBack="true" Width="115" OnSelectedIndexChanged="ddlRepClass_SelectedIndexChanged">
            <asp:ListItem Value="-1">��ѡ��ά�����</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            <asp:DropDownList ID="ddlTroubClass" runat="server" AutoPostBack="true" Width="115" OnSelectedIndexChanged="ddlTroubClass_SelectedIndexChanged">
            <asp:ListItem Value="-1">��ѡ��������</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            <asp:DropDownList ID="ddlTroubleName" runat="server" AutoPostBack="true" Width="115" OnSelectedIndexChanged="ddlTroubleName_SelectedIndexChanged">
            <asp:ListItem Value="-1">��ѡ���������</asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        </table>
        </ContentTemplate>
        </asp:UpdatePanel>
        <div class="ftoolleft">
        <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td class="red">
                   ģ����ѯ��
                </td>
                <td>
                    <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
                </td><td align="left">
                    <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
                 </tr>
            </table>   
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                </span>
            </td>
            </tr>
            </table>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="height:413px; width:500px;">
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
            <asp:BoundField HeaderText="��Ʒ���" DataField="GoodsClass" />
            <asp:BoundField HeaderText="ά�����" DataField="RepairClass" />
            <asp:BoundField HeaderText="�������" DataField="TroubleClass" />
            <asp:BoundField HeaderText="��������" DataField="Summary" />
            <asp:BoundField HeaderText="�����ʩ" DataField="Take_Steps" />
        </Columns>
    </asp:GridView>
    <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" NumericButtonCount="5" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
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
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ddlProduct" EventName="SelectedIndexChanged"/>
        <asp:AsyncPostBackTrigger ControlID="ddlRepClass" EventName="SelectedIndexChanged"/>
        <asp:AsyncPostBackTrigger ControlID="ddlTroubClass" EventName="SelectedIndexChanged"/>
        <asp:AsyncPostBackTrigger ControlID="ddlTroubleName" EventName="SelectedIndexChanged"/>
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div style="background:#ECE9D8;" >
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td><span class="si2">��ѡ��ѡ�����ѡ�񣬿ɶ�ѡ</span></td>
            <td align="right" style="padding-right:20px;">
                <input id="btnAdd" type="button" value="ȷ��" class="bt1" onclick="ChkPass();"/>
                <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();" />
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
    var mid=$("hfcbID").value;
    mid=mid.substring(0,mid.length-1);
    mid=mid.replace(/\^/g,",");
    if(mid=="")
        mid=$("hfRecID").value;
    var m=$("hfcbInfo").value;
    m=m.substring(0,m.length-1);
    m=m.replace(/\^/g,",");
    if(m=="")
        m=$("hfInfo").value;

    if("<%=Str_X %>"=="2")
    {
        parent.<%=Str_Fid %>.$("tbTakeSteps").value=m;
        if(parent.<%=Str_Fid %>.$("hfTakeSteps"))
            parent.<%=Str_Fid %>.$("hfTakeSteps").value=mid;
    }
    else
    {
        parent.<%=Str_Fid %>.$("<%=Str_ID %>").value=m;
        if(parent.<%=Str_Fid %>.$("hfTakeSteps"))
            parent.<%=Str_Fid %>.$("hfTakeSteps").value=mid;
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

function ChkValue(name)
{
    $("hfInfo").value=name;
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
