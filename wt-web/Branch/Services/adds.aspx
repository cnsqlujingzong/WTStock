<%@ page language="C#"  CodeFile="adds.aspx.cs"     autoeventwireup="true" inherits="Branch_Services_AddS" enableeventvalidation="false" %>
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
                        <td align="right" class="red">����ʽ��</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlDoStyle" runat="server" CssClass="pindl" AutoPostBack="true" onchange="chkbtn();" OnSelectedIndexChanged="ddlDoStyle_SelectedIndexChanged">
                                <asp:ListItem Value="1">�����ɹ�</asp:ListItem>
                                <asp:ListItem Value="2">��ɹر�</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                         <td align="right">
                        �����ˣ�</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl" Width="180">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">�²�����</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlUpDispatching" runat="server" CssClass="pindl" AutoPostBack="true" OnSelectedIndexChanged="ddlUpDispatching_SelectedIndexChanged">
                                <asp:ListItem Value="4">�ڲ�����</asp:ListItem>
                                <asp:ListItem Value="3">�ɸ�����</asp:ListItem>
                                <asp:ListItem Value="1">ί������</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlCloseTyle" runat="server" CssClass="pindl" AutoPostBack="true" OnSelectedIndexChanged="ddlCloseTyle_SelectedIndexChanged">
                                <asp:ListItem Value="1">���</asp:ListItem>
                                <asp:ListItem Value="2">ȡ��</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="lbTitle" runat="server" Text="����Ա"></asp:Label>��</td>
                        <td style="padding-left:0px; width:180px;">
                            <asp:TextBox ID="tbDisposal" runat="server" CssClass="pin" Width="174"></asp:TextBox>
                            <asp:DropDownList ID="ddlParam" runat="server" CssClass="pindl" Width="180" OnSelectedIndexChanged="ddlParam_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Width="176"></asp:TextBox>
                            
                            <div class="isinDiv" id="dcancel" runat="server">
                                <input type="text" id="tbCaReason" runat="server" class="pin" style="width:163px;position: absolute;" />
                                <asp:DropDownList ID="ddlCancel" runat="server" onchange="document.getElementById('tbCaReason').value=this.options[this.selectedIndex].text" style="width:180px;clip: rect(auto auto auto 162px); position: absolute;height:20px;">
                                </asp:DropDownList>
                            </div>
                        </td>
                        <td style="padding:0px;"><input id="btnSltStaff" runat="server" type="button" value="" onclick="SltTec();" title="ѡ����Ա" class="bview"/></td>
                    </tr>
                    <tr id="trbtec" runat="server" visible="false">
                    <td align="right">����Ա��</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbDisposal2" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td style="padding:0px;"><input id="btnSltStaff2" runat="server" type="button" onclick="SltTec2();" title="ѡ����Ա" class="bview"/></td>
                </tr>
                <tr>
                    <td align="right">����������</td>
                    <td style="padding-left:0px;padding-top:5px;padding-bottom:5px;" colspan="3">
                        <asp:TextBox ID="tbFault" runat="server" CssClass="pinb" ReadOnly="true" TextMode="multiLine" Height="57" Width="386"></asp:TextBox>
                    </td>
                    <td style="padding:0px;"><input id="btnFaultAttch" title="���ƹ��ϸ���" type="button" onclick="FaultAttach();" class="battach"/></td>
                </tr>
                <tr>
                    <td class="sysred" align="center">�����ʩ<br />
                    /�����</td>
                    <td style="padding-left:0px;height:84px;" colspan="3">
                        <asp:TextBox ID="tbTakeSteps" runat="server" TextMode="multiLine" CssClass="pin" Height="70" Width="384"></asp:TextBox>
                        <asp:HiddenField ID="hfTakeSteps" runat="server" />
                        <asp:HiddenField ID="hfTSAttachs" runat="server" />
                        <asp:HiddenField ID="hfAttachs" runat="server" />
                        <asp:HiddenField ID="hfReasonAttachs" runat="server" />
                        <asp:HiddenField ID="hfEnforceInput" runat="server" Value="0" />
                    </td>
                     <td style="padding:0px; text-align:left; vertical-align:bottom; padding-bottom:5px;"><input id="btnTSAttch" title="�����ʩ/�������" type="button" onclick="TSAttachs();" class="battach"/><br />
                     <input id="Button1" type="button" value="" onclick="SltTroubleSteps();" class="bview"/></td>
                </tr>
                <tr>
                    <td align="right" <%=EnforceStyle %>>����ʱ�䣺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbDoorDate" runat="server" CssClass="pin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox></td>
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
                <td><a href="#" style="color:#0000ff;" onclick="NewQty();">�½�������</a>
                </td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="ȷ��" CssClass="bt1" OnClientClick="if(ChkSave()==false) return false;"  UseSubmitBehavior="false" OnClick="btnAdd_Click"/>
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
    if($("ddlOperator").value=="-1")
    {
        window.alert("����ʧ�ܣ������˲���Ϊ��");
        $("ddlOperator").focus();
        return false
    }
    if($("ddlDoStyle").value=="1")
    {
        if($("ddlUpDispatching").value=="4")
        {
            if(isNull($("tbDisposal").value))
            {
                window.alert("����ʧ�ܣ�"+$("lbTitle").innerHTML+"����Ϊ��");
                $("tbDisposal").focus();
                return false
            }
        }else
        {
            if($("ddlParam").value=="-1")
            {
                window.alert("����ʧ�ܣ���ѡ��"+$("lbTitle").innerHTML);
                $("ddlParam").focus();
                return false
            }
        }
    }else
    {
        if($("ddlCloseTyle").value=="1")
        {
            if(isNull($("tbDate").value))
            {
                window.alert("����ʧ�ܣ�"+$("lbTitle").innerHTML+"����Ϊ��");
                $("tbDate").focus();
                return false
            }
            if(isNull($("tbTakeSteps").value))
            {
                window.alert("����ʧ�ܣ������ʩ/�������Ϊ��");
                $("tbTakeSteps").focus();
                return false
            }
        }else
        {
            if(isNull($("tbCaReason").value))
            {
                window.alert("����ʧ�ܣ�"+$("lbTitle").innerHTML+"����Ϊ��");
                $("tbCaReason").focus();
                return false
            }
        }
    }
    
    if(<%=EnforceInput %>&&$("ddlDoStyle").value=="2")
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

function chkbtn()
{
    if($("ddlDoStyle").value=="1")
    {
        $("btnAdd").value="ȷ��";
    }else
    {
        $("btnAdd").value="ȷ�Ϲر�";
    }
}
function NewQty()
{
    var id=<%=Str_id %>;
    if(id=="-1")
    {
        alert("��ѡ��һ�����������������");
        return false;
    }
    parent.ShowDialog1(455, 150, 'Customer/QtyAdd.aspx?id='+id+'&iflag=2&f=2', '������');
}
function SltTec()
{
    parent.ShowDialog1(400, 510, 'Services/SltTec.aspx?f=1', '����Ա');
}
function SltTec2()
{
    var deptid=1;
    if($("ddlParam").value!="-1")
    {
        deptid=$("ddlParam").value;
    }else
    {
        $("ddlParam").focus();
        alert("����ѡ�����㣡");
        return false;
    }
    parent.ShowDialog1(400, 510, 'Services/SltTec.aspx?f=1&x=1&strid=tbDisposal2&dept='+deptid, '����Ա');
}
function SltTroubleSteps()
{
    parent.ShowDialog1(500, 510, 'Services/SltoubleStepsList.aspx', '�����ʩ');
}
</script>
