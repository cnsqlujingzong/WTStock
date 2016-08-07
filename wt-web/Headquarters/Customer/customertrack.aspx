<%@ page language="C#"  CodeFile="customertrack.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_CustomerTrack" theme="Themes" enableEventValidation="false" %>
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
                <input id="btnAllot" runat="server" type="button" value="����" class="bt1" onclick="ChkAllot();" />
                <input id="btnDo" type="button" runat="server" value="�رո���" class="bt1" onclick="CloseTrack();" />
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
                    <input id="btnClass" runat="server" type="button" class="bclass" value="�����޸�" onclick="ChkEditClass();" />
                    <input id="btnInput" runat="server" type="button" class="binput" value="����" onclick="ChkInput();" />
                </td>
                <td>
                    <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
                </td>
               <td>
                    <asp:DropDownList ID="ddlKey" runat="server" onchange="document.getElementById('tbCon').focus();" CssClass="pindl">
                        <asp:ListItem Value="0">ģ����ѯ</asp:ListItem>
                        <asp:ListItem Value="1">���ͻ���Ų�ѯ</asp:ListItem>
                        <asp:ListItem Value="2">���ͻ����Ʋ�ѯ</asp:ListItem>
                        <asp:ListItem Value="3">����ϵ�˲�ѯ</asp:ListItem>
                        <asp:ListItem Value="4">���绰��ѯ</asp:ListItem>
                        <asp:ListItem Value="5">����ַ��ѯ</asp:ListItem>
                        <asp:ListItem Value="6">���ʱ��ѯ</asp:ListItem>
                        <asp:ListItem Value="7">�������ѯ</asp:ListItem>
                        <asp:ListItem Value="8">��Email��ѯ</asp:ListItem>
                        <asp:ListItem Value="9">���ͻ������ѯ</asp:ListItem>
                        <asp:ListItem Value="10">���Ǽǲ��Ų�ѯ</asp:ListItem>
                        <asp:ListItem Value="11">���ͻ���Դ��ѯ</asp:ListItem>
                        <asp:ListItem Value="12">��ҵ��Ա��ѯ</asp:ListItem>
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
    
    <div id="lndiv" class="lndiv">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:TreeView ID="tvcus" runat="server" ShowLines="True" OnSelectedNodeChanged="tvcus_SelectedNodeChanged">
            <SelectedNodeStyle BackColor="#7d8abe" BorderColor="White" />
        </asp:TreeView>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="tvcus" EventName="SelectedNodeChanged" />
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
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderTemplate>
                    <input id="cball" type="checkbox" class="cb1" onclick="SltAllValue();" title="ȫѡ/ȡ��ȫѡ"/>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="�ͻ�����" DataField="ClassName" />
            <asp:BoundField HeaderText="������" DataField="TrackOperator" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="_Name" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="�ֻ�����" DataField="Tel2" />
            <asp:BoundField HeaderText="��ַ" DataField="Adr" />
            <asp:BoundField HeaderText="�ʱ�" DataField="Zip" />
            <asp:BoundField HeaderText="����" DataField="Fax" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="QQ/MSN" DataField="QQ" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="Area" />
            <asp:BoundField HeaderText="�ͻ���Դ" DataField="CusFrom" />
            <asp:BoundField HeaderText="��Ա����" DataField="Member" />
            <asp:BoundField HeaderText="�ͻ�״̬" DataField="Status" />
            <asp:BoundField HeaderText="�Ǽǲ���" DataField="DeptID" />
            <asp:BoundField HeaderText="�Ǽ�ʱ��" DataField="_Date" />
            <asp:BoundField HeaderText="�طñ�־" DataField="bCall" />
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
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    <asp:HiddenField ID="hfcbID" runat="server" />
        <asp:HiddenField ID="hfPurArea" runat="server" />
        <asp:HiddenField ID="hfPur1" runat="server" />
        <asp:HiddenField ID="hfPur2" runat="server" />
        <asp:HiddenField ID="hfPur3" runat="server" />
        <asp:HiddenField ID="hfPur4" runat="server" />
        <asp:HiddenField ID="hfClass" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tvcus" EventName="SelectedNodeChanged" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    <div id="cnbut" style="overflow:hidden;">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1" class="tabs_activeleft"></span>
                <span id="tabs1" class="tabs_active" >������Ϣ</span>
                <span id="tabs_r1" class="tabs_activeright"></span>
            </div>
        </div>
        <div id="info1" style="height:175px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
           <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
            <tr>
            <td>
               <input id="btnNewT" runat="server" type="button" value="�½�" class="bt1" onclick="NewT();" />
               <input id="btnModT" runat="server" type="button" value="�޸�" class="bt1" onclick="ModT();" />
               <asp:Button ID="btnDelT" runat="server" Text="ɾ��" CssClass="bt1" OnClientClick="if(ChkDel2('������Ϣ')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelT_Click" />
            </td>
            <td align="right">
                    <asp:Button ID="btnExcelDe" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcelDe_Click" />
            </td>
            </tr>
           </table>
        </div>
        <div class="cndiv2" id="Div4" style="height:145px;">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="��������" DataField="_Date" />
                        <asp:BoundField HeaderText="������" DataField="Operator" />
                        <asp:BoundField HeaderText="��������" DataField="Content" />
                        <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
                        <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
                        <asp:BoundField HeaderText="���ٷ�ʽ" DataField="TrackStyle" />
                        <asp:BoundField HeaderText="�������" DataField="TrackType" />
                        <asp:BoundField HeaderText="���ٽ��" DataField="Result" />
                        <asp:BoundField HeaderText="�´θ�������" DataField="NextTrack" />
                        <asp:BoundField HeaderText="���ٸ���" DataField="bTrack" />
                    </Columns>
                </asp:GridView>
                    <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelT" EventName="Click" />
                </Triggers>       
                </asp:UpdatePanel>
        </div>
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
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}
function Chkset()
{
    Chkwhcus();
    Chkbom(); 
}

function ShowCus()
{
    ChkMod(600, 450, 'Customer/CusMod.aspx', '�޸Ŀͻ�');
}
function ChkEditClass()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(300, 242,'Customer/EditCusClass.aspx?id='+id,'�����޸Ŀͻ�����');
    }
}
function NewT()
{
    var id=$("hfRecID").value;
    if(id==""||id=="-1")
    {
        alert("��ѡ��һ���ͻ���¼�������");
        return false;
    }
     parent.ShowDialog(470, 290, 'Customer/TrackAdd.aspx?id='+id, '�½�����');
}

function ModT()
{
    var id=document.getElementById("hfRecID2").value;
    if(id=="-1")
    {
        alert("��ѡ��һ��������ϸ�������");
    }
    else
    {
        parent.ShowDialog(470, 290,'Customer/TrackMod.aspx?id='+id, '�޸ĸ���');
    }
}
function CloseTrack()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(300, 95,'Customer/CloseTrack.aspx?id='+id,'�رո���');
    }
}
function ChkAllot()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(300, 155,'Customer/CusAllot.aspx?id='+id,'���ɿͻ�');
    }
}
function ShowTC(id)
{
    parent.ShowDialog(470, 360,'Customer/ShowTC.aspx?id='+id, '��������');
}
function ShowTR(id)
{
    parent.ShowDialog(470, 360,'Customer/ShowTR.aspx?id='+id, '���ٽ��');
}
function ChkInput()
{
    parent.ShowDialog(600, 473,'Customer/InputCus.aspx?iflag=2', '����ͻ�����');
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("�ͻ�����");
}
</script>
