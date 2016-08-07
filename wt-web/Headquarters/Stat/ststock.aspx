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
            <td class="red">网点：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" Width="100" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="padding-left:0px;display:none"><span id="stock" runat="server" visible="false">仓库</span></td>
            <td style="display:none">
                <asp:DropDownList ID="ddlStock" runat="server" CssClass="pindl" Width="100" Visible="false">
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>日期从：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
            <td>到：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDateE" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
            <td align="left">
                <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td>
                <input id="btnDetail" type="button" value="明细" class="bt1" onclick="ChkView();" />
                
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
            <td><asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
            
              <span style="display:none;">
                <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
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
            <asp:BoundField HeaderText="序" />
            <asp:BoundField HeaderText="编号" DataField="GoodsNO"/>
            <asp:BoundField HeaderText="名称" DataField="_Name"/>
            <asp:BoundField HeaderText="规格" DataField="Spec"/>
            <asp:BoundField HeaderText="属性" DataField="Attr" />
            <asp:BoundField HeaderText="单位" DataField="Unit"/>
            <asp:BoundField HeaderText="期初数量" DataField="BeginQty" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="期初金额" DataField="BeginTotal" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="入库数量" DataField="INQty" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="入库金额" DataField="INTotal" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="出库数量" DataField="OUTQty" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="出库金额" DataField="OUTCost" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="期末数量" DataField="EndQty" DataFormatString="{0:n2}" HtmlEncode="false"/>
            <asp:BoundField HeaderText="期末金额" DataField="EndTotal" DataFormatString="{0:n2}" HtmlEncode="false"/>
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="a.ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" Value="编号,名称,规格,属性,单位,期初数量,期初金额,入库数量,入库金额,出库数量,出库金额,期末数量,期末金额" />
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
        window.alert("请选择一条记录后操作或直接双击记录查看明细！");
        return false;
    }
    var deptid=$("ddlBranch").value;
    var startdate=$("tbDateB").value;
    var enddate=$("tbDateE").value;
    parent.ShowDialog(870,513, 'Stat/StockDe.aspx?billdate='+billdate+'&deptid='+deptid+'&iflag=1'+'&startdate='+startdate+'&enddate='+enddate, '明细');
}
function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("仓库汇总表");
}
</script>
