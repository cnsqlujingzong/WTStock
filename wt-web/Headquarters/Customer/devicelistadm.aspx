<%@ page language="C#"  CodeFile="devicelistadm.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_DeviceListAdm" theme="Themes" enableeventvalidation="false" %>
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
                <input id="btnNew" type="button" value="�½�" class="bt1" onclick="parent.ShowDialog(750, 430, 'Customer/DeviceAdd.aspx', '�½���������');" />
                <input id="btnMod" type="button" value="�޸�" class="bt1" onclick="ChkMod(750, 430,'Customer/DeviceMod.aspx','�޸Ļ�������');" />
                <asp:Button ID="btnDel" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('��������')==false) return false;ChkValue();" OnClick="btnDel_Click"/>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                    <asp:Button ID="btnShow" runat="server" Text="��ʾ" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="false"/>
                    <asp:Button ID="btnSchH" runat="server" Text="�߼���ѯ" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />
                </span>
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                    <input id="btnInput" runat="server" type="button" class="binput" value="����" onclick="ChkInput();" />
                </td>
                <td>
                    <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
                </td>
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
                    <asp:ListItem Value="9">�������ƻ�״̬��ѯ</asp:ListItem>
                    <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td style="padding:0px;"><input id="btnSchsH" type="button" value="�߼���ѯ" class="bsch" onclick="parent.ShowDialog(510,425, 'Customer/DeviceCd.aspx', '�߼���ѯ');" /></td>
            </tr>
            </table>   
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvtrouble" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvtrouble_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:TemplateField HeaderText="ѡ��" >
                <HeaderTemplate>
                <input type="checkbox" id="chkall" onclick="ChkALL()"/>ѡ��
                </HeaderTemplate>
                <ItemTemplate>
                <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
             </asp:TemplateField>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="�ͻ����" DataField="CustomerNO" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="ClassName" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="_Name" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��������" DataField="CusDept" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="�ֻ�����" DataField="Tel2" />
            <asp:BoundField HeaderText="����" DataField="Fax" />
            <asp:BoundField HeaderText="�ʱ�" DataField="Zip" />
            <asp:BoundField HeaderText="��ַ" DataField="Adr" />
            <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
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
            <asp:BoundField HeaderText="���ұ��޽�ֹ" DataField="WarrantyEnd" />
            <asp:BoundField HeaderText="ά�޴���" DataField="RepairTimes" />
            <asp:BoundField HeaderText="���ά��ʱ��" DataField="Repairlately" />
            <asp:BoundField HeaderText="ά�ޱ��޽�ֹ" DataField="RepairWarrantyEnd" />
            <asp:BoundField HeaderText="��ͬ���޿�ʼ" DataField="ContractWarrantyStart" />
            <asp:BoundField HeaderText="��ͬ���޽�ֹ" DataField="ContractWarrantyEnd" />
            <asp:BoundField HeaderText="ά�޺�ͬ���" DataField="ContractNO" />
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
            <td style="padding-left:8px;"><asp:Label ID="lbCountText" runat="server" ToolTip="�ܼ�¼��" Text="�ܼ�¼:"></asp:Label><asp:Label ID="lbCount" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
        </tr>
    </table>
    <asp:HiddenField ID="hfcbID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    <asp:HiddenField ID="hfPurArea" runat="server" />
    <asp:HiddenField ID="hfPur1" runat="server" />
    <asp:HiddenField ID="hfPurDept" runat="server" Value="0" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut" style="overflow:hidden;">
        <div class="ftool2">
        <div id="mytabs" style="padding-left:2px;">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">�����ƻ�</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">��������</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">�����б�</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">������</span>
            <span id="tabs_r4"></span>
            <span id="tabs_l5"></span>
            <span id="tabs5" onclick="ChkTab('5');">�����¼</span>
            <span id="tabs_r5"></span>
            <span id="tabs_l6"></span>
            <span id="tabs6" onclick="ChkTab('6');">����</span>
            <span id="tabs_r6"></span>
            <span class="changwin">
                <input id="btnMin" type="button" value="" class="changmin" onclick="changmin();"/>
                <input id="btnRed" type="button" value="" class="changred" onclick="changred();" style="display:none;" />
                <input id="btnMax" type="button" value="" class="changmax" onclick="changmax();"/></span>
        </div>
        </div>
        <div id="info1" style="height:163px;background:#ECE9D8;">
          <div style="border-bottom:#808080 1px solid;">
           <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
               <input id="btnNewPlan" type="button" value="�½�" class="bt1" onclick="NewDevPlan();" />
               <input id="btnModPlan" type="button" value="�޸�" class="bt1" onclick="EditDevPlan();" />
               <input id="btnEditPlan" type="button" value="��ֹ" class="bt1" onclick="ModDevPlan();" />
               <asp:Button ID="btnDelPlan" runat="server" CssClass="bt1" Text="ɾ��" OnClick="btnDelPlan_Click" OnClientClick="if(ChkDelPlan()==false) return false;"/>
            </td>
            </tr>
            </table>
            </div>
            <div class="cndiv2" id="cndiv21" style="height:116px;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false" Width="70%">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="��"/>
                        <asp:BoundField HeaderText="����" DataField="_Name" />
                        <asp:BoundField HeaderText="��ǰ����(��)" DataField="RemindDay" />
                        <asp:BoundField HeaderText="��ʼ����" DataField="StartDate" />
                        <asp:BoundField HeaderText="��ֹ����" DataField="EndDate" />
                        <asp:BoundField HeaderText="��ʱ��ʽ" DataField="TimingStyle" />
                        <asp:BoundField HeaderText="����/����" DataField="MaintenanceCycle" />
                        <asp:BoundField HeaderText="��ǰ״̬" DataField="Status" />
                        <asp:BoundField HeaderText="��ֹԭ��" DataField="Reason" />
                        <asp:BoundField HeaderText="��ע" DataField="Remark" />
                    </Columns>
                </asp:GridView>
                <asp:HiddenField ID="hfRecID3" runat="server" Value="-1" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnDelPlan" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
        </div>
        <div id="info2" style="height:163px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
       <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
        <td>
           <input id="btnNewConf" type="button" value="�½�" class="bt1" onclick="NewDevConf();" />
           <input id="btnModConf" type="button" value="�޸�" class="bt1" onclick="ModDevConf();" />
           <asp:Button ID="btnDelConf" runat="server" Text="ɾ��" CssClass="bt1" OnClientClick="if(ChkDel2('��������')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelConf_Click" />
        </td>
        <td align="right" style="padding-right:30px;">
            <input id="btnIntputDevConf" runat="server" type="button" class="binput" value="��������" style="width:75px;" onclick="ChkInputDevConfAll();" />
           <input id="btnInDevConf" runat="server" type="button" class="binput" value="����" onclick="ChkInputDevConf();" />
        </td>
        </tr>
        </table>
        </div>
        <div class="cndiv2" id="cndiv22" style="height:116px;">
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
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDelConf" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info3" style="height:163px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
              <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
                <tr>
                <td>
                   <input id="btnAccAdd" type="button" value="�½�" class="bt1" onclick="NewAcc();" />
                   <input id="btnAccMod" type="button" value="�޸�" class="bt1" onclick="ModAcc();" />
                   <asp:Button ID="btnDelAcc" runat="server" Text="ɾ��" CssClass="bt1" OnClientClick="if(ChkDel2('��������')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelAcc_Click" />
                </td>
                <td align="right" style="padding-right:30px;">
                    <asp:Button ID="btnAccExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkAccToExcel()==false)return false;" OnClick="btnAccExcel_Click" />
                </td>
                </tr>
              </table>
        </div>
        <div class="cndiv2" id="cndiv23" style="height:116px;">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
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
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDelAcc" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info4" style="height:163px;background:#ECE9D8;">
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
        <div class="cndiv2" id="cndiv24" style="height:116px;">
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
                    <asp:BoundField HeaderText="����" DataField="Allowance" />
                    <asp:BoundField HeaderText="��ע"  DataField="Remark"/>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDelQty" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info5" style="height:163px;background:#ECE9D8;">
        <div class="cndiv2" id="cndiv25" style="height:146px;">
        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
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
            
            <table cellpadding="0" cellspacing="0" class="pages">
                <tr>
                    <td><webdiyer:aspnetpager id="jsPagerle" runat="server" onpagechanged="jsPagerle_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
                    <td style="padding-left:8px;"><asp:Label ID="lbPagele" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
                    <td style="padding-left:8px;"><asp:Label ID="lbCountTextle" runat="server" Visible="false" ToolTip="�ܼ�¼��" Text="�ܼ�¼:"></asp:Label><asp:Label ID="lbCountle" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
                </tr>
            </table>
                    
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        
        <div id="info6" style="height:163px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
           <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
            <tr>
            <td>
               <input id="btnSerV" type="button" value="�鿴" class="bt1" onclick="SerV();" />
               </td>
            <td align="right" style="padding-right:30px;">
                <asp:Button ID="btnExcelSer" runat="server" Text="����" CssClass="bexcel" OnClick="btnExcelSer_Click" />
                <input type ="button" onclick="ChkValue();" value="ȷ��" />
            </td>
            </tr>
           </table>
        </div>
        <div class="cndiv2" id="cndiv26" style="height:116px;">
           <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
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
    <div id="fbon" class="fbon">
    </div>
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
var tabnum=7;
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}
function Chkset()
{
    Chkwh2();
    Chkbom(); 
}

