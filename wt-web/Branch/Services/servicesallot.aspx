<%@ page language="C#"  CodeFile="servicesallot.aspx.cs"     autoeventwireup="true" inherits="Branch_Services_ServicesAllot" theme="Themes" enableEventValidation="false" %>
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
            <input id="btnTake" runat="server" type="button" value="��������" class="bt1" onclick="parent.ShowDialog(870,600, 'Services/ServicesAdd.aspx', '��������');" />
            <input id="btnMod" runat="server" type="button" value="�鿴�޸�" class="bt1" onclick="ChkView();" />
            <input id="btnCancel" runat="server" type="button" value="ȡ��" class="bt1" onclick="ChkCancel();" />
            <input id="btnConf" runat="server" type="button" value="ȷ��" visible="false" class="bt1" onclick="ChkConf();"/>
            <span style="display:none;">
                <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                <asp:Button ID="btnSchH" runat="server" Text="�߼���ѯ" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />
                <asp:Button ID="btnShow" runat="server" Text="show" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="False" />
            </span>
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                <input id="btnPrint" runat="server" type="button" value="��ӡ" class="iprint" onclick="ChkPrintChoise('PrintBill.aspx');" />
                </td>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">ģ����ѯ</asp:ListItem>
                    <asp:ListItem Value="1">�����񵥺Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="2">����������ѯ</asp:ListItem>
                    <asp:ListItem Value="3">�������Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="4">�������Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="5">������ʽ��ѯ</asp:ListItem>
                    <asp:ListItem Value="6">�����񼶱��ѯ</asp:ListItem>
                    <asp:ListItem Value="7">�������˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="8">���ͻ����Ʋ�ѯ</asp:ListItem>
                    <asp:ListItem Value="9">����ϵ�˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="10">���ͻ��绰��ѯ</asp:ListItem>
                    <asp:ListItem Value="11">���ͻ���ַ��ѯ</asp:ListItem>
                    <asp:ListItem Value="12">�������ͺŲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="13">������Ʒ�Ʋ�ѯ</asp:ListItem>
                    <asp:ListItem Value="14">����������ѯ</asp:ListItem>
                    <asp:ListItem Value="15">���������кŲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="16">��ά�޼���Ա��ѯ</asp:ListItem>
                    <asp:ListItem Value="17">�����ϲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="18">�����������ѯ</asp:ListItem>
                    <asp:ListItem Value="19">����ע��ѯ</asp:ListItem>
                    <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server"  onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td>
            <td align="left">
            <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td style="padding:0px;"><input id="btnSchsH" type="button" value="�߼���ѯ" class="bsch" onclick="parent.ShowDialog(470,428, 'Services/SerCd.aspx', '�߼���ѯ');" /></td>
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
            <asp:BoundField HeaderText="����״̬" DataField="curStatus" />
            <asp:BoundField HeaderText="ԤԼʱ��" DataField="SubscribeTime" />
            <asp:BoundField HeaderText="���񵥺�" DataField="BillID" />
            <asp:BoundField HeaderText="����״̬" DataField="curStatus" />
            <asp:BoundField HeaderText="�������" DataField="ServicesType" />
            <asp:BoundField HeaderText="������" DataField="Operator" />
            <asp:BoundField HeaderText="����ʱ��" DataField="Time_TakeOver" />
            <asp:BoundField HeaderText="����ʱ��" DataField="Speding" />
            <asp:BoundField HeaderText="����ʽ" DataField="TakeStyle" />
            <asp:BoundField HeaderText="������" DataField="TakeDept" />
            <asp:BoundField HeaderText="��Ŀȷ��" DataField="SerCount" />
            <asp:BoundField HeaderText="����ȷ��" DataField="OfferConf" />
            <asp:BoundField HeaderText="���񼶱�" DataField="_PRI" />
            <asp:BoundField HeaderText="����Ա" DataField="DisposalOper" />  
            <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
            <asp:BoundField HeaderText="������" DataField="LinkMan" />
            <asp:BoundField HeaderText="�����˵绰" DataField="Tel" />
            <asp:BoundField HeaderText="ʹ����" DataField="UsePerson" />
            <asp:BoundField HeaderText="ʹ���˵绰" DataField="UsePersonTel" />
            <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
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
            <asp:BoundField HeaderText="����" DataField="bAgain" />
            <asp:BoundField HeaderText="����" DataField="bRepair" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            <asp:BoundField HeaderText="bTake" DataField="bTake" />
            <asp:BoundField HeaderText="IsDismissed" DataField="IsDismissed" />
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
    <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    <asp:HiddenField ID="hfcbID" runat="server" />
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    <asp:HiddenField ID="hfTecPur" runat="server" Value="1" />
    <asp:HiddenField ID="hfPurArea" runat="server" Value="" />
    <asp:HiddenField ID="hfPurDept" runat="server" Value="0" />
    <asp:HiddenField ID="hfPurOPDept" runat="server" Value="0" />
    <asp:HiddenField ID="hfTecDept" runat="server" Value="0" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut" style="overflow:hidden;">
        <div class="ftool2">
        <div id="mytabs" style="padding-left:2px;">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">��������</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">����/�Ĳ�</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">������Ŀ</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">��������</span>
            <span id="tabs_r4"></span>
            <span id="tabs_l5"></span>
            <span id="tabs5" onclick="ChkTab('5');">���񱨼�</span>
            <span id="tabs_r5"></span>
            <span id="tabs_l6"></span>
            <span id="tabs6" onclick="ChkTab('6');">�ߵ�</span>
            <span id="tabs_r6"></span>
            <span id="tabs_l7"></span>
            <span id="tabs7" onclick="ChkTab('7');">������</span>
            <span id="tabs_r7"></span>
        </div>
        </div>
        <div id="info1" style="height:175px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>
           <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
               <input id="btnNewS" type="button" value="����" class="bt1" onclick="NewS();" />
               <input id="btnModS" type="button" value="�޸�" class="bt1" onclick="ModS();" />
               <asp:Button ID="btnDelS" runat="server" Text="ɾ��" CssClass="bt1" OnClientClick="if(ChkDel2('����')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelS_Click" />
            </td>
            </tr>
           </table>
           </ContentTemplate>
           <Triggers>
           <asp:AsyncPostBackTrigger ControlID = "btnDelS" EventName = "Click" />
           </Triggers>
           </asp:UpdatePanel>
        </div>
        <div class="cndiv2" id="Div4" style="height:145px;">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="��"/>
                            <asp:BoundField HeaderText="����ʽ" DataField="DoStyle" />
                            <asp:BoundField HeaderText="������" DataField="Person" />
                            <asp:BoundField HeaderText="��������" DataField="Dept" />
                            <asp:BoundField HeaderText="������" DataField="Operator" />
                            <asp:BoundField HeaderText="����ʱ��" DataField="_Date" />
                            <asp:BoundField HeaderText="�����ʩ/���" DataField="TakeSteps" />
                            <asp:BoundField HeaderText="����ʱ��" DataField="StartTime" />
                            <asp:BoundField HeaderText="����ʱ��" DataField="Spending" />
                            <asp:BoundField HeaderText="���ʱ��" DataField="ArrivedTime" />
                            <asp:BoundField HeaderText="����ԭ��" DataField="Reason" />
                            <asp:BoundField HeaderText="�²�������" DataField="DoDept" />
                            <asp:BoundField HeaderText="�²�������" DataField="DoOperator" />
                            <asp:BoundField HeaderText="����ʱ��" DataField="visitdate" />
                            <asp:BoundField HeaderText="�������" DataField="Course" />
                         </Columns>
                    </asp:GridView>
                    </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelS" EventName="Click" />
                </Triggers>
                 </asp:UpdatePanel>
            </div>
        </div>
        <div id="info2" style="height:175px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
        <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
           <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
               <input id="btnNewM" type="button" value="�½�" class="bt1" onclick="NewM();" />
               <input id="btnModM" type="button" value="�޸�" class="bt1" onclick="ModM();" />
               <asp:Button ID="btnDelM" runat="server" Text="ɾ��" CssClass="bt1" OnClientClick="if(ChkDel2('���')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelM_Click" />
                <input id="btnBroughtM" runat="server" type="button" value="��������" class="bt1" onclick="BroughtM();" />
            </td>
            </tr>
           </table>
           </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelM" EventName="Click" />
                </Triggers>
                 </asp:UpdatePanel>
        </div>
        <div class="cndiv2" id="cndiv2" style="height:145px;">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView2_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="��"/>
                            <asp:BoundField HeaderText="��Ʒ���" DataField="GoodsNO" />
                            <asp:BoundField HeaderText="����" DataField="_Name" />
                            <asp:BoundField HeaderText="���" DataField="Spec" />
                            <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
                            <asp:BoundField HeaderText="��λ" DataField="Unit" />
                            <asp:BoundField HeaderText="����" DataField="Qty" />
                            <asp:BoundField HeaderText="��������" DataField="LQty" />
                            <asp:BoundField HeaderText="����" DataField="Price" />
                            <asp:BoundField HeaderText="˰��" DataField="TaxRate" />
                            <asp:BoundField HeaderText="˰��" DataField="TaxAmount" />
                            <asp:BoundField HeaderText="���" DataField="Total" />
                            <asp:BoundField HeaderText="���к�" DataField="SN" />
                            <asp:BoundField HeaderText="������" DataField="MaintenancePeriod" />
                            <asp:BoundField HeaderText="��ֹ����" DataField="PeriodEndDate" />
                            <asp:BoundField HeaderText="���㷽ʽ" DataField="ChargeStyle" />
                            <asp:BoundField HeaderText="�Ƿ��⹺" DataField="OutSourcing" />
                            <asp:BoundField HeaderText="�⹺����" DataField="OutCostPrice" />
                            <asp:BoundField HeaderText="��ע" DataField="Remark" />
                         </Columns>
                    </asp:GridView>
                     </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelM" EventName="Click" />
                </Triggers>
                 </asp:UpdatePanel>
        </div>
        </div>
         
        <div id="info3" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
               <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnNewI" type="button" value="�½�" class="bt1" onclick="NewI();" />
                   <input id="btnModI" type="button" value="�޸�" class="bt1" onclick="ModI();" />
                   <asp:Button ID="btnDelI" runat="server" Text="ɾ��" CssClass="bt1" OnClientClick="if(ChkDel2('��Ŀ')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelI_Click" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="Div1" style="height:116px;">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView3_RowDataBound" ShowFooter="true">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="��"/>
                            <asp:BoundField HeaderText="��Ŀ���" DataField="ItemNO" />
                            <asp:BoundField HeaderText="����" DataField="_Name" />
                            <asp:BoundField HeaderText="���" DataField="Price" />
                            <asp:BoundField HeaderText="��ʱ" DataField="dPoint" />
                            <asp:BoundField HeaderText="���" DataField="TecDeduct" />
                            <asp:BoundField HeaderText="���㷽ʽ" DataField="ChargeStyle" />
                            <asp:BoundField HeaderText="�Ƿ��깤" DataField="bComplete" />
                            <asp:BoundField HeaderText="��ע" DataField="Remark" />
                         </Columns>
                    </asp:GridView>
                    </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelI" EventName="Click" />
                </Triggers>
                 </asp:UpdatePanel>
            </div>
        </div>
        
        <div id="info4" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
               <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnNewDevConf" type="button" value="�½�" class="bt1" onclick="NewDevConf();" />
                   <input id="btnModDevConf" type="button" value="�޸�" class="bt1" onclick="ModDevConf();" />
                   <asp:Button ID="btnDelD" runat="server" Text="ɾ��" CssClass="bt1" OnClientClick="if(ChkDel2('��������')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelD_Click" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="Div2" style="height:116px;">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView4_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="��"/>
                            <asp:BoundField HeaderText="����" DataField="_Name" />
                            <asp:BoundField HeaderText="����" DataField="Parameter" />
                            <asp:BoundField HeaderText="���к�" DataField="SN" />
                            <asp:BoundField HeaderText="������" DataField="MaintenancePeriod" />
                            <asp:BoundField HeaderText="��ֹ����" DataField="MaintenanceEnd" />
                            <asp:BoundField HeaderText="��������" DataField="BuyDate" />
                            <asp:BoundField HeaderText="��ע" DataField="Remark" />
                         </Columns>
                    </asp:GridView>
                    </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelD" EventName="Click" />
                </Triggers>
                 </asp:UpdatePanel>
            </div>
        </div>
        <div id="info5" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
               <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnNewOffer" type="button" value="�½�" class="bt1" onclick="NewO();" />
                   <input id="btnModOffer" type="button" value="�޸�" class="bt1" onclick="ModO();" />
                   <asp:Button ID="btnDelO" runat="server" Text="ɾ��" CssClass="bt1" OnClientClick="if(ChkDel2('���񱨼�')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelO_Click" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="Div5" style="height:116px;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView6_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="��"/>
                            <asp:BoundField HeaderText="����" DataField="_Date" />
                            <asp:BoundField HeaderText="������" DataField="Operator" />
                            <asp:BoundField HeaderText="������" DataField="Seller" />
                            <asp:BoundField HeaderText="������Ŀ" DataField="_Name" />
                            <asp:BoundField HeaderText="���" DataField="dAmount" />
                            <asp:BoundField HeaderText="�ͻ�ȷ��" DataField="CusConf" />
                            <asp:BoundField HeaderText="��ע" DataField="Remark" />
                         </Columns>
                    </asp:GridView>
                    </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelO" EventName="Click" />
                </Triggers>
                 </asp:UpdatePanel>
            </div>
        </div>
        <div id="info6" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
               <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnNewP" type="button" value="�½�" class="bt1" onclick="NewP();" />
                   <input id="btnModP" type="button" value="�޸�" class="bt1" onclick="ModP();" />
                   <asp:Button ID="btnDelP" runat="server" Text="ɾ��" CssClass="bt1" OnClientClick="if(ChkDel2('�ߵ�')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelP_Click" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="Div3" style="height:116px;">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView5_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="��"/>
                            <asp:BoundField HeaderText="�ߵ���" DataField="LinkMan" />
                            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
                            <asp:BoundField HeaderText="�ߵ�ʱ��" DataField="_Date" />
                            <asp:BoundField HeaderText="������" DataField="Operator" />
                            <asp:BoundField HeaderText="������" DataField="Result" />
                         </Columns>
                    </asp:GridView>
                    </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelP" EventName="Click" />
                </Triggers>
                 </asp:UpdatePanel>
            </div>
        </div>
        <div id="info7" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
              <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnQtyNew" type="button" value="�½�" class="bt1" onclick="NewQty();" />
                   <input id="btnQtyMod" type="button" value="�޸�" class="bt1" onclick="ModQty();" />
                   <asp:Button ID="btnDelQty" runat="server" Text="ɾ��" CssClass="bt1" OnClientClick="if(ChkDel2('������')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelQty_Click" />
                </td>
                </tr>
              </table>
            </div>
            <div class="cndiv2" id="Div7" style="height:145px;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView7_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="��"/>
                            <asp:BoundField HeaderText="��������" DataField="_Date" />
                            <asp:BoundField HeaderText="������" DataField="Operator" />
                            <asp:BoundField HeaderText="����" DataField="QtyType" />
                            <asp:BoundField HeaderText="����" DataField="Qty" />
                            <asp:BoundField HeaderText="����" DataField="Allowance" />
                            <asp:BoundField HeaderText="��ע"  DataField="Remark"/>
                         </Columns>
                    </asp:GridView>
                    </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelQty" EventName="Click" />
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
                <span class="sred">������</span>
                <span class="sgreen">������</span>
                <span class="sblue">ԤԼ����</span>
                <span class="syellows">����δȡ</span>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
