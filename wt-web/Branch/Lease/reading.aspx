<%@ page language="C#"  CodeFile="reading.aspx.cs"     autoeventwireup="true" inherits="Branch_Lease_Reading" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:586px;">
    <div class="fdivs" style="width:584px; height:40px;">
    <div class="sdivs" style="width:582px; height:38px;">
    <div class="divh"></div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tb5">
                <tr>
                     <td align="right">�������ڣ�</td>
                    <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                    </td>
                    <td align="right">
                    �����ˣ�</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <a href="#" onclick="ViewHistory();">>>�鿴��ʷ����</a>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <div class="fdivs" style="width:584px; height:277px;">
    <div class="sdivs" style="width:582px; height:275px; overflow:auto; background:#ffffff;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound">
                <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="DeviceID" DataField="DeviceID" />
                <asp:BoundField HeaderText="QtyType" DataField="QtyType" />
                <asp:BoundField HeaderText="BillID" DataField="ID" />
                <asp:BoundField HeaderText="��" />
                <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
                <asp:BoundField HeaderText="�������к�" DataField="ProductSN1" />
                <asp:BoundField HeaderText="����������" DataField="QtyTypeName" />
                <asp:TemplateField HeaderText="���μ���" HeaderStyle-ForeColor="#ff0000">
                    <ItemTemplate>
                        <asp:TextBox ID="tbQty" runat="server" CssClass="tbstyle" Width="60" onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="�������">
                    <ItemTemplate>
                        <asp:TextBox ID="tbLoss" runat="server" CssClass="tbstyle" Width="50" onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="�Ĳ�Ԥ������">
                    <ItemTemplate>
                        <asp:TextBox ID="tbWDate" runat="server" CssClass="Wdate3" Width="95" onfocus="WdatePicker()"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="��ע">
                    <ItemTemplate>
                        <asp:TextBox ID="tbWRemark" runat="server" CssClass="tbstyle" Width="120" onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
    </div>
    </div>
     <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td><span class="si1">���μ���Ϊ�ջ���Ϊ�㲻�Ǽ�.</span></td>
        <td align="right">
            <asp:Button ID="btnAdd" runat="server" Text="ȷ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
            <input id="btnCls" type="button" value="ȡ��" class="bt1" onclick="parent.CloseDialog();"/>
        </td>
    </tr>
    </table>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detailslt.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var processtip=1;
function ChkAdd()
{
    if(isNull($("tbDate").value))
    {
        window.alert("����ʧ�ܣ��������ڲ���Ϊ��");
        $("tbDate").focus();
        return false
    }
    if($("ddlOperator").value=="-1")
    {
        window.alert("����ʧ�ܣ������˲���Ϊ��");
        $("ddlOperator").focus();
        return false
    }
}

function ViewHistory()
{
     parent.ShowDialog1(700, 510,'Lease/HistoryReading.aspx?id=<%=Str_id %>', '��ʷ����');
}
</script>
