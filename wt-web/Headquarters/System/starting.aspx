<%@ page language="C#"  CodeFile="starting.aspx.cs"     autoeventwireup="true" inherits="Starting" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa" style="width:586px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
        <fieldset style=" border: 1px #808080 solid; padding:5px 0;">
        <legend style="color:#0000ff">��ѡҪ��յ�����</legend>
        <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td><asp:CheckBox ID="cb1" runat="server" onclick="chkcheck(this,'2')" />�ֿ����</td>
                <td><asp:CheckBox ID="cb2" runat="server" onclick="chkcheck(this,'2')" />�ɹ�����</td>
                <td><asp:CheckBox ID="cb3" runat="server" onclick="chkcheck(this,'2')" />���۹���</td>
                <td><asp:CheckBox ID="cb4" runat="server" onclick="chkcheck(this,'2')" />�������</td>
                <td><asp:CheckBox ID="cb12" runat="server" onclick="chkcheck(this,'1')" />����/ȫ��</td>
                <td><asp:CheckBox ID="cb5" runat="server" onclick="chkcheck(this,'1');chkkh(this)" />�ͻ���ϵ</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="cb6" runat="server" onclick="chkcheck(this,'1')" />�ʿ����</td>
                <td><asp:CheckBox ID="cb7" runat="server" onclick="chkcheck(this,'1')" />�շ�����</td>
                <td><asp:CheckBox ID="cb8" runat="server" onclick="chkcheck(this,'1')" />�칫OA</td>
                <td><asp:CheckBox ID="cb9" runat="server" onclick="chkcheck(this,'1')" />ϵͳ��־</td>
                <td><asp:CheckBox ID="cb10" runat="server" onclick="chkjc(this)" /><span class="sysred">��������</span></td>
                <td><asp:CheckBox ID="cb11" runat="server" onclick="chkcp(this)" /><span class="sysred">��ƷĿ¼</span></td>
            </tr>
            
            </table>
        
        </fieldset>
        <fieldset style=" border: 1px #808080 solid; padding:5px 0;">
        <legend style="color:#0000ff">��֤</legend>
        <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td>�����½���룺<asp:TextBox ID="tbAdminPs2" runat="server" CssClass="pin" TextMode="Password"></asp:TextBox></td>
            </tr>
        </table>
        </fieldset>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <asp:Label ID="lbInfo" runat="server" style=" background:#dd0000; color:#ffffff; padding:2px 15px;" Text="ע:��ʼ�������ϵͳ���ݣ������ز���!"></asp:Label></td>
        <td align="right">
            <asp:CheckBox ID="cb_all" runat="server" onclick="ChkIsAll(this);" /><span style="color:#0000ff">ȫѡ</span>
            <asp:Button ID="btnSave" runat="server" Text="ȷ��" CssClass="bt1" UseSubmitBehavior="false"  OnClick="btnSave_Click" />
            <input id="btnCls" type="button" value="ȡ��" class="bt1" onclick="parent.CloseDialog();"/>
        </td>
    </tr>
    </table>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/menu.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkSave()
{
   if(isNull($("tbAdminPs").value))
   {
        alert("�������½����.");
        $("tbAdminPs").select();
        return false;
   }
}

function ChkIsAll(obj)
{
    if(obj.checked)
    {
        for(var i=1;i<=12;i++)
        {
            $("cb"+i).checked=true;
        }
    }else
    {
        for(var i=1;i<=12;i++)
        {
            $("cb"+i).checked=false;
        }
    }
}

function chkjc(obj)
{
    if(obj.checked)
    {
        for(var i=1;i<=12;i++)
        {
            $("cb"+i).checked=true;
        }
    }else
    {
        for(var i=1;i<=12;i++)
        {
            $("cb"+i).checked=false;
        }
    }
}
function chkcp(obj)
{
    if(obj.checked)
    {
        for(var i=1;i<=4;i++)
        {
            $("cb"+i).checked=true;
        }
    }else
    {
        for(var i=1;i<=4;i++)
        {
            $("cb"+i).checked=false;
        }
    }
}
function chkkh(obj)
{
    if(obj.checked)
    {
        for(var i=2;i<=6;i++)
        {
            $("cb"+i).checked=true;
            $("cb12").checked=true;
        }
    }else
    {
        for(var i=2;i<=6;i++)
        {
            $("cb"+i).checked=false;
            $("cb12").checked=false;
        }
    }
}
function chkcheck(obj,flag)
{
    if($("cb10").checked)
        obj.checked=true;
    
    if(flag=="2")
    {
        if($("cb11").checked)
            obj.checked=true;
    }
}
</script>
