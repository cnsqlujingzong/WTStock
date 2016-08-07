<%@ page language="C#"  CodeFile="ststockinde.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stat_StStockINDe" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
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
            <td>
            <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
            <asp:ListItem Value="BillID">�����ݱ�Ų�ѯ</asp:ListItem>
                <asp:ListItem Value="_Date">���Ƶ����ڲ�ѯ</asp:ListItem>
                <asp:ListItem Value="Person">���Ƶ��˲�ѯ</asp:ListItem>
                <asp:ListItem Value="Operator">�������˲�ѯ</asp:ListItem>
                <asp:ListItem Value="Reason">�����ԭ���ѯ</asp:ListItem>
                <asp:ListItem Value="OperationID">��ҵ���Ų�ѯ</asp:ListItem>
                <asp:ListItem Value="ChkDate">��������ڲ�ѯ</asp:ListItem>
                <asp:ListItem Value="ChkOperator">������˲�ѯ</asp:ListItem>
                <asp:ListItem Value="StockName">���ֿ��ѯ</asp:ListItem>
                <asp:ListItem Value="GoodsNO">����Ʒ��Ų�ѯ</asp:ListItem>
                <asp:ListItem Value="_Name">����Ʒ���Ʋ�ѯ</asp:ListItem>
                <asp:ListItem Value="Spec">����Ʒ����ѯ</asp:ListItem>
                <asp:ListItem Value="ProductBrand">����ƷƷ�Ʋ�ѯ</asp:ListItem>
                <asp:ListItem Value="SN">�����кŲ�ѯ</asp:ListItem>
                <asp:ListItem Value="Remark">����ע��ѯ</asp:ListItem>
                <asp:ListItem Value="BillRemark">�����ݱ�ע��ѯ</asp:ListItem>
                <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td>
                <input id="btnSchsH" type="button" value="�߼���ѯ" class="bsch" onclick="parent.ShowDialog(460,316, 'Stat/StStockDeCd.aspx', '�߼���ѯ');" />
            </td>
            <td>
            <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
            </td>
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
                            <asp:Button ID="btnSchH" runat="server" Text="�߼���ѯ" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />
                        </span>
                    </td>
                </tr>
            </table>   
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="statf" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="���ݱ��" DataField="BillID" />
            <asp:BoundField HeaderText="����" DataField="_Date" />
            <asp:BoundField HeaderText="�Ƶ���" DataField="Person" />
            <asp:BoundField HeaderText="������" DataField="Operator" />
            <asp:BoundField HeaderText="����" DataField="Dept" />
            <asp:BoundField HeaderText="���ԭ��" DataField="Reason" />
            <asp:BoundField HeaderText="ҵ����" DataField="OperationID" />
            <asp:BoundField HeaderText="�������" DataField="ChkDate" />
            <asp:BoundField HeaderText="�����" DataField="ChkOperator" />
            <asp:BoundField HeaderText="�ֿ�" DataField="StockName" />
            <asp:BoundField HeaderText="��Ʒ���" DataField="GoodsNO" />
            <asp:BoundField HeaderText="����" DataField="_Name" />
            <asp:BoundField HeaderText="���" DataField="Spec" />
            <asp:BoundField HeaderText="����" DataField="Attr" />
            <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
            <asp:BoundField HeaderText="��λ" DataField="Unit" />
            <asp:BoundField HeaderText="����" DataField="Qty" />
            <asp:BoundField HeaderText="����" DataField="Price" />
            <asp:BoundField HeaderText="���" DataField="Total" />
            <asp:BoundField HeaderText="���к�"  DataField="SN"/>
            <asp:BoundField HeaderText="������" DataField="MainTenancePeriod" />
            <asp:BoundField HeaderText="��ע"  DataField="Remark"/>
        </Columns>
    </asp:GridView>
    
    <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCountText" runat="server" ToolTip="�ܼ�¼��" Text="�ܼ�¼:"></asp:Label><asp:Label ID="lbCount" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
        </tr>
    </table>
    
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
        <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
        <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
        <asp:HiddenField ID="hfSql" runat="server" />
        <asp:HiddenField ID="hfTbTitle" runat="server" />
        <asp:HiddenField ID="hfTbField" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
       
    <div class="fbom">  
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><div id="fbon" class="fbon"></div></td>
            <td>
                
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                   <span class="sysred">����ܽ�</span>
                   <asp:Label ID="lbAmount" runat="server" CssClass="sysred" Text="0.00"></asp:Label>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
                </Triggers>       
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
}
function ViewSN(strsn)
{
    parent.ShowDialog1(400, 300, 'Stock/ViewSN.aspx?sn='+escape(strsn), '�鿴���к�');
}
function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("�����ϸ���ܱ�");
}
</script>