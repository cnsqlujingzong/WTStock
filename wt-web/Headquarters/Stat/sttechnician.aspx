<%@ page language="C#"  CodeFile="sttechnician.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stat_StTechnician" theme="Themes" enableEventValidation="false" %>
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
            </span>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="statf" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false" Width="60%">
        <Columns>
            <asp:BoundField HeaderText="��"/>
            <asp:BoundField HeaderText="����Ա" DataField="Technician"/>
            <asp:BoundField HeaderText="��ɵ�ҵ����" DataField="Finish_Op" />
            <asp:BoundField HeaderText="ȡ����ҵ����" DataField="Cancel_Op" />
            <asp:BoundField HeaderText="����" DataField="Tec_Score" HtmlEncode="false" DataFormatString="{0:n2}" />
            <asp:BoundField HeaderText="���Ϸ�" DataField="Cost_CL" HtmlEncode="false" DataFormatString="{0:c2}" />
            <asp:BoundField HeaderText="�˹���" DataField="Cost_RG" HtmlEncode="false" DataFormatString="{0:c2}"  />
            <asp:BoundField HeaderText="���ӷ�" DataField="Cost_FJ" HtmlEncode="false" DataFormatString="{0:c2}"  />
            <asp:BoundField HeaderText="���ϳɱ�" DataField="Cost_CB" HtmlEncode="false" DataFormatString="{0:c2}"  />
            <asp:BoundField HeaderText="����ɱ�" DataField="Cost_EW" HtmlEncode="false" DataFormatString="{0:c2}"  />
            <asp:BoundField HeaderText="�Կͻ��տ�" DataField="Charge_Cus" HtmlEncode="false" DataFormatString="{0:c2}"  />
            <asp:BoundField HeaderText="�Գ����տ�" DataField="Charge_Sup" HtmlEncode="false" DataFormatString="{0:c2}"  />
            <asp:BoundField HeaderText="Ӫҵ��" DataField="ChargeValue" HtmlEncode="false" DataFormatString="{0:c2}" />
            <asp:BoundField HeaderText="ë��" DataField="Profit" HtmlEncode="false" DataFormatString="{0:c2}" />
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="a.ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
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
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("����Աҵ��");
}
</script>