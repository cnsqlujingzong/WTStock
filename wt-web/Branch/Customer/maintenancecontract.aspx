<%@ page language="C#"  CodeFile="maintenancecontract.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_MaintenanceContract" theme="Themes" enableEventValidation="false" %>
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
            <input id="btnNewCont" type="button" value="�½�" class="bt1" onclick="NewCont();" />
           <input id="btnModCont" type="button" value="�޸�" class="bt1" onclick="ModCont();" />
           <asp:Button ID="btnDelCont" runat="server" Text="ɾ��" CssClass="bt1" OnClientClick="if(ChkDel('�����ͬ')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelCont_Click" />
           <input id="btnCancel" runat="server" type="button" value="��ֹ" class="bt1" onclick="ChkCancel();" />
            <span style="display:none;">
                <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                <asp:Button ID="btnSchH" runat="server" Text="�߼���ѯ" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />
                <asp:Button ID="btnShow" runat="server" Text="��ϸ" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="False" />
            </span>
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                <input id="btnPrint" runat="server" type="button" value="��ӡ" class="iprint" onclick="ChkPrint('HT');" />
                </td>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">ģ����ѯ</asp:ListItem>
                    <asp:ListItem Value="1">��ǩԼ���ڲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="2">����ͬ��Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="3">����ʼ���ڲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="4">����ֹ���ڲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="5">����ͬ�����ѯ</asp:ListItem>
                    <asp:ListItem Value="6">���ͻ����Ʋ�ѯ</asp:ListItem>
                    <asp:ListItem Value="7">����ϵ�˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="8">����ϵ�绰��ѯ</asp:ListItem>
                    <asp:ListItem Value="9">����ַ��ѯ</asp:ListItem>
                    <asp:ListItem Value="10">������ѯ</asp:ListItem>
                    <asp:ListItem Value="11">��ҵ��Ա��ѯ</asp:ListItem>
                    <asp:ListItem Value="12">�������˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="13">����ע��ѯ</asp:ListItem>
                    <asp:ListItem Value="14">���ͻ������ѯ</asp:ListItem>
                    <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server"  onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td>
            <td align="left">
            <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td style="padding:0px;"><input id="btnSchsH" type="button" value="�߼���ѯ" class="bsch" onclick="parent.ShowDialog(470,284, 'Customer/Mtnsconcd.aspx', '�߼���ѯ');" /></td>
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
            <asp:BoundField HeaderText="CustomerID" DataField="CustomerID" />
            <asp:BoundField HeaderText="״̬" DataField="Status" />
            <asp:BoundField HeaderText="��ͬ���" DataField="ContractType" />
            <asp:BoundField HeaderText="ǩԼ����" DataField="_Date" />
            <asp:BoundField HeaderText="��ͬ���" DataField="ContractNO" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
             <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="��ַ" DataField="Adr" />
            <asp:BoundField HeaderText="��ʼ����" DataField="StartDate" />
            <asp:BoundField HeaderText="��ֹ����" DataField="EndDate" />
            <asp:BoundField HeaderText="���" DataField="dAmount" />
            <asp:BoundField HeaderText="�ֽ���" DataField="dInCash" />
            <asp:BoundField HeaderText="����" DataField="Accessory" />
            <asp:BoundField HeaderText="��ͬ����" DataField="Summary" />
            <asp:BoundField HeaderText="ҵ��Ա" DataField="Seller" />
            <asp:BoundField HeaderText="������" DataField="Operator" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            <asp:BoundField HeaderText="��ֹԭ��" DataField="termRemark" />
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
    <asp:HiddenField ID="hfCustomerID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
    <asp:HiddenField ID="hfDeviceID" runat="server" Value="-1" />
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
        <asp:AsyncPostBackTrigger ControlID="btnDelCont" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut" style="overflow:hidden;">
        <div class="ftool2">
        <div id="mytabs" style="padding-left:2px;">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">������Ϣ</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">�ͻ���Ϣ</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">����</span>
            <span id="tabs_r3"></span>
        </div>
        </div>
       
        <div id="info1" style="height:205px;background:#ECE9D8;">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
             <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView2_RowDataBound"  EnableViewState="false" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="����Ʒ��" DataField="ProductBrand" />
                    <asp:BoundField HeaderText="���" DataField="ProductClass" />
                    <asp:BoundField HeaderText="�ͺ�" DataField="ProductModel" />
                    <asp:BoundField HeaderText="���к�" DataField="ProductSN1" />
                    <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
                    <asp:BoundField HeaderText="���񼶱�" DataField="ServiceLevel" />
                    <asp:BoundField HeaderText="��ά�޷�" DataField="bRepair" />
                    <asp:BoundField HeaderText="��Ĳķ�" DataField="bConsumables" />
                    <asp:BoundField HeaderText="�ⱸ����" DataField="bMaterial" />
                    <asp:BoundField HeaderText="��ע"  DataField="Remark"/>
                </Columns>
            </asp:GridView>
             </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            </Triggers>       
        </asp:UpdatePanel>
        </div>
        <div id="info2" style="height:205px;background:#ECE9D8;">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td>�ͻ����</td>
                <td style="padding-left:0px;">
                    <input type="text" id="tbCusClass" runat="server" class="pinb" readonly="readonly" />
                 </td>
                 <td align="right">��ϵ�ˣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbCusLinkMan" runat="server" CssClass="pinb"></asp:TextBox></td>
                    <td>��ϵ�绰��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbCusTel" runat="server" CssClass="pinb"></asp:TextBox></td>
            </tr>
                <tr>
                    <td align="right">�ֻ����룺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbCusTel2" runat="server" CssClass="pinb"></asp:TextBox></td>
                    <td align="right">���棺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbCusFax" runat="server" CssClass="pinb"></asp:TextBox></td>
                    <td align="right">�ʱࣺ</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbCusZip" runat="server" CssClass="pinb"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">Email��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbEmail" runat="server" CssClass="pinb"></asp:TextBox>
                    </td>
                    <td align="right">�ͻ�����</td>
                    <td style="padding-left:0px;">
                    <asp:TextBox ID="tbArea" runat="server" CssClass="pinb"></asp:TextBox>
                    </td>
                    <td align="right">��ͼ���꣺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbCoordinates" runat="server" CssClass="pinb"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">�ͻ���Դ��</td>
                    <td style="padding-left:0px;">
                    <asp:TextBox ID="tbFrom" runat="server" CssClass="pinb"></asp:TextBox>
                    </td>
                    <td align="right">ҵ��Ա��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbSeller" runat="server" CssClass="pinb"></asp:TextBox>
                    </td>
                    <td align="right">��Ա����</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbMember" runat="server" CssClass="pinb"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">�ʻ���</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbAccount" runat="server" CssClass="pinb"></asp:TextBox></td>
                    <td align="right">��ַ��</td>
                    <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbCusAdr" runat="server" CssClass="pinb" Width="341"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">��ע��</td>
                    <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pinb" Width="341"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left:0px;">
                         <asp:CheckBox ID="cbStop" runat="server" /> <span class="sysred">ͣ��</span>
                         <asp:CheckBox ID="cbCall" runat="server" /> �ط�
                    </td>
                </tr>
            </table>
            </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
        </div>
         <div id="info3" style="height:205px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
           <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
            <tr>
            <td>
               <input id="btnSerV" type="button" value="�鿴" class="bt1" onclick="SerV();" />
               </td>
            <td align="right" style="padding-right:30px;">
                <asp:Button ID="btnExcelSer" runat="server" Text="����" CssClass="bexcel" OnClick="btnExcelSer_Click" />
            </td>
            </tr>
           </table>
        </div>
        <div class="cndiv2" id="ddd" style="height:175px;">
           <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView3_RowDataBound" EnableViewState="false">
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
             <asp:HiddenField ID="hfSql2" runat="server" />
             <asp:HiddenField ID="hfTbTitle2" runat="server" />
            <asp:HiddenField ID="hfTbField2" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            </Triggers>       
            </asp:UpdatePanel>
        </div>
        </div>
    </div>
    
    <div class="fbom">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td><div id="fbon" class="fbon"></div></td>
                <td>
                    <span class="sred">��ִ��</span>
                    <span class="sgreen">��ִ��</span>
                    <span class="sblue">�ѹ���</span>
                    <span class="sgay">����ֹ</span>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
var tabnum=4;
function ChkID(id,customerid)
{
    ClrID(id);
    $("hfCustomerID").value=customerid;
    $("btnShow").click();
}
function ChkIDd(id)
{
    ClrID(id);
    $("btnShow").click();
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
        parent.ShowDialog(860,444, 'Services/SerView.aspx?id='+id, '����');
    }
}

function ChkCancel()
{
    id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ����ͬ�������");
        return;
    }
    parent.ShowDialog(460, 95, 'Customer/MaitenTerminate.aspx?id='+id, '��ֹ��ͬ');
}
function NewCont()
{
    parent.ShowDialog(820, 510, 'Customer/DevContAdd.aspx', '�½������ͬ')
}

function ModCont()
{
    var id=document.getElementById("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ����¼�������");
    }
    else
    {
        parent.ShowDialog(820, 510, 'Customer/DevContMod.aspx?id='+id, '�޸ķ����ͬ');
    }
}
function Chkset()
{
    Chkwh12();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("�����ͬ");
}
</script>
