<%@ page language="C#"  CodeFile="smsadm.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Tool_SmsAdm" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa22" style="width:586px;">
    <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">����</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">����</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">ģ��</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">�ѷ�����</span>
            <span id="tabs_r4"></span>
            <span id="tabs_l5"></span>
            <span id="tabs5" onclick="ChkTab('5');">�յ�����</span>
            <span id="tabs_r5"></span>
     </div>
    <div id="info1" style="height:271px;padding:3px 0px 0px 3px; overflow:hidden;">
        <div id="divinfo1" class="divinfo" style="height:265px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td>���͵���</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin" Width="200"></asp:TextBox></td>
                    <td style="padding-left:120px;">ģ�棺</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlTmp" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlTmp_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height:165px">
                        <asp:TextBox ID="tbSmsContent" runat="server" TextMode="MultiLine" Height="150" Width="540"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSnd" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="560px">
            <tr>
                <td align="right">
                    <asp:Button ID="btnSnd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSnd()==false)return false;" OnClick="btnSnd_Click"/>
                </td>
            </tr>
            </table>
        </div>
    </div>
    <div id="info2" style="height:274px;overflow:hidden;">
        <div id="div1" class="divinfo" style="height:235px; width:584px; overflow:auto;">
       <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="RecID" />
                <asp:BoundField HeaderText="��" />
                <asp:BoundField HeaderText="����ʱ��" DataField="SndTiming" />
                <asp:BoundField HeaderText="����ģ��" DataField="SmsTmp" />
            </Columns>
        </asp:GridView>
            <span style="display:none;">
                <asp:Button ID="btnRefTiming" runat="server" Text="btnRefTiming" UseSubmitBehavior="false" OnClick="btnRefTiming_Click"/>
            </span>
        </ContentTemplate>
           <Triggers>
               <asp:AsyncPostBackTrigger ControlID="btnTimingDel" EventName="Click" />
           </Triggers>
        </asp:UpdatePanel>
        </div>
        <div class="fbombtn">
          <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                <td style="padding-left:0px;">
                <input id="btnTimingAdd" type="button" value="�½�" class="bt1" onclick="parent.ShowDialog1(500, 93, 'Tool/SmsTimingAdd.aspx', '�½�ģ��');"/>
                <input id="btnTimingMod" type="button" value="�޸�" class="bt1" onclick="ModTmp(500,93,'Tool/SmsTimingMod.aspx','�鿴�޸�');"/>
                <asp:Button ID="btnTimingDel" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('���Ͳ���')==false) return false;" OnClick="btnTimingDel_Click"/>
                </td>
                </tr>
            </table>
      </div>
    </div>
    <div id="info3" style="height:274px;overflow:hidden;">
        <div id="div2" class="divinfo" style="height:235px; width:584px; overflow:auto;">
       <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="RecID" />
                <asp:BoundField HeaderText="��" />
                <asp:BoundField HeaderText="����" DataField="Title" />
                <asp:BoundField HeaderText="����" DataField="Content" />
            </Columns>
        </asp:GridView>
            <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
            <span style="display:none;">
                <asp:Button ID="btnRefTmp" runat="server" Text="btnRefTmp" UseSubmitBehavior="false" OnClick="btnRefTmp_Click"/>
            </span>
        </ContentTemplate>
           <Triggers>
               <asp:AsyncPostBackTrigger ControlID="btnDelTmp" EventName="Click" />
           </Triggers>
        </asp:UpdatePanel>
        </div>
        <div class="fbombtn">
          <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                <td style="padding-left:0px;">
                <input id="btnNewTmp" type="button" value="�½�" class="bt1" onclick="parent.ShowDialog1(600, 260, 'Tool/SmsTmpAdd.aspx', '�½�ģ��');"/>
                <input id="btnEditTmp" type="button" value="�޸�" class="bt1" onclick="ModTmp(600,260,'Tool/SmsTmpMod.aspx','�鿴�޸�');"/>
                <asp:Button ID="btnDelTmp" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('����ģ��')==false) return false;" OnClick="btnDelTmp_Click"/>
                </td>
                </tr>
            </table>
      </div>
    </div>
    <div id="info4" style="height:274px;overflow:hidden;">
        <div id="div3" class="divinfo" style="height:235px; width:584px; overflow:auto;">
       <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView2_RowDataBound" EnableViewState="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="RecID" />
                <asp:BoundField HeaderText="��" />
                <asp:BoundField HeaderText="���պ���" DataField="SndTo" />
                <asp:BoundField HeaderText="ʱ��" DataField="SDate" />
                <asp:BoundField HeaderText="����" DataField="Content" />
                <asp:BoundField HeaderText="���" DataField="SFlag" />
                <asp:BoundField HeaderText="������" DataField="SenderName" />
                <asp:BoundField HeaderText="����" DataField="SenderDept" />
            </Columns>
        </asp:GridView>
        <table cellpadding="0" cellspacing="0" class="pages">
            <tr>
                <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
                <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
                <td style="padding-left:8px;"><asp:Label ID="lbCountText" runat="server" ToolTip="�ܼ�¼��" Text="�ܼ�¼:"></asp:Label><asp:Label ID="lbCount" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
            </tr>
        </table>
        </ContentTemplate>
           <Triggers>
               <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnSndDel" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
           </Triggers>
        </asp:UpdatePanel>
        </div>
        <div class="fbombtn">
          <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                <td style="padding-left:0px;">
                <asp:Button ID="btnFsh" runat="server" Text="ˢ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnFsh_Click" />
                <input id="btnSndView" type="button" value="�鿴" class="bt1" onclick="ModTmp(500,260,'Tool/SmsSndView.aspx','�鿴����');"/>
                <asp:Button ID="btnSndDel" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('����')==false) return false;" OnClick="btnSndDel_Click"/>
                <asp:Button ID="btnClean" runat="server" Text="���" CssClass="bt1" OnClientClick="if(confirm('��������ѷ����ţ�')==false) return false;"  UseSubmitBehavior="false" OnClick="btnClean_Click"/>
                </td>
                </tr>
            </table>
      </div>
    </div>
    <div id="info5" style="height:274px;overflow:hidden;">
       <div id="div4" class="divinfo" style="height:235px; width:584px; overflow:auto;">
       <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView3_RowDataBound" EnableViewState="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="RecID" />
                <asp:BoundField HeaderText="��" />
                <asp:BoundField HeaderText="���ͷ�����" DataField="SndFrom" />
                <asp:BoundField HeaderText="ʱ��" DataField="SDate" />
                <asp:BoundField HeaderText="����" DataField="Content" />
            </Columns>
        </asp:GridView>
        <table cellpadding="0" cellspacing="0" class="pages">
            <tr>
                <td><webdiyer:aspnetpager id="jsPagers" runat="server" onpagechanged="jsPagers_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
                <td style="padding-left:8px;"><asp:Label ID="lbPage1" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
                <td style="padding-left:8px;"><asp:Label ID="lbCountText1" runat="server" ToolTip="�ܼ�¼��" Text="�ܼ�¼:"></asp:Label><asp:Label ID="lbCount1" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
            </tr>
        </table>
        </ContentTemplate>
           <Triggers>
               <asp:AsyncPostBackTrigger ControlID="btnFsh1" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnSndDel1" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnClean1" EventName="Click" />
           </Triggers>
        </asp:UpdatePanel>
        </div>
        <div class="fbombtn">
          <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                <td style="padding-left:0px;">
                <asp:Button ID="btnFsh1" runat="server" Text="ˢ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnFsh1_Click" />
                <input id="btnRcvView" type="button" value="�鿴" class="bt1" onclick="ModTmp(500,260,'Tool/SmsRcvView.aspx','�鿴����');"/>
                <asp:Button ID="btnSndDel1" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('����')==false) return false;" OnClick="btnSndDel1_Click"/>
                <asp:Button ID="btnClean1" runat="server" Text="���" CssClass="bt1" OnClientClick="if(confirm('��������յ����ţ�')==false) return false;"  UseSubmitBehavior="false" OnClick="btnClean1_Click"/>
                </td>
                </tr>
            </table>
      </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right">
            <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();"/>
        </td>
    </tr>
    </table>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var tabnum=6;
