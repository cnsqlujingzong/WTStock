<%@ page language="C#"  CodeFile="stservicede.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stat_StServiceDe" theme="Themes" enableeventvalidation="false" %>
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
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>���ڴӣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
            <td>����</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDateE" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
            <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">ģ����ѯ</asp:ListItem>
                    <asp:ListItem Value="1">�����񵥺Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="2">����������ѯ</asp:ListItem>
                    <asp:ListItem Value="3">�������Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="4">�������Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="5">������ʽ��ѯ</asp:ListItem>
                    <asp:ListItem Value="6">�����񼶱��ѯ</asp:ListItem>
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
                    <asp:ListItem Value="23">�����ۺ�ͬ�Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="18">�����������ѯ</asp:ListItem>
                    <asp:ListItem Value="20">�����޳��̲�ѯ</asp:ListItem>
                    <asp:ListItem Value="21">������״̬��ѯ</asp:ListItem>
                    <asp:ListItem Value="19">����ע��ѯ</asp:ListItem>
                    <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td>
            <td align="left">
                <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td style="padding:0px;"><input id="btnSchsH" type="button" value="�߼���ѯ" class="bsch" onclick="parent.ShowDialog(470,620, 'Services/SerSchCd.aspx', '�߼���ѯ');" /></td>
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
            <asp:BoundField HeaderText="�������" DataField="ServicesType" />
            <asp:BoundField HeaderText="����ʽ" DataField="TakeStyle" />
            <asp:BoundField HeaderText="���ݱ��" DataField="BillID" />
            <asp:BoundField HeaderText="��������" DataField="TakeDept" />
            <asp:BoundField HeaderText="��������" DataField="DisposalDept" />
            <asp:BoundField HeaderText="����ʱ��" DataField="Time_TakeOver" />
            <asp:BoundField HeaderText="������" DataField="Operator" />
            <asp:BoundField HeaderText="����ʱ��" DataField="Speding" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
            <asp:BoundField HeaderText="��������" DataField="UsePersonDept" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="��ַ" DataField="Adr" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="Area" />
            <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
            <asp:BoundField HeaderText="����Ʒ��" DataField="ProductBrand" />
            <asp:BoundField HeaderText="���" DataField="ProductClass" />
            <asp:BoundField HeaderText="�ͺ�" DataField="ProductModel" />
            <asp:BoundField HeaderText="���к�1" DataField="ProductSN1" />
            <asp:BoundField HeaderText="���к�2" DataField="ProductSN2" />
            <asp:BoundField HeaderText="���" DataField="Aspect" />
            <asp:BoundField HeaderText="�������" DataField="Accessory" />
            <asp:BoundField HeaderText="���񼶱�" DataField="_PRI" />
            <asp:BoundField HeaderText="�������" DataField="Warranty" />
            <asp:BoundField HeaderText="���ƹ���" DataField="Fault" />
            <asp:BoundField HeaderText="����Ա" DataField="DisposalOper" />
            <asp:BoundField HeaderText="�����ʩ/���" DataField="TakeSteps" />
            <asp:BoundField HeaderText="������" DataField="QtyType" />
            <asp:BoundField HeaderText="����ʱ��" DataField="BuyDate" />
            <asp:BoundField HeaderText="������" DataField="BuyFrom" />
            <asp:BoundField HeaderText="����Ʊ" DataField="BuyInvoice" />
            <asp:BoundField HeaderText="����" DataField="dPoint" />
            <asp:BoundField HeaderText="�Ƿ���" DataField="bRepair" />
            <asp:BoundField HeaderText="�浵����" DataField="SaveID" />
            <asp:BoundField HeaderText="ԤԼʱ��" DataField="SubscribeTime" />
            <asp:BoundField HeaderText="ԤԼȡ��" DataField="SubscribeConnectTime" />
            <asp:BoundField HeaderText="���޳���" DataField="RepairCorp" />
            <asp:BoundField HeaderText="�깤ʱ��" DataField="Time_Over" />
            <asp:BoundField HeaderText="����ʱ��" DataField="Time_Payee" />
            <asp:BoundField HeaderText="������" DataField="PayeeOper" />
            <asp:BoundField HeaderText="���ʱ��" DataField="Time_Close" />
            <asp:BoundField HeaderText="�����" DataField="ChkOperator" />
            <asp:BoundField HeaderText="���Ϸ�" DataField="Fee_Materail" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="���ϳɱ�" DataField="MaterailCost" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="�˹���" DataField="Fee_Labor" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="���ӷ�" DataField="Fee_Add" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="���޳ɱ�" DataField="RepairCost" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="����ɱ�" DataField="ExtraCost" HtmlEncode="false" DataFormatString="{0:F2}"/>
            <asp:BoundField HeaderText="�ϼ�Ӧ��" DataField="Fee_Total" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="�Żݽ��" DataField="PreMoney" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="ë��" DataField="Profit" HtmlEncode="false" DataFormatString="{0:F2}" />
            <asp:BoundField HeaderText="ʵ���տ�" DataField="RealMoney" HtmlEncode="false" DataFormatString="{0:F2}"/>
            <asp:BoundField HeaderText="���տ�" DataField="HaveAmount" HtmlEncode="false" DataFormatString="{0:F2}"  />
            <asp:BoundField HeaderText="δ�տ�" DataField="NotChargeAmount" HtmlEncode="false" DataFormatString="{0:F2}"  />
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
    ChkMod(860,444, 'Services/SerView.aspx', '����');
}
function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("������ϸ��");
}
</script>
