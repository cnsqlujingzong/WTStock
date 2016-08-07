<%@ page language="C#"  CodeFile="stmonthseller.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stat_StMonthSeller" theme="Themes" enableEventValidation="false" %>
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
            <td style="padding-left:0px;"><asp:TextBox ID="tbDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM'})" Width="100"></asp:TextBox></td>
            <td>����</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDateE" runat="server" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM'})" Width="100"></asp:TextBox></td>
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
            <asp:BoundField HeaderText="��" />
            <asp:BoundField HeaderText="ҵ���¶�" DataField="by_curmonth"/>
            <asp:BoundField HeaderText="����Ӫҵ��" DataField="SerTotal" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="����ë��" DataField="SerProfit" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="����Ӫҵ��" DataField="SellTotal" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="����ë��" DataField="SellProfit" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="�ϼ�Ӫҵ��" DataField="Total" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="�ϼ�ë��" DataField="Profit" DataFormatString="{0:n2}" HtmlEncode="false"/>
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="a.ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" Value="ҵ���¶�,����Ӫҵ��,����ë��,����Ӫҵ��,����ë��,�ϼ�Ӫҵ��,�ϼ�ë��" />
    <asp:HiddenField ID="hfTbField" runat="server" Value="by_curmonth,SerTotal,SerProfit,SellTotal,SellProfit,Total,Profit" />
    <asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
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

function ChkView()
{
    var billdate=$("hfRecID").value;
    if(billdate=="-1"||billdate=="")
    {
        window.alert("��ѡ��һ����¼�������ֱ��˫����¼�鿴��ϸ��");
        return false;
    }
    var deptid=$("ddlBranch").value;
    parent.ShowDialog(870,513, 'Stat/DaySellerDe.aspx?iflag=2&billdate='+billdate+'&deptid='+deptid, '��ϸ');
}

function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("��Ӫҵ����ܱ�");
}
</script>