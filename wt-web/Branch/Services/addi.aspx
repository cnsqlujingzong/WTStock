<%@ page language="C#"  CodeFile="addi.aspx.cs"     autoeventwireup="true" inherits="Branch_Services_AddI" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:786px;">
    <div class="fdivs" style="height:316px; width:784px;">
    <div class="sdivs" style="height:314px; width:782px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView2_RowDataBound" OnRowDeleting="GridView2_RowDeleting">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ItemID" />
                <asp:BoundField HeaderText="��"/>
                <asp:BoundField HeaderText="��Ŀ���" DataField="ItemNO" />
                <asp:BoundField HeaderText="����" DataField="_Name" />
                <asp:TemplateField HeaderText="���">
                    <ItemTemplate>
                        <asp:TextBox ID="tbPrice" runat="server" Text='<%# Eval("Price") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="��ʱ">
                    <ItemTemplate>
                        <asp:TextBox ID="tbdPoint" runat="server" Text='<%# Eval("dPoint") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="���">
                    <ItemTemplate>
                        <asp:TextBox ID="tbTecDeduct" runat="server" Text='<%# Eval("TecDeduct") %>' CssClass="tbstyle" onfocus='<%#strFocus() %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="����Ա">
                    <ItemTemplate>
                        <asp:TextBox ID="tbTec" runat="server" Text='<%# Eval("Tec") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                        <input id="btnsch" name="btnsch" type="button" value="" runat="server" class="sch_btn" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="���㷽ʽ">
                    <ItemTemplate>
                        <asp:TextBox ID="tbChargeStyle" runat="server" Text='<%# Eval("ChargeStyle") %>' style="display:none;"></asp:TextBox>
                        <asp:DropDownList ID="ddlChargeStyle" runat="server">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="�Ƿ��깤">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbbComplete" runat="server" Checked='<%# Eval("bComplete") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="��ע">
                    <ItemTemplate>
                        <asp:TextBox ID="tbRemark" runat="server" Text='<%# Eval("Remark") %>' CssClass="tbstyle" Width="170"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ɾ��">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="ɾ��" style="color:#0000ff;"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
            <asp:HiddenField ID="hfdellist2" runat="server" />
            <asp:HiddenField ID="hfreclist2" runat="server" Value="-1" />
            <asp:HiddenField ID="hfmoddet" runat="server" Value="-1" />
             <span style="display:none;">
             <asp:Button ID="btnId2" runat="server" Text="..." OnClick="btnId2_Click" />
             <asp:Button ID="btnSure2" runat="server" Text="..." OnClick="btnSure2_Click" />
             </span>
        </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    </div>
    <div id="Div5" class="devtemadd">
        <table cellpadding="0" cellspacing="0" class="tb4">
            <tr>
             <td style="padding-left:15px;">
                <asp:DropDownList ID="ddlSchFld2" runat="server" CssClass="pindl" Width="70">
                    <asp:ListItem Value="ItemNO">�����</asp:ListItem>
                    <asp:ListItem Value="_Name">������</asp:ListItem>
                </asp:DropDownList>
            </td>
                <td>
                   <asp:TextBox ID="tbConInfo2" runat="server" CssClass="pin" onkeydown="EnterTextBoxItem(event, this);" ToolTip="������ɺ�س����"></asp:TextBox>
                </td>
                <td>
                    <input id="btnSltItem" type="button" value="ѡ����Ŀ" class="bt1" onclick="parent.ShowDialog1(800, 520, 'Basic/SltSerItem.aspx?flag=1', 'ѡ����Ŀ');" />
                </td>
            </tr>
        </table>
    </div>
    
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right">
            <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/detailslt.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var processtip=1;
function ChkID(id)
{
    ClrID(id);
}

function EnterTextBoxItem(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            $("btnSure2").click();
        }
    }
}
function SltTec(strid)
{
    parent.ShowDialog1(400, 510, 'Services/SltTec.aspx?f=1&x=1&strid='+strid, '����Ա');
}
</script>
