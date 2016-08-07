<%@ page language="C#"  CodeFile="repairrcvcal.aspx.cs"     autoeventwireup="true" inherits="Branch_Services_RepairRcvCal" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:666px;">
    <div class="fdivs">
    <div class="sdivs" style="padding:5px 0 5px 0px;width:662px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td>�������</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbRepairType" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
                </td>
                <td>���޳��̣�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbRepairCorp" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>�ջ����ڣ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td class="red">ά�޷��ã�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbRMoney" runat="server" CssClass="pin pbr"></asp:TextBox>
                </td>
            </tr>
        </table>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnAvg" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <div class="fdivs">
    <div class="sdivs" style="width:662px; height:253px; overflow:auto; background:#ffffff;">
     <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
        <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound">
            <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="��" />
            <asp:BoundField HeaderText="���񵥺�" DataField="BillID" />
            <asp:BoundField HeaderText="��������" DataField="RepairSndDate" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
            <asp:TemplateField HeaderText="ά�޷���" HeaderStyle-ForeColor="#ff0000">
                <ItemTemplate>
                    <asp:TextBox ID="tbCost" runat="server" Text='<%# Eval("Cost") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="�����ͺ�" DataField="ProductModel" />
            <asp:BoundField HeaderText="���к�1" DataField="ProductSN1" />
            <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
            <asp:BoundField HeaderText="���" DataField="ProductClass" />
            <asp:TemplateField HeaderText="��ע">
                <ItemTemplate>
                    <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Text='<%# Eval("Remark") %>' Width="200" BorderWidth="0" ReadOnly="true"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnAvg" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnAvg" runat="server" Text="ƽ������" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAvg_Click"/>
                <asp:Button ID="btnSave" runat="server" Text="ȷ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnSave_Click"/>
                <input id="btnClose" type="button" value="ȡ��" class="bt1" onclick="parent.CloseDialog();" />
            </td>
        </tr>
    </table>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/menu.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
function ChkSave()
{
    if(isNull($("tbDate").value))
    {
        window.alert("����ʧ�ܣ��ջ����ڲ���Ϊ��");
        $("tbDate").focus();
        return false
    }
    if(isNull($("tbRMoney").value))
    {
        window.alert("����ʧ�ܣ�ά�޷��ò���Ϊ��");
        $("tbRMoney").focus();
        return false
    }
    if(!isMoney($("tbRMoney").value))
    {
        window.alert("����ʧ�ܣ�ά�޷��ø�ʽ����ȷ");
        $("tbRMoney").focus();
        return false
    }
}
</script>

