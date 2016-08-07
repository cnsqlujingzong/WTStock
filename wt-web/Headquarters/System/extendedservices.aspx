<%@ page language="C#"  CodeFile="extendedservices.aspx.cs"     autoeventwireup="true" inherits="Headquarters_System_ExtendedServices" theme="Themes" enableEventValidation="false" %>
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
                   <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                        <asp:ListItem Value="0">ģ����ѯ</asp:ListItem>
                        <asp:ListItem Value="1">�����񵥺Ų�ѯ</asp:ListItem>
                        <asp:ListItem Value="2">����������ѯ</asp:ListItem>
                        <asp:ListItem Value="3">�������Ų�ѯ</asp:ListItem>
                        <asp:ListItem Value="4">�������Ų�ѯ</asp:ListItem>
                        <asp:ListItem Value="5">������ʽ��ѯ</asp:ListItem>
                        <asp:ListItem Value="6">�����ȼ���ѯ</asp:ListItem>
                        <asp:ListItem Value="7">�������˲�ѯ</asp:ListItem>
                        <asp:ListItem Value="8">���ͻ����Ʋ�ѯ</asp:ListItem>
                        <asp:ListItem Value="9">����ϵ�˲�ѯ</asp:ListItem>
                        <asp:ListItem Value="10">���ͻ��绰��ѯ</asp:ListItem>
                        <asp:ListItem Value="11">���ͻ���ַ��ѯ</asp:ListItem>
                        <asp:ListItem Value="12">�������ͺŲ�ѯ</asp:ListItem>
                        <asp:ListItem Value="13">������Ʒ�Ʋ�ѯ</asp:ListItem>
                        <asp:ListItem Value="14">����������ѯ</asp:ListItem>
                        <asp:ListItem Value="15">���������кŲ�ѯ</asp:ListItem>
                        <asp:ListItem Value="16">��ά�޼���Ա��ѯ</asp:ListItem>
                        <asp:ListItem Value="17">�����ϲ�ѯ</asp:ListItem>
                        <asp:ListItem Value="18">�����������ѯ</asp:ListItem>
                        <asp:ListItem Value="19">����ע��ѯ</asp:ListItem>
                        <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                    </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" />
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
                    <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                </span>
            </td>
            <td style="padding-right:80px;">
                
            </td>
            </tr>
            </table>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="height:480px; width:920px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="���񵥺�" DataField="BillID" />
            <asp:BoundField HeaderText="����״̬" DataField="curStatus" />
            <asp:BoundField HeaderText="�������" DataField="ServicesType" />
            <asp:BoundField HeaderText="��׼��ʱ" DataField="bPoint" />
            <asp:BoundField HeaderText="���ù�ʱ" DataField="yPoint" />
            <asp:BoundField HeaderText="ȷ��ʱ��" DataField="ConfirmDate" />
            <asp:BoundField HeaderText="������" DataField="Operator" />
            <asp:BoundField HeaderText="����ʱ��" DataField="Time_TakeOver" />
            <asp:BoundField HeaderText="����ʱ��" DataField="Speding" />
            <asp:BoundField HeaderText="���ȼ�" DataField="_PRI" />
            <asp:BoundField HeaderText="����Ա" DataField="DisposalOper" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
            <asp:BoundField HeaderText="������" DataField="LinkMan" />
            <asp:BoundField HeaderText="�����˵绰" DataField="Tel" />
            <asp:BoundField HeaderText="ʹ����" DataField="UsePerson" />
            <asp:BoundField HeaderText="ʹ���˵绰" DataField="UsePersonTel" />
            <asp:BoundField HeaderText="�����ͺ�" DataField="ProductModel" />
            <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
            <asp:BoundField HeaderText="���" DataField="ProductClass" />
            <asp:BoundField HeaderText="���к�1" DataField="ProductSN1" />
            <asp:BoundField HeaderText="���к�2" DataField="ProductSN2" />
            <asp:BoundField HeaderText="����" DataField="Fault" />
            <asp:BoundField HeaderText="�������" DataField="Warranty" />
            <asp:BoundField HeaderText="ԤԼʱ��" DataField="SubscribeTime" />
            <asp:BoundField HeaderText="Ԥ����" DataField="SubscribePrice" />
            <asp:BoundField HeaderText="Ԥ�շ�" DataField="PreCharge" />
            <asp:BoundField HeaderText="����" DataField="bRepair" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
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
        <asp:HiddenField ID="hfreclist" runat="server" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
}
function ChkView()
{
    var id=$("hfRecID").value;
    parent.ShowDialog1(860,444, 'Services/SerView.aspx?id='+id+'&iflag=1', '����');
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
