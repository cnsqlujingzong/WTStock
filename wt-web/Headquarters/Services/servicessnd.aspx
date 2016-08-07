<%@ page language="C#"  CodeFile="servicessnd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_ServicesSnd" theme="Themes" enableEventValidation="false" %>
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
            <td>
                <asp:Button ID="btnFsh" runat="server" Text="ˢ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnFsh_Click"/>
                <input id="btnView" type="button" value="��ϸ" class="bt1" onclick="ChkView();" />
                <input id="btnBackAllot" type="button" value="����" class="bt1" onclick="ChkMod(460,98,'Services/SndBackAllot.aspx','����');"/>
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
                <td>
                <input id="btnPrint" runat="server" type="button" value="��ӡ" class="iprint" onclick="ChkPrintChoise('PrintBill.aspx');" />
                </td>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">ģ����ѯ</asp:ListItem>
                    <asp:ListItem Value="1">�����񵥺Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="20">�����޳��̲�ѯ</asp:ListItem>
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
    
    <div id="lndiv" class="lndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:TreeView ID="tvsup" runat="server" ShowLines="True" OnSelectedNodeChanged="tvsup_SelectedNodeChanged">
            <SelectedNodeStyle BackColor="#7d8abe" BorderColor="White" />
        </asp:TreeView>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="tvsup" EventName="SelectedNodeChanged" />
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
            <asp:BoundField HeaderText="���޳���ID" DataField="RepairCorpID" />
            <asp:BoundField HeaderText="���޳���" DataField="RepairCorp" />
            <asp:BoundField HeaderText="ԤԼʱ��" DataField="SubscribeTime" />
            <asp:BoundField HeaderText="���񵥺�" DataField="BillID" />
            <asp:BoundField HeaderText="�������" DataField="ServicesType" />
            <asp:BoundField HeaderText="�������" DataField="RepairType" />
            <asp:BoundField HeaderText="���޳���" DataField="RepairCorp" />
            <asp:BoundField HeaderText="������" DataField="Operator" />
            <asp:BoundField HeaderText="����ʱ��" DataField="Time_TakeOver" />
            <asp:BoundField HeaderText="����ʱ��" DataField="Speding" />
            <asp:BoundField HeaderText="����ʽ" DataField="TakeStyle" />
            <asp:BoundField HeaderText="������" DataField="TakeDept" />
            <asp:BoundField HeaderText="���񼶱�" DataField="_PRI" />
            <asp:BoundField HeaderText="����Ա" DataField="DisposalOper" />  
            <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
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
            <asp:BoundField HeaderText="����" DataField="bRepair" />
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
        <asp:HiddenField ID="hfClass" runat="server" />
        <asp:HiddenField ID="hfTbTitle" runat="server" />
        <asp:HiddenField ID="hfTbField" runat="server" />
        <asp:HiddenField ID="hfSup" runat="server" />
        <asp:HiddenField ID="hfSupID" runat="server" />
        <asp:HiddenField ID="hfRecList" runat="server" />
        <asp:HiddenField ID="hfRecsList" runat="server" />
        <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tvsup" EventName="SelectedNodeChanged" />
        <asp:AsyncPostBackTrigger ControlID="btnBackAll" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnGo" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnGoAll" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSnd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnBack" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnNO" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="divlbut" style="height:200px;float:left;">
        <div id="cnbut" style="overflow:hidden; border-bottom:#808080 1px solid;">
          <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
            <td style="padding-left:0px;">
            <span style="display:none;">
                <asp:Button ID="btnNO" runat="server" Text="btnNO" OnClick="btnNO_Click"/>
                <asp:Button ID="btnGo" runat="server" OnClientClick="if(ChkJoin()==false)return false;" Text=">" UseSubmitBehavior="false"  OnClick="btnGo_Click"/>
                <asp:Button ID="btnBack" runat="server" Text="<" UseSubmitBehavior="false" OnClick="btnBack_Click" />
            </span>
            </td>
            <td>
                <asp:Button ID="btnGoAll" runat="server" Text="ȫѡ" UseSubmitBehavior="false" ToolTip="���ѡ��ȫ��" CssClass="bt1" OnClick="btnGoAll_Click"/>
            </td>
            <td>
                <asp:Button ID="btnBackAll" runat="server" Text="ȫ����" UseSubmitBehavior="false" ToolTip="�������ȫ��ѡ��" CssClass="bt1" OnClick="btnBackAll_Click"/>
            </td>
            <td>���кţ�</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbSNO" runat="server" CssClass="pin" onkeydown="EnterTextBox(event, this);"></asp:TextBox>
            </td>
            <td style="color:#0000ff;">
                ����������кź�س�����������б��������ɨ��ǹ������롣
            </td>
            </tr>
          </table>
        </div>
        <div id="divlbutcon">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" EnableViewState="false" OnRowDataBound="GridView2_RowDataBound" SkinID="gv4">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="���񵥺�" DataField="BillID" />
                        <asp:BoundField HeaderText="�������" DataField="ServicesType" />
                        <asp:BoundField HeaderText="������" DataField="Operator" />
                        <asp:BoundField HeaderText="����ʱ��" DataField="Time_TakeOver" />
                        <asp:BoundField HeaderText="����ʱ��" DataField="Speding" />
                        <asp:BoundField HeaderText="����ʽ" DataField="TakeStyle" />
                        <asp:BoundField HeaderText="������" DataField="TakeDept" />
                        <asp:BoundField HeaderText="���ȼ�" DataField="_PRI" />
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
                        <asp:BoundField HeaderText="�������" DataField="Warranty" />
                        <asp:BoundField HeaderText="ԤԼʱ��" DataField="SubscribeTime" />
                        <asp:BoundField HeaderText="Ԥ����" DataField="SubscribePrice" />
                        <asp:BoundField HeaderText="Ԥ�շ�" DataField="PreCharge" />
                        <asp:BoundField HeaderText="����" DataField="bRepair" />
                    </Columns>
                </asp:GridView>
                <span style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; padding-top: 5px">
                    <asp:Label ID="lbsCount" runat="server" Style="color: #0000ff"></asp:Label></span>
                <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
                <asp:HiddenField ID="hflist" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBack" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnBackAll" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnGo" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnGoAll" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSnd" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnNO" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        </div>
        <div id="divlbutdo">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td>���޳��̣�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlRepairCorp" runat="server" CssClass="pindl">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>�������ڣ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbSndDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td>�ջ��ˣ�</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                          <asp:TextBox ID="tbLinkman" runat="server" CssClass="pin pinin" Width="100"></asp:TextBox>
                          <asp:DropDownList ID="ddlLinkman" runat="server" onchange="document.getElementById('tbLinkman').value=this.options[this.selectedIndex].text" style="width:103px;clip: rect(auto auto auto 86px);width:105px\9;clip: rect(auto auto auto 88px)\9;height:20px; position: absolute;" OnSelectedIndexChanged="ddlLinkman_SelectedIndexChanged" AutoPostBack="true">
                          </asp:DropDownList>
                      </div>
                </td>
                <td>�ջ���ַ��</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbAdr" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>���˷�ʽ��</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlSndStyle" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td>�������ţ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbPostNO" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td>���ʣ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbPostage" runat="server" Width="100"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSnd" runat="server" Text="ȷ�Ϸ���" CssClass="bt1"  UseSubmitBehavior="False" OnClientClick="if(chkReturn()==false)return false;" OnClick="btnSnd_Click" />
                </td>
            </tr>
          </table>
          </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBack" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnBackAll" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnGo" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnGoAll" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSnd" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnNO" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        </div>
    </div>
    <div class="clearfloat"></div>
    <div class="fbom">  
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><div id="fbon" class="fbon"></div></td>
            <td>
                <span class="sblue">ԤԼ����</span>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
}
function Chkset()
{
    Chkwhser2();
    Chkbom(); 
}

