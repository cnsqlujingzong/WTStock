<%@ page language="C#"  CodeFile="membersadm.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_MembersAdm" theme="Themes" enableEventValidation="false" %>
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
        <div class="sdiv2" style="height:255px;">
        <asp:GridView ID="GridView1" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" Width="90%">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="序" />
                <asp:BoundField HeaderText="级别名称" DataField="_Name" />
                <asp:BoundField HeaderText="执行价格" DataField="Price" />
                <asp:BoundField HeaderText="折扣" DataField="Dis" />
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
        </div>
    </div>
    <div class="divh"></div>
    <div class="fdiv">
    <div class="sdiv">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb4">
            <tr>
                <td>等级名称：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" ToolTip="输入等级名称"></asp:TextBox>
                    <asp:HiddenField ID="hfTemp" runat="server" />
                </td>
            </tr>
            <tr>
                <td>执行价格：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlPrice" runat="server" CssClass="pindl">
                        <asp:ListItem Value="零售价">零售价</asp:ListItem>
                        <asp:ListItem Value="进货价">进货价</asp:ListItem>
                        <asp:ListItem Value="内部价">内部价</asp:ListItem>
                        <asp:ListItem Value="旧货价">旧货价</asp:ListItem>
                        <asp:ListItem Value="替代价">替代价</asp:ListItem>
                        <asp:ListItem Value="列表价">列表价</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>折扣：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDis" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
        </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <asp:Button ID="btnAdd" runat="server" Text="新建" CssClass="bt1" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click" UseSubmitBehavior="false" />
            <asp:Button ID="btnMod" runat="server" Text="修改" CssClass="bt1" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnMod_Click" UseSubmitBehavior="false" />
            <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel('会员级别')==false)return false;" OnClick="btnDel_Click" UseSubmitBehavior="false" />
        </td>
        <td align="right">
            <span style="display:none;">
            <asp:Button ID="btnShow" runat="server" Text="显示" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="false"/>
            </span>
            <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();"/> 
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
        if($("btnMod").value=="保存")
        {
            if(Chk()==false)return false;
        }
    }else{return false;}
}

function ChkAdd()
{
    if($("btnAdd").value=="保存")
    {
        if(Chk()==false)return false;
    }
}

//
function ChkFocus()
{
    $("tbName").select();
}

function Chk()
{
    if(isNull($("tbName").value))
    {
        window.alert("操作失败！级别名称不能为空");
        $("tbName").focus();
        return false
    }
    if(isNull($("tbDis").value))
    {
        window.alert("操作失败！折扣不能为空");
        $("tbDis").focus();
        return false
    }
    if(!isMoney($("tbDis").value))
    {
        window.alert("操作失败！折扣格式不正确");
        $("tbDis").focus();
        return false
    }
    if(parseFloat($("tbDis").value)>1||parseFloat($("tbDis").value)<0)
    {
        window.alert("操作失败！折扣必须在0.01至1之间");
        $("tbDis").focus();
        return false
    }
}
</script>
