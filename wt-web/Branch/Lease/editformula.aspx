<%@ page language="C#"  CodeFile="editformula.aspx.cs"     autoeventwireup="true" inherits="Branch_Lease_EditFormula" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:386px;">
    <div class="fdivs" style="width:384px; height:205px;">
    <div class="sdivs"  style="width:382px; height:203px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
      <asp:GridView ID="gvdata" runat="server" SkinID="gv3" AutoGenerateColumns="False" OnRowDataBound="gvdata_RowDataBound" OnRowDeleting="gvdata_RowDeleting">
            <Columns>
                <asp:BoundField HeaderText="��"/>
                <asp:BoundField HeaderText="��ʼ����" DataField="StartQty" />
                <asp:BoundField HeaderText="��ֹ����" DataField="EndQty" />
                <asp:BoundField HeaderText="����" DataField="Price" />
                <asp:TemplateField HeaderText="ɾ��">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="ɾ��"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfFormula" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh">
    </div>
    <div class="fdivs" style="width:384px; height:33px;">
    <div class="sdivs"  style="width:382px; height:31px;">
        <table cellpadding="0" cellspacing="0" class="tb4">
        <tr>
            <td style="padding-left:15px;">
                ��ʼ������
            </td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbStartQty" runat="server" CssClass="pin" Width="50"></asp:TextBox>
            </td>
            <td>��ֹ������</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbEndQty" runat="server" CssClass="pin" Width="50"></asp:TextBox>
            </td>
            <td>���ۣ�</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbPrice" runat="server" CssClass="pin" Width="50"></asp:TextBox>
            </td>
         </tr>
        </table>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                
            </td>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="���" CssClass="bt1" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click" UseSubmitBehavior="false" />
                <input id="btnClose" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();" />
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
function ChkAdd()
{
    if(isNull($("tbStartQty").value))
    {
        window.alert("����ʧ�ܣ���ʼ��������Ϊ��");
        $("tbStartQty").focus();
        return false
    }
    if(!isDigit($("tbStartQty").value))
    {
        window.alert("��ʼ������ʽ����ȷ");
        $("tbStartQty").focus();
        return false
    }
    if(isNull($("tbEndQty").value))
    {
        window.alert("����ʧ�ܣ���ֹ��������Ϊ��");
        $("tbEndQty").focus();
        return false
    }
    if(!isDigit($("tbEndQty").value))
    {
        window.alert("��ֹ������ʽ����ȷ");
        $("tbEndQty").focus();
        return false
    }
    if(isNull($("tbPrice").value))
    {
        window.alert("����ʧ�ܣ����۲���Ϊ��");
        $("tbPrice").focus();
        return false
    }
    if(!isMoney($("tbPrice").value))
    {
        window.alert("���۸�ʽ����ȷ");
        $("tbPrice").focus();
        return false
    }
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
