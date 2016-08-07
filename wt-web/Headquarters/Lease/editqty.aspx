<%@ page language="C#"  CodeFile="editqty.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Lease_EditQty" theme="Themes" enableEventValidation="false" %>
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
    <div id="sad" style="width:586px;">
    <div class="fdivs" style="width:584px; height:225px;">
    <div class="sdivs"  style="width:582px; height:223px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
      <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" OnRowDeleting="gvdata_RowDeleting">
        <Columns>
        <asp:BoundField HeaderText="��" />
        <asp:BoundField HeaderText="����������" DataField="QtyType" />
        <asp:TemplateField HeaderText="�ڳ�����">
            <ItemTemplate>
                <asp:TextBox ID="tbBeginQty" runat="server" CssClass="tbstyle" Text='<%# Eval("BeginQty") %>' onfocus="select();"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="���">
            <ItemTemplate>
                <asp:TextBox ID="tbRated" runat="server" Text='<%# Eval("Rated") %>' Width="80" CssClass="tbstyle" onfocus="select();"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="���ŷ�">
            <ItemTemplate>
                <asp:TextBox ID="tbSuperZhangFee" runat="server" CssClass="tbstyle" Text='<%# Eval("SuperZhangFee") %>' onfocus="select();"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="���ųɱ�">
            <ItemTemplate>
                <asp:TextBox ID="tbCostPrice" runat="server" CssClass="tbstyle" Text='<%# Eval("CostPrice") %>' onfocus="select();"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="�Ʒѷ�ʽ">
            <ItemTemplate>
                <asp:TextBox ID="tbChargeStyle" runat="server" Text='<%# Eval("ChargeStyle") %>' style="display:none;"></asp:TextBox>
                <asp:DropDownList ID="ddlCalStyle" runat="server" CssClass="pindl" Width="120">
                </asp:DropDownList>
                <asp:TextBox ID="tbFormula" runat="server" style="display:none;" Text='<%# Eval("Formula") %>'></asp:TextBox>
                <asp:HyperLink ID="hlFormula" runat="server" style="display:none;" NavigateUrl="#" ToolTip="�༭��ʽ">�༭��ʽ</asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ɾ��">
            <ItemTemplate>
                <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="ɾ��" style="color:#0000ff;"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfFormula" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnConf" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh">
    </div>
    <div class="fdivs" style="width:584px; height:93px;">
    <div class="sdivs"  style="width:582px; height:91px;">
        <table cellpadding="0" cellspacing="0" class="tb4">
        <tr>
            <td style="padding-left:15px;">
                ���������ͣ�
            </td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlQtyType" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td align="right">�ڳ�������</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbStartQty" runat="server" CssClass="pin"></asp:TextBox>
            </td>
            
         </tr>
         <tr>
            <td align="right">�����</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbRated" runat="server" CssClass="pin"></asp:TextBox>
            </td>
            <td align="right">
                ���ŷѣ�
            </td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbSuperZhangFee" runat="server" CssClass="pin"></asp:TextBox>
            </td>
            
         </tr>
         <tr>
            <td align="right">
                ���ųɱ���
            </td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbCostPrice" runat="server" CssClass="pin"></asp:TextBox>
            </td>
            <td align="right">
                �Ʒѷ�ʽ��
            </td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlCalStyle" runat="server" CssClass="pindl">
                    <asp:ListItem Value="1">��׼�Ʒѷ�</asp:ListItem>
                    <asp:ListItem Value="2">���ݼƷѷ�</asp:ListItem>
                    <asp:ListItem Value="3">�ϲ��Ʒѷ�</asp:ListItem>
                    <asp:ListItem Value="6">����Ʒѷ�</asp:ListItem>
                    <asp:ListItem Value="7">δӡ���õֳ䷨</asp:ListItem>
                    <asp:ListItem Value="4">������(����)�Ʒѷ�</asp:ListItem>
                    <asp:ListItem Value="5">������(������)�Ʒѷ�</asp:ListItem>
                    <asp:ListItem Value="8">ȫ��ӡ��ƽ����</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="���" CssClass="bt1" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click" UseSubmitBehavior="false" />
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
                <asp:Button ID="btnConf" runat="server" Text="ȷ��" CssClass="bt1" OnClick="btnConf_Click" UseSubmitBehavior="false" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkAdd()
{
    if($("ddlQtyType").value=="-1")
    {
        window.alert("����ʧ�ܣ����������Ͳ���Ϊ��");
        $("ddlQtyType").focus();
        return false
    }
    if(isNull($("tbStartQty").value))
    {
        window.alert("����ʧ�ܣ��ڳ���������Ϊ��");
        $("tbStartQty").focus();
        return false
    }
    if(!isDigit($("tbStartQty").value))
    {
        window.alert("�ڳ�������ʽ����ȷ");
        $("tbStartQty").focus();
        return false
    }
    if(isNull($("tbRated").value))
    {
        window.alert("����ʧ�ܣ��������Ϊ��");
        $("tbRated").focus();
        return false
    }
    if(!isDigit($("tbRated").value))
    {
        window.alert("�����ʽ����ȷ");
        $("tbRated").focus();
        return false
    }
    if(isNull($("tbSuperZhangFee").value))
    {
        window.alert("����ʧ�ܣ����ŷѲ���Ϊ��");
        $("tbSuperZhangFee").focus();
        return false
    }
    if(!isMoney($("tbSuperZhangFee").value))
    {
        window.alert("���ŷѸ�ʽ����ȷ");
        $("tbSuperZhangFee").focus();
        return false
    }
    if(isNull($("tbCostPrice").value))
    {
        window.alert("����ʧ�ܣ����ųɱ�����Ϊ��");
        $("tbCostPrice").focus();
        return false
    }
    if(!isMoney($("tbCostPrice").value))
    {
        window.alert("���ųɱ���ʽ����ȷ");
        $("tbCostPrice").focus();
        return false
    }
}
function ChkStyle(CalStyle,hlxFormula)
{
    if($(CalStyle).value=="2")
        $(hlxFormula).style.display = "inline";
    else
        $(hlxFormula).style.display = "none";
}

function EditFormula(tbFormula)
{
    parent.ShowDialog2(400, 300, 'Lease/EditFormula.aspx?ff=<%=Str_FF %>&tbformula='+tbFormula+'&formula='+escape($(tbFormula).value), '�༭��ʽ');
}

document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
