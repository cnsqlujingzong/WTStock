<%@ page language="C#"  CodeFile="smstmpmod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Tool_SmsTmpMod" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:586px;">
    <div class="fdiv" style="height:206px;">
    <div class="sdiv" style="background:#ECE9D8;height:201px; padding-top:3px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb4">
            <tr>
                <td>ģ����⣺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTitle" runat="server" CssClass="pin" Width="180"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="height:28px;">
                <input id="it1" type="button" value="�ͻ�����" class="bt1" onclick="Instr('{�ͻ�����}');" />
                <input id="it2" type="button" value="�ͻ��绰" class="bt1" onclick="Instr('{�ͻ��绰}');" />
                <input id="it3" type="button" value="�ͻ���ַ" class="bt1" onclick="Instr('{�ͻ���ַ}');" />
                <input id="it4" type="button" value="��ϵ��" class="bt1" onclick="Instr('{��ϵ��}');" />
                <input id="it5" type="button" value="����Ʒ��" class="bt1" onclick="Instr('{����Ʒ��}');" />
                <input id="it6" type="button" value="�������" class="bt1" onclick="Instr('{�������}');" />
                <input id="it7" type="button" value="�����ͺ�" class="bt1" onclick="Instr('{�����ͺ�}');" />
                <input id="it22" type="button" value="���񼶱�" class="bt1" onclick="Instr('{���񼶱�}');" />
                </td>
            </tr>
            
            <tr>
                <td colspan="2"style="height:28px;">
                
                <input id="it8" type="button" value="���к�" class="bt1" onclick="Instr('{���к�}');" />
                <input id="it9" type="button" value="��������" class="bt1" onclick="Instr('{��������}');" />
                <input id="it10" type="button" value="Ԥ����" class="bt1" onclick="Instr('{Ԥ����}');" />
                <input id="it11" type="button" value="�������" class="bt1" onclick="Instr('{�������}');" />
                <input id="it12" type="button" value="��������" class="bt1" onclick="Instr('{��������}');" />
                <input id="it13" type="button" value="����Ա" class="bt1" onclick="Instr('{����Ա}');" />
                    <input id="it14" type="button" value="���˷�ʽ" class="bt1" onclick="Instr('{���˷�ʽ}');" />
                </td>
            </tr>
            <tr>
                <td colspan="2"style="height:28px;">
                    
                    <input id="it15" type="button" value="��������" class="bt1" onclick="Instr('{��������}');" />
                    <input id="it16" type="button" value="��ƷժҪ" class="bt1" onclick="Instr('{��ƷժҪ}');" />
                    <input id="it17" type="button" value="����Ա�绰" class="bt1" onclick="Instr('{����Ա�绰}');" />
                    <input id="it18" type="button" value="��������" class="bt1" onclick="Instr('{��������}');" />
                    <input id="it19" type="button" value="������ϵ��" class="bt1" onclick="Instr('{������ϵ��}');" />
                    <input id="it20" type="button" value="����绰" class="bt1" onclick="Instr('{����绰}');" />
                    <input id="it21" type="button" value="ԤԼʱ��" class="bt1" onclick="Instr('{ԤԼʱ��}');" />
                </td>

            </tr>
            <tr>
                <td>ģ�����ݣ�</td>
                <td style="padding-left:0px; height:80px;"><asp:TextBox ID="tbContent" runat="server" TextMode="MultiLine" CssClass="pin" Height="70" Width="450"></asp:TextBox></td>
            </tr>
        </table>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right">
            <asp:Button ID="btnSave" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnSave_Click" />
            <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog1();"/>
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
<script language="javascript" type="text/javascript">
function ChkSave()
{
    if(isNull($("tbTitle").value))
    {
        window.alert("����ʧ�ܣ�ģ����ⲻ��Ϊ��");
        $("tbTitle").focus();
        return false
    }
    if(isNull($("tbContent").value))
    {
        window.alert("����ʧ�ܣ�ģ�����ݲ���Ϊ��");
        $("tbContent").focus();
        return false
    }
}
function Instr(str)
{
    var tc = document.getElementById("tbContent");
    var tclen = tc.value.length;
    tc.focus();
    if(typeof document.selection != "undefined")
    {
        document.selection.createRange().text = str;
    }
    else
    {
        tc.value = tc.value.substr(0,tc.selectionStart)+str+tc.value.substring(tc.selectionStart,tclen);
    }
}
</script>
