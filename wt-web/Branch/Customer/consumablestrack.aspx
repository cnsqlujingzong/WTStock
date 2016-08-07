<%@ page language="C#"  CodeFile="consumablestrack.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_ConsumablesTrack" theme="Themes" enableEventValidation="false" %>
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
                </span>
            </td>
            
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                    <asp:CheckBox ID="cbHidden" runat="server" AutoPostBack="True" OnCheckedChanged="cbHidden_CheckedChanged" /> �����ѹ���
                </td>
                <td>
                    <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="pindl" Width="100">
                        <asp:ListItem Value="1">������</asp:ListItem>
                        <asp:ListItem Value="2">�Ѹ���</asp:ListItem>
                        <asp:ListItem Value="3">��ȡ��</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="CustomerName">���ͻ����Ʋ�ѯ</asp:ListItem>
                    <asp:ListItem Value="BillID">��ҵ�񵥺Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="LinkMan">����ϵ�˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="Tel">����ϵ�绰��ѯ</asp:ListItem>
                    <asp:ListItem Value="QtyTypeName">�����������Ͳ�ѯ</asp:ListItem>
                    <asp:ListItem Value="_Date">���������ڲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="TrackDate">���������ڲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="TrackOperator">�������˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="Result">�����ٽ����ѯ</asp:ListItem>
                    <asp:ListItem Value="Remark">����ע�˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
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
            
            <asp:BoundField HeaderText="Ԥ������" DataField="WarringDate" />
            <asp:BoundField HeaderText="ҵ�����" DataField="Type" />
            <asp:BoundField HeaderText="ҵ�񵥺�" DataField="BillID" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="����������" DataField="QtyTypeName" />
            <asp:BoundField HeaderText="��������" DataField="_Date" />
            <asp:BoundField HeaderText="������" DataField="Operator" />
            <asp:BoundField HeaderText="������" DataField="TrackOperator" />
            <asp:BoundField HeaderText="��������" DataField="TrackDate" />
            <asp:BoundField HeaderText="���ٽ��" DataField="Result" />
            <asp:BoundField HeaderText="�ٴθ���" DataField="bAgain" />
            <asp:BoundField HeaderText="�����ɹ�" DataField="bAllot" />
            <asp:BoundField HeaderText="�ɹ�����" DataField="OperationID" />
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
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="cbHidden" EventName="CheckedChanged" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1" class="tabs_activeleft"></span>
                <span id="tabs1" class="tabs_active" >�Ĳĸ���</span>
                <span id="tabs_r1" class="tabs_activeright"></span>
            </div>
        </div>
        <div class="cndiv2" id="cndiv2">
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" class="tb5">
                <tr>
                    <td align="right">
                    �����ˣ�</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                        </asp:DropDownList>
                    </td>
                    <td>�������ڣ�</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbDate" CssClass="Wdates" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                    </td>
                    <td style="padding-left:5px;">
                        <input id="btntel" type="button" class="btel2" onclick="ChkMod(600, 350, 'Tool/SmsAdm.aspx?f=1','���Ͷ���');" value="���Ͷ���" /></td>
                </tr>
               <tr>
                    <td align="right">���ٽ����</td>
                    <td style="padding-left:0px;height:80px;" colspan="3">
                    <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" TextMode="MultiLine" Height="70" Width="343"></asp:TextBox></td>
                    <td valign="top" style="padding-left:5px;">
                        <input id="btntrack" type="button" class="btrack" onclick="ChkAllot();" value="�����ɹ�" /></td>
               </tr>
            </table>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="left" style="padding-left:350px;">
                        <asp:CheckBox ID="cbagain" runat="server" /> <span class="sysblue">���ٴθ���</span>
                        <asp:Button ID="btnSave" runat="server" Text="ȷ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false) return false" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="ȡ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkCancel()==false) return false" OnClick="btnCancel_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
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

function ChkAllot()
{
    if(ChkSlt()!=false)
    {
        parent.ShowDialog(480, 185, 'Customer/TrackAllot.aspx?id='+$("hfRecID").value+'&str='+escape($("tbRemark").value), '�����ɹ�');
    }else{return false;}
}
function ChkCancel()
{
    if(ChkSltValue()!=false)
    {
        return confirm("ȷ��Ҫȡ��[�Ĳĸ���]��");
    }else{return false;}
}

function ChkSave()
{
    if(ChkSlt()!=false)
    {
        if($("ddlOperator").value=="-1")
        {
            window.alert("����ʧ�ܣ������˲���Ϊ��");
            $("ddlOperator").focus();
            return false
        }
         if(isNull($("tbDate").value))
        {
            window.alert("����ʧ�ܣ��������ڲ���Ϊ��");
            $("tbDate").focus();
            return false
        }
        if(isNull($("tbRemark").value))
        {
            window.alert("����ʧ�ܣ����ٽ������Ϊ��");
            $("tbRemark").focus();
            return false
        }
        if($("cbagain").checked)
        {
            parent.ShowDialog(300, 95, 'Customer/AgainTrack.aspx?id='+$("hfRecID").value+'&str='+escape($("tbRemark").value)+'&stroper='+escape($("ddlOperator").value)+'&strdate='+escape($("tbDate").value), '�ٴθ��ٴ���');
            return false;
        }
    }else{return false;}
}
function Sell(id,title)
{
    parent.ShowDialog(800, 480,'Sell/SellMod.aspx?ids='+id,title);
}
function Lease(id)
{
    parent.ShowDialog(800, 480,'Lease/LeaseMod.aspx?ids='+id,'ҵ��');
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("�Ĳĸ���");
}

</script>
