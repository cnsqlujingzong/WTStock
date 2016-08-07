<%@ page language="C#"  CodeFile="assmod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_AssMod" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa" style="width:536px;">
    <div class="fdiv">
    <div class="sdiv">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td>客户编号：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbCusNO" runat="server" CssClass="pin" Width="300" ReadOnly="true"></asp:TextBox>
                </td>
                <td style="padding:0px;"><input id="btnSlt" type="button" value="" onclick="SltCus();" class="bview"/></td>
            </tr>
            <tr>
                <td>客户名称：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbCusName" runat="server" CssClass="pin" Width="300" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:HiddenField ID="hfCusID" runat="server" />
                </td>
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
        <td></td>
        <td align="right">
            <asp:Button ID="btnSave" runat="server" Text="确定" UseSubmitBehavior="false" CssClass="bt1" OnClick="btnSave_Click" />
            <input id="btnCls" type="button" value="取消" class="bt1" onclick="parent.CloseDialog();"/> 
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
<script language="javascript" type="text/javascript">
var processtip=1;

function ChkSave()
{
    if(isNull($("hfCusID").value))
    {
        window.alert("操作失败！请选择关联客户");
        $("hfCusID").focus();
        return false
    }
}
function SltCus()
{
    parent.ShowDialog1(800, 500, 'Customer/SltCus.aspx?f=3', '选择客户');
}
</script>