function EnterTextBox(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            $("btnNO").click();
        }
    }
}
function ChkSupplier(supplier,supid)
{
    $("hfSup").value=supplier;
    $("hfSupID").value=supid;
}
function ChkJoin()
{
    if($("ddlRepairCorp").value!="")
    {
        if($("ddlRepairCorp").options[$("ddlRepairCorp").selectedIndex].text!=$("hfSup").value&&$("ddlRepairCorp").value!=$("hfSupID").value)
        {
            alert("ͬһ�������б�������ڲ�ͬ�����޳��̣�");
            return false
        }
    }
}

function ChkGo()
{
    $("btnGo").click();
}
function ChkBack()
{
    $("btnBack").click();
}

function chkReturn()
{
    var list=$("hflist").value;
    if(list==""||list=="-1")
    {
        alert("����ʧ�ܣ���������޻���");return false;
    }
    
    if(!isNull($("tbPostage").value))
    {
        if(!isMoney($("tbPostage").value))
        {
            window.alert("����ʧ�ܣ����ʸ�ʽ����ȷ");
            $("tbPostage").focus();
            return false
        }
    }
    
    if(isNull($("tbSndDate").value))
    {
        window.alert("����ʧ�ܣ��������ڲ���Ϊ��");
        $("tbSndDate").focus();
        return false
    }
    
    if($("ddlSndStyle").value=="-1")
    {
        window.alert("����ʧ�ܣ����˷�ʽ����Ϊ��");
        $("ddlSndStyle").focus();
        return false
    }
}
function ChkView()
{
    ChkMod(860,444, 'Services/SerView.aspx', '����');
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("���޷���");
}
</script>