function NewDevConf()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ���������������");
        return false;
    }
    parent.ShowDialog(680, 390, 'Customer/DevConfAdd.aspx?id='+id, '�½���������')
}

function ModDevConf()
{
    var id=document.getElementById("hfRecID2").value;
    if(id=="-1")
    {
        alert("��ѡ��һ������������ϸ�������");
    }
    else
    {
        parent.ShowDialog(480, 175, 'Customer/DevConfMod.aspx?id='+id, '�޸Ļ�������');
    }
}

function NewDevPlan()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�����������������");
        return false;
    }
    parent.ShowDialog(470, 175, 'Customer/DevPlanAdd.aspx?id='+id, '�½������ƻ�')
}

function ChkInputDevConf()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�����������������");
        return false;
    }
    parent.ShowDialog(480, 250, 'Customer/InputDevConf.aspx?id='+id, '�����������')
}
function ChkInputDevConfAll()
{
    parent.ShowDialog(480, 275, 'Customer/InputDevConf_All.aspx', '���������������')
}
function ChkDelPlan()
{
    var id=document.getElementById("hfRecID3").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�������ƻ��������");
        return false;
    }
    else
    {
        return confirm("ȷ��Ҫɾ���ñ����ƻ���");
    }
}
function ModDevPlan()
{
    var id=document.getElementById("hfRecID3").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�������ƻ��������");
    }
    else
    {
        parent.ShowDialog(400, 93, 'Customer/DevPlanMod.aspx?id='+id, '��ֹ�����ƻ�');
    }
}
function EditDevPlan()
{
    var id=document.getElementById("hfRecID3").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�������ƻ��������");
    }
    else
    {
        parent.ShowDialog(470, 175, 'Customer/DevPlanModify.aspx?id='+id, '�޸ı����ƻ�');
    }
}

