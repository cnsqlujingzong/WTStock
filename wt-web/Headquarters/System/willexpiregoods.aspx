<%@ page language="C#"  CodeFile="willexpiregoods.aspx.cs"     autoeventwireup="true" inherits="Headquarters_System_WillExpireGoods" theme="Themes" enableEventValidation="false" %>
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
                    <asp:DropDownList ID="ddlWaring" runat="server">
                        <asp:ListItem Value="3">3���ڽ�Ҫ����</asp:ListItem>
                        <asp:ListItem Value="5">5���ڽ�Ҫ����</asp:ListItem>
                        <asp:ListItem Value="7" Selected="true">7���ڽ�Ҫ����</asp:ListItem>
                        <asp:ListItem Value="14">14���ڽ�Ҫ����</asp:ListItem>
                        <asp:ListItem Value="30">30���ڽ�Ҫ����</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                   <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                        <asp:ListItem Value="strBillID">����ⵥ�Ų�ѯ</asp:ListItem>
                        <asp:ListItem Value="StockName">���ֿ��ѯ</asp:ListItem>
                        <asp:ListItem Value="_Name">����Ʒ���Ʋ�ѯ</asp:ListItem>
                        <asp:ListItem Value="Spec">������ѯ</asp:ListItem>
                        <asp:ListItem Value="ProductBrand">��Ʒ�Ʋ�ѯ</asp:ListItem>
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
            <asp:BoundField HeaderText="�ֿ�" DataField="StockName" />
            <asp:BoundField HeaderText="��Ʒ���" DataField="GoodsNO" />
            <asp:BoundField HeaderText="����" DataField="_Name" />
            <asp:BoundField HeaderText="���" DataField="Spec" />
            <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
            <asp:BoundField HeaderText="��ⵥ��" DataField="strBillID" />
            <asp:BoundField HeaderText="�������" DataField="_Date" HtmlEncode="false" DataFormatString="{0:yyyy-MM-dd}"/>
            <asp:BoundField HeaderText="��Ч����" DataField="EndDate" HtmlEncode="false" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField HeaderText="�������" DataField="Qty" HtmlEncode="false" DataFormatString="{0:F2}" />
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
