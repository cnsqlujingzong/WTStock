<%@ page language="C#"  CodeFile="layout.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Tool_Layout" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
                <td>
                    <input id="btnSure" type="button" value="�������" class="bt1" onclick="parent.ShowDialog1(600, 380, 'Tool/LayoutClass.aspx', '���ַ���');" />
                    <asp:Button ID="btnBackDefault" runat="server" Text="�ָ�Ĭ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(Backdefault()==false)return false;" OnClick="btnBackDefault_Click"/>
                    <input id="btnAdd" type="button" value="����û�" class="bt1" onclick="AddLayUser();" />
                    <asp:Button ID="btnDel" runat="server" Text="ɾ���û�" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('�����û�')==false)return false;" OnClick="btnDel_Click" />
                </td>
             </tr>
            </table>   
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                </span>
            </td>
            <td class="red">�������ƣ�</td>
            <td style="padding-left:0px; padding-right:200px;">
                <asp:DropDownList ID="ddlWinName" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlWinName_SelectedIndexChanged">
                    <asp:ListItem Value="1">��ƷĿ¼</asp:ListItem>
                    <asp:ListItem Value="2">��ǰ���</asp:ListItem>
                    <asp:ListItem Value="3">��Ʒ���</asp:ListItem>
                    <asp:ListItem Value="5">�������</asp:ListItem>
                    <asp:ListItem Value="6">����ȷ��</asp:ListItem>
                    <asp:ListItem Value="7">��������</asp:ListItem>
                    <asp:ListItem Value="8">���޷���</asp:ListItem>
                    <asp:ListItem Value="9">�ջ�����</asp:ListItem>
                    <asp:ListItem Value="10">��ʷ����</asp:ListItem>
                    <asp:ListItem Value="11">�깤����</asp:ListItem>
                    <asp:ListItem Value="12">����ط�</asp:ListItem>
                    <asp:ListItem Value="13">��˹ر�</asp:ListItem>
                    <asp:ListItem Value="14">���񵥲�ѯ</asp:ListItem>
                    <asp:ListItem Value="15">�ͻ�����</asp:ListItem>
                    <asp:ListItem Value="16">��������</asp:ListItem>
                    <asp:ListItem Value="17">��������</asp:ListItem>
                    <asp:ListItem Value="18">����Ŀ¼</asp:ListItem>
                    <asp:ListItem Value="19">Ա��Ŀ¼</asp:ListItem>
                    <asp:ListItem Value="20">�ط���ϸ��</asp:ListItem>
                </asp:DropDownList>
            </td>
            </tr>
            </table>
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="lndiv" class="lndiv" style="height:450px">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:TreeView ID="tv" runat="server" ShowLines="True" OnSelectedNodeChanged="tv_SelectedNodeChanged">
            <SelectedNodeStyle BackColor="#7d8abe" BorderColor="White" />
        </asp:TreeView>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="tv" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="lncn" class="uw" style="height:450px"></div>
    <div id="cndiv" style="float:left;height:450px;width:233px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvuser" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvuser_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="��" DataField="ID" />
            <asp:BoundField HeaderText="���ַ���" DataField="_Name" />
            <asp:BoundField HeaderText="�û���" DataField="UserName" />
        </Columns>
    </asp:GridView>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfClass" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tv" EventName="SelectedNodeChanged" />
        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="Div1" class="uw" style="height:450px"></div>
    <div id="Div2" style="float:left;height:420px;width:400px;overflow:auto;">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="˳��">
                <ItemTemplate>
                    <asp:TextBox ID="tbOrder" runat="server" Text='<%# Bind("_Order") %>' Height="15" Width="50"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��ʾ����">
                <ItemTemplate>
                    <asp:TextBox ID="tbName" runat="server" Text='<%# Bind("TitleName") %>' Height="15" Width="150"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��ʾ">
                <ItemTemplate>
                    <asp:CheckBox ID="cbbShow" runat="server" Checked='<%# Bind("bShow") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="FieldName" DataField="FieldName" />
        </Columns>
    </asp:GridView>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tv" EventName="SelectedNodeChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlWinName" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnBackDefault" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div class="fbombtn">
      <table cellpadding="0" cellspacing="0" class="tb3" width="100%">
            <tr>
            <td align="right" style="padding-right:7px;">
            <asp:Button ID="btnSave" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnSave_Click"/>
            <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog('1');"/>
            </td>
            </tr>
      </table>
    </div>
    <div class="clearfloat"></div>
    <div class="fbombtn">
    <span style="color:#0000ff; line-height:25px; padding-left:5px;">����ѡ�񲼾ַ���,�м���ʾ����������û�,�ұ���ʾҳ��������õ��ֶ�.</span>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkID(id)
{
    ClrID(id);
}
function AddLayUser()
{
    if($("hfClass").value==""||$("hfClass").value=="-1")
    {
        parent.ShowDialog1(500, 120, 'Tool/LayoutUserAdd.aspx', '���ַ���-����û�');
    }else{parent.ShowDialog1(500, 120, 'Tool/LayoutUserAdd.aspx?classid='+$("hfClass").value, '���ַ���-����û�');}
}
function Backdefault()
{
    if(confirm("ȷ��Ҫ�ָ�Ĭ����ʾ������"))
    {
        return true;
    }else{ return false;}
}
</script>
