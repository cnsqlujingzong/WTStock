<%@ page language="C#"  CodeFile="materialde.aspx.cs"     autoeventwireup="true" inherits="Branch_Stat_MaterialDe" theme="Themes" enableEventValidation="false" %>
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
                <asp:ListItem Value="billid">�����ݱ�Ų�ѯ</asp:ListItem>
                <asp:ListItem Value="CustomerName">���ͻ����Ʋ�ѯ</asp:ListItem>
                <asp:ListItem Value="LinkMan">����ϵ�˲�ѯ</asp:ListItem>
                <asp:ListItem Value="UsePerson">��ʹ���˲�ѯ</asp:ListItem>
                <asp:ListItem Value="UsePersonTel">��ʹ���˵绰��ѯ</asp:ListItem>
                <asp:ListItem Value="Adr">����ַ��ѯ</asp:ListItem>
                <asp:ListItem Value="D_Name">���������Ʋ�ѯ</asp:ListItem>
                <asp:ListItem Value="D_Parameters">������������ѯ</asp:ListItem>
                <asp:ListItem Value="D_SN">���������кŲ�ѯ</asp:ListItem>
                <asp:ListItem Value="D_Maint">�����������ڲ�ѯ</asp:ListItem>
                <asp:ListItem Value="D_BuyDate">���������ڲ�ѯ</asp:ListItem>
                
                <asp:ListItem Value="M_GoodsNO">��������Ų�ѯ</asp:ListItem>
                <asp:ListItem Value="M_Name">���������Ʋ�ѯ</asp:ListItem>
                <asp:ListItem Value="M_SN">���������кŲ�ѯ</asp:ListItem>
                <asp:ListItem Value="M_MaintenancePeriod">�����������ڲ�ѯ</asp:ListItem>
                <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td>
                <input id="btnSchsH" type="button" value="�߼���ѯ" class="bsch" onclick="parent.ShowDialog(500,345, 'Stat/SchHMaterialDe.aspx', '�߼���ѯ');" />
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
            <asp:BoundField HeaderText="ҵ����" DataField="billid" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="�绰" DataField="Tel" />
            <asp:BoundField HeaderText="ʹ����" DataField="UsePerson" />
            <asp:BoundField HeaderText="ʹ���˲���" DataField="UsePersonDept" />
            <asp:BoundField HeaderText="ʹ���˵绰" DataField="UsePersonTel" />
            <asp:BoundField HeaderText="��ַ" DataField="Adr" />
            <asp:BoundField HeaderText="��������" DataField="D_Name" />
            <asp:BoundField HeaderText="��������" DataField="D_Parameters" />
            <asp:BoundField HeaderText="�������к�" DataField="D_SN" />
            <asp:BoundField HeaderText="����������" DataField="D_Maint" />
            <asp:BoundField HeaderText="�������޽�ֹ" DataField="D_MaintE" />
            <asp:BoundField HeaderText="��������" DataField="D_BuyDate" />
            <asp:BoundField HeaderText="������ע" DataField="D_Remark" />
            <asp:BoundField HeaderText="�������" DataField="M_GoodsNO" />
            <asp:BoundField HeaderText="��������" DataField="M_Name" />
            <asp:BoundField HeaderText="������λ" DataField="M_Unit" />
            <asp:BoundField HeaderText="��������"  DataField="M_Qty"/>
            <asp:BoundField HeaderText="�����۸�" DataField="M_Price" />
            <asp:BoundField HeaderText="�����ܶ�" DataField="M_Total" />
            <asp:BoundField HeaderText="��������"  DataField="M_LQty"/>
            <asp:BoundField HeaderText="�������к�"  DataField="M_SN"/>
            <asp:BoundField HeaderText="����������"  DataField="M_MaintenancePeriod"/>
            <asp:BoundField HeaderText="���޽�ֹ"  DataField="M_PeriodEndDate"/>
            <asp:BoundField HeaderText="�����ɱ�"  DataField="M_CostPrice"/>
            <asp:BoundField HeaderText="������ע"  DataField="M_Remark"/>

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
    <div id="fbon" class="fbon"></div>
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
    $("fbon").innerHTML=parent.DrawInfo("������ϸ���ܱ�");
}
</script>
