<%@ page language="C#"  CodeFile="sttakestepsdis.aspx.cs"     autoeventwireup="true" inherits="Branch_Stat_StTakeStepsDis" theme="Themes" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
            <td class="red">网点：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" Width="100">
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>日期从：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
            <td>到：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDateE" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
            <td align="left">
                <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClientClick="ChkGetImg();" OnClick="btnSch_Click" /></td>
            <td>
                <input id="btnDetail" type="button" value="明细" class="bt1" onclick="ChkView();" />
            </td>
            </tr>
          </table>
        </div>
        <div class="ftoolright">
              <span style="display:none;">
                <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
            </span>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="float:left;height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="statf" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="序" />
            <asp:BoundField HeaderText="处理措施" DataField="Summary" />
            <asp:BoundField HeaderText="出现次数" DataField="TakeStepsCount"/>
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" Value="名称,出现次数" />
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
        <img id="img" src="../../Public/Images/li1.gif" title="故障分部图标" alt="统计图" galleryimg="no"/>
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
        window.alert("请选择一条记录后操作或直接双击记录查看明细！");
        return false;
    }
    var deptid=document.getElementById("ddlBranch").value;
    var startdate=$("tbDateB").value;
    var enddate=$("tbDateE").value;
    parent.ShowDialog(870,513, 'Stat/ServiceDe3.aspx?strid='+escape(strid)+'&deptid='+deptid+'&startdate='+startdate+'&enddate='+enddate+'&iflag=3', '明细');
}
function ChkGetImg()
{
    var num=Math.round(Math.random()*10000);
    var deptid=document.getElementById("ddlBranch").value;
    var startdate=$("tbDateB").value;
    var enddate=$("tbDateE").value;
    var h1=document.body.clientHeight-54;//表格高度
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    var w2=312;//滑条宽度
    var widths=w1-w2;
    var heights=h1;
    var iflag=6;
    document.getElementById("img").src="../../Public/Handler/PicTakeStepsDis.ashx?&deptid="+deptid+"&startdate="+startdate+"&enddate="+enddate+"&iflag="+iflag+"&width="+widths+"&height="+heights+"&c="+num;
}

function Chkset()
{
    Chkwhtj();
    Chkbom(); 
    ChkGetImg();
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("故障分布图表");
}
</script>
