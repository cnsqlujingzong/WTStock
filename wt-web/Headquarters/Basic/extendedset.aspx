<%@ page language="C#"  CodeFile="extendedset.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_ExtendedSet" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <div class="main">
    <div class="maincon">
    <div id="sa" style="width:586px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional" ChildrenAsTriggers="false">
    <ContentTemplate>
    
        <div class="fdiv" >
        <div class="sdiv2" style="height:256px;">
        <asp:GridView ID="GridView1" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" Width="90%">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="��" />
                <asp:BoundField HeaderText="Ʒ��" DataField="Brand" />
                <asp:BoundField HeaderText="���" DataField="Class" />
                <asp:BoundField HeaderText="��ʱ" DataField="dPoint" />
            </Columns>
        </asp:GridView>
        
        <table cellpadding="0" cellspacing="0" class="pages">
            <tr>
                <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
                <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
                <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
            </tr>
        </table>
            <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        </div>
    </div>
    <div class="divh"></div>
    <div class="fdiv">
    <div class="sdiv">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb4">
            <tr>
                <td>Ʒ�ƣ�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pindl" onchange="NewProductBrand();">
                    </asp:DropDownList>
                </td>
                <td align="right">���</td>
                <td style="padding-left:0px;">              
                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="pindl" onchange="NewProductClass();">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">��ʱ��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbPeriod" runat="server" CssClass="pin" ToolTip="�����׼��ʱ"></asp:TextBox>
                    <asp:HiddenField ID="hfBrand" runat="server" />
                    <asp:HiddenField ID="hfClass" runat="server" />
                    <asp:HiddenField ID="hfTemp" runat="server" />
                    <span style="display:none;">
                        <asp:Button ID="btnRefBrand" runat="server" Text="RefBrand" OnClick="btnRefBrand_Click" />
                        <asp:Button ID="btnRefClass" runat="server" Text="RefClass" OnClick="btnRefClass_Click" /></span>
                </td>
            </tr>
        </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnRefBrand" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnRefClass" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <asp:Button ID="btnAdd" runat="server" Text="�½�" CssClass="bt1" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click" UseSubmitBehavior="false" />
            <asp:Button ID="btnMod" runat="server" Text="�޸�" CssClass="bt1" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnMod_Click" UseSubmitBehavior="false" />
            <asp:Button ID="btnDel" runat="server" Text="ɾ��" CssClass="bt1" OnClientClick="if(ChkDel('���ڵ�')==false)return false;" OnClick="btnDel_Click" UseSubmitBehavior="false" />
        </td>
        <td align="right">
            <span style="display:none;">
            <asp:Button ID="btnShow" runat="server" Text="��ʾ" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="false"/>
            </span>
            <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();"/> 
        </td>
    </tr>
    </table>
    
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnMod" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="jsPager" EventName="PageChanged" />
        </Triggers>
        </asp:UpdatePanel>
    </div>
    </div>
    </div>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript" src="../../Public/Script/menu.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkID(id)
{
    ClrBaseID(id);
    $("btnShow").click();
}

function ChkSave()
{
    if(ChkSlt()!=false)
    {
        if($("btnMod").value=="����")
        {
            if(Chk()==false)return false;
        }
    }else{return false;}
}

function ChkAdd()
{
    if($("btnAdd").value=="����")
    {
        if(Chk()==false)return false;
    }
}

//
function ChkFocus()
{
    $("tbPeriod").select();
}

function Chk()
{
    if($("ddlBrand").value=="-1")
    {
        window.alert("����ʧ�ܣ�Ʒ�Ʋ���Ϊ��");
        $("ddlBrand").focus();
        return false
    }
    if($("ddlClass").value=="-1")
    {
        window.alert("����ʧ�ܣ������Ϊ��");
        $("ddlClass").focus();
        return false
    }
    if(isNull($("tbPeriod").value))
    {
        window.alert("����ʧ�ܣ���ʱ����Ϊ��");
        $("tbPeriod").focus();
        return false
    }
}
</script>
