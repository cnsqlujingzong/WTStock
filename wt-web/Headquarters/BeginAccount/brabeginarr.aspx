<%@ page language="C#"  CodeFile="brabeginarr.aspx.cs"     autoeventwireup="true" inherits="Headquarters_BeginAccount_BraBeginArr" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body onload="Chkset();" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="divh2"></div>
    <div class="tldiv">
        �����ڳ�Ӧ��Ӧ��
    </div>
    <div id="cndiv" style="height:1px;">
        <div id="fdiv" class="fdiv">
            <div id="sdiv" class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv5" OnRowDataBound="gvdata_RowDataBound" OnRowDeleting="gvdata_RowDeleting">
                        <Columns>
                        <asp:BoundField HeaderText="ID" DataField="CusID" />
                        <asp:BoundField HeaderText="��" />
                        <asp:BoundField HeaderText="������" DataField="CusNO" />
                        <asp:BoundField HeaderText="����" DataField="_Name" />
                        <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
                        <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
                        <asp:TemplateField HeaderText="�ڳ�Ӧ��">
                            <ItemTemplate>
                                <asp:TextBox ID="tbRec" runat="server" Text='<%# Eval("Rec") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�ڳ�Ӧ��">
                            <ItemTemplate>
                                <asp:TextBox ID="tbDue" runat="server" Text='<%# Eval("Due") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
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
                    <asp:HiddenField ID="hfreclist" runat="server" />
                    <asp:HiddenField ID="hfRecIDs" runat="server" Value="-1" />
                    <asp:HiddenField ID="hfName" runat="server" />
                     <span style="display:none;">
                     <asp:Button ID="btnId" runat="server" Text="..." OnClick="btnId_Click" />
                     </span>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnSure" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
                </Triggers>
             </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="divh"></div>
    <div class="tdiv">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" class="tb3">
        <tr>
            <td style="padding-left:15px;">
                <asp:DropDownList ID="ddlSchFld" runat="server" CssClass="pindl" Width="70">
                    <asp:ListItem Value="BranchNO">�����</asp:ListItem>
                    <asp:ListItem Value="_Name">������</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td><asp:TextBox ID="tbCon" runat="server" CssClass="pin" onkeydown="EnterTextBox(event, this);" ToolTip="������ɺ�س����"></asp:TextBox></td>
            <td><asp:Button ID="btnSure" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSch()==false)return false;" OnClick="btnSure_Click" /></td>
            <td><input id="tbSltGoods" type="button" value="ѡ������" class="bt1" onclick="parent.ShowDialog(800, 520, 'BeginAccount/SltBranch.aspx', 'ѡ������');" /></td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnId" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSure" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    
    <div class="ftool">
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td><span class="si1">���ֹ������Ż����ƣ�������ɺ�س�</span></td>
            <td align="right" style="padding-right:20px;">
                <asp:Button ID="btnChk" runat="server" Text="ȷ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnChk_Click"/>
                <asp:Button ID="btnClean" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click"/>
                <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseWin();" />
            </td>
        </tr>
    </table>
    </div>
    <div class="fbom">
        <div id="fbon" class="fbon"></div> 
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
var noOpen=1;

function ChkID(id)
{
    ClrID(id);
}

function ChkIDs(id,unitid)
{
    ClrID4(id);
    $("hfUnitID").value=unitid;
}

function EnterTextBox(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            $("btnSure").click();
        }
    }
}

function ChkSave()
{
    if(confirm("ȷ��Ҫ�����ڳ�����Ӧ��Ӧ���𣿽����󽫲����޸�"))
    {
        return true;
    }
    else
        return false;
}

function Chkset()
{
    Chkwh9();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("�����ڳ�Ӧ��Ӧ��");
}
</script>
