<%@ page language="C#"  CodeFile="starrde.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stat_StArrDe" theme="Themes" enableEventValidation="false" %>
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
                    <asp:ListItem Value="CustomerName">����λ���Ʋ�ѯ</asp:ListItem>
                    <asp:ListItem Value="OperationID">�����ݱ�Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="RecType">���������Ͳ�ѯ</asp:ListItem>
                    <asp:ListItem Value="_Date">�����ڲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="_Name">�������˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="LinkMan">����ϵ�˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="Tel">����ϵ�绰��ѯ</asp:ListItem>
                    <asp:ListItem Value="RemindDate">���������ڲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="Amount">���ܽ���ѯ</asp:ListItem>
                    <asp:ListItem Value="Remark">����ע��ѯ</asp:ListItem>
                    <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td>
            <td>
                <asp:RadioButton ID="r1" runat="server" GroupName="g1" Checked="true" Text=" Ӧ�տ� " />
                <asp:RadioButton ID="r2" runat="server" GroupName="g1" Text=" Ӧ���� " />
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
                <asp:BoundField HeaderText="��λ����" DataField="CustomerName"/>
                <asp:BoundField HeaderText="����" DataField="Dept"/>
                <asp:BoundField HeaderText="�������" DataField="RecType"/>
                <asp:BoundField HeaderText="���ݱ��" DataField="OperationID"/>
                <asp:BoundField HeaderText="������" DataField="_Name"/>
                <asp:BoundField HeaderText="����" DataField="_Date"/>
                <asp:BoundField HeaderText="�ܽ��" DataField="Amount"/>
                <asp:BoundField HeaderText="�ѽ�����" DataField="HaveAmount"/>
                <asp:BoundField HeaderText="δ������" DataField="NotChargeAmount"/>
                <asp:BoundField HeaderText="��������" DataField="RemindDate" />
                <asp:BoundField HeaderText="��ע" DataField="Remark"/>
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
function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function ChkCG(bid)
{
    parent.ShowDialog(800, 480,'Purchase/PurchaseMod.aspx?ids='+bid,'�ɹ���');
}

function ChkHT(bid)
{
    parent.ShowDialog(820, 510, 'Customer/DevContMod.aspx?conno='+bid, '�޸ķ����ͬ');
}

function ChkGD(bid)
{
    parent.ShowDialog(860,444, 'Services/SerView.aspx?ids='+bid, '����');
}

function ChkDB(bid)
{
    parent.ShowDialog(800, 480,'Stock/AllocateMod.aspx?ids='+bid,'������');
}

function ChkXS(bid)
{
    parent.ShowDialog(800, 480,'Sell/SellMod.aspx?ids='+bid,'���۵�');
}

function ChkJS(bid)
{
    parent.ShowDialog(700, 480,'Lease/ShowCharge.aspx?ids='+bid, '������ϸ');
}
function ChkSFK(bid)
{
    parent.ShowDialog(670,245, 'Financial/InPayView.aspx?ids='+bid, '�ո��');
}

function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("Ӧ��Ӧ����ϸ��");
}
</script>
