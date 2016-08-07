<%@ page language="C#"  CodeFile="visitmod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_VisitMod" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:586px;">
            <div class="fdiv">
            <div class="sdiv" style="padding-left:0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td class="sysred">�ط����ݣ�</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbName" runat="server" Width="200"></asp:TextBox>
                        </td>
                        <td>��ע��</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbRemark" runat="server" Width="220"></asp:TextBox>
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
            <div class="fdiv">
            <div class="sdiv" style="height:227px;background:#ffffff;padding:0px;">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" SkinID="gv3" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField HeaderText="��" />
                        <asp:TemplateField HeaderText="�طý��">
                            <ItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("_Name") %>' Width="160"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���ͽ��">
                            <ItemTemplate>
                                <asp:TextBox ID="txtMoney" runat="server" Text='<%# Bind("dMoney") %>' Width="60"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��ע">
                            <ItemTemplate>
                                <asp:TextBox ID="txtRemark" runat="server" Text='<%# Bind("Remark") %>' Width="200"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ɾ��">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="ɾ��" style="color:#0000ff;"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:HiddenField ID="hfdellist" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAddTake" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td width="80">
                    <asp:Button ID="btnAddTake" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAddTake_Click"/>
                </td>
                <td>
                    <asp:CheckBox ID="cbbStop" runat="server" /><label for="cbbStop" style="color:Red;">ͣ��</label>
                </td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var isfocus=1;
var processtip=1;
function ChkAdd()
{
    if(isNull($("tbName").value))
    {
        window.alert("����ʧ�ܣ��ط����ݲ���Ϊ��");
        $("tbName").focus();
        return false
    }
}
</script>
