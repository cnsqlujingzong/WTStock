<%@ page language="C#"  CodeFile="supplieradm.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_SupplierAdm" theme="Themes" enableEventValidation="false" %>
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
                <input id="btnNew" type="button" value="�½�" class="bt1" onclick="NewSup();" />
                <input id="btnMod" type="button" value="�޸�" class="bt1" onclick="ChkMod(540, 290,'Basic/SupplierMod.aspx','�޸ĳ���');" />
                <asp:Button ID="btnDel" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('��������')==false) return false;" OnClick="btnDel_Click"/>
                <input id="btnMerge" runat="server" type="button" value="�ϲ�" class="bt1" onclick="ChkMerge();" />
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
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
                    <input id="btntel"   runat="server" type="button" class="btel" value="Ⱥ��" onclick="SmsSndSBat();" />
                    <input id="btnInput" runat="server" type="button" class="binput" value="����" onclick="ChkInput();" />
                </td>
                <td>
                    <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl">
                        <asp:ListItem Value="All">���г���</asp:ListItem>
                        <asp:ListItem Value="bTransmitCorp">���޳���</asp:ListItem>
                        <asp:ListItem Value="bSupplier">��Ʒ��Ӧ��</asp:ListItem>
                        <asp:ListItem Value="bChargeCorp">��Լά�޽��㳧��</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlKey" runat="server" onchange="document.getElementById('tbCon').focus();" CssClass="pindl">
                        <asp:ListItem Value="0">ģ����ѯ</asp:ListItem>
                        <asp:ListItem Value="1">���������Ʋ�ѯ</asp:ListItem>
                        <asp:ListItem Value="2">�����̱�Ų�ѯ</asp:ListItem>
                        <asp:ListItem Value="3">����ϵ�˲�ѯ</asp:ListItem>
                        <asp:ListItem Value="4">���绰��ѯ</asp:ListItem>
                        <asp:ListItem Value="5">����ַ��ѯ</asp:ListItem>
                        <asp:ListItem Value="6">�������ѯ</asp:ListItem>
                        <asp:ListItem Value="7">���ʱ��ѯ</asp:ListItem>
                        <asp:ListItem Value="8">��Email��ѯ</asp:ListItem>
                        <asp:ListItem Value="9">����ע��ѯ</asp:ListItem>
                        <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                    </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td></tr>
            </table>   
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="lndiv" class="lndiv">
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
    <asp:GridView ID="GvData" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="GvData_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="ͣ��" DataField="bStop" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderTemplate>
                    <input id="cball" type="checkbox" class="cb1" onclick="SltAllValue();" title="ȫѡ/ȡ��ȫѡ"/>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="���̷���" DataField="ClassName" />
            <asp:BoundField HeaderText="���̱��" DataField="SupNO" />
            <asp:BoundField HeaderText="��������" DataField="_Name" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="�ֻ�����" DataField="Tel2" />
            <asp:BoundField HeaderText="����" DataField="Fax" />
            <asp:BoundField HeaderText="�ʱ�" DataField="Zip" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="�ʻ�" DataField="Account" />
            <asp:BoundField HeaderText="��ַ" DataField="Adr" />
            <asp:BoundField HeaderText="���޳���" DataField="bTransmitCorp" />
            <asp:BoundField HeaderText="��Ʒ��Ӧ��" DataField="bSupplier" />
            <asp:BoundField HeaderText="��Լά�޽��㳧��" DataField="bChargeCorp" />
            <asp:BoundField HeaderText="ͣ��" DataField="bStop" />
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
        <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
        <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
        <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
        <asp:HiddenField ID="hfSql" runat="server" />
        <asp:HiddenField ID="hfClass" runat="server" />
        <asp:HiddenField ID="hfClassID" runat="server" />
        <asp:HiddenField ID="hfTbTitle" runat="server" />
        <asp:HiddenField ID="hfTbField" runat="server" />
        <asp:HiddenField ID="hfcbID" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tvsup" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="cnbut" style="overflow:hidden;">
        <div class="ftool2">
        <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');ChkSltD('1');">��ϵ����</span>
            <span id="tabs_r1"></span>
            <span class="changwin">
                <input id="btnMin" type="button" value="" class="changmin" onclick="changmin();"/>
                <input id="btnRed" type="button" value="" class="changred" onclick="changred();" style="display:none;" />
                <input id="btnMax" type="button" value="" class="changmax" onclick="changmax();"/></span>
        </div>
        </div>
        <div id="info1" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnNewLink" type="button" value="�½�" class="bt1" onclick="NewLink();" />
                   <input id="btnModLink" type="button" value="�޸�" class="bt1" onclick="ModLink();" />
                   <asp:Button ID="btnDelLink" runat="server" Text="ɾ��" CssClass="bt1" OnClientClick="if(ChkDel2('��ϵ��')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelLink_Click" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="cndiv21">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="����" DataField="_Name" />
                            <asp:BoundField HeaderText="�Ա�" DataField="Sex" />
                            <asp:BoundField HeaderText="ְλ" DataField="Posit" />
                            <asp:BoundField HeaderText="�칫�绰" DataField="Tel_office" />
                            <asp:BoundField HeaderText="լ��" DataField="Tel_home" />
                            <asp:BoundField HeaderText="�ƶ��绰" DataField="Tel_Mobile" />
                            <asp:BoundField HeaderText="����" DataField="Fax" />
                            <asp:BoundField HeaderText="Email" DataField="Email" />
                            <asp:BoundField HeaderText="����" DataField="Birthday" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
                            <asp:BoundField HeaderText="��ַ" DataField="Adr" />
                            <asp:BoundField HeaderText="��ע" DataField="Remark" />
                        </Columns>
                    </asp:GridView>

                    <table cellpadding="0" cellspacing="0" class="pages">
                        <tr>
                            <td><webdiyer:aspnetpager id="jsPagerl" runat="server" onpagechanged="jsPagerl_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbPagel" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbCountTextl" runat="server" Visible="false" ToolTip="�ܼ�¼��" Text="�ܼ�¼:"></asp:Label><asp:Label ID="lbCountl" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
                        </tr>
                    </table>
                    
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnDelLink" EventName="Click" />
                    </Triggers>       
                    </asp:UpdatePanel>
            </div>
        </div>
    </div>
    
    <div class="clearfloat"></div>
    <div class="fbom">  
    <div id="fbon" class="fbon">
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
var tabnum=2;
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}
function Chkset()
{
    Chkwhcus();//Chkwh3();
    Chkbom(); 
}
function NewSup()
{
    var classid=$("hfClassID").value;
    parent.ShowDialog(540, 290, 'Basic/SupplierAdd.aspx?classid='+classid, '�½�����');
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("��������");
}
function ChkInput()
{
    parent.ShowDialog(600, 360,'Basic/InputSuplierList.aspx?iflag=1', '����ֿ�');
}
function ChkEditClass()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(300, 180,'Basic/EditSuplierInfo.aspx?id='+id,'�����޸ĳ�����Ϣ');
    }
}
function ChkMerge()
{
    var id=$("hfcbID").value;
    if(id==""||id.replace(/(^[\s,]*)|([\s,]*$)/g,"").indexOf(',')<=0)
    {
        alert("�빴ѡ������¼�ϲ���");
        return;
    }
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(500, 360,'Basic/SupMerge.aspx?id='+id,'�ϲ��ͻ�');
    }
}
//��������ΪĬ�ϴ�С
function changred()
{
    var h1=document.body.clientHeight-54;//���߶�
    var h2=h1-200;//�̶�ռ�ø߶�
    $("lndiv").style.height=h1+"px";
    $("lncn").style.height=h1+"px";
    $("cndiv").style.height=h2+"px";
    $("cnbut").style.height="200px";
    
    $("btnRed").style.display="none";
    $("btnMax").style.display="inline";
    $("btnMin").style.display="inline";
    
    if(typeof(tabnum)!="undefined")
    {
        for(i=1; i <tabnum; i++)
         {
             $("info"+i).style.height="175px";
             $("cndiv2"+i).style.height="145px";
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
    $("lndiv").style.height=h1+"px";
    $("lncn").style.height=h1+"px";
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
    $("lndiv").style.height=h1+"px";
    $("lncn").style.height=h1+"px";
    $("cndiv").style.height=h2+"px";
    $("cnbut").style.height="23px";
    
    $("btnRed").style.display="inline";
    $("btnMax").style.display="inline";
    $("btnMin").style.display="none";
}
function NewLink()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�����̼�¼�������");
        return false;
    }
    parent.ShowDialog(460, 263, 'Basic/LinkManAdd.aspx?id='+id, '�½���ϵ��');
}
function SmsSndSBat()
{
    if($("hfTbTitle").value=="")
    {
        window.alert("����ʧ�ܣ����ѯ��Ҫ���Ͷ��ŵĿͻ��б�.");
        return false;
    }
    parent.ShowDialog(500, 275,'Tool/SmsSndSBat.aspx', '����Ⱥ��');
}
function ModLink()
{
    var id=document.getElementById("hfRecID2").value.replace("l","");
    if(id=="-1")
    {
        alert("��ѡ��һ����ϵ�˺������");
    }
    else
    {
        parent.ShowDialog(460, 263,'Basic/LinkManMod.aspx?id='+id, '�޸���ϵ��');
    }
}
</script>