function NewAcc()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�����������������");
        return false;
    }
    parent.ShowDialog(500, 200, 'Customer/DevAccAdd.aspx?id='+id, '�½�����');
}

function ModAcc()
{
    var id=document.getElementById("hfRecID2").value.replace("a","");
    if(id=="-1")
    {
        alert("��ѡ��һ�����������������");
    }
    else
    {
        parent.ShowDialog(500, 200,'Customer/DevAccMod.aspx?id='+id, '�޸ĸ���');
    }
}

function NewQty()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�����������������");
        return false;
    }
    parent.ShowDialog(455, 150, 'Customer/QtyAdd.aspx?id='+id+'&iflag=1', '������');
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

function ChkInput()
{
    parent.ShowDialog(750, 475,'Customer/InputDev.aspx', '�����������');
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
//��������ΪĬ�ϴ�С
function changred()
{
    var h1=document.body.clientHeight-54;//���߶�
    var h2=h1-200;//�̶�ռ�ø߶�
    $("cndiv").style.height=h2+"px";
    $("cnbut").style.height="200px";
    
    $("btnRed").style.display="none";
    $("btnMax").style.display="inline";
    $("btnMin").style.display="inline";
    
    if(typeof(tabnum)!="undefined")
    {
        for(i=1; i <tabnum; i++)
         {
             $("info"+i).style.height="153px";
             $("cndiv2"+i).style.height="116px";
         }
    }
}
//��������Ϊ���
function changmax()
{
    var h1=document.body.clientHeight-54;//���߶�
    var h2=h1-200;//�̶�ռ�ø߶�
    var h3=h1-30;
    var h4=h1-60;
    $("cndiv").style.height="0px";
    $("cnbut").style.height=h1+"px";
    
    $("btnRed").style.display="inline";
    $("btnMax").style.display="none";
    $("btnMin").style.display="inline";
    
    if(typeof(tabnum)!="undefined")
    {
        for(i=1; i <tabnum; i++)
         {
             $("info"+i).style.height=h3+"px";
             $("cndiv2"+i).style.height=h4+"px";
         }
    }
}
//��������Ϊ��С��
function changmin()
{
    var h1=document.body.clientHeight-54;//���߶�
    var h2=h1-23;//�̶�ռ�ø߶�
    $("cndiv").style.height=h2+"px";
    $("cnbut").style.height="23px";
    
    $("btnRed").style.display="inline";
    $("btnMax").style.display="inline";
    $("btnMin").style.display="none";
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("��������");
}
function ChkAccToExcel()
{
    if($("hfRecID").value=="-1")
    {
        alert("��ѡ��һ�����������������");
        return false;
    }
    return true;
}
/////
function ChkALL()
{
    var tb=document.getElementById("gvtrouble");
    var cb = document.getElementById("chkall");
    if(cb.checked == true)
    {
        for(i=0;i<tb.rows.length;i++)
       {
            var chk=tb.rows[i].getElementsByTagName("input")[0];
            if(chk != null)
            {
                 chk.checked = true;
            }
        }
    }
    else
    {
        for(i=0;i<tb.rows.length;i++)
       {
            var chk=tb.rows[i].getElementsByTagName("input")[0];
            if(chk != null)
            {
                 chk.checked = false;
            }
        }
    }
    
}
 ///
function ChkValue()
{
    var tb=document.getElementById("gvtrouble");
    var ids="";
    for(i=1;i<tb.rows.length;i++)
    {
        var chk=tb.rows[i].getElementsByTagName("input")[0];
        if(null!=chk&&chk.checked==true)
        {
            var id=chk.id.replace(/^chk(\d+)$/,"$1");
            ids+=id+",";
        }
    }
    if(ids=="")
    {
        alert("�빴ѡ��¼��");
        return;
    }
    ids=ids.replace(/(^,*)|(,*$)/g,"");
    document.getElementById("hfcbID").value = ids;
}
</script>
