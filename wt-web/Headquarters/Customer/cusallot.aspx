<%@ page language="C#"  CodeFile="cusallot.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_CusAllot" enableEventValidation="false" %>
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
    <div id="sad" style="width:286px;">
    <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:282px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td>分派类型：</td>
                <td style="padding-left:0px;">
                    <asp:RadioButton ID="r1" runat="server" GroupName="g" Checked="true" AutoPostBack="True" OnCheckedChanged="r1_CheckedChanged" /> 内部分派
                    <asp:RadioButton ID="r2" runat="server" GroupName="g" AutoPostBack="True" OnCheckedChanged="r2_CheckedChanged" /> 派给网点
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lbName" runat="server" Text="跟踪人"></asp:Label>：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl" Width="180">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>分派原因：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv" id="dcancel" runat="server">
                        <input type="text" id="tbCaReason" runat="server" class="pin" style="width:163px;position: absolute;" />
                        <asp:DropDownList ID="ddlCancel" runat="server" onchange="document.getElementById('tbCaReason').value=this.options[this.selectedIndex].text" style="width:180px;clip: rect(auto auto auto 162px); position: absolute;height:20px;">
                        </asp:DropDownList>
                    </div>
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
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click"/>
                <input id="btnClose" type="button" value="取消" class="bt1" onclick="parent.CloseDialog();" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkSave()
{
    if($("ddlOperator").value=="-1")
    {
        window.alert("操作失败！请选择业务员");
        $("ddlOperator").focus();
        return false
    }
}
</script>
