<%@ page language="C#"  CodeFile="snadm.aspx.cs"     autoeventwireup="true" inherits="Branch_Stock_SNAdm" theme="Themes" enableEventValidation="false" %>
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
            <td style="padding-left:15px;color:#ff0000;">���㣺</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" Width="100">
                </asp:DropDownList>
            </td>
            <td style="padding-left:15px;color:#ff0000;">�ֿ⣺</td>
            <td style="padding-left:0px;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DropDownList ID="ddlStock" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlStock_SelectedIndexChanged" Width="120">
                </asp:DropDownList>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="tvgds" EventName="SelectedNodeChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlBranch" EventName="SelectedIndexChanged" />
            </Triggers>
            </asp:UpdatePanel>
            </td>
            <td>
                <input id="btnNew" type="button" value="���" class="bt1" onclick="parent.ShowDialog(800, 500, 'Stock/SNStockIN.aspx', '���к����');" />
                <input id="btnMod" type="button" value="����" class="bt1" onclick="parent.ShowDialog(800, 500,'Stock/SNStockOUT.aspx','���кų���');" />
                <span style="display:none;">
                    <asp:Button ID="btnFsh" runat="server" Text="ˢ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnFsh_Click"/>
                    
                    <asp:Button ID="btnDel" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('���к�')==false) return false;" OnClick="btnDel_Click"/>
                    <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                </span>
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
        <table cellpadding="0" cellspacing="0" class="tb2">
        <tr>
            <td style="padding-left:0px;">
                <input id="btnInput" runat="server" type="button" class="binput" value="����" onclick="ChkInput();" />
            </td>
            <td style="padding-left:0px;">
                <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
             <td>
             <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl" onchange="document.getElementById('ddlKey').focus();" Width="80">
                <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                <asp:ListItem Value="�ڿ�">�ڿ�</asp:ListItem>
                <asp:ListItem Value="���">���</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td>
            <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                <asp:ListItem Value="SN">�����кŲ�ѯ</asp:ListItem>
                <asp:ListItem Value="GoodsNO">����Ʒ��Ų�ѯ</asp:ListItem>
                <asp:ListItem Value="_Name">����Ʒ���Ʋ�ѯ</asp:ListItem>
                <asp:ListItem Value="Spec">����Ʒ����ѯ</asp:ListItem>
                <asp:ListItem Value="Brand">����ƷƷ�Ʋ�ѯ</asp:ListItem>
                <asp:ListItem Value="BillID">����ⵥ�Ų�ѯ</asp:ListItem>
                <asp:ListItem Value="_Date">��������ڲ�ѯ</asp:ListItem>
                <asp:ListItem Value="Type">�����ҵ������ѯ</asp:ListItem>
                <asp:ListItem Value="OperationID">�����ҵ�񵥺Ų�ѯ</asp:ListItem>
                <asp:ListItem Value="StockOUTNO">�����ⵥ�Ų�ѯ</asp:ListItem>
                <asp:ListItem Value="_OUTDate">���������ڲ�ѯ</asp:ListItem>
                <asp:ListItem Value="OUTType">������ҵ������ѯ</asp:ListItem>
                <asp:ListItem Value="OUTOperationID">������ҵ�񵥺Ų�ѯ</asp:ListItem>
                <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td>
            <td align="left">
            <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
          </tr>
        </table>
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="lndiv" class="lndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:TreeView ID="tvgds" runat="server" ShowLines="True" OnSelectedNodeChanged="tvgds_SelectedNodeChanged" OnTreeNodeExpanded="tvgds_TreeNodeExpanded">
            <SelectedNodeStyle BackColor="#7d8abe" BorderColor="White" />
        </asp:TreeView>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="tvgds" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="lncn" class="uw"></div>
    <div id="cndiv" style="float:left;height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="״̬" DataField="Status" />
            <asp:BoundField HeaderText="���к�" DataField="SN" />
            <asp:BoundField HeaderText="״̬" DataField="Status" />
            <asp:BoundField HeaderText="��Ʒ���" DataField="GoodsNO" />
            <asp:BoundField HeaderText="����" DataField="_Name" />
            <asp:BoundField HeaderText="��������" DataField="Dept" />
            <asp:BoundField HeaderText="�����ֿ�" DataField="StockName" />
            <asp:BoundField HeaderText="�ֿ�����" DataField="Reject" />
            <asp:BoundField HeaderText="��λ" DataField="StockLocName" />
            <asp:BoundField HeaderText="����" DataField="Price" />
            <asp:BoundField HeaderText="�ֿ����" DataField="CostPrice" />
            <asp:BoundField HeaderText="���" DataField="Spec" />
            <asp:BoundField HeaderText="Ʒ��" DataField="Brand" />
            <asp:BoundField HeaderText="��ⵥ��" DataField="BillID" />
            <asp:BoundField HeaderText="�������" DataField="_Date" />
            <asp:BoundField HeaderText="���ҵ�����" DataField="Type" />
            <asp:BoundField HeaderText="���ҵ�񵥺�" DataField="OperationID" />
            <asp:BoundField HeaderText="���ⵥ��" DataField="StockOUTNO" />
            <asp:BoundField HeaderText="��������" DataField="_OUTDate" />
            <asp:BoundField HeaderText="����ҵ�����" DataField="OUTType" />
            <asp:BoundField HeaderText="����ҵ�񵥺�" DataField="OUTOperationID" />
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
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfClass" runat="server" />
    <asp:HiddenField ID="hfClassID" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    <asp:HiddenField ID="hfPurCostPrice" runat="server" Value="0" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tvgds" EventName="SelectedNodeChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlBranch" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlStock" EventName="SelectedIndexChanged" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    <div class="fbom">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td><div id="fbon" class="fbon"></div></td>
                <td>
                    <span class="sred">���</span>
                    <span class="sgreen">�ڿ�</span>
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
function Goods(id)
{
    parent.ShowDialog(620, 425,'Stock/GoodsMod.aspx?ids='+id,'��Ʒ��ϸ');
}
function StockIN(id)
{
    parent.ShowDialog(800, 520, 'Stock/StockINMod.aspx?ids=' + id, '��ⵥ');
}
function StockOut(id)
{
    parent.ShowDialog(800, 520,'Stock/StockOutMod.aspx?ids='+id,'���ⵥ');
}
function BroughtBack(id,title)
{
    parent.ShowDialog(800, 480,'Stock/BroughtBackMod.aspx?ids='+id,title);
}
function Sell(id,title)
{
    parent.ShowDialog(800, 480,'Sell/SellMod.aspx?ids='+id,title);
}
function Lease(id)
{
    parent.ShowDialog(800, 480,'Lease/LeaseMod.aspx?ids='+id,'ҵ��');
}
function Chkset()
{
    Chkwh3();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("���кſ�");
}
function ChkInput()
{
    parent.ShowDialog(520, 193,'Stock/InputSN.aspx', '�������кſ�');
}
</script>
