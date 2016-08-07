<%@ page language="C#"  CodeFile="sltdev.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_SltDev" theme="Themes" enableEventValidation="false" %>
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
                    <asp:ListItem Value="1">��������Ų�ѯ</asp:ListItem>
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
                <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" />
                <input id="btnNew" runat="server" type="button" value="�½�" class="bt1" onclick="parent.ShowDialog2(750, 430, '../Branch/Customer/DeviceAdd.aspx?f=2'+strtel, '�½���������');" />
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
                    <asp:Button ID="btnShow" runat="server" Text="��ʾ" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="false"/>
                </span>
            </td>
            <td style="padding-right:80px;">
                <input id="btnAdd" type="button" value="ȷ��" class="bt1" onclick="ChkSltList();"/>
            </td>
            </tr>
            </table>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="height:300px; width:800px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderTemplate>
                    <input id="cball" type="checkbox" class="cb1" onclick="allcb();" title="ȫѡ/ȡ��ȫѡ"/>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="_Name" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
            <asp:BoundField HeaderText="���" DataField="ProductClass" />
            <asp:BoundField HeaderText="�ͺ�" DataField="ProductModel" />
            <asp:BoundField HeaderText="���к�1" DataField="ProductSN1" />
            <asp:BoundField HeaderText="���к�2" DataField="ProductSN2" />
            <asp:BoundField HeaderText="���" DataField="ProductAspect" />
            <asp:BoundField HeaderText="��Ȩ" DataField="Property" />
            <asp:BoundField HeaderText="����ʱ��" DataField="BuyDate" />
            <asp:BoundField HeaderText="����۸�" DataField="BuyPrice" />
            <asp:BoundField HeaderText="������" DataField="BuyFrom" />
            <asp:BoundField HeaderText="����Ʊ" DataField="BuyInvoice" />
            <asp:BoundField HeaderText="��װ����" DataField="InstallDate" />
            <asp:BoundField HeaderText="������" DataField="MaintenancePeriod" />
            <asp:BoundField HeaderText="�������" DataField="Warranty" />
            <asp:BoundField HeaderText="���ұ��޿�ʼ" DataField="WarrantyStart" />
            <asp:BoundField HeaderText="���ұ��޽���" DataField="WarrantyEnd" />
            <asp:BoundField HeaderText="ά�޴�" DataField="RepairTimes" />
            <asp:BoundField HeaderText="���ά��ʱ��" DataField="Repairlately" />
            <asp:BoundField HeaderText="ά�ޱ��޽���" DataField="RepairWarrantyEnd" />
            <asp:BoundField HeaderText="��ͬ���޿�ʼ" DataField="ContractWarrantyStart" />
            <asp:BoundField HeaderText="��ͬ���޽���" DataField="ContractWarrantyEnd" />
            <asp:BoundField HeaderText="ά�޺�ͬ���" DataField="ContractNO" />
            <asp:BoundField HeaderText="��������" DataField="CusDept" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="�ֻ�����" DataField="Tel2" />
            <asp:BoundField HeaderText="����" DataField="Fax" />
            <asp:BoundField HeaderText="�ʱ�" DataField="Zip" />
            <asp:BoundField HeaderText="��ַ" DataField="Adr" />
            <asp:BoundField HeaderText="�Զ���1" DataField="userdef1" />
            <asp:BoundField HeaderText="�Զ���2" DataField="userdef2" />
            <asp:BoundField HeaderText="�Զ���3" DataField="userdef3" />
            <asp:BoundField HeaderText="�Զ���4" DataField="userdef4" />
            <asp:BoundField HeaderText="�Զ���5" DataField="userdef5" />
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
        <asp:HiddenField ID="hfPurArea" runat="server" />
        <asp:HiddenField ID="hfreclist" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="cnbut" style=" height:160px;overflow:hidden;">
        <div class="ftool2">
        <div id="mytabs" style="padding-left:2px;">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">��������</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">�����б�</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">������</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">�����¼</span>
            <span id="tabs_r4"></span>
            <span id="tabs_l5"></span>
            <span id="tabs5" onclick="ChkTab('5');">����</span>
            <span id="tabs_r5"></span>
            <span id="tabs_l6"></span>
            <span id="tabs6" onclick="ChkTab('6');">����/ȫ��</span>
            <span id="tabs_r6"></span>
        </div>
        </div>
        <div id="info1" style="height:130px;background:#ECE9D8;">
        <div class="cndiv2" id="cndiv2" style="height:130px;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView2_RowDataBound" EnableViewState="false" Width="70%">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="����" DataField="_Name" />
                    <asp:BoundField HeaderText="����" DataField="Parameter" />
                    <asp:BoundField HeaderText="���к�" DataField="SN" />
                    <asp:BoundField HeaderText="������" DataField="MaintenancePeriod" />
                    <asp:BoundField HeaderText="��������" DataField="BuyDate" />
                    <asp:BoundField HeaderText="��ֹ����" DataField="MaintenanceEnd" />
                    <asp:BoundField HeaderText="��ע" DataField="Remark" />
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info2" style="height:130px;background:#ECE9D8;">
        <div class="cndiv2" id="Div1" style="height:130px;">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView4_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="����" DataField="_Name" />
                    <asp:BoundField HeaderText="ժҪ" DataField="Remark" />
                    <asp:BoundField HeaderText="����" DataField="Path" />
                    <asp:BoundField HeaderText="��������" DataField="_Date" />
                    <asp:BoundField HeaderText="������" DataField="Operator" />
                </Columns>
            </asp:GridView>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info3" style="height:130px;background:#ECE9D8;">
        <div class="cndiv2" id="Div2" style="height:130px;">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView3_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="��������" DataField="_Date" />
                    <asp:BoundField HeaderText="������" DataField="Operator" />
                    <asp:BoundField HeaderText="����" DataField="QtyType" />
                    <asp:BoundField HeaderText="����" DataField="Qty" />
                    <asp:BoundField HeaderText="��ע"  DataField="Remark"/>
                </Columns>
            </asp:GridView>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info4" style="height:130px;background:#ECE9D8;">
        <div class="cndiv2" id="Div3" style="height:130px;">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView5_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="��������" DataField="_Date" />
                    <asp:BoundField HeaderText="������" DataField="Operator" />
                    <asp:BoundField HeaderText="����������" DataField="_Name" />
                    <asp:BoundField HeaderText="����" DataField="Qty" />
                    <asp:BoundField HeaderText="�������" DataField="Loss" />
                    <asp:BoundField HeaderText="��ע"  DataField="WRemark"/>
                </Columns>
            </asp:GridView>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info5" style="height:130px;background:#ECE9D8;">
        <div class="cndiv2" id="Div4" style="height:130px;">
        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView6_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="���񵥺�" DataField="BillID" />
                    <asp:BoundField HeaderText="����״̬" DataField="curStatus" />
                    <asp:BoundField HeaderText="�������" DataField="ServicesType" />
                    <asp:BoundField HeaderText="������" DataField="Operator" />
                    <asp:BoundField HeaderText="����ʱ��" DataField="Time_TakeOver" />
                    <asp:BoundField HeaderText="����ʱ��" DataField="Speding" />
                    <asp:BoundField HeaderText="����ʽ" DataField="TakeStyle" />
                    <asp:BoundField HeaderText="����λ" DataField="TakeDept" />
                    <asp:BoundField HeaderText="���񼶱�" DataField="_PRI" />
                    <asp:BoundField HeaderText="����Ա" DataField="DisposalOper" />  
                    <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
                    <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
                    <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
                    <asp:BoundField HeaderText="�����ͺ�" DataField="ProductModel" />
                    <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
                    <asp:BoundField HeaderText="���" DataField="ProductClass" />
                    <asp:BoundField HeaderText="���к�1" DataField="ProductSN1" />
                    <asp:BoundField HeaderText="���к�2" DataField="ProductSN2" />
                    <asp:BoundField HeaderText="����" DataField="Fault" />
                    <asp:BoundField HeaderText="�����ʩ/���" DataField="TakeSteps" />
                    <asp:BoundField HeaderText="������" DataField="QtyType" />
                    <asp:BoundField HeaderText="�������" DataField="Warranty" />
                    <asp:BoundField HeaderText="ԤԼʱ��" DataField="SubscribeTime" />
                    <asp:BoundField HeaderText="Ԥ����" DataField="SubscribePrice" />
                    <asp:BoundField HeaderText="Ԥ�շ�" DataField="PreCharge" />
                    <asp:BoundField HeaderText="����" DataField="bRepair" />
                    <asp:BoundField HeaderText="��ע" DataField="Remark" />
                </Columns>
            </asp:GridView>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info6" style="height:130px;background:#ECE9D8;">
        <div class="cndiv2" id="Div5" style="height:130px;">
        <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="ҵ�����" DataField="Type" />
                    <asp:BoundField HeaderText="ҵ��״̬" DataField="curStatus" />
                    <asp:BoundField HeaderText="ҵ����" DataField="BillID" />
                    <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
                    <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
                     <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
                    <asp:BoundField HeaderText="��ַ" DataField="Adr" />
                    <asp:BoundField HeaderText="��������" DataField="Rent" />
                    <asp:BoundField HeaderText="��ʼ����" DataField="StartDate" />
                    <asp:BoundField HeaderText="��ֹ����" DataField="EndDate" />
                    <asp:BoundField HeaderText="��������" DataField="ChargeCycle" />
                    <asp:BoundField HeaderText="��ͬ���" DataField="ContractNO" />
                    <asp:BoundField HeaderText="Ѻ��" DataField="Deposit" />
                    <asp:BoundField HeaderText="����" DataField="_Date" />
                    <asp:BoundField HeaderText="�Ƶ���" DataField="Operator" />
                    <asp:BoundField HeaderText="ҵ��Ա" DataField="Seller" />
                    <asp:BoundField HeaderText="��ע" DataField="Remark" />
                </Columns>
            </asp:GridView>
         </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
    </div>
    <div class="clearfloat"></div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var isfocus=2;
