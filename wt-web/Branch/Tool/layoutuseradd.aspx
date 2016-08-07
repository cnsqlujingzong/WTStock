<%@ page language="C#"  CodeFile="layoutuseradd.aspx.cs"     autoeventwireup="true" inherits="Branch_Tool_LayoutUserAdd" enableEventValidation="false" %>
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
    <div id="sa" style="width:486px;">
    <div class="fdiv">
    <div class="sdiv">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td style="text-align:right;">用户名：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlUser" runat="server" CssClass="pslt" Width="205">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    布局分类：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlRight" runat="server" CssClass="pslt" Width="205">
                    </asp:DropDownList>
                </td>
            </tr>
       </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td><asp:Label ID="lbMod" runat="server"></asp:Label></td>
        <td align="right">
            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnSave_Click"/>
            <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog1();" />
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
function ChkAdd()
{
    if($("ddlUser").value=="-1")
    {
        window.alert("操作失败！用户名不能为空");
        $("ddlUser").focus();
        return false
    }
    if($("ddlRight").value=="")
    {
        window.alert("操作失败！布局分类不能为空");
        $("ddlRight").focus();
        return false
    }
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog1();}catch(e){}}}
</script>
