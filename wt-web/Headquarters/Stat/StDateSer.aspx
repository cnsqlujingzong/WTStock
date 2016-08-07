<%@ page language="C#"  CodeFile="StDateSer.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stat_StDateSer" theme="Themes" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <td class="red">���㣺</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" Width="100" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="red">Ա����</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlStaff" runat="server" CssClass="pindl" Width="100">
                    <asp:ListItem Value="0">��ѡ��Ա��</asp:ListItem>
                </asp:DropDownList>
            </td>
          </ContentTemplate>
          </asp:UpdatePanel>
            <td>���ڣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
            <td align="left">
                <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td>
                <input id="btnDetail" type="button" value="��ϸ" class="bt1" onclick="ChkView();" />
                <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
            </td>
            </tr>
          </table>
        </div>
        <div class="ftoolright">
              <span style="display:none;">
                <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
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
            <asp:BoundField HeaderText="���񵥺�" DataField="BillID" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
            <asp:BoundField HeaderText="����Ʒ��" DataField="ProductBrand" />
            <asp:BoundField HeaderText="�������" DataField="ProductClass" />
            <asp:BoundField HeaderText="�����ͺ�" DataField="ProductModel" />
            <asp:BoundField HeaderText="����ʱ��" DataField="Time_Takeover" />
            <asp:BoundField HeaderText="��Ӧʱ��" DataField="FirstDo" />
            <asp:BoundField HeaderText="����ʱ��" DataField="visitdate" />
            <asp:BoundField HeaderText="���ʱ��" DataField="fintime" />
            <asp:BoundField HeaderText="������Ŀ" DataField="SerItem" />
            <asp:BoundField HeaderText="������" DataField="ReadNum" />
            <asp:BoundField HeaderText="����/�Ĳ�" DataField="SerMaterial" />
            <asp:BoundField HeaderText="�����ʩ" DataField="TakeSteps" />
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="a.ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" Value="���񵥺�,�ͻ�����,����Ʒ��,�������,�����ͺ�,����ʱ��,��Ӧʱ��,����ʱ��,���ʱ��,������Ŀ,������,����/�Ĳ�,�����ʩ" />
    <asp:HiddenField ID="hfTbField" runat="server" Value="BillID,CustomerName,ProductBrand,ProductClass,ProductModel,Time_TakeOver,FirstDo,visitdate,fintime,SerItem,ReadNum,SerMaterial,TakeSteps"/>
    <asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div class="fbom">  
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
    <td>
    <div id="fbon" class="fbon"></div></td>
    <td>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
                    <span class="bs1" style="color:#0000ff;">���մ����깤�ɹ���С��:<asp:Label ID="Label1" runat="server" Text="0"></asp:Label></span>
                    <span class="bs1" style="color:#ff0000;">δ�����ɹ���С��:<asp:Label ID="Label2" runat="server" Text="0"></asp:Label></span>
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
                </td>
    </tr>
    </table>
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
    var billdate=$("hfRecID").value;
    if(billdate=="-1"||billdate=="")
    {
        window.alert("��ѡ��һ����¼�������ֱ��˫����¼�鿴��ϸ��");
        return false;
    }
    var deptid=$("ddlBranch").value;
    var startdate=$("tbDateB").value;
    var enddate=$("tbDateE").value;
    parent.ShowDialog(870,513, 'Stat/BroughtBackDe.aspx?billdate='+billdate+'&deptid='+deptid+'&iflag=1'+'&startdate='+startdate+'&enddate='+enddate, '��ϸ');
}
function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("��Ʒ���˻��ܱ�");
}
</script>