var tabnum=7;
var strtel="";
var uri=location.href;
if(uri.indexOf("itel=1")>0)
    strtel="&itel=1";
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}

function ChkSltList()
{
    if(ChkSlt()==false)
     return;
    
    try{
    if("<%=Str_X %>"=="")
    {
        parent.<%=Str_Fid %>.$("hfDevID").value=$("hfRecID").value;
    }else
    {
        var list=document.getElementById("hfreclist").value;
        
        if(list=="")
            list=document.getElementById("hfRecID").value;
            
        if(list==""||list=="-1")
        {
            alert("����ʧ�ܣ���ѡ������.");return false;
        }
        else
        {
            parent.<%=Str_Fid %>.$("hfDevID").value=list;
        }
    }
        parent.<%=Str_Fid %>.$("btnChkDev").click();
    }catch(e){}
    parent.CloseDialog1();
}

function SerV()
{
    var id=document.getElementById("hfRecID2").value.replace("b","");
    if(id=="-1")
    {
        alert("��ѡ��һ�����񵥺������");
    }
    else
    {
        parent.ShowDialog2(860,444, 'Services/SerView.aspx?id='+id+'&iflag=2', '����');
    }
}

function LeaseV()
{
    var id=document.getElementById("hfRecID2").value.replace("le","");
    if(id=="-1")
    {
        alert("��ѡ��һ��ҵ�񵥺������");
    }
    else
    {
        parent.ShowDialog2(800, 480,'Lease/LeaseMod.aspx?id='+id+'&f=2','ҵ��');
    }
}
function ShowTA(id)
{
    parent.ShowDialog2(470, 360,'Services/ShowTA.aspx?id='+id, '�����ʩ/���');
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
