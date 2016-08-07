<%@ page language="C#"  CodeFile="repositoryadd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Repository_RepositoryAdd" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body onload="ChkSetFocus('tbTitle');">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:686px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td>知识标题：</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbTitle" runat="server" CssClass="pin" style="width:341px;"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>知识类别：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                        <td>访问级别：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlAccessLevel" runat="server" CssClass="pindl">
                                <asp:ListItem Value="1">开放</asp:ListItem>
                                <asp:ListItem Value="2">本部可见</asp:ListItem>
                                <asp:ListItem Value="3">网点可见</asp:ListItem>
                                <asp:ListItem Value="4">保密</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
               </table>
               <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td>查看权限：</td>
                        <td style="padding-left:0px;">
                            <asp:CheckBox ID="cb1" runat="server" Text="技术员" />
                            <asp:CheckBox ID="cb2" runat="server" Text="业务员" />
                            <asp:CheckBox ID="cb3" runat="server" Text="仓库管理员" />
                            <asp:CheckBox ID="cb4" runat="server" Text="受理员" />
                            <asp:CheckBox ID="cb5" runat="server" Text="财务人员" />
                        </td>
                    </tr>
               </table>
               <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td style="height:285px;padding-left:0px;">
                            <textarea id="content" runat="server" name="content" style="display:none"></textarea>
                            <iframe id="Editor" name="Editor" src="../../Public/Editor/index.html?ID=content" frameborder="0" marginheight="0" marginwidth="0" scrolling="no" style="height:280px;width:670px"></iframe>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
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
function ChkAdd()
{
    if(isNull($("tbTitle").value))
    {
        window.alert("操作失败！知识标题不能为空");
        $("tbTitle").focus();
        return false
    }
}
</script>
