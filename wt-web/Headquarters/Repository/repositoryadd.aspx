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
                        <td>֪ʶ���⣺</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbTitle" runat="server" CssClass="pin" style="width:341px;"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>֪ʶ���</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                        <td>���ʼ���</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlAccessLevel" runat="server" CssClass="pindl">
                                <asp:ListItem Value="1">����</asp:ListItem>
                                <asp:ListItem Value="2">�����ɼ�</asp:ListItem>
                                <asp:ListItem Value="3">����ɼ�</asp:ListItem>
                                <asp:ListItem Value="4">����</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
               </table>
               <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td>�鿴Ȩ�ޣ�</td>
                        <td style="padding-left:0px;">
                            <asp:CheckBox ID="cb1" runat="server" Text="����Ա" />
                            <asp:CheckBox ID="cb2" runat="server" Text="ҵ��Ա" />
                            <asp:CheckBox ID="cb3" runat="server" Text="�ֿ����Ա" />
                            <asp:CheckBox ID="cb4" runat="server" Text="����Ա" />
                            <asp:CheckBox ID="cb5" runat="server" Text="������Ա" />
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
                    <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();"/>
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
        window.alert("����ʧ�ܣ�֪ʶ���ⲻ��Ϊ��");
        $("tbTitle").focus();
        return false
    }
}
</script>
