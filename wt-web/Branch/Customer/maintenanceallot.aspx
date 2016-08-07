<%@ page language="C#"  CodeFile="maintenanceallot.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_MaintenanceAllot" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body onload="Chkset();" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="ftool">
        <div class="ftoolleft">
        <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
                <asp:Button ID="btnFsh" runat="server" Text="ˢ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnFsh_Click"/>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                    <asp:Button ID="btnSchH" runat="server" Text="�߼���ѯ" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />
                </span>
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="pindl" Width="100">
                        <asp:ListItem Value="0">���ɹ�</asp:ListItem>
                        <asp:ListItem Value="1">���ɹ�</asp:ListItem>
                        <asp:ListItem Value="2">��ȡ��</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">ģ����ѯ</asp:ListItem>
                    <asp:ListItem Value="1">���ͻ���Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="2">���ͻ����Ʋ�ѯ</asp:ListItem>
                    <asp:ListItem Value="3">����ϵ�˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="4">����ϵ�绰��ѯ</asp:ListItem>
                    <asp:ListItem Value="5">��Ʒ�Ʋ�ѯ</asp:ListItem>
                    <asp:ListItem Value="6">������ѯ</asp:ListItem>
                    <asp:ListItem Value="7">���ͺŲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="8">�����кŲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td style="padding:0px;"><input id="btnSchsH" type="button" value="�߼���ѯ" class="bsch" onclick="parent.ShowDialog(510,373, 'Customer/DeviceCd.aspx', '�߼���ѯ');" /></td>
            </tr>
            </table>   
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderTemplate>
                    <input id="cball" type="checkbox" class="cb1" onclick="SltAllValue();" title="ȫѡ/ȡ��ȫѡ"/>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="��������" DataField="_Date" />
            <asp:BoundField HeaderText="�ͻ����" DataField="CustomerNO" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="_Name" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��������" DataField="CusDept" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="��ַ" DataField="Adr" />
            <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
            <asp:BoundField HeaderText="���" DataField="ProductClass" />
            <asp:BoundField HeaderText="�ͺ�" DataField="ProductModel" />
            <asp:BoundField HeaderText="���к�1" DataField="ProductSN1" />
            <asp:BoundField HeaderText="���к�2" DataField="ProductSN2" />
            <asp:BoundField HeaderText="���" DataField="ProductAspect" />
            <asp:BoundField HeaderText="����ʱ��" DataField="BuyDate" />
            <asp:BoundField HeaderText="������" DataField="BuyFrom" />
            <asp:BoundField HeaderText="����Ʊ" DataField="BuyInvoice" />
            <asp:BoundField HeaderText="��װ����" DataField="InstallDate" />
            <asp:BoundField HeaderText="������" DataField="MaintenancePeriod" />
            <asp:BoundField HeaderText="�������" DataField="Warranty" />
            <asp:BoundField HeaderText="���ұ��޿�ʼ" DataField="WarrantyStart" />
            <asp:BoundField HeaderText="���ұ��޽���" DataField="WarrantyEnd" />
            <asp:BoundField HeaderText="ά�޴���" DataField="RepairTimes" />
            <asp:BoundField HeaderText="���ά��ʱ��" DataField="Repairlately" />
            <asp:BoundField HeaderText="ά�ޱ��޽���" DataField="RepairWarrantyEnd" />
            <asp:BoundField HeaderText="��ͬ���޿�ʼ" DataField="ContractWarrantyStart" />
            <asp:BoundField HeaderText="��ͬ���޽���" DataField="ContractWarrantyEnd" />
            <asp:BoundField HeaderText="ά�޺�ͬ���" DataField="ContractNO" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
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
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    <asp:HiddenField ID="hfcbID" runat="server" />
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    <asp:HiddenField ID="hfPurArea" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1" class="tabs_activeleft"></span>
                <span id="tabs1" class="tabs_active" >�����ɹ�</span>
                <span id="tabs_r1" class="tabs_activeright"></span>
            </div>
        </div>
        <div class="cndiv2" id="cndiv2">
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" class="tb5">
                <tr>
                    <td align="right" style="width:60px;">
                    ����Ա��</td>
                    <td style="padding-left:0px; width:130px;">
                        <asp:TextBox ID="tbDisposal" runat="server" CssClass="pinks"></asp:TextBox>
                    </td>
                    <td style="padding:0px; text-align:left;"><input id="btnSltStaff" type="button" value="" onclick="SltTec();" class="bview"/></td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" class="tb5">
                <tr>
                    <td align="right">���񼶱�</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlPRI" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="��ͨ">��ͨ</asp:ListItem>
                            <asp:ListItem Value="����">����</asp:ListItem>
                            <asp:ListItem Value="����">����</asp:ListItem>
                        </asp:DropDownList>
                    </td>
               </tr>
               <tr>
                    <td align="right">��ע��</td>
                    <td style="padding-left:0px;height:50px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" TextMode="MultiLine" Height="40" Width="300"></asp:TextBox></td>
                </tr>
            </table>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="left" style="padding-left:230px;">
                        <asp:Button ID="btnSave" runat="server" Text="��������" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSltValue()==false) return false" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="ȡ������" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkCancel()==false) return false" OnClick="btnCancel_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="fbom">
        <div id="fbon" class="fbon"></div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
}

function Chkset()
{
    Chkwh2();
    Chkbom(); 
}

function ChkCancel()
{
    if(ChkSltValue()!=false)
    {
        return confirm("ȷ��Ҫȡ�������ɹ���");
    }else{return false;}
}

function SltTec()
{
    parent.ShowDialog1(400, 510, 'Services/SltTec.aspx?f=1&fid='+parent.$("hfActiveWin").value, '����Ա');
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("�����ɹ�");
}

</script>
