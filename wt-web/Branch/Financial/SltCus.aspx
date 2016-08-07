<%@ page language="C#"  CodeFile="SltCus.aspx.cs"     autoeventwireup="true" inherits="Branch_Financial_SltCus" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

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
                    <asp:DropDownList ID="ddlKey" runat="server" onchange="document.getElementById('tbCon').focus();" CssClass="pindl">
                        <asp:ListItem Value="0">ģ����ѯ</asp:ListItem>
                        <asp:ListItem Value="1">���ͻ���Ų�ѯ</asp:ListItem>
                        <asp:ListItem Value="2">���ͻ����Ʋ�ѯ</asp:ListItem>
                        <asp:ListItem Value="3">����ϵ�˲�ѯ</asp:ListItem>
                        <asp:ListItem Value="4">���绰��ѯ</asp:ListItem>
                        <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                    </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbCon" runat="server" CssClass="pink" onkeydown="EnterTextBoxSch(event, this);" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" />
                <input id="btnNew" type="button" value="�½�" class="bt1" onclick="NewCus();"/>
                </td>
             </tr>
            </table>   
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
                <input id="btnAss" runat="server" type="button" value="���ɻ�Ա" class="bt1" onclick="ChkAss();"/></td>
            <td style="padding-right:50px;">
                <input id="btnAdd" runat="server" type="button" value="ȷ��" class="bt1" onclick="ChkCus();"/>
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
    
    <div id="cndiv" style="float:left;height:460px; width:635px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvcus" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvcus_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="CustomerID" />
            <asp:BoundField HeaderText="���" DataField="Type" />
            <asp:BoundField HeaderText="�ͻ����" DataField="CustomerNO" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="_Name" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="Area" />
            <asp:BoundField HeaderText="CusType" DataField="CusType" />
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
        <asp:HiddenField ID="hfOrderName" runat="server" Value="" />
        <asp:HiddenField ID="hfOrderTitle" runat="server" Value="" />
        <asp:HiddenField ID="hfOrder" runat="server" Value="" />
        <asp:HiddenField ID="hfSql" runat="server" />
        <asp:HiddenField ID="hfClass" runat="server" />
        <asp:HiddenField ID="hfCusName" runat="server" />
        <asp:HiddenField ID="hfCusNO" runat="server" />
        <asp:HiddenField ID="hfCusType" runat="server" />
        <asp:HiddenField ID="hfPurArea" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
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
function ChkID(id)
{
    ClrID(id);
}
function ChkIDCus(strname,strcusno,strcustype)
{
    $("hfCusName").value=strname;
    $("hfCusNO").value=strcusno;
    $("hfCusType").value=strcustype;
}
function ChkCus()
{
    if(ChkSlt()==false)
     return;
    
    try{
    if(parent.<%=Str_Fid %>.$("hfCusID"))
    parent.<%=Str_Fid %>.$("hfCusID").value=$("hfRecID").value;
    parent.<%=Str_Fid %>.$("tbCusName").value=$("hfCusName").value;
    if(parent.<%=Str_Fid %>.$("hfType"))
    parent.<%=Str_Fid %>.$("hfType").value=$("hfCusType").value;
    if(parent.<%=Str_Fid %>.$("btnId"))
        parent.<%=Str_Fid %>.$("btnId").click();
    
//    if("<%=Str_F %>"=="2")
//      {
//        parent.<%=Str_Fid %>.$("tbCusNO").value=$("hfCusNO").value;
//        parent.<%=Str_Fid %>.$("btnCusInfo").click();
//      }
//    if("<%=Str_F %>"=="3")
//      {
//        parent.<%=Str_Fid %>.$("btnCusInfo").click();
//      }
//      if("<%=Str_F %>"=="4")
//      {
//        parent.<%=Str_Fid %>.$("tbCusNO").value=$("hfCusNO").value;
//      }
      parent.CloseDialog1();
    }catch(e){ alert(e);}
}

function ChkAss()
{
    parent.ShowDialog1(400, 215, 'Customer/AssAdd.aspx', '���ɻ�Ա');
}
function NewCus()
{
    parent.ShowDialog2(600, 400, 'Customer/CusAdd.aspx?f=2', '�½��ͻ�');
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog1();}catch(e){}}}
</script>
