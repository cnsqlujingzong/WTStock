<%@ page language="C#"  CodeFile="ststock.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stat_StStock" theme="Themes" enableEventValidation="false" %>
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
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
          <table cellpadding="0" cellspacing="0" class="tb2" style="float:left;">
            <tr>
            <td class="red">���㣺</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" Width="100" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="padding-left:0px;display:none"><span id="stock" runat="server" visible="false">�ֿ�</span></td>
            <td style="display:none">
                <asp:DropDownList ID="ddlStock" runat="server" CssClass="pindl" Width="100" Visible="false">
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>���ڴӣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
            <td>����</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDateE" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
            <td align="left">
                <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td>
                <input id="btnDetail" type="button" value="��ϸ" class="bt1" onclick="ChkView();" />
                
            </td>
            </tr>
          </table>
          </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlBranch" EventName="SelectedIndexChanged" />
        </Triggers>
        </asp:UpdatePanel>
          <table cellpadding="0" cellspacing="0" class="tb2" style="float:right;">
          <tr>
            <td><asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
            
              <span style="display:none;">
                <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
            </span></td>
          </tr>
          </table>
        </div>
        
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="statf" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false" ShowFooter="true">
        <Columns>
            <asp:BoundField HeaderText="��" />
            <asp:BoundField HeaderText="���" DataField="GoodsNO"/>
            <asp:BoundField HeaderText="����" DataField="_Name"/>
            <asp:BoundField HeaderText="���" DataField="Spec"/>
            <asp:BoundField HeaderText="����" DataField="Attr" />
            <asp:BoundField HeaderText="��λ" DataField="Unit"/>
            <asp:BoundField HeaderText="�ڳ�����" DataField="BeginQty" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="�ڳ����" DataField="BeginTotal" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="�������" DataField="INQty" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="�����" DataField="INTotal" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="��������" DataField="OUTQty" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="������" DataField="OUTCost" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="��ĩ����" DataField="EndQty" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="��ĩ���" DataField="EndTotal" DataFormatString="{0:n2}" HtmlEncode="false"/>
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="a.ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" Value="���,����,���,����,��λ,�ڳ�����,�ڳ����,�������,�����,��������,������,��ĩ����,��ĩ���" />
    <asp:HiddenField ID="hfTbField" runat="server" Value="GoodsNO,_Name,Spec,Attr,Unit,BeginQty,BeginTotal,INQty,INTotal,OUTQty,OUTCost,EndQty,EndTotal" />
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
    parent.ShowDialog(870,513, 'Stat/StockDe.aspx?billdate='+billdate+'&deptid='+deptid+'&iflag=1'+'&startdate='+startdate+'&enddate='+enddate, '��ϸ');
}
function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("�ֿ���ܱ�");
}
</script>