function ChkID(id)
{
    ClrBaseID(id);
}

function ChkSnd()
{
    if(isNull($("tbTel").value))
    {
        window.alert("������Ҫ���͵��ֻ����룡");
        $("tbTel").select();
        return false
    }
    
    if(isNull($("tbSmsContent").value))
    {
        window.alert("������Ҫ���͵Ķ������ݣ�");
        $("tbSmsContent").select();
        return false
    }
    
    var smsno=$("tbTel").value;
    var sn=smsno.split(',');
    var flag=0;
    for(var i=0;i<sn.length;i++)
    {
        if(!sn[i].isMobile())
        {
            flag=1;
            break;
        }
    }
    if(flag==1)
    {
        return confirm("���ڲ���ȷ���ֻ����룬�Ƿ����");
    }
}

String.prototype.isMobile = function(){   
return (/^0?(13[0-9]|15[012356789]|18[0236789]|14[57])[0-9]{8}$/.test(this.Trim()));   
} 
String.prototype.Trim = function() {   
var m = this.match(/^\s*(\S+(\s+\S+)*)\s*/);   
return (m == null) ? "" : m[1];   
} 
 

//�޸�
function ModTmp(w,h,url,title)
{
    if(ChkSlt()!=false)
    {
        var recid=$("hfRecID").value;
        parent.ShowDialog1(w,h,url+'?id='+recid,title);
    }
}
</script>