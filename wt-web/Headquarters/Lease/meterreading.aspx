<%@ page language="C#"  CodeFile="meterreading.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Lease_MeterReading" theme="Themes" enableEventValidation="false" %>
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
                <asp:Button ID="btnChkU" runat="server" Text="�����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkConf('����˸�[ҵ��]')==false) return false;" OnClick="btnChkU_Click"/>
                <input id="btnReading" type="button" value="����Ǽ�" class="bt1" onclick="ChkMeter();" />
                <input id="btnCharge" type="button" value="���㿪��" class="bt1" onclick="ChkCharge();" />
                <input id="btnDevAdd" type="button" value="����" class="bt1" onclick="ChkDeviceAdd();" />
                <input id="btnTranspond" type="button" value="�ɵ�" class="bt1" onclick="Transpond();" />
                <span style="display:none;">
                    <asp:Button ID="btnSchH" runat="server" Text="�߼���ѯ" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" /> 
                    <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                    <asp:Button ID="btnShow" runat="server" Text="��ʾ" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="false"/>
                </span>
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>���㣺</td>
                <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" Width="100">
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnSchDept" runat="server" CssClass="bt1" Text="��ѯ" OnClick="btnSchDept_Click" />
                </td>
                <td>
                <input id="btnPrint" runat="server" type="button" value="��ӡ" class="iprint" onclick="ChkPrint('ZLD');" />
                </td>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">ģ����ѯ</asp:ListItem>
                    <asp:ListItem Value="1">��ҵ���Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="2">���ͻ����Ʋ�ѯ</asp:ListItem>
                    <asp:ListItem Value="3">����ϵ�˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="4">����ϵ�绰��ѯ</asp:ListItem>
                    <asp:ListItem Value="5">����ַ��ѯ</asp:ListItem>
                    <asp:ListItem Value="6">�������ͺŲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="7">�����кŲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="8">������Ʒ�Ʋ�ѯ</asp:ListItem>
                    <asp:ListItem Value="9">����������ѯ</asp:ListItem>
                    <asp:ListItem Value="10">����ʼ���ڲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="11">����ֹ���ڲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="12">��ҵ��Ա��ѯ</asp:ListItem>
                    <asp:ListItem Value="13">����ע��ѯ</asp:ListItem>
                    <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                    <asp:ListItem Value="22">7���ڽ�Ҫ���ڵ�</asp:ListItem>
                    <asp:ListItem Value="23">�ѹ���</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td>
                <input id="btnSchsH" type="button" value="�߼���ѯ" class="bsch" onclick="parent.ShowDialog(460,260, 'Lease/LeaseCd.aspx', '�߼���ѯ');" />
            </td>
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
            <asp:BoundField HeaderText="ҵ�����" DataField="Type" />
            <asp:BoundField HeaderText="ҵ����" DataField="BillID" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="��ַ" DataField="Adr" />
            <asp:BoundField HeaderText="��ʼ����" DataField="StartDate" />
            <asp:BoundField HeaderText="��ֹ����" DataField="EndDate" />
            <asp:BoundField HeaderText="��������" DataField="Rent" />
            <asp:BoundField HeaderText="���ڳ�������" DataField="ReadingDate" />
            <asp:BoundField HeaderText="���ڽ�������" DataField="ChargeDate" />
            <asp:BoundField HeaderText="��������" DataField="ChargeCycle" />
            <asp:BoundField HeaderText="��ͬ���" DataField="ContractNO" />
            <asp:BoundField HeaderText="Ѻ��" DataField="Deposit" />
            <asp:BoundField HeaderText="����" DataField="_Date" />
            <asp:BoundField HeaderText="�Ƶ���" DataField="Operator" />
            <asp:BoundField HeaderText="ҵ��Ա" DataField="Seller" />
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
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    <asp:HiddenField ID="hfcbID" runat="server" />
    <asp:HiddenField ID="hfCusID" runat="server" />
    <asp:HiddenField ID="hfPurDept" runat="server" Value="0" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkU" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut" style="overflow:hidden;">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1"></span>
                <span id="tabs1" onclick="ChkTab('1');">���޻���</span>
                <span id="tabs_r1"></span>
                <span id="tabs_l2"></span>
                <span id="tabs2" onclick="ChkTab('2');">�����¼</span>
                <span id="tabs_r2"></span>
                <span id="tabs_l3"></span>
                <span id="tabs3" onclick="ChkTab('3');">���㵥</span>
                <span id="tabs_r3"></span>
            </div>
        </div>
        <div id="info1" style="height:175px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
           <table style="margin-left:35px;" cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
                <asp:Button ID="bteEx" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="bteEx_Click" />
            </td>
            </tr>
           </table>
        </div>
        <div class="cndiv2" id="cndiv2" style="height:175px;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView1_RowDataBound"  EnableViewState="false" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="����״̬" DataField="DevStatus" />
                    <asp:BoundField HeaderText="�ֿ�" DataField="StockName" />
                    <asp:BoundField HeaderText="���޻���" DataField="GoodsNO" />
                    <asp:BoundField HeaderText="��������" DataField="iCount" />
                    <asp:BoundField HeaderText="�������" DataField="LeasePrice" />
                    <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
                    <asp:BoundField HeaderText="����Ʒ��" DataField="Brand" />
                    <asp:BoundField HeaderText="���" DataField="Class" />
                    <asp:BoundField HeaderText="�ͺ�" DataField="Model" />
                    <asp:BoundField HeaderText="���к�" DataField="ProductSN1" />
                    <asp:BoundField HeaderText="���к�2" DataField="ProductSN2" />
                    <asp:BoundField HeaderText="������"/>
                    <asp:BoundField HeaderText="��ע" DataField="Remark" />
                </Columns>
            </asp:GridView>
            
            <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        
        </div>
        <div id="info2" style="height:175px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
           <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
               <input id="btnModD" type="button" value="�޸�" class="bt1" onclick="ModD();" />
               <asp:Button ID="btnDelD" runat="server" Text="ɾ��" CssClass="bt1" OnClientClick="if(ChkDel2('�����¼')==false) return false;" UseSubmitBehavior="false" OnClick="btnDelD_Click" />
            </td>
            <td align="right">
                <asp:Button ID="btnExcelDetail" runat="server" Text="����" CssClass="bexcel" OnClick="btnExcelDetail_Click" OnClientClick="return excelDetail();" /></td>
            </tr>
           </table>
        </div>
        <div class="cndiv2" style="height:145px;">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView2_RowDataBound"  EnableViewState="false" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="��������" DataField="_Date" />
                    <asp:BoundField HeaderText="������" DataField="Operator" />
                    <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
                    <asp:BoundField HeaderText="�������к�" DataField="ProductSN1" />
                    <asp:BoundField HeaderText="����������" DataField="_Name" />
                    <asp:BoundField HeaderText="����" DataField="Qty" />
                    <asp:BoundField HeaderText="�������" DataField="Loss" />
                    <asp:BoundField HeaderText="��ע"  DataField="WRemark"/>
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfRecID3" runat="server" Value="-1" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDelD" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info3" style="height:175px;background:#ECE9D8;">
          <div style="border-bottom:#808080 1px solid;">
           <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnChkCU" runat="server" Text="������" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkConf2('�������[���㵥]')==false) return false;" OnClick="btnChkCU_Click"/>
                    <asp:Button ID="btnCancelC" runat="server" Text="ȡ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkConf2('ȡ����[���㵥]')==false) return false;" OnClick="btnCancelC_Click"/>
                    <asp:Button ID="btnDelC" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkConf2('ɾ����[���㵥]')==false) return false;" OnClick="btnDelC_Click"/>
                    <input id="btnShowCharge" type="button" value="�鿴��ϸ" class="bt1" onclick="ChkShowCharge();" />
                </td>
                
                <td>
                    <asp:Button ID="btnExcel2" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel2_Click" />
                </td>
                <td>
                <input id="btnPrint2" runat="server" type="button" value="��ӡ" class="iprint" onclick="ChkPrint2('ZLJSD');" />
                </td>
            </tr>
           </table>
        </div>
        <div class="cndiv2" style="height:145px;">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView3_RowDataBound"  EnableViewState="false" >
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="��"/>
                        <asp:BoundField HeaderText="���㵥��" DataField="OperationID" />
                        <asp:BoundField HeaderText="״̬" DataField="strStatus" />
                        <asp:BoundField HeaderText="����" DataField="_Date" />
                        <asp:BoundField HeaderText="������" DataField="Operator" />
                        <asp:BoundField HeaderText="��ʼ����" DataField="StartDate" />
                        <asp:BoundField HeaderText="��ֹ����" DataField="EndDate" />
                        <asp:BoundField HeaderText="����" DataField="Cycle" />
                        <asp:BoundField HeaderText="���ڼ���" DataField="BenQty" />
                        <asp:BoundField HeaderText="���ڼ���" DataField="ShangQty" />
                        <asp:BoundField HeaderText="�������" DataField="Loss" />
                        <asp:BoundField HeaderText="��������" DataField="Rent" />
                        <asp:BoundField HeaderText="���ŷ�" DataField="SuperZhangFee" />
                        <asp:BoundField HeaderText="�ϼ�Ӧ��" DataField="dRec" />
                        <asp:BoundField HeaderText="���ս��" DataField="InCash" />
                        <asp:BoundField HeaderText="���㱸ע" DataField="Remark" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnChkCU" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelC" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnDelC" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
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
                    <span class="sblue">����������</span>
                    <span class="stin">�ǳ���������</span>
                    <span class="sgreen">ȫ��</span>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
