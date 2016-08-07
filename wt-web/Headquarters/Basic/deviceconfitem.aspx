<%@ page language="C#"  CodeFile="deviceconfitem.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_DeviceConfItem" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa" style="width:586px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional" ChildrenAsTriggers="false">
    <ContentTemplate>
        <div class="fdiv">
        <div class="sdiv2" style="height:255px;">
        <asp:GridView ID="GridView1" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" Width="70%">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="��" />
                <asp:BoundField HeaderText="���" DataField="ProductClass" />
                <asp:BoundField HeaderText="����" DataField="_Name" />
                <asp:BoundField HeaderText="����" DataField="Parameter" />
                <asp:BoundField HeaderText="������" DataField="MaintenancePeriod" />
                <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
        </asp:GridView>
        
        <table cellpadding="0" cellspacing="0" class="pages">
            <tr>
                <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" TabIndex="-1" /></td>
                <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
                <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
            </tr>
        </table>
        
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfClass" runat="server" />
        </div>
        </div>
    
    <div class="divh"></div>
    <div class="fdiv">
    <div class="sdiv">
    
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" class="tb4">
        <tr>
            <td align="right" class="red">���</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlClass" runat="server" CssClass="pindl" onchange="NewProductClass();">
                </asp:DropDownList>
            </td>
            <td align="right">���ƣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin"></asp:TextBox>
             <td align="right">������</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbParam" runat="server" CssClass="pin"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">�����ڣ�</td>
            <td style="padding-left:0px;">
                <div class="isinDiv">
                    <input type="text" id="tbProt" runat="server" class="pin pinin" />
                    <select id="slProt" runat="server" onchange="document.getElementById('tbProt').value=this.options[this.selectedIndex].value" class="pininsl">
                        <option value="" selected="selected"></option>
                        <option value="�ޱ���">�ޱ���</option>
                        <option value="һ����">һ����</option>
                        <option value="������">������</option>
                        <option value="������">������</option>
                        <option value="һ��">һ��</option>
                        <option value="����">����</option>
                        <option value="����">����</option>
                        <option value="����">����</option>
                        <option value="����">����</option>
                    </select>
                </div>
            </td>
            <td>��ע��</td>
            <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="312"></asp:TextBox></td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
        
    </div>
    </div>
    
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <asp:Button ID="btnAdd" runat="server" Text="�½�" CssClass="bt1" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click" UseSubmitBehavior="false" />
            <asp:Button ID="btnMod" runat="server" Text="�޸�" CssClass="bt1" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnMod_Click" UseSubmitBehavior="false" />
            <asp:Button ID="btnDel" runat="server" Text="ɾ��" CssClass="bt1" OnClientClick="if(ChkDel('����������')==false)return false;" OnClick="btnDel_Click" UseSubmitBehavior="false" />
        </td>
        <td align="right">
            <span style="display:none;">
            <asp:Button ID="btnShow" runat="server" Text="��ʾ" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="false"/>
            <asp:Button ID="btnRefClass" runat="server" Text="RefClass" OnClick="btnRefClass_Click" UseSubmitBehavior="false"/>
            </span>
            <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();"/> 
        </td>
    </tr>
    </table>
    
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="jsPager" EventName="PageChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnRefClass" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnMod" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
    </div>
    </div>
    </div>    
    </form>
</body>
</html>

<script language="javascript" type="text/javascript" src="../../Public/Script/menu.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkID(id)
{
    ClrBaseID(id);
    $("btnShow").click();
}
function ChkSave()
{
    if(ChkSlt()!=false)
    {
        if($("btnMod").value=="����")
        {
            if(Chk()==false)return false;
        }
    }else{return false;}
}

function ChkAdd()
{
    if($("btnAdd").value=="����")
    {
        if(Chk()==false)return false;
    }
}

//
function ChkFocus()
{
    $("tbName").select();
}

function Chk()
{
    if($("ddlClass").value=="-1")
    {
        window.alert("����ʧ�ܣ������Ϊ��");
        $("ddlClass").focus();
        return false
    }
    if(isNull($("tbName").value))
    {
        window.alert("����ʧ�ܣ����Ʋ���Ϊ��");
        $("tbName").focus();
        return false
    }
}
</script>
