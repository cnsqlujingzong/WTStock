<%@ page language="C#"  CodeFile="stpayde.aspx.cs"     autoeventwireup="true" inherits="Branch_Stat_StPayDe" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
</head>
<body onload="Chkset();" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="ftool">
        <div class="ftoolleft">
          <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td class="red">���㣺</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" Width="100">
                </asp:DropDownList>
            </td>
            <td>���ڴӣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
            <td>����</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDateE" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
            <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="BillID">�����ݱ�Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="Type">���������Ͳ�ѯ</asp:ListItem>
                    <asp:ListItem Value="_Date">�����ڲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="Operator">�������˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="CustomerName">��������λ��ѯ</asp:ListItem>
                    <asp:ListItem Value="ChargeStyle">�����㷽ʽ��ѯ</asp:ListItem>
                    <asp:ListItem Value="Account">�������ʻ���ѯ</asp:ListItem>
                    <asp:ListItem Value="InvoiceClass">����Ʊ����ѯ</asp:ListItem>
                    <asp:ListItem Value="InvoiceNO">����Ʊ�����ѯ</asp:ListItem>
                    <asp:ListItem Value="CheckNO">��֧Ʊ�����ѯ</asp:ListItem>
                    <asp:ListItem Value="VoucherNO">��ƾ֤�����ѯ</asp:ListItem>
                    <asp:ListItem Value="ChargeItem">����֧��Ŀ��ѯ</asp:ListItem>
                    <asp:ListItem Value="ChkDate">��������ڲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="ChkOperator">������˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="Remark">����ע��ѯ</asp:ListItem>
                    <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td>
            <td align="left">
                <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td>
                <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
            </td>
            </tr>
          </table>
        </div>
        <div class="ftoolright">
              <span style="display:none;">
                <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                <asp:Button ID="btnSchH" runat="server" Text="�߼���ѯ" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />
            </span>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="statf" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false" ShowFooter="true">
        <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="�������" DataField="type" />
                <asp:BoundField HeaderText="���ݱ��" DataField="billid" />
                <asp:BoundField HeaderText="����" DataField="dept" />
                <asp:BoundField HeaderText="����" DataField="_Date" />
                <asp:BoundField HeaderText="������" DataField="operator" />
                <asp:BoundField HeaderText="������λ" DataField="customername" />
                <asp:BoundField HeaderText="Ӧ�տ�" DataField="DueMoney" />
                <asp:BoundField HeaderText="�Żݽ��" DataField="PreMoney" />
                <asp:BoundField HeaderText="ʵ�տ�" DataField="RealDueMoney" />
                <asp:BoundField HeaderText="���㷽ʽ" DataField="ChargeStyle" />
                <asp:BoundField HeaderText="�����ʻ�" DataField="Account" />
                <asp:BoundField HeaderText="��Ʊ���" DataField="InvoiceClass" />
                <asp:BoundField HeaderText="��Ʊ����" DataField="InvoiceNO" />
                <asp:BoundField HeaderText="ƾ֤����" DataField="VoucherNO" />
                <asp:BoundField HeaderText="������Ŀ" DataField="ChargeItem" />
                <asp:BoundField HeaderText="�������" DataField="chkdate" />
                <asp:BoundField HeaderText="�����" DataField="chkoperator" />
                <asp:BoundField HeaderText="��ע" DataField="Remark" />
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    �ܼ�¼��<asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
function ChkID(id)
{
    ClrID(id);
}
function ChkView()
{
    ChkMod(670,245, 'Financial/InPayView.aspx', '���');
}
function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("�����ϸ��");
}
</script>
