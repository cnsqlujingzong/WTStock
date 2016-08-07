<%@ page language="C#"  CodeFile="mods.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_ModS" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="main">
        <div class="maincon">
        <div id="sa" style="width:506px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tb5">
                    <tr>
                        <td align="right" style="white-space:nowrap;">����ʽ��</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbDoStyle" CssClass="pinb" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                        <td align="right">
                        �����ˣ�</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbOperator" runat="server" CssClass="pinb" ReadOnly="true" Width="176"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">�����ˣ�</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbDisposal" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td align="right" style="white-space:nowrap;">
                            ����ʱ�䣺
                        </td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbDate" runat="server" CssClass="pinb" ReadOnly="true" Width="176"></asp:TextBox>
                        </td>
                    </tr>
                <tr>
                    <td align="right">����������</td>
                    <td style="padding-left:0px;height:67px" colspan="3">
                        <asp:TextBox ID="tbFault" runat="server" CssClass="pinb" ReadOnly="true" TextMode="multiLine" Height="57" Width="386px"></asp:TextBox>
                    </td>
                    <td style="padding:0px;"><input id="btnFaultAttch" title="���ƹ��ϸ���" type="button" onclick="FaultAttach();" class="battach"/></td>
                </tr>
                <tr>
                    <td class="sysred" align="center">ά�޴�ʩ<br />
                    /�����</td>
                    <td style="padding-left:0px;height:84px;" colspan="3">
                        <asp:TextBox ID="tbTakeSteps" runat="server" TextMode="multiLine" CssClass="pin" Height="70" Width="384px"></asp:TextBox>
                        <asp:HiddenField ID="hfTakeSteps" runat="server" />
                        <asp:HiddenField ID="hfEnforceInput" runat="server" Value="0" />
                    </td>
                    <td style="padding:0px; text-align:left; vertical-align:bottom; padding-bottom:5px;"><input id="btnTSAttch" title="�����ʩ/�������" type="button" onclick="TSAttachs();" class="battach"/><br />
                    <input id="Button1" type="button" value="" onclick="SltTroubleSteps();" class="bview"/></td>
                </tr>
                <tr>
                    <td align="right" <%=EnforceStyle %>>����ʱ�䣺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbDoorDate" runat="server" CssClass="pin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox></td>
                    <td>����ʱ����</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbDay" runat="server" CssClass="pin" Width="60"></asp:TextBox> ��
                        <asp:TextBox ID="tbHour" runat="server" CssClass="pin" Width="60"></asp:TextBox> Сʱ
                    </td>
                </tr>
                <tr>
                    <td align="right" class="sysred">���ʱ�䣺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbArrDate" runat="server" CssClass="pin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox></td>
                    <td align="right" <%=EnforceStyle %>>����ԭ��</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                            <input type="text" id="tbReason" runat="server" class="pin" style="width:163px;position: absolute;"/>
                            <asp:DropDownList ID="ddlTroubleReason" runat="server" onchange="document.getElementById('tbReason').value=this.options[this.selectedIndex].text" style="width:180px;clip: rect(auto auto auto 162px); position: absolute;height:20px;">
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td style="padding:0px;"><input id="btnRSAttach" title="����ԭ�򸽼�" type="button" onclick="ReasonAttachs();" class="battach"/></td>
                </tr>
                <tr>
                    <td align="right">ִ�й��̣�</td>
                    <td style="padding-left:0px;" colspan="4"><asp:TextBox ID="tbCourse" runat="server" CssClass="pin" Width="285"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkOver" runat="server" Text="����δȡ" />
                    </td>
                </tr>
             </table>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                        <asp:HiddenField ID="hfTSAttachs" runat="server" />
                        <asp:HiddenField ID="hfReasonAttachs" runat="server" />
                        <asp:HiddenField ID="hfAttachs" runat="server" />
                </td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false) return false;" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var processtip=1;

function FaultAttach()
{
    var ids=$("hfAttachs").value;
    parent.ShowDialog1(480, 243, 'Services/SerAttachs.aspx?m=0&t=1&aids='+ids+'&bid='+<%=Str_id %>, '���ƹ��ϸ���');
}
function TSAttachs()
{
    var ids=$("hfTSAttachs").value;
    parent.ShowDialog1(480, 243, 'Services/SerAttachs.aspx?t=2&aids='+ids+'&bid='+<%=Str_id %>, '�����ʩ/�������');
}
function ReasonAttachs()
{
    var ids=$("hfReasonAttachs").value;
    parent.ShowDialog1(480, 243, 'Services/SerAttachs.aspx?t=3&aids='+ids+'&bid='+<%=Str_id %>, '����ԭ�򸽼�');
}
function ChkSave()
{
    if(isNull($("tbTakeSteps").value))
    {
        window.alert("����ʧ�ܣ�ά�޴�ʩ����Ϊ��");
        $("tbTakeSteps").focus();
        return false
    }
    if(<%=EnforceInput %>&&$("tbDoStyle").value=="��ɹر�")
    {
        if($("tbDoorDate").value=="")
        {
            window.alert("����ʧ�ܣ�����ʱ�䲻��Ϊ��");
            $("tbDoorDate").focus();
            return false;
        }
        if($("tbReason").value=="")
        {
            window.alert("����ʧ�ܣ�����ԭ����Ϊ��");
            $("tbReason").focus();
            return false;
        }
    }
    if(isNull($("tbArrDate").value))
    {
        window.alert("����ʧ�ܣ����ʱ�䲻��Ϊ��");
        $("tbArrDate").focus();
        return false
    }
}
function SltTroubleSteps()
{
    parent.ShowDialog1(500, 510, 'Services/SltoubleStepsList.aspx', '�����ʩ');
}
</script>
