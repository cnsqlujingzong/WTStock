<%@ page language="C#"  CodeFile="sltcus.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_SltCus" theme="themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
                    <asp:DropDownList ID="ddlKey" runat="server" onchange="document.getElementById('tbCon').focus();" CssClass="pindl">
                        <asp:ListItem Value="0">ģ����ѯ</asp:ListItem>
                        <asp:ListItem Value="2">���ͻ����Ʋ�ѯ</asp:ListItem>
                        <asp:ListItem Value="1">���ͻ���Ų�ѯ</asp:ListItem>
                        <asp:ListItem Value="3">����ϵ�˲�ѯ</asp:ListItem>
                        <asp:ListItem Value="4">���绰��ѯ</asp:ListItem>
                        <asp:ListItem Value="5">����ַ��ѯ</asp:ListItem>
                        <asp:ListItem Value="6">���ʱ��ѯ</asp:ListItem>
                        <asp:ListItem Value="7">�������ѯ</asp:ListItem>
                        <asp:ListItem Value="8">��Email��ѯ</asp:ListItem>
                        <asp:ListItem Value="9">���ͻ������ѯ</asp:ListItem>
                        <asp:ListItem Value="10">���Ǽǲ��Ų�ѯ</asp:ListItem>
                        <asp:ListItem Value="11">���ͻ���Դ��ѯ</asp:ListItem>
                        <asp:ListItem Value="12">��ҵ��Ա��ѯ</asp:ListItem>
                        <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                    </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbCon" runat="server" CssClass="pink" onkeydown="EnterTextBoxSch(event, this);" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" />
                <input id="btnNew" type="button" value="�½�" class="bt1" onclick="NewCus();"/>
                </td>
               <td><asp:CheckBox ID="cbDept" runat="server" AutoPostBack="true" OnCheckedChanged="cbDept_CheckedChanged" Checked="true" /><span style="color:#0000ff">ֻ��ʾ�����ŵĿͻ�</span></td> 
             </tr>
            </table>   
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td style="padding-right:50px;">
                <input id="btnAdd" type="button" value="ȷ��" class="bt1" onclick="ChkCus();"/>
            </td>
            <td>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                </span>
            </td>
            </tr>
            </table>
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="lndiv" class="lndiv" style="height:460px">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:TreeView ID="tvcus" runat="server" ShowLines="True" OnSelectedNodeChanged="tvcus_SelectedNodeChanged">
            <SelectedNodeStyle BackColor="#7d8abe" BorderColor="White" />
        </asp:TreeView>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="tvcus" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="lncn" class="uw" style="height:460px"></div>
    <div id="cndiv" style="float:left;height:460px; width:635px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvcus" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvcus_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="ClassName" />
            <asp:BoundField HeaderText="�ͻ����" DataField="CustomerNO" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="_Name" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="�ֻ�����" DataField="Tel2" />
            <asp:BoundField HeaderText="��ַ" DataField="Adr" />
            <asp:BoundField HeaderText="�ʱ�" DataField="Zip" />
            <asp:BoundField HeaderText="����" DataField="Fax" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="QQ/MSN" DataField="QQ" />
            <asp:BoundField HeaderText="�ʻ�" DataField="Account" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="Area" />
            <asp:BoundField HeaderText="�ͻ���Դ" DataField="CusFrom" />
            <asp:BoundField HeaderText="ҵ��Ա" DataField="Seller" />
            <asp:BoundField HeaderText="�Ǽǲ���" DataField="DeptID" />
            <asp:BoundField HeaderText="�Ǽ�ʱ��" DataField="_Date" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            <asp:BoundField HeaderText="��Ա����" DataField="Member" />
        </Columns>
    </asp:GridView>
    <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
        </tr>
    </table>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
        <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
        <asp:HiddenField ID="hfSql" runat="server" />
        <asp:HiddenField ID="hfClass" runat="server" />
        <asp:HiddenField ID="hfCusName" runat="server" />
        <asp:HiddenField ID="hfLinkMan" runat="server" />
        <asp:HiddenField ID="hfTel" runat="server" />
        <asp:HiddenField ID="hfArea" runat="server" />
        <asp:HiddenField ID="hfAdr" runat="server" />
        <asp:HiddenField ID="hfPurArea" runat="server" />
        <asp:HiddenField ID="hfPur1" runat="server" />
        <asp:HiddenField ID="hfPurDept" runat="server" Value="0" />
        <asp:HiddenField ID="hfMember" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tvcus" EventName="SelectedNodeChanged" />
        <asp:AsyncPostBackTrigger ControlID="cbDept" EventName="CheckedChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div class="clearfloat"></div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>

<script language="javascript" type="text/javascript">
var isfocus=2;
var strtel="";
var uri=location.href;
if(uri.indexOf("itel=1")>0)
    strtel="&itel=1";
function ChkID(id)
{
    ClrID(id);
}
function ChkIDCus(strname,strlinkman,strtel,strarea,stradr,strmember)
{
    $("hfCusName").value=strname;
    $("hfLinkMan").value=strlinkman;
    $("hfTel").value=strtel;
    $("hfArea").value=strarea;
    $("hfAdr").value=stradr;
    $("hfMember").value=strmember;
}
function ChkCus()
{
    if(ChkSlt()==false)
     return;
    
    try{
    parent.<%=Str_Fid %>.$("hfCusID").value=$("hfRecID").value;
    parent.<%=Str_Fid %>.$("tbCusName").value=$("hfCusName").value;
    parent.<%=Str_Fid %>.$("tbLinkMan").value=$("hfLinkMan").value;
    parent.<%=Str_Fid %>.$("tbTel").value=$("hfTel").value;
    parent.<%=Str_Fid %>.$("tbArea").value=$("hfArea").value;
    parent.<%=Str_Fid %>.$("tbAdr").value=$("hfAdr").value;
    parent.<%=Str_Fid %>.$("tbCusLevel").value=$("hfMember").value;
    parent.<%=Str_Fid %>.$("btnValiCus").click();
    }catch(e){}
    parent.CloseDialog1();
}
function NewCus()
{
    parent.ShowDialog2(600, 400, '../Headquarters/Customer/CusAdd.aspx?f=2'+strtel, '�½��ͻ�');
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog1();}catch(e){}}}
</script>