var tabnum=8;
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}

function NewS()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�����񵥺������");
        return false;
    }
    parent.ShowDialog(520, 354, 'Services/AddS.aspx?id='+id, '��������')
}

function ModS()
{
    var id=document.getElementById("hfRecID2").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�����������ϸ�����!");
    }
    else
    {
        parent.ShowDialog(520, 354, 'Services/ModS.aspx?id='+id, '��������');
    }
}

function NewM()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�����񵥺������");
        return false;
    }
    parent.ShowDialog(800, 400, 'Services/AddM.aspx?id='+id, '�½����')
}

function ModM()
{
    var id=document.getElementById("hfRecID2").value;
    if(id=="-1")
    {
        alert("��ѡ��һ��ʹ�������ϸ�����!");
    }
    else
    {
        parent.ShowDialog(480, 319, 'Services/ModM.aspx?id='+id, '�޸����');
    }
}

function NewI()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�����񵥺������");
        return false;
    }
    parent.ShowDialog(800, 400, 'Services/AddI.aspx?id='+id, '�½�������Ŀ')
}
function NewQty()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�����������������");
        return false;
    }
    parent.ShowDialog(455, 150, 'Customer/QtyAdd.aspx?id='+id+'&iflag=2', '������');
}

function ModQty()
{
    var id=document.getElementById("hfRecID2").value.replace("q","");
    if(id=="-1")
    {
        alert("��ѡ��һ���������������");
    }
    else
    {
        parent.ShowDialog(455, 150,'Customer/QtyMod.aspx?id='+id, '������');
    }
}
function ModI()
{
    var id=document.getElementById("hfRecID2").value;
    if(id=="-1")
    {
        alert("��ѡ��һ��������Ŀ��ϸ�����!");
    }
    else
    {
        parent.ShowDialog(480, 205, 'Services/ModI.aspx?id='+id, '�޸ķ�����Ŀ');
    }
}

