<%@ page language="C#"  CodeFile="troubleadd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_TroubleAdd" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td>��Ʒ���</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="pindl" onchange="NewProductClass();">
                            </asp:DropDownList>
                        </td>
                        <td>ά�����</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlRepair" runat="server" CssClass="pindl" onchange="NewRepairClass();">
                            </asp:DropDownList>
                        </td>
                        <td>���֣�</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbScore" runat="server" Width="50px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>�������</td>
                        <td style="padding-left:0px;">
                            <div class="isinDiv">
                            <input type="text" id="tbTroubClass" runat="server" class="pin pinin" readonly="readonly" />
                                <select id="slTroubClass" runat="server" onchange="getclassvalue('tbTroubClass',this.options[this.selectedIndex].text);" class="pininsl">
                                </select>
                            </div>
                        </td>
                        <td>���ϱ�ţ�</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbTroubleNO" runat="server" Enabled="false" CssClass="pin"></asp:TextBox>
                        </td>
                        <td colspan="2" style="color:#ff0000; padding-left:0px;">
                            <asp:CheckBox ID="cbsys" runat="server" Checked="true" Text="ϵͳĬ��" onclick="ChkSysNO();" /></td>
                    </tr>
                    <tr>
                        <td>�������ƣ�</td>
                        <td colspan="5" style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="408" TextMode="MultiLine" Height="30"></asp:TextBox></td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnRefClass" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnRefRepair" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <div class="fdiv">
            <div class="sdiv" style="height:213px;background:#ffffff;padding:0px;">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" Width="100%">
                    <Columns>
                        <asp:BoundField HeaderText="��" />
                        <asp:TemplateField HeaderText="�����ʩ">
                            <ItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("_Name") %>' Height="30" Width="485" TextMode="MultiLine"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ɾ��">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="ɾ��" style="color:#0000ff;"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:HiddenField ID="hfClass" runat="server" />
                <asp:HiddenField ID="hfRepair" runat="server" />
                    <span style="display:none;">
                        <asp:Button ID="btnRefRepair" runat="server" Text="RefRepair" OnClick="btnRefRepair_Click" />
                        <asp:Button ID="btnRefClass" runat="server" Text="RefClass" OnClick="btnRefClass_Click" /></span>
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
                <td style="padding-left:5px;color:#0000ff">
                    <asp:CheckBox ID="cbClose" runat="server" Text="�����رմ���" Checked="true" /></td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog('1');"/>
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
    if($("ddlClass").value=="-1")
    {
        window.alert("����ʧ�ܣ���Ʒ�����Ϊ��");
        $("ddlClass").focus();
        return false
    }
    if($("ddlRepair").value=="-1")
    {
        window.alert("����ʧ�ܣ�ά�������Ϊ��");
        $("ddlRepair").focus();
        return false
    }
    if(isNull($("slTroubClass").value))
    {
        window.alert("����ʧ�ܣ����������Ϊ��");
        $("slTroubClass").focus();
        return false
    }
    if(!$("cbsys").checked)
    {
        if(isNull($("tbTroubleNO").value))
        {
            window.alert("����ʧ�ܣ����ϱ�Ų���Ϊ��");
            $("tbTroubleNO").focus();
            return false
        }
    }
    if(isNull($("tbName").value))
    {
        window.alert("����ʧ�ܣ����ϲ���Ϊ��");
        $("tbName").focus();
        return false
    }
}

function ChkSysNO()
{
    if(!$("cbsys").checked)
    {
        $("tbTroubleNO").disabled=false;
        $("tbTroubleNO").focus();
    }else
    {
        $("tbTroubleNO").disabled=true;
    }
}
</script>
