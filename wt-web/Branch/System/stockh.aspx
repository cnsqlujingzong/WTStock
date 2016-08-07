<%@ page language="C#"  CodeFile="stockh.aspx.cs"     autoeventwireup="true" inherits="Branch_System_StockH" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <div class="ftool">
        <div class="ftoolleft">
        <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                        <asp:ListItem Value="0">ģ����ѯ</asp:ListItem>
                        <asp:ListItem Value="1">����Ų�ѯ</asp:ListItem>
                        <asp:ListItem Value="2">�����Ʋ�ѯ</asp:ListItem>
                        <asp:ListItem Value="3">������ѯ</asp:ListItem>
                        <asp:ListItem Value="4">�����Բ�ѯ</asp:ListItem>
                        <asp:ListItem Value="6">��Ʒ�Ʋ�ѯ</asp:ListItem>
                        <asp:ListItem Value="7">�������ڲ�ѯ</asp:ListItem>
                        <asp:ListItem Value="9">����ע��ѯ</asp:ListItem>
                        <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                    </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
             </tr>
            </table>   
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                </span>
            </td>
            <td style="padding-right:80px;">
                
            </td>
            </tr>
            </table>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="height:480px; width:920px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="��Ʒ���" DataField="GoodsNO" />
            <asp:BoundField HeaderText="��Ʒ����" DataField="_Name" />
            <asp:BoundField HeaderText="����" DataField="Attr" />
            <asp:BoundField HeaderText="�ֿ�" DataField="StockName" />
            <asp:BoundField HeaderText="���" DataField="Stock" />
            <asp:BoundField HeaderText="�ɱ�����" DataField="CostPrice" />
            <asp:BoundField HeaderText="��λ" DataField="StockLocName" />
            <asp:BoundField HeaderText="��������" DataField="downWarning" />
            <asp:BoundField HeaderText="��������" DataField="upWarning" />
            <asp:BoundField HeaderText="���" DataField="Spec" />
            <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
            <asp:BoundField HeaderText="��λ" DataField="Unit" />
            <asp:BoundField HeaderText="���ۼ�" DataField="PriceDetail" />
            <asp:BoundField HeaderText="������" DataField="PriceCost" />
            <asp:BoundField HeaderText="�ڲ���" DataField="PriceInner" />
            <asp:BoundField HeaderText="�ɻ���" DataField="PriceWholesale1" />
            <asp:BoundField HeaderText="�����" DataField="PriceWholesale2" />
            <asp:BoundField HeaderText="�б��" DataField="PriceWholesale3" />
            <asp:BoundField HeaderText="������" DataField="MaintenancePeriod" />
            <asp:BoundField HeaderText="���ò�Ʒ" DataField="ForProducts" />
            <asp:BoundField HeaderText="�ɱ�ģʽ" DataField="CostMode" />
            <asp:BoundField HeaderText="Ĭ�ϲֿ�" DataField="StockName" />
            <asp:BoundField HeaderText="��Ӧ��" DataField="Provider" />
            <asp:BoundField HeaderText="�������" DataField="bStock" />
            <asp:BoundField HeaderText="��Ч��(��)" DataField="Valid" />
            <asp:BoundField HeaderText="��ֵ��Ʒ" DataField="bIncrement" />
            <asp:BoundField HeaderText="����" DataField="BarCode" />
            <asp:BoundField HeaderText="ͣ��" DataField="bStop" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
        </Columns>
    </asp:GridView>
    <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
        </tr>
    </table>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
        <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
        <asp:HiddenField ID="hfSql" runat="server" />
        <asp:HiddenField ID="hfClass" runat="server" />
        <asp:HiddenField ID="hfCusName" runat="server" />
        <asp:HiddenField ID="hfreclist" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div class="clearfloat"></div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