function NewDevConf()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�����񵥺������");
        return false;
    }
    parent.ShowDialog(800, 400, 'Services/AddD.aspx?id='+id, '�½���������')
}

function ModDevConf()
{
    var id=document.getElementById("hfRecID2").value;
    if(id=="-1")
    {
        alert("��ѡ��һ������������ϸ�����!");
    }
    else
    {
        parent.ShowDialog(460, 175, 'Services/ModD.aspx?id='+id, '�޸Ļ�������');
    }
}

function NewO()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�����񵥺������");
        return false;
    }
    parent.ShowDialog(500, 340, 'Services/AddO.aspx?id='+id, '���񱨼�')
}

function ModO()
{
    var id=document.getElementById("hfRecID2").value;
    if(id=="-1")
    {
        alert("��ѡ��һ��ʹ�������ϸ�����!");
    }
    else
    {
        parent.ShowDialog(460, 180, 'Services/ModO.aspx?id='+id, '�޸ı���');
    }
}
function NewP()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�����񵥺������");
        return false;
    }
    parent.ShowDialog(460, 175, 'Services/AddP.aspx?id='+id, '�½��ߵ�')
}

function ModP()
{
    var id=document.getElementById("hfRecID2").value;
    if(id=="-1")
    {
        alert("��ѡ��һ��ʹ�ôߵ���ϸ�����!");
    }
    else
    {
        parent.ShowDialog(460, 175, 'Services/ModP.aspx?id='+id, '�޸Ĵߵ�');
    }
}

function ChkView()
{
    ChkMod(870,513, 'Services/SerMod.aspx', '�޸ķ���');
}

function ChkConf()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog1(460,98, 'Services/SerConf.aspx?id='+id+'&iflag=1', 'ȷ�Ϸ���');
    }
}
function BroughtM()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�����񵥺������");
        return false;
    }
    parent.ShowDialog(800, 480, 'Stock/BroughtM.aspx?id='+id, '���˿���')
}
function ChkCancel()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(460, 95, 'Services/SerCancel.aspx?id='+id, 'ȡ������');
    }
}
function ViewSN(strsn)
{
    parent.ShowDialog1(400, 300, 'Stock/ViewSN.aspx?sn='+escape(strsn), '�鿴���к�');
}
function Chkset()
{
    Chkwhs();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("��������");
}
</script>
