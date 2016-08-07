<%@ page language="C#"  CodeFile="staffadm.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_StaffAdm" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
</head>
<body onload="Chkset();" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="ftool">
        <div class="ftoolleft">
        <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
                <asp:Button ID="btnFsh" runat="server" Text="ˢ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnFsh_Click"/>
                <input id="btnNew" type="button" value="�½�" class="bt1" onclick="parent.ShowDialog(600, 430, 'Basic/StaffAdd.aspx', '�½�Ա��');" />
                <input id="btnMod" type="button" value="�޸�" class="bt1" onclick="ChkMod(600, 430,'Basic/StaffMod.aspx','�޸�Ա��');" />
                <asp:Button ID="btnDel" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('Ա��')==false) return false;" OnClick="btnDel_Click"/>
                <input id="btnSchLocation" type="button" value="�鿴λ��" class="bt1" onclick="ChkMod(800, 600,'Basic/StSerMap.aspx','Ա������λ��');" />
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                </span>
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                    <input id="btnInput" runat="server" type="button" class="binput" value="����" onclick="ChkInput();" />
                </td>
                <td>
                    <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
                </td>
               <td>
                    <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                        <asp:ListItem Value="JobNO">����Ų�ѯ</asp:ListItem>
                        <asp:ListItem Value="_Name">��������ѯ</asp:ListItem>
                        <asp:ListItem Value="Sex">���Ա��ѯ</asp:ListItem>
                        <asp:ListItem Value="Tel">���绰��ѯ</asp:ListItem>
                        <asp:ListItem Value="Adr">����ַ��ѯ</asp:ListItem>
                        <asp:ListItem Value="NativePlace">�������ѯ</asp:ListItem>
                        <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
                </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td></tr>
            </table>   
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvstaff" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvstaff_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="��ǰ״̬" DataField="Status" />
            <asp:BoundField HeaderText="���" DataField="JobNO" />
            <asp:BoundField HeaderText="����" DataField="_Name" />
            <asp:BoundField HeaderText="��λ" DataField="Quarters" />
            <asp:BoundField HeaderText="����" DataField="NativePlace" />
            <asp:BoundField HeaderText="�Ա�" DataField="Sex" />
            <asp:BoundField HeaderText="�绰" DataField="Tel" />
            <asp:BoundField HeaderText="����" DataField="Area" />
            <asp:BoundField HeaderText="Ա������" DataField="StaffDept" />
            <asp:BoundField HeaderText="סַ" DataField="Adr" />
            <asp:BoundField HeaderText="���֤��" DataField="CardID" />
            <asp:BoundField HeaderText="��������" DataField="BirthDate" />
            <asp:BoundField HeaderText="ѧ��" DataField="Academic" />
            <asp:BoundField HeaderText="��ҵԺУ" DataField="School" />
            <asp:BoundField HeaderText="רҵ" DataField="Specialty" />
            <asp:BoundField HeaderText="��ְʱ��" DataField="JobDate" />
            <asp:BoundField HeaderText="��н" DataField="Salary" />
            <asp:BoundField HeaderText="����" DataField="Allowance" />
            <asp:BoundField HeaderText="�����ʺ�" DataField="Account" />
            <asp:BoundField HeaderText="����Ա" DataField="bDestClerk" />
            <asp:BoundField HeaderText="�ɹ���Ա" DataField="bAllot" />
            <asp:BoundField HeaderText="����Ա" DataField="bTechnician" />
            <asp:BoundField HeaderText="ҵ��Ա" DataField="bSeller" />
            <asp:BoundField HeaderText="������Ա" DataField="bAccountant" />
            <asp:BoundField HeaderText="�ֿ����Ա" DataField="bStockMan" />
            <asp:BoundField HeaderText="�������" DataField="SellDeduct" />
            <asp:BoundField HeaderText="ά�����" DataField="BillDeduct" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            <asp:BoundField HeaderText="��ǰ״̬" DataField="Status" />
        </Columns>
    </asp:GridView>
    
    <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCountText" runat="server" ToolTip="�ܼ�¼��" Text="�ܼ�¼:"></asp:Label><asp:Label ID="lbCount" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
        </tr>
    </table>
    
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
       
    <div class="fbom">  
    <div id="fbon" class="fbon">
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
}
function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("Ա��Ŀ¼");
}
function ChkInput()
{
    parent.ShowDialog(600, 499,'Basic/InputStaff.aspx?iflag=1', '����Ա��');
}
</script>
