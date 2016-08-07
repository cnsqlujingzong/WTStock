<%@ page language="C#"  CodeFile="editsn.aspx.cs"     autoeventwireup="true" inherits="Branch_Stock_EditSN" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
                <asp:BoundField HeaderText="���к�" DataField="SN" />
                <asp:TemplateField HeaderText="ɾ��">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="ɾ��"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfSN" runat="server" />
        <asp:HiddenField ID="hfNum" runat="server" Value="1" />
        <asp:HiddenField ID="hfreclist" runat="server" />
        <span style="display:none;">
            <asp:Button ID="btnId" runat="server" Text="..." OnClick="btnId_Click" />
        </span>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnAutoAdd" EventName="Click" />
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
                ���кţ�
            </td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbSN" runat="server" CssClass="pin" onkeydown="EnterTextBox(event, this);"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="���" CssClass="bt1" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click" UseSubmitBehavior="false" />
            </td>
            <td>
                <asp:Button ID="btnAutoAdd" runat="server" Text="�Զ�����" CssClass="bt1" OnClick="btnAutoAdd_Click" UseSubmitBehavior="false" />
                <input id="btnSltSN" runat="server" type="button" value="ѡ��SN" class="bt1" onclick="SltSN();" />
            </td>
        </tr>
        </table>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:Label ID="lbMod" runat="server" CssClass="si1">�������кŻس����</asp:Label>
            </td>
            <td align="right">
                <input id="btnPrint" runat="server" type="button" value="��ӡ" class="bt1" onclick="PrintSN();" />
                <input id="btnClose" type="button" value="ȷ��" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();" />
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
<script language="javascript" type="text/javascript">
function EnterTextBox(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            $("btnAdd").click();
        }
    }
}
function ChkAdd()
{
    if(isNull($("tbSN").value))
    {
        window.alert("����ʧ�ܣ����кŲ���Ϊ��");
        $("tbSN").focus();
        return false
    }
}

function SltSN()
{
    parent.ShowDialog<%=Str_F=="" ? "1" : Convert.ToDouble(int.Parse(Str_F)+1).ToString() %>(800, 520, 'Stock/SltSN.aspx?gid=<%=Str_Goodsid %>&iflag=<%=Str_F %>', 'ѡ�����к�');
}

function PrintSN()
{
    if($("hfSN").value=="")
    {
        window.alert("����ʧ�ܣ��������Ҫ��ӡ�����к�");
        return;
    }
    
    var w=(window.screen.width-750)/2;
    var num=Math.round(Math.random()*10000);
    window.open("../Print/interface_print.aspx?type=Print&obj=CPSN&ids=" + escape($("hfSN").value)+"&a="+num,"","width=750,height=580,toolbar=no,left="+w+",top=20,location=no,directories=yes,status=yes,menubar=yes,resizable=yes,scrollbars=yes");
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