var tabnum=4;
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}

function ModBill()
{
    ChkMod(800, 480,'Lease/LeaseView.aspx','ҵ��');
}

function ChkMeter()
{
    ChkMod(600, 380,'Lease/Reading.aspx','����Ǽ�');
}

function ChkCharge()
{
    ChkMod(700, 480,'Lease/Charge.aspx','���㿪��');
}
function ChkDeviceAdd()
{
    ChkMod(700, 450,'Lease/DeviceAdd.aspx','����');
}
function Transpond()
{
    if($("hfcbID").value=="")
    {
        ChkMod(275, 90,'Lease/Transpond.aspx','�ɵ�');
    }else
    {
        parent.ShowDialog(275,90,'Lease/Transpond.aspx?idlist='+$("hfcbID").value,'�ɵ�');
    }
}
function ViewQty(id)
{
    parent.ShowDialog(400, 300,'Lease/ViewQty.aspx?id='+id, '�鿴������');
}

function ModD()
{
    var id=document.getElementById("hfRecID2").value.replace("q","");
    if(id=="-1")
    {
        alert("��ѡ��һ�������¼�������");
    }
    else
    {
        parent.ShowDialog(460, 150,'Lease/ReadingMod.aspx?id='+id, '�޸ĳ���');
    }
}
function ChkShowCharge()
{
    var id=document.getElementById("hfRecID2").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�����㵥��ϸ�������");
    }
    else
    {
        parent.ShowDialog(700, 480,'Lease/ShowCharge.aspx?id='+id, '������ϸ');
    }
}
function Chkset()
{
    Chkwhs();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("����Ǽ�");
}
function excelDetail()
{
    var id = document.getElementById("hfRecID").value;
    if(id == "" || id== "-1")
    {
        alert("��ѡ��һ�����޵������");
        return false;
    }
    else
    {
        return true;
    }
}
</script>
