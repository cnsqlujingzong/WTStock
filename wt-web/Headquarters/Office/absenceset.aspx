<%@ page language="C#"  CodeFile="absenceset.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Office_AbsenceSet" theme="Themes" enableEventValidation="false" %>
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
            <span id="tabs1" onclick="ChkTab('1');">��Ϣʱ������</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">�ٵ���������</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">ȱ������</span>
            <span id="tabs_r3"></span>
     </div>
    <div id="info1" style="height:304px;overflow:hidden;">
      
      <div class="divcon" style="height:275px;">
      <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
        <asp:GridView ID="GridView1" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="��" />
                <asp:BoundField HeaderText="����" DataField="Week" />
                <asp:BoundField HeaderText="�ϰ�ʱ��" DataField="WorkTime"/>
                <asp:BoundField HeaderText="�°�ʱ��" DataField="AfterWorkTime"/>
                <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
        </asp:GridView>
          <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
          </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnRef1" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel1" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
       </div>
       <div class="fbombtn">
      <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
            <td style="padding-left:0px;">
            <asp:Button ID="btnRef1" runat="server" Text="ˢ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnRef1_Click"/>
            <input id="btnNew1" type="button" value="�½�" class="bt1" onclick="parent.ShowDialog1(470, 150, 'Office/TimeSetAdd.aspx', '��Ϣʱ������');"/>
            <input id="btnEdit1" type="button" value="�޸�" class="bt1" onclick="Mod1();"/>
            <asp:Button ID="btnDel1" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnDel1_Click"/>
            </td>
            </tr>
        </table>
      </div>
    </div>
    <div id="info2" style="height:304px;overflow:hidden;">
       <div class="divcon" style="height:275px;">
      <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
        <asp:GridView ID="GridView2" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="��" />
                <asp:BoundField HeaderText="���" DataField="Type" />
                <asp:BoundField HeaderText="��ʼ����" DataField="StartMin"/>
                <asp:BoundField HeaderText="��������" DataField="EndMin"/>
                <asp:BoundField HeaderText="�ۿ���" DataField="dMoney"/>
                <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
        </asp:GridView>
          <asp:HiddenField ID="HiddenField1" runat="server" Value="-1" />
          </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnRef2" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel2" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
       </div>
       <div class="fbombtn">
      <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
            <td style="padding-left:0px;">
            <asp:Button ID="btnRef2" runat="server" Text="ˢ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnRef2_Click"/>
            <input id="btnNew2" type="button" value="�½�" class="bt1" onclick="parent.ShowDialog1(470, 150, 'Office/LateSetAdd.aspx', '�ٵ���������');"/>
            <input id="btnEdit2" type="button" value="�޸�" class="bt1" onclick="Mod2();"/>
            <asp:Button ID="btnDel2" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnDel2_Click"/>
            </td>
            </tr>
        </table>
      </div>
    </div>
    <div id="info3" style="height:304px;overflow:hidden;">
       <div class="divcon" style="height:275px;">
      <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
        <asp:GridView ID="GridView3" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView3_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="��" />
                <asp:BoundField HeaderText="���" DataField="Type" />
                <asp:BoundField HeaderText="�ۿ���" DataField="dMoney"/>
                <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
        </asp:GridView>
          </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnRef3" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel3" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
       </div>
       <div class="fbombtn">
      <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
            <td style="padding-left:0px;">
            <asp:Button ID="btnRef3" runat="server" Text="ˢ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnRef3_Click"/>
            <input id="btnNew3" type="button" value="�½�" class="bt1" onclick="parent.ShowDialog1(450, 120, 'Office/AbsenceSetAdd.aspx', 'ȱ������');"/>
            <input id="btnEidt3" type="button" value="�޸�" class="bt1" onclick="Mod3();"/>
            <asp:Button ID="btnDel3" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnDel3_Click"/>
            </td>
            </tr>
        </table>
      </div>
    </div>
    
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td></td>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var tabnum=4;
function ChkID(id)
{
    ClrBaseID(id);
}

function Mod1()
{
    if(ChkSlt()!=false)
    {
        parent.ShowDialog1(470, 150,'Office/TimeSetMod.aspx?id='+$("hfRecID").value,'��Ϣʱ������');
    }
}

function Mod2()
{
    if(ChkSlt()!=false)
    {
        parent.ShowDialog1(470, 150,'Office/LateSetMod.aspx?id='+$("hfRecID").value,'�ٵ���������');
    }
}

function Mod3()
{
    if(ChkSlt()!=false)
    {
        parent.ShowDialog1(450, 120,'Office/AbsenceSetMod.aspx?id='+$("hfRecID").value,'ȱ������');
    }
}
</script>
