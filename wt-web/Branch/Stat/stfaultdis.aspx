<%@ page language="C#"  CodeFile="stfaultdis.aspx.cs"     autoeventwireup="true" inherits="Branch_Stat_StFaultDis" theme="Themes" enableEventValidation="false" %>
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
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
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
            <td>Ʒ�ƣ�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pindl" Width="100" AutoPostBack="True" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>���</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlClass" runat="server" CssClass="pindl" Width="100" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>�ͺţ�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlModel" runat="server" CssClass="pindl" Width="100" AutoPostBack="True" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td align="left">
                <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClientClick="ChkGetImg();" OnClick="btnSch_Click" /></td>
            <td>
                <input id="btnDetail" type="button" value="��ϸ" class="bt1" onclick="ChkView();" />
            </td>
            </tr>
          </table>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="ftoolright">
              <span style="display:none;">
                <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
            </span>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="float:left;height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="statf" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="��" />
            <asp:BoundField HeaderText="��������" DataField="by_name" />
            <asp:BoundField HeaderText="���ִ���" DataField="by_count"/>
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" Value="����,���ִ���" />
    <asp:HiddenField ID="hfTbField" runat="server" Value="" />
    <asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="divright">
        <img id="img" src="../../Public/Images/li1.gif" title="���Ϸֲ�ͼ��" alt="ͳ��ͼ" galleryimg="no"/>
    </div>
     <div class="clearfloat"></div>
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
    var strid=$("hfRecID").value;
    if(strid=="-1"||strid=="")
    {
        window.alert("��ѡ��һ����¼�������ֱ��˫����¼�鿴��ϸ��");
        return false;
    }
    var deptid=document.getElementById("ddlBranch").value;
    var startdate=$("tbDateB").value;
    var enddate=$("tbDateE").value;
    var brandid=$("ddlBrand").value;
    var classid=$("ddlClass").value;
    
    parent.ShowDialog(870,513, 'Stat/ServiceDe2.aspx?strid='+escape(strid)+'&deptid='+deptid+'&startdate='+startdate+'&enddate='+enddate+'&brandid='+brandid+'&classid='+classid+'&iflag=3', '��ϸ');
}
function ChkGetImg()
{
    var num=Math.round(Math.random()*10000);
    var deptid=document.getElementById("ddlBranch").value;
    var startdate=$("tbDateB").value;
    var enddate=$("tbDateE").value;
    var brandid=$("ddlBrand").value;
    var classid=$("ddlClass").value;
    var modelid=$("ddlModel").value;
    var h1=document.body.clientHeight-54;//����߶�
    var w1=window.screen.availWidth;//��Ļ���ù���������
    var w2=312;//��������
    var widths=w1-w2;
    var heights=h1;
    var iflag=6;
    document.getElementById("img").src="../../Public/Handler/PicFaultDis.ashx?&deptid="+deptid+"&startdate="+startdate+"&enddate="+enddate+"&brandid="+brandid+"&classid="+classid+"&modelid="+modelid+"&iflag="+iflag+"&width="+widths+"&height="+heights+"&c="+num;
}

function Chkset()
{
    Chkwhtj();
    Chkbom(); 
    ChkGetImg();
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("���Ϸֲ�ͼ��");
}
</script>